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
using System.Text.RegularExpressions;


public partial class Manger_EditProduct : System.Web.UI.Page
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
            mcObj.ddlClassBind(ddlCategory);
            mcObj.ddlUrl(ddlUrl);
            GetBookInfo();
        }
    }
    /// <summary>
    /// 获取指定图书的信息，并将其显示在界面上
    /// </summary>
    public void GetBookInfo()
    {
        DataSet ds = mcObj.GetBookInfoByIDDs(Convert.ToInt32(Request["BookID"].Trim()), "BookInfo");
        txtName.Text=ds.Tables["BookInfo"].Rows[0][2].ToString();
        ddlCategory.SelectedValue = ds.Tables["BookInfo"].Rows[0][1].ToString();
        txtISBN.Text = ds.Tables["BookInfo"].Rows[0][4].ToString();
        txtPageNum.Text = ds.Tables["BookInfo"].Rows[0][5].ToString();
        txtPublisher.Text = ds.Tables["BookInfo"].Rows[0][6].ToString();
        txtPublishDate.Text = ds.Tables["BookInfo"].Rows[0][7].ToString();
        txtAuthor.Text = ds.Tables["BookInfo"].Rows[0][8].ToString();
        txtMarketPrice.Text = Convert.ToDouble(ds.Tables["BookInfo"].Rows[0][10]).ToString("0.00");
        txtMemberPrice.Text = Convert.ToDouble(ds.Tables["BookInfo"].Rows[0][11]).ToString("0.00");
        ddlUrl.SelectedValue = ds.Tables["BookInfo"].Rows[0][9].ToString();
        ImageMapPhoto.ImageUrl = ddlUrl.SelectedItem.Value;
        cbxCommend.Checked = Convert.ToBoolean(ds.Tables["BookInfo"].Rows[0][12].ToString());
        cbxHot.Checked = Convert.ToBoolean(ds.Tables["BookInfo"].Rows[0][13].ToString());
        cbxDiscount.Checked = Convert.ToBoolean(ds.Tables["BookInfo"].Rows[0][15].ToString());
        txtShortDesc.Text = ds.Tables["BookInfo"].Rows[0][3].ToString();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "" || txtISBN.Text == "" || txtPageNum.Text == "" || txtPublisher.Text == "" || txtPublishDate.Text == "" ||txtAuthor.Text == "" || txtMemberPrice.Text == "" || txtMarketPrice.Text == "")
        {
            Response.Write("<script>alert('请输入必要的信息！')</script>");

        }
        else if (IsValidInt(txtMarketPrice.Text.Trim()) == false || IsValidInt(txtMemberPrice.Text.Trim()) == false)
        {
            Response.Write("<script>alert('请正确输入（格式：1.00）！')</script>");
        }
        else
        {
            bool Isrefinement;
            bool IsHot;
            bool IsDisCount;
            if (cbxCommend.Checked == true)
            {
                Isrefinement = true;
            }
            else
            {
                Isrefinement = false;
            }
            if (cbxHot.Checked == true)
            {
                IsHot = true;
            }
            else
            {
                IsHot = false;
            }
            if (cbxDiscount.Checked == true)
            {
                IsDisCount = true;
            }
            else
            {
                IsDisCount = false;
            }
            mcObj.UpdateGInfo(Convert.ToInt32(ddlCategory.SelectedItem.Value.ToString()), txtName.Text.Trim(), txtShortDesc.Text.Trim(), txtISBN.Text.Trim(),txtPageNum.Text.Trim(),txtPublisher.Text.Trim(),txtPublishDate.Text,txtAuthor.Text.Trim(), ddlUrl.SelectedItem.Value.Trim(), float.Parse(txtMarketPrice.Text.Trim()), float.Parse(txtMemberPrice.Text.Trim()), Isrefinement, IsHot, IsDisCount, Convert.ToInt32(Request["BookID"].Trim()));
            Response.Write("<script>alert('该图书修改成功！');</script>");
           
        }
    }
    public bool IsValidInt(string num)
    {
        return Regex.IsMatch(num, @"^[0-9]+(.[0-9]{2})?$");
    }
    protected void ddlUrl_SelectedIndexChanged(object sender, EventArgs e)
    {
        ImageMapPhoto.ImageUrl = ddlUrl.SelectedItem.Value;
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Product.aspx");
    }
}
