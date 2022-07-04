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


public partial class User_CheckOut : System.Web.UI.Page
{
    UserInfoClass ucObj = new UserInfoClass();
    public  static float  P_Flt_TotalSF;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["UID"]) == "")
        {
            Response.Redirect("index.aspx");          
        }
        btnSave.Attributes.Add("OnClick", "javascript:return confirm('Sure to pay？')");
        if (!IsPostBack)
        {
            ddlCityBind();
            ddlShipBind();
            ddlPayBind();
            labKM.Text = ddlShipCity.SelectedValue.ToString(); 
        }
    }
    public void ddlCityBind()
    {
        ucObj.ddlCityBind(ddlShipCity);
    }
    public void ddlShipBind()
    {
        ucObj.ddlShipBind(ddlShipType);
    }
    public void ddlPayBind()
    {
        ucObj.ddlPayBind(ddlPayType);
    }
    public float  TotalBookPrice()
    {
        DataSet ds = ucObj.ReturnTotalDs(Convert.ToInt32(Session["UID"].ToString()), "TotalInfo");
       float  P_Flt_TotalGP = float.Parse(ds.Tables["TotalInfo"].Rows[0][0].ToString());
       return P_Flt_TotalGP;
    }
    public float  TotalShipFee()
    {
        P_Flt_TotalSF = 0;
        float  P_Flt_SF = ucObj.GetSFValue(ddlShipType.SelectedItem.Text.ToString());
        P_Flt_TotalSF += P_Flt_SF;
        return P_Flt_TotalSF;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtReciverName.Text == "" || txtReceiverAddress.Text == "" || txtReceiverPhone.Text == "" || txtReceiverPostCode.Text == "" || txtReceiverEmails.Text == "")
        {
            Response.Write("<script>alert('Please fulfill all the fields ！')</script>");
            return;
        }
        else
        { 
          float  P_Flt_TotalSF=TotalShipFee();
          if (P_Flt_TotalSF <= 0 || P_Flt_TotalSF == 100)
          {
              return;
          }
          float  P_Flt_TotalGP=TotalBookPrice();
          int P_Int_Cart = ucObj.IsUserCart(Convert.ToInt32(Session["UID"].ToString()), P_Flt_TotalGP, P_Flt_TotalSF);
          if (P_Int_Cart == -100 && ddlPayType.SelectedItem.Text.Trim() == "Membership")
          {
              Response.Write("<script>alert('Insufficient balance please recharge ！')</script>");
              return;
          }
          else
          {
              int P_Int_OrderID = ucObj.AddOrderInfo(P_Flt_TotalGP, P_Flt_TotalSF, Convert.ToInt32(ddlShipType.SelectedItem.Value.ToString()), Convert.ToInt32(ddlPayType.SelectedItem.Value.ToString()), Convert.ToInt32(Session["UID"].ToString()), txtReciverName.Text.Trim(), txtReceiverPhone.Text.Trim(), txtReceiverPostCode.Text.Trim(), txtReceiverAddress.Text.Trim(), txtReceiverEmails.Text.Trim());
               DataSet ds = ucObj.ReturnSCDs(Convert.ToInt32(Session["UID"].ToString()), "SCInfo");
               for(int i = 0; i < ds.Tables["SCInfo"].Rows.Count; i++)
               {
                  ucObj.AddBuyInfo(Convert.ToInt32(ds.Tables["SCInfo"].Rows[i][1].ToString()), Convert.ToInt32(ds.Tables["SCInfo"].Rows[i][2].ToString()), P_Int_OrderID, float.Parse (ds.Tables["SCInfo"].Rows[i][3].ToString()), Convert.ToInt32(ds.Tables["SCInfo"].Rows[i][4].ToString()));
               } 
               ucObj.DeleteSCInfo(Convert.ToInt32(Session["UID"].ToString()));
               Response.Write("<script>alert('shopping success！');location='index.aspx'</script>");
               return;
          }
         
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }
    protected void lnkbtnSee_Click(object sender, EventArgs e)
    {

        Response.Write("<script language=javascript>window.open('ShipFeeInfo.aspx','','width=640,height=640')</script>");
    }
    protected void ddlShipCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        labKM.Text = ddlShipCity.SelectedItem.Value;
    }
}
