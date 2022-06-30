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


public partial class Manger_CategoryAdd : System.Web.UI.Page
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
            mcObj.ddlUrl(ddlUrl);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtName.Text = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "")
        {
            Response.Write("<script>alert('请输入图书类别！');location='javascript:history.go(-1)';</script>");
        }
        else
        {
            int P_Int_ReturnValue = mcObj.AddCategory(txtName.Text.Trim(),ddlUrl.SelectedItem.Value.ToString());
            if (P_Int_ReturnValue == -100)
            {
                Response.Write("<script>alert('该图书类别名已存在，请输入其它的图书类别名！');location='javascript:history.go(-1)';</script>");
            }
            else
            {
                Response.Write("<script>alert('添加成功！');location='javascript:history.go(-1)';</script>");
            
            }

        
        }

    }
    protected void ddlUrl_SelectedIndexChanged(object sender, EventArgs e)
    {
        ImageMapPhoto.ImageUrl = ddlUrl.SelectedItem.Value;
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");
    }
}
