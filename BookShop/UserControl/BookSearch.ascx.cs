using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class UserControl_BookSearch : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtSearch.Text == "") { Response.Write("<script>alert('请输入要搜索的图书名');</script>"); }
        else
        {
            Response.Redirect("~/User/SearchResult.aspx?SearchName=" + txtSearch.Text);
        }
    }
}
