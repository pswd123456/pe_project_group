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


public partial class User_ClassBook : System.Web.UI.Page
{
    MangerClass mcObj = new MangerClass();
    UserInfoClass ucObj = new UserInfoClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ClassID"] == null)
        {
            Response.Redirect("index.aspx");
        }
        if (!IsPostBack)
        {
            dlClassBind();
            lbClassName.Text = GetClass(Convert.ToInt32(this.Request.QueryString["ClassID"].ToString()));
        }
    }
    public string GetClass(int P_Int_ClassID)
    {
        string P_Str_ClassName = mcObj.GetClass(P_Int_ClassID);
        return P_Str_ClassName;
    }
    //绑定市场价格
    public string GetVarMKP(string P_Str_MarketPrice)
    {
        return ucObj.VarStr(P_Str_MarketPrice, 2);
    }
    //绑定会员价格
    public string GetVarMBP(string P_Str_MemberPrice)
    {
        return ucObj.VarStr(P_Str_MemberPrice, 2);
    }

    /// <summary>
    /// 显示指定类别的图书信息
    /// </summary>
    public void dlClassBind()
    {
        ucObj.DCGIBind(Convert.ToInt32(this.Request.QueryString["ClassID"].ToString()), "Class", DLClass);
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
        Book.MemberPrice = float.Parse(BookStyle.Substring(index + 1));
        return (Book);
    }
    public void AddShopCart(DataListCommandEventArgs e, DataList DLName)
    {
        if (Session["UID"] != null)
        {
            SaveSubBookClass Book = null;
            Book = GetSubBookInformation(e, DLName);
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
    protected void DLClass_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "detailSee")
        {
            Session["address"] = "";
            Session["address"] = "ClassBook.aspx?ClassID=" + Convert.ToInt32(this.Request.QueryString["ClassID"].ToString());
            Response.Redirect("~/User/BookDetail.aspx?BookID=" + Convert.ToInt32(DLClass.DataKeys[e.Item.ItemIndex].ToString()));
        }
        else if (e.CommandName == "buyBook")
        {
            AddShopCart(e, DLClass);
        }
    }
}
