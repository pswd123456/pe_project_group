using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


/// <summary>
/// SaveSubBookClass 的摘要说明
/// </summary>
public class SaveSubBookClass
{
    public int BookID;  //图书编号
    public float MemberPrice;//会员价格
    public int Num;//图书数量
    public float SumPrice;//小计

    public SaveSubBookClass()
    {
    }
}