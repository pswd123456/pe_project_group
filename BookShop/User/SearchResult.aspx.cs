﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class User_SearchResult : System.Web.UI.Page
{
    MangerClass mcObj = new MangerClass();
    UserInfoClass ucObj = new UserInfoClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        dlSearchBind();
    }
    public string GetClass(int P_Int_ClassID)
    {
        string P_Str_ClassName = mcObj.GetClass(P_Int_ClassID);
        return P_Str_ClassName;
    }

    public void dlSearchBind()
    {
        ucObj.DCSearchBind(Request.QueryString["SearchName"].ToString(), "SearchName", DLsearch);
    }

    public string GetVarMKP(string P_Str_MarketPrice)
    {
        return ucObj.VarStr(P_Str_MarketPrice, 2);
    }

    public string GetVarMBP(string P_Str_MemberPrice)
    {
        return ucObj.VarStr(P_Str_MemberPrice, 2);
    }

    public SaveSubBookClass GetSubBookInformation(DataListCommandEventArgs e, DataList DLName)
    {
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
    
                Response.Write("<script>alert('No data');</script>");
                return;
            }
            else
            {
                ucObj.AddShopCart(Book.BookID, Book.MemberPrice, Convert.ToInt32(Session["UID"].ToString()));
                Response.Write("<script>alert('Add success！')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Please login first！');</script>");

        }

    }
    protected void DLsearch_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "detailSee")
        {
            Session["address"] = "";
            Session["address"] = "SearchResult.aspx?SearchName=" + Convert.ToInt32(this.Request.QueryString["SearchName"].ToString());
            Response.Redirect("~/User/BookDetail.aspx?BookID=" + Convert.ToInt32(DLsearch.DataKeys[e.Item.ItemIndex].ToString()));
        }
        else if (e.CommandName == "buyBook")
        {
            AddShopCart(e,DLsearch);
        }
    }
}
