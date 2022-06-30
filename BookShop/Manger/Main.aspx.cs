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


public partial class Manger_Main : System.Web.UI.Page
{
    UserInfoClass uiObj = new UserInfoClass();
    MangerClass mcObj = new MangerClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["AID"]) == "")
        {
            Response.Redirect("Fail.aspx");
        }
        if (!IsPostBack)
        {
            gvNewOBind();
            gvNewMBind();    
        }
    }
    public string GetMemberName(int P_Int_MemberId)
    {   
        DataSet ds = new DataSet();
        ds = uiObj.ReturnUIDsByID(P_Int_MemberId, "UserInfo");
        return  (ds.Tables["UserInfo"].Rows[0][1].ToString());  
    }
    public void gvNewOBind()
    {
        int P_Int_returnValue = mcObj.IsExistsNI("Pr_GetNOI");
        if (P_Int_returnValue == -100)
        {
           
        }
        else
        {
            SqlCommand myCmd = mcObj.GetNewICmd("Pr_GetNOI");
            mcObj.gvBind(gvOrderList,myCmd,"OrderInfo");
        }
    }
    public void gvNewMBind()
    {
        int P_Int_returnValue = mcObj.IsExistsNI("Pr_GetNMI");
        if (P_Int_returnValue == -100)
        {
           
        }
        else
        {
            SqlCommand myCmd = mcObj.GetNewICmd("Pr_GetNMI");
            mcObj.gvBind(gvMember,myCmd,"MemberInfo");     
        }
    
    
    }

    protected void gvOrderList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOrderList.PageIndex = e.NewPageIndex;
        gvNewOBind();

    }
    protected void gvMember_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMember.PageIndex = e.NewPageIndex;
        gvNewMBind();
    }
}
