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
/// CommonProperty 的摘要说明
/// </summary>
public class CommonProperty
{
    public int OrderNo;  //订单编号
    public DateTime OrderTime;//下单时间
    public float ProductPrice;//图书总金额
    public float ShipPrice;//图书运费
    public float TotalPrice;//订单总金额
    public string BuyerName;//购书人姓名
    public string BuyerPhone;//购书人电话
    public string BuyerEmail;//购书人Email地址
    public string BuyerAddress;//购书人地址
    public string BuyerPostalcode;//购书人邮政编码
    public string ReceiverName;//收书人姓名
    public string ReceiverPhone;//收书人电话
    public string ReceiverEmail;//收书人Email地址
    public string ReceiverAddress;//收书人地址
    public string ReceiverPostalcode;//收书人邮政编码
    public int ShipType;//运输类型
    public int PayType;//支付类型

    public CommonProperty()
    {
    }
}
