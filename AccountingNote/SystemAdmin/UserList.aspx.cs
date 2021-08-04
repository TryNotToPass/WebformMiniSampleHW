using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccountingNote.Auth;
using AccountingNote.DBSource;
using System.Data;

namespace AccountingNote
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "使用者清單頁";
            //Admin mainMaster = this.Master as Admin;
            //mainMaster.MyTitle = "使用者資訊編輯頁";

            if (!AuthManager.IsLogined()) 
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            var currentUser = AuthManager.GetCurrentUser();

            if (currentUser == null)                             // 如果帳號不存在，導至登入頁
            {
                this.Session["UserLoginInfo"] = null;
                Response.Redirect("/Login.aspx");
                return;
            }
            DataTable dt = UserInfoManager.GetDataBase("U");
            if (dt.Rows.Count > 0)  // check is empty data
            {
                var dtPaged = this.GetPagedDataTable(dt);

                this.gv_UserList.DataSource = dtPaged;
                this.gv_UserList.DataBind();

                this.ucPager.TotalSize = dt.Rows.Count;
                this.ucPager.Bind();
            }
            else
            {
                this.gv_UserList.Visible = false;
                this.Label1.Visible = true;
            }
            this.gv_UserList.DataSource = dt;
            this.gv_UserList.DataBind();

        }

        protected void btn_addUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemAdmin/UserDetail.aspx");
        }

        //下面兩個王八好像進不了類別庫
        private int GetCurrentPage()
        {
            string pageText = Request.QueryString["Page"];

            if (string.IsNullOrWhiteSpace(pageText))
                return 1;
            int intPage;
            if (!int.TryParse(pageText, out intPage))
                return 1;
            if (intPage <= 0)
                return 1;
            return intPage;
        }

        private DataTable GetPagedDataTable(DataTable dt)
        {
            DataTable dtPaged = dt.Clone();

            int startIndex = (this.GetCurrentPage() - 1) * this.ucPager.PageSize;
            int endIndex = (this.GetCurrentPage()) * this.ucPager.PageSize;
            if (endIndex > dt.Rows.Count)
                endIndex = dt.Rows.Count;

            for (var i = startIndex; i < endIndex; i++)
            {
                DataRow dr = dt.Rows[i];
                var drNew = dtPaged.NewRow();

                foreach (DataColumn dc in dt.Columns)
                {
                    drNew[dc.ColumnName] = dr[dc];
                }

                dtPaged.Rows.Add(drNew);
            }
            return dtPaged;
        }


    }
}