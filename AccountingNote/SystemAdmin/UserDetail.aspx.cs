using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccountingNote.Auth;
using AccountingNote.DBSource;
using System.Data;

namespace AccountingNote.SystemAdmin
{
    public partial class UserDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "使用者資訊編輯頁";
            Admin mainMaster = this.Master as Admin;
            mainMaster.MyTitle = "使用者資訊編輯頁";
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            string account = this.Session["UserLoginInfo"] as string;
            var currentUser = AuthManager.GetCurrentUser();

            if (currentUser == null)                             // 如果帳號不存在，導至登入頁
            {
                this.Session["UserLoginInfo"] = null;
                Response.Redirect("/Login.aspx");
                return;
            }

            if (!this.IsPostBack)
            {
                // Check is create mode or edit mode
                if (this.Request.QueryString["ID"] == null)
                {
                    this.btnDelete.Visible = false;
                    //若要新增使用者，那就要讓他們打密碼，更新無法打密碼
                    this.PlaceHolderPWD.Visible = true;
                }
                else
                {
                    this.btnDelete.Visible = true;

                    string idText = this.Request.QueryString["ID"];
                    if (!string.IsNullOrWhiteSpace(idText))
                    {
                        var drAccounting = UserInfoManager.GetUserInfoByUID(idText);

                        if (drAccounting == null)
                        {
                            this.ltMsg.Text = "Data doesn't exist";
                            this.btnSave.Visible = false;
                            this.btnDelete.Visible = false;
                        }
                        else
                        {
                            string pwdcText = this.Request.QueryString["Txt"];
                            if (!string.IsNullOrWhiteSpace(pwdcText)) this.ltMsg.Text = "密碼變更完成！";
                            this.txtAccount.Text = drAccounting["Account"].ToString();
                            this.txtName.Text = drAccounting["Name"].ToString();
                            this.txtMail.Text = drAccounting["Email"].ToString();
                        }
                    }
                    else
                    {
                        this.ltMsg.Text = "ID is required.";
                        this.btnSave.Visible = false;
                        this.btnDelete.Visible = false;
                    }



                }
            }
        }
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<string> msgList = new List<string>();
            if (!this.CheckInput(out msgList))
            {
                this.ltMsg.Text = string.Join("<br/>", msgList);
                return;
            }


            UserInfoModel currentUser = AuthManager.GetCurrentUser();
            if (currentUser == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            //string userID = currentUser.ID;
            string account = this.txtAccount.Text;
            string name = this.txtName.Text;
            string email = this.txtMail.Text;
            

            string idText = this.Request.QueryString["ID"];
            if (string.IsNullOrWhiteSpace(idText))
            {
                string pwd = this.txtPassword.Text;
                UserInfoManager.CreateUser(account, pwd, name, email);
                //AccountingManager.CreateAccounting(userID, caption, amount, actType, body);
            }
            else
            {
                UserInfoManager.UpdateUser(idText, account, name, email);
            }

            Response.Redirect("/SystemAdmin/UserList.aspx");
        }

        private bool CheckInput(out List<string> errorMsgList)
        {
            List<string> msgList = new List<string>();

            if (string.IsNullOrWhiteSpace(this.txtAccount.Text)) msgList.Add("帳號沒打");
            if (string.IsNullOrWhiteSpace(this.txtName.Text)) msgList.Add("稱呼沒打");
            if (string.IsNullOrWhiteSpace(this.txtMail.Text)) msgList.Add("信箱沒打");
            if (this.txtPassword.Visible) 
            {
                if (string.IsNullOrWhiteSpace(this.txtPassword.Text)) msgList.Add("密碼沒打");
                else if (string.IsNullOrWhiteSpace(this.txtPWDCheck.Text)) msgList.Add("確認密碼欄位沒打");
                else if (this.txtPassword.Text.CompareTo(this.txtPWDCheck.Text) != 0) msgList.Add("兩次輸入的密碼不相同");
            }

            errorMsgList = msgList;
            if (msgList.Count == 0)
                return true;
            else
                return false;
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string idText = this.Request.QueryString["ID"];

            if (string.IsNullOrWhiteSpace(idText))
                return;

            UserInfoManager.DeleteAccounting(idText);

            Response.Redirect("/SystemAdmin/UserList.aspx");
        }
    }
}