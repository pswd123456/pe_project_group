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


public partial class index : System.Web.UI.Page
{
    UserInfoClass ucObj = new UserInfoClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RefineBind();
            HotBind();
            DiscountBind();
        }
    }
    //绑定市场价格
    public string GetMKPStr(string P_Str_MarketPrice)
    {
        return ucObj.VarStr(P_Str_MarketPrice, 2);
    }
    //绑定会员价格
    public string GetMBPStr(string P_Str_MemberPrice)
    {
       return  ucObj.VarStr(P_Str_MemberPrice, 2); 
    }
  
    //当购买图书时，获取图书信息
    public SaveSubBookClass GetSubBookInformation(DataListCommandEventArgs e, DataList DLName)
    {
        //获取购物车中的信息
        SaveSubBookClass Book = new SaveSubBookClass();
        Book.BookID = int.Parse(DLName.DataKeys[e.Item.ItemIndex].ToString());
        string BookStyle = e.CommandArgument.ToString();
        int index = BookStyle.IndexOf("|");
        if (index < -1 || index + 1 >= BookStyle.Length)
            return Book;
        Book.MemberPrice =float.Parse( BookStyle.Substring(index + 1));
        return (Book);

    }
    public void AddShopCart(DataListCommandEventArgs e, DataList DLName)
    {
        if (Session["UID"] != null)
        {
            SaveSubBookClass Book = null;
            Book = GetSubBookInformation(e,DLName);
            if (Book == null)
            {
                //显示错误信息
                Response.Write("<script>alert('没有可用的数据');</script>");
                return;
            }
            else
            {
                ucObj.AddShopCart(Book.BookID, Book.MemberPrice, Convert.ToInt32(Session["UID"].ToString()));
                Response.Write("<script>alert('恭喜您，添加成功！')</script>");

            }
        }
        else
        {
            Response.Write("<script>alert('请先登录，谢谢合作！');</script>");

        }

    }

    public void RefineBind()
    {
        ucObj.DGIBind(1, "Refine", DLrefinement);
    }
    public void HotBind()
    {
        ucObj.DGIBind(2, "Hot", DLHot);
    }
    public void DiscountBind()
    {
        ucObj.DGIBind(3, "Discount", DLDiscount);
    }
    protected void DLrefinement_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "detailSee")
        {
            Session["address"] = "";
            Session["address"] = "index.aspx";
            Response.Redirect("~/User/BookDetail.aspx?BookID=" + Convert.ToInt32(DLrefinement.DataKeys[e.Item.ItemIndex].ToString()));
        }
        else if (e.CommandName == "buyBook")
        {
            AddShopCart(e,DLrefinement);
        }
    }
    protected void DLHot_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "detailSee")
        {
            Session["address"] = "";
            Session["address"] = "index.aspx";
            Response.Redirect("~/User/BookDetail.aspx?BookID=" + Convert.ToInt32(DLHot.DataKeys[e.Item.ItemIndex].ToString()));
        }
        else if (e.CommandName == "buyBook")
        {

            AddShopCart(e,DLHot);
        }
    }
    protected void DLDiscount_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "detailSee")
        {
            Session["address"] = "";
            Session["address"] = "index.aspx";
            Response.Redirect("~/User/BookDetail.aspx?BookID=" + Convert.ToInt32(DLDiscount.DataKeys[e.Item.ItemIndex].ToString()));
        }
        else if (e.CommandName == "buyBook")
        {
            AddShopCart(e,DLDiscount);
        }
    }

    protected void DLrefinement_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
