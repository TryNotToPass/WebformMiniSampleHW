using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AccountingNote
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (this.ltmsg.Text.CompareTo("A") == 0) return;
            DataTable dtAccStart = AccountingNote.DBSource.UserInfoManager.GetDataBase("AS");
            DataTable dtAccLast = AccountingNote.DBSource.UserInfoManager.GetDataBase("AL");
            DataTable dtUserinfo = AccountingNote.DBSource.UserInfoManager.GetDataBase("U");
            DataRow drAccStart;
            DataRow drAccLast;
            if (dtUserinfo == null || dtUserinfo.Rows.Count == 0) 
            {
                this.ltmsg.Text = "目前還沒有使用者！";
                this.Button1.Visible = true;
                this.loginLink.Visible = false;
                return;
            }
            
            if (dtAccStart == null || dtAccStart.Rows.Count == 0)
            {
                this.ltmsg.Text = $"第一筆紀錄日期：尚未存在 <br/>" +
                $"最近一筆的更新日期：尚未存在 <br/>" +
                $"共0筆流水帳 <br/>" +
                $"共{dtUserinfo.Rows.Count}位使用者";
            }
            else 
            {
                drAccStart = dtAccStart.Rows[0];
                drAccLast = dtAccLast.Rows[0];
                int cnt = dtAccStart.Rows.Count;
                this.ltmsg.Text = $"第一筆紀錄日期：{drAccStart.Field<DateTime>("CreateDate").ToString()} <br/>" +
                $"最近一筆的更新日期：{drAccLast.Field<DateTime>("CreateDate").ToString()} <br/>" +
                $"共{cnt}筆流水帳 <br/>" +
                $"共{dtUserinfo.Rows.Count}位使用者";
            }
            
            //測試用
            //this.GridView1.DataSource = dtAccStart;
            //this.GridView1.DataBind();



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Session["FromUserDetail"] = "yesfromdetail";
            Response.Redirect("/SystemAdmin/UserDetail.aspx");
        }
    }
}