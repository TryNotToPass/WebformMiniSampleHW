using AccountingNote.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.SystemAdmin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        public string MyTitle { get; set; } = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            string account = this.Session["FromUserDetail"] as string;
            if (account != null && account.CompareTo("yesfromdetail") == 0)  //若使用者是第一位，則破例讓他創
            {
                return;
            }
            // 如果尚未登入，導至登入頁
            if (!AuthManager.IsLogined())                
            {
                
                Response.Redirect("/Login.aspx");
                return;
            }

            var currentUser = AuthManager.GetCurrentUser();
            // 如果帳號不存在，導至登入頁
            if (currentUser == null)                             
            {
                Response.Redirect("/Login.aspx");
                return;
            }
        }
    }
}