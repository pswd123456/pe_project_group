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
using System.Data.SqlClient;

public partial class Manger_Product : System.Web.UI.Page
{
    MangerClass mcObj = new MangerClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["AID"]) == "")
        {
            Response.Redirect("Fail.aspx");
        }
        if (!IsPostBack)
        {
            gvBind();
        }
    }
    public string GetClass(int P_Int_ClassID)
    {
        string P_Str_ClassName = mcObj.GetClass(P_Int_ClassID);
        return P_Str_ClassName;
    }
    public String GetVarStr(string P_Str_MemberPrice)
    {
       return  mcObj.VarStr(P_Str_MemberPrice, 2);
    }
    /// <summary>
    /// 绑定所有图书的信息
    /// </summary>
    public void gvBind()
    {
        DataSet ds = mcObj.GetBookInfoDs("BookInfo");
        gvBookInfo.DataSource = ds.Tables["BookInfo"].DefaultView;
        gvBookInfo.DataBind();
    }
    /// <summary>
    /// 在搜索中绑定图书信息
    /// </summary>
    public void gvSearchBind()
    {
        DataSet ds = mcObj.SearchBookInfoDs("BookInfo", txtKey.Text.Trim());
        gvBookInfo.DataSource = ds.Tables["BookInfo"].DefaultView;
        gvBookInfo.DataBind();
    }

    protected void gvBookInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBookInfo.PageIndex = e.NewPageIndex;
        if (txtKey.Text.Trim() == "")
        {
            gvBind();
        }
        else
        {
            gvSearchBind();
        }
    }

    protected void gvBookInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int P_Int_BookID = Convert.ToInt32(gvBookInfo.DataKeys[e.RowIndex].Value);
        mcObj.DeleteBookInfo(P_Int_BookID);
        if (txtKey.Text.Trim() == "")
        {
            gvBind();
        }
        else
        {
            gvSearchBind();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gvSearchBind();
    }
}
