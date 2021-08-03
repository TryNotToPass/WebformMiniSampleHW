using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccountingNote.Auth;
using AccountingNote.DBSource;

namespace AccountingNote.SystemAdmin
{
    public partial class UserChangePWD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // check is logined
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            var currentUser = AuthManager.GetCurrentUser();

            if (currentUser == null)
            {
                this.Session["UserLoginInfo"] = null;
                Response.Redirect("/Login.aspx");
                return;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            //檢查密碼字數對不對
            if (string.IsNullOrWhiteSpace(this.txtPassword.Text))
            {  
                this.ltlMsg.Text = "密碼沒打";
                return;
            }
            else if (string.IsNullOrWhiteSpace(this.txtPWDCheck.Text))
            {
                this.ltlMsg.Text = "確認密碼欄位沒打";
                return;
            }
            else if (this.txtPassword.Text.CompareTo(this.txtPWDCheck.Text) != 0)
            {
                this.ltlMsg.Text = "兩次輸入的密碼不相同";
                return;
            }
            else if (this.txtPassword.Text.Length < 8 || this.txtPassword.Text.Length > 16)
            {
                this.ltlMsg.Text = "密碼長度必須介於8~16碼之間";
                return;
            }
            this.ltlMsg.Text = "變更完成！";
            var currentUser = AuthManager.GetCurrentUser();
            UserInfoManager.UpdateUserPassword(currentUser.ID, this.txtPassword.Text);
            Response.Redirect($"UserDetail.aspx?ID={currentUser.ID}&Txt=changeisgood");
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            string inp_Account = this.txtAccount.Text;
            string inp_PWD = this.txtPWD.Text;

            string msg;
            if (!AuthManager.TryLogin(inp_Account, inp_PWD, out msg))
            {
                this.ltlMsg.Text = msg;
                return;
            }
            //登入認證成功
            this.PWDPlaceHolder.Visible = true;
            this.AccPlaceHolder.Visible = false;
            this.ltlMsg.Text = "設置密碼時，請將密碼長度設定於8~16碼之間";
        }

    }
}