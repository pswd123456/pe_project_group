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

public partial class User_BookDetail : System.Web.UI.Page
{
    MangerClass mcObj = new MangerClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["BookID"]==null)
        {
            Response.Redirect("index.aspx");
        }
        if (!IsPostBack)
        {
            GetBookInfo();
        }
    }
    public string GetClass(int P_Int_ClassID)
    {
        string P_Str_ClassName = mcObj.GetClass(P_Int_ClassID);
        return P_Str_ClassName;
    }
    public void GetBookInfo()
    {
        DataSet ds = mcObj.GetBookInfoByIDDs(Convert.ToInt32(Request["BookID"].Trim()), "BookInfo");
        lblName.Text = ds.Tables["BookInfo"].Rows[0][2].ToString();
        lblCategory.Text = GetClass(Convert.ToInt32(ds.Tables["BookInfo"].Rows[0][1].ToString()));
        lblISBN.Text = ds.Tables["BookInfo"].Rows[0][4].ToString();
        lblPageNum.Text = ds.Tables["BookInfo"].Rows[0][5].ToString();
        lblPublisher.Text = ds.Tables["BookInfo"].Rows[0][6].ToString();
        lblPublishDate.Text = ds.Tables["BookInfo"].Rows[0][7].ToString();
        lblAuthor.Text = ds.Tables["BookInfo"].Rows[0][8].ToString();
        lblMarketPrice.Text=Convert.ToDouble(ds.Tables["BookInfo"].Rows[0][10]).ToString("0.00");
        lblMemberPrice.Text = Convert.ToDouble(ds.Tables["BookInfo"].Rows[0][11]).ToString("0.00");
        ImageMapPhoto.ImageUrl = ds.Tables["BookInfo"].Rows[0][9].ToString();
        txtShortDesc.Text = ds.Tables["BookInfo"].Rows[0][3].ToString();
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        if (Session["address"] == null)
            Response.Redirect("index.aspx");
        else
        {
            string addr = Session["address"].ToString();
            Response.Redirect(addr);
        } 
    }
}
