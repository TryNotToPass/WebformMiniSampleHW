using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.UserControls
{
    public partial class ucPager : System.Web.UI.UserControl
    {
        /// <summary> 頁面 url </summary>
        public string Url { get; set; }
        /// <summary> 總筆數 </summary>
        public int TotalSize { get; set; }
        /// <summary> 頁面筆數 </summary>
        public int PageSize { get; set; }
        /// <summary> 目前頁數 </summary>
        public int CurrentPage { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public void Bind()
        {
            int totalPages = this.GetTotalPages();
            int cp = GetCurrentPage();
            int firstp = cp - 1;

            this.aLinkF.HRef = $"{this.Url}?page=1";
            this.aLinkL.HRef = $"{this.Url}?page={totalPages}";

            this.ltmsg.Text = $"共 {this.TotalSize} 筆，共 {totalPages} 頁，目前在第 {this.GetCurrentPage()} 頁<br/>";
            for (var i = firstp; i <= cp + 1; i++)
            {
                if (i == firstp+1) this.ltPager.Text += $"&nbsp {i} &nbsp;";
                else if (i <= 0) cp += 1;
                else if (i > totalPages) break;
                else this.ltPager.Text += $"<a href='{this.Url}?page={i}'>{i}</a>&nbsp;";
            }
        }

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

        private int GetTotalPages()
        {
            int pagers = this.TotalSize / this.PageSize;
            if ((this.TotalSize % this.PageSize) > 0)
                pagers += 1;
            return pagers;
        }

        public void UCCloser() 
        {
            this.aLinkF.Visible = false;
            this.aLinkL.Visible = false;
        }
    }
}