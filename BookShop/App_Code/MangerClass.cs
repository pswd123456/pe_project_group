using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;


/// <summary>
/// MangerClass 的摘要说明
/// </summary>
public class MangerClass
{
    DBClass dbObj = new DBClass();
    public MangerClass()
    {
    }
    /// <summary>
    /// GridView控件的绑定
    /// </summary>
    /// <param name="gvName">控件名字</param>
    /// <param name="P_Str_srcTable">绑定信息</param>
    public void gvBind(GridView gvName, SqlCommand myCmd, string P_Str_srcTable)
    {
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        gvName.DataSource = ds.Tables[P_Str_srcTable].DefaultView;
        gvName.DataBind();
    }
    /// <summary>
    /// 判断有没有最新的订单或新会员
    /// </summary>
    /// <param name="P_Str_PrName">执行语句的存储过程名</param>
    /// <returns></returns>
    public int IsExistsNI(string P_Str_PrName)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand(P_Str_PrName, myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter returnValue = myCmd.Parameters.Add("returnValue", SqlDbType.Int, 4);
        returnValue.Direction = ParameterDirection.ReturnValue;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        int P_Int_returnValue = Convert.ToInt32(returnValue.Value.ToString());
        return P_Int_returnValue;
    }
    /// <summary>
    /// 绑定最新信息(最新订单信息，最新用户信息量)
    /// </summary>
    /// <param name="P_Str_PrName">执行语句的存储过程名</param>
    /// <returns></returns>
    public SqlCommand GetNewICmd(string P_Str_PrName)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand(P_Str_PrName, myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter returnValue = myCmd.Parameters.Add("returnValue", SqlDbType.Int, 4);
        returnValue.Direction = ParameterDirection.ReturnValue;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }

        return myCmd;
    }

    /// <summary>
    ///  获取订单信息
    /// </summary>
    /// <param name="P_Int_Flag">是否是功能菜单栏传来的值</param>
    /// <param name="P_Int_IsMember">是否是以会员来查询</param>
    /// <param name="P_Int_MemberID">会员编号</param>
    /// <param name="P_Int_OrderID">订单编号</param>
    /// <param name="P_Int_Confirm">是否选择了确认下拉菜单</param>
    /// <param name="P_Int_Payed">是否选择了确认下拉菜单</param>
    /// <param name="P_Int_Shipped">是否选择了付款下拉菜单</param>
    /// <param name="P_Int_Finished">是否选择了归档下拉菜单</param>
    /// <param name="P_Int_IsConfirm">订单是否已确认</param>
    /// <param name="P_Int_IsPayment">订单是否已付款</param>
    /// <param name="P_Int_IsConsignment">订单是否已发贷</param>
    /// <param name="P_Int_IsPigeonhole">订单是否已归档</param>
    /// <returns>返回Sqlcommand</returns>
    public SqlCommand GetOrderInfo(int P_Int_Flag, int P_Int_IsMember, int P_Int_MemberID, int P_Int_OrderID, int P_Int_Confirm, int P_Int_Payed, int P_Int_Shipped, int P_Int_Finished, int P_Int_IsConfirm, int P_Int_IsPayment, int P_Int_IsConsignment, int P_Int_IsPigeonhole)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_GetOrderInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter Flag = new SqlParameter("@Flag", SqlDbType.Int, 4);
        Flag.Value = P_Int_Flag;
        myCmd.Parameters.Add(Flag);

        SqlParameter IsMember = new SqlParameter("@IsMember", SqlDbType.Int, 4);
        IsMember.Value = P_Int_IsMember;
        myCmd.Parameters.Add(IsMember);

        SqlParameter MemberID = new SqlParameter("@MemberID", SqlDbType.Int, 4);
        MemberID.Value = P_Int_MemberID;
        myCmd.Parameters.Add(MemberID);

        SqlParameter OrderID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
        OrderID.Value = P_Int_OrderID;
        myCmd.Parameters.Add(OrderID);

        SqlParameter Confirm = new SqlParameter("@Confirm", SqlDbType.Int, 4);
        Confirm.Value = P_Int_Confirm;
        myCmd.Parameters.Add(Confirm);

        SqlParameter Payed = new SqlParameter("@Payed", SqlDbType.Int, 4);
        Payed.Value = P_Int_Payed;
        myCmd.Parameters.Add(Payed);

        SqlParameter Shipped = new SqlParameter("@Shipped", SqlDbType.Int, 4);
        Shipped.Value = P_Int_Shipped;
        myCmd.Parameters.Add(Shipped);
        SqlParameter Finished = new SqlParameter("@Finished", SqlDbType.Int, 4);
        Finished.Value = P_Int_Finished;
        myCmd.Parameters.Add(Finished);

        SqlParameter IsConfirm = new SqlParameter("@IsConfirm", SqlDbType.Int, 4);
        IsConfirm.Value = P_Int_IsConfirm;
        myCmd.Parameters.Add(IsConfirm);

        SqlParameter IsPayment = new SqlParameter("@IsPayment", SqlDbType.Int, 4);
        IsPayment.Value = P_Int_IsPayment;
        myCmd.Parameters.Add(IsPayment);

        SqlParameter IsConsignment = new SqlParameter("@IsConsignment", SqlDbType.Int, 4);
        IsConsignment.Value = P_Int_IsConsignment;
        myCmd.Parameters.Add(IsConsignment);

        SqlParameter IsPigeonhole = new SqlParameter("@IsPigeonhole", SqlDbType.Int, 4);
        IsPigeonhole.Value = P_Int_IsPigeonhole;
        myCmd.Parameters.Add(IsPigeonhole);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        return myCmd;
    }
    /// <summary>
    /// 删除指定订单的信息
    /// </summary>
    /// <param name="P_Int_OrderID">订单编号</param>
    public void DeleteOrderInfo(int P_Int_OrderID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_DeleteOrderInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter OrderID = new SqlParameter("@OrderID", SqlDbType.BigInt, 8);
        OrderID.Value = P_Int_OrderID;
        myCmd.Parameters.Add(OrderID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    /// <summary>
    /// 获取运输方式名
    /// </summary>
    /// <param name="P_Int_ShipType">运输编号</param>
    /// <returns></returns>
    public string GetShipWay(int P_Int_ShipType)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_GetShipWay", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ShipType = new SqlParameter("@ShipType", SqlDbType.Int, 4);
        ShipType.Value = P_Int_ShipType;
        myCmd.Parameters.Add(ShipType);
        //执行过程
        myConn.Open();
        string P_Str_ShipWay = Convert.ToString(myCmd.ExecuteScalar());
        myCmd.Dispose();
        myConn.Close();
        return P_Str_ShipWay;
    }
    /// <summary>
    /// 获取支付方式名
    /// </summary>
    /// <param name="P_Int_PayType">获取支付编号</param>
    /// <returns></returns>
    public string GetPayWay(int P_Int_PayType)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_GetPayWay", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter PayType = new SqlParameter("@PayType", SqlDbType.Int, 4);
        PayType.Value = P_Int_PayType;
        myCmd.Parameters.Add(PayType);
        //执行过程
        myConn.Open();
        string P_Str_PayWay = Convert.ToString(myCmd.ExecuteScalar());
        myCmd.Dispose();
        myConn.Close();
        return P_Str_PayWay;
    }
    /// <summary>
    /// 获取订单状态的Dataset数据集
    /// </summary>
    /// <param name="P_Int_OrderID">订单编号</param>
    /// <param name="P_Str_srcTable">订单信息</param>
    /// <returns>返回Dataset</returns>
    public DataSet GetStatusDS(int P_Int_OrderID, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_GetStatus", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter OrderID = new SqlParameter("@OrderID", SqlDbType.BigInt, 8);
        OrderID.Value = P_Int_OrderID;
        myCmd.Parameters.Add(OrderID);
        //执行过程
        myConn.Open();
        myCmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        myCmd.Dispose();
        myConn.Dispose();
        return ds;
    }
    /// <summary>
    /// 获取订单状态的Dataset数据集
    /// </summary>
    /// <param name="P_Int_OrderID">订单编号</param>
    /// <param name="P_Str_srcTable">订单信息</param>
    /// <returns>返回Dataset</returns>
    public DataSet GetOdIfDS(int P_Int_OrderID, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_GetOdIf", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter OrderID = new SqlParameter("@OrderID", SqlDbType.BigInt, 8);
        OrderID.Value = P_Int_OrderID;
        myCmd.Parameters.Add(OrderID);
        //执行过程
        myConn.Open();
        myCmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        myCmd.Dispose();
        myConn.Dispose();
        return ds;
    }
    /// <summary>
    /// 通过订单ID代号，获取图书信息
    /// </summary>
    /// <param name="P_Int_OrderID">订单ID代号</param>
    /// <param name="P_Str_srcTable">信息</param>
    /// <returns>返回信息的数据集Ds</returns>
    public DataSet GetGIByOID(int P_Int_OrderID, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_GetBookIByOID", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter OrderID = new SqlParameter("@OrderID", SqlDbType.BigInt, 8);
        OrderID.Value = P_Int_OrderID;
        myCmd.Parameters.Add(OrderID);
        //执行过程
        myConn.Open();
        myCmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        myCmd.Dispose();
        myConn.Dispose();
        return ds;
    }
    /// <summary>
    ///  修改订单中的信息
    /// </summary>
    /// <param name="P_Int_OrderID">订单编号</param>
    /// <param name="P_Bl_IsConfirm">是否确认</param>
    /// <param name="P_Bl_IsPayment">是否付款</param>
    /// <param name="P_Bl_IsConsignment">是否已发货</param>
    /// <param name="P_Bl_IsPigeonhole">是否已归档</param>
    public void UpdateOI(int P_Int_OrderID, bool P_Bl_IsConfirm, bool P_Bl_IsPayment, bool P_Bl_IsConsignment, bool P_Bl_IsPigeonhole)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_UpdateOI", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter OrderID = new SqlParameter("@OrderID", SqlDbType.BigInt, 8);
        OrderID.Value = P_Int_OrderID;
        myCmd.Parameters.Add(OrderID);

        SqlParameter IsConfirm = new SqlParameter("@IsConfirm", SqlDbType.Bit, 1);
        IsConfirm.Value = P_Bl_IsConfirm;
        myCmd.Parameters.Add(IsConfirm);

        SqlParameter IsPayment = new SqlParameter("@IsPayment", SqlDbType.Bit, 1);
        IsPayment.Value = P_Bl_IsPayment;
        myCmd.Parameters.Add(IsPayment);

        SqlParameter IsConsignment = new SqlParameter("@IsConsignment", SqlDbType.Bit, 1);
        IsConsignment.Value = P_Bl_IsConsignment;
        myCmd.Parameters.Add(IsConsignment);

        SqlParameter IsPigeonhole = new SqlParameter("@IsPigeonhole", SqlDbType.Bit, 1);
        IsPigeonhole.Value = P_Bl_IsPigeonhole;
        myCmd.Parameters.Add(IsPigeonhole);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }

    /// <summary>
    /// 添加图书类别名称
    /// </summary>
    /// <param name="P_Str_ClassName">图书类别名称</param>
    /// <param name="P_Str_categoryUrl">图书类别图像</param>
    /// <returns></returns>
    public int AddCategory(string P_Str_ClassName, string P_Str_categoryUrl)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_AddCategory", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ClassName = new SqlParameter("@ClassName", SqlDbType.VarChar, 50);
        ClassName.Value = P_Str_ClassName;
        myCmd.Parameters.Add(ClassName);

        SqlParameter categoryUrl = new SqlParameter("@categoryUrl", SqlDbType.VarChar, 50);
        categoryUrl.Value = P_Str_categoryUrl;
        myCmd.Parameters.Add(categoryUrl);

        SqlParameter returnValue = myCmd.Parameters.Add("returnValue", SqlDbType.Int, 4);
        returnValue.Direction = ParameterDirection.ReturnValue;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        int P_Int_returnValue = Convert.ToInt32(returnValue.Value.ToString());
        return P_Int_returnValue;
    }
    /// <summary>
    /// 获取图书类别的数据集
    /// </summary>
    /// <param name="P_Str_srcTable">图书类别信息表名</param>
    /// <returns>图书类别的数据集</returns>
    public DataSet GetCategory(string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_GetCategory", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //执行过程
        myConn.Open();
        myCmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        myCmd.Dispose();
        myConn.Dispose();
        return ds;
    }
    /// <summary>
    /// 删除指定图书的类别名
    /// </summary>
    /// <param name="P_Int_ClassID">类别编号</param>
    public void DeleteCategory(int P_Int_ClassID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_DeleteCategory", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ClassID = new SqlParameter("@ClassID", SqlDbType.BigInt, 8);
        ClassID.Value = P_Int_ClassID;
        myCmd.Parameters.Add(ClassID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }


    /// <summary>
    /// 绑定图书类别名
    /// </summary>
    /// <param name="ddlName">绑定控件名</param>
    public void ddlClassBind(DropDownList ddlName)
    {
        string P_Str_SqlStr = "select * from Class";
        SqlConnection myConn = dbObj.GetConnection();
        SqlDataAdapter da = new SqlDataAdapter(P_Str_SqlStr, myConn);
        DataSet ds = new DataSet();
        da.Fill(ds, "Class");
        ddlName.DataSource = ds.Tables["Class"].DefaultView;
        ddlName.DataTextField = ds.Tables["Class"].Columns[1].ToString();
        ddlName.DataValueField = ds.Tables["Class"].Columns[0].ToString();
        ddlName.DataBind();

    }

    /// <summary>
    /// 绑定图书图像
    /// </summary>
    /// <param name="ddlName">绑定控件名</param>
    public void ddlUrl(DropDownList ddlName)
    {
        string P_Str_SqlStr = "select * from Image";
        SqlConnection myConn = dbObj.GetConnection();
        SqlDataAdapter da = new SqlDataAdapter(P_Str_SqlStr, myConn);
        DataSet ds = new DataSet();
        da.Fill(ds, "Url");
        ddlName.DataSource = ds.Tables["Url"].DefaultView;
        ddlName.DataTextField = ds.Tables["Url"].Columns[1].ToString();
        ddlName.DataValueField = ds.Tables["Url"].Columns[2].ToString();
        ddlName.DataBind();
    }
    /// <summary>
    /// 添加图书信息
    /// </summary>
    /// <param name="P_Int_ClassID">类型编号</param>
    /// <param name="P_Str_BookName">图书名称</param>
    /// <param name="P_Str_BookIntroduce">书籍描述</param>
    /// <param name="P_Str_BookISBN">图书ISBN</param>
    /// <param name="P_Str_BookPagenum">图书页码</param>
    /// <param name="P_Fl_BookPublisher">出版社</param>
    /// <param name="P_Str_BookPublishDate">出版日期</param>
    /// <param name="P_Str_BookAuthor">作者</param>
    /// <param name="P_Str_BookUrl">书籍图片</param>
    /// <param name="P_Fl_MarketPrice">图书市场价</param>
    /// <param name="P_Fl_MemberPrice">图书会员价</param>
    /// <param name="P_Bl_Isrefinement">是否是精品</param>
    /// <param name="P_Bl_IsHot">是否是热销图书</param>
    /// <param name="P_Bl_IsDiscount">是否是打折图书</param>
    /// <returns>返回一个值，判断图书是否存在</returns>
    public int AddBookInfo(int P_Int_ClassID, string P_Str_BookName, string P_Str_BookIntroduce, string P_Str_BookISBN, string P_Str_BookPagenum, string P_Str_BookPublisher, string P_Str_BookPublishDate, string P_Str_Author, string P_Str_BookUrl, float P_Flt_MarketPrice, float P_Flt_MemberPrice, bool P_Bl_Isrefinement, bool P_Bl_IsHot, bool P_Bl_IsDiscount)
    {

        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_AddBookInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ClassID = new SqlParameter("@ClassID", SqlDbType.BigInt, 8);
        ClassID.Value = P_Int_ClassID;
        myCmd.Parameters.Add(ClassID);

        SqlParameter BookName = new SqlParameter("@BookName", SqlDbType.VarChar, 50);
        BookName.Value = P_Str_BookName;
        myCmd.Parameters.Add(BookName);

        SqlParameter BookIntroduce = new SqlParameter("@BookIntroduce", SqlDbType.NText, 1024);
        BookIntroduce.Value = P_Str_BookIntroduce;
        myCmd.Parameters.Add(BookIntroduce);

        SqlParameter BookISBN = new SqlParameter("@BookISBN", SqlDbType.VarChar, 20);
        BookISBN.Value = P_Str_BookISBN;
        myCmd.Parameters.Add(BookISBN);

        SqlParameter PageNum = new SqlParameter("@PageNum", SqlDbType.VarChar, 20);
        PageNum.Value = P_Str_BookPagenum;
        myCmd.Parameters.Add(PageNum);

        SqlParameter Publisher = new SqlParameter("@Publisher", SqlDbType.VarChar, 20);
        Publisher.Value = P_Str_BookPublisher;
        myCmd.Parameters.Add(Publisher);

        SqlParameter PublishDate = new SqlParameter("@PublishDate", SqlDbType.VarChar, 20);
        PublishDate.Value = P_Str_BookPublishDate;
        myCmd.Parameters.Add(PublishDate);

        SqlParameter Author = new SqlParameter("@Author", SqlDbType.VarChar, 50);
        Author.Value = P_Str_Author;
        myCmd.Parameters.Add(Author);

        SqlParameter BookUrl = new SqlParameter("@BookUrl", SqlDbType.VarChar, 50);
        BookUrl.Value = P_Str_BookUrl;
        myCmd.Parameters.Add(BookUrl);

        SqlParameter MarketPrice = new SqlParameter("@MarketPrice", SqlDbType.Float, 8);
        MarketPrice.Value = P_Flt_MarketPrice;
        myCmd.Parameters.Add(MarketPrice);

        SqlParameter MemberPrice = new SqlParameter("@MemberPrice", SqlDbType.Float, 8);
        MemberPrice.Value = P_Flt_MemberPrice;
        myCmd.Parameters.Add(MemberPrice);

        SqlParameter Isrefinement = new SqlParameter("@Isrefinement", SqlDbType.Bit, 1);
        Isrefinement.Value = P_Bl_Isrefinement;
        myCmd.Parameters.Add(Isrefinement);

        SqlParameter IsHot = new SqlParameter("@IsHot", SqlDbType.Bit, 1);
        IsHot.Value = P_Bl_IsHot;
        myCmd.Parameters.Add(IsHot);

        SqlParameter IsDiscount = new SqlParameter("@IsDiscount", SqlDbType.Bit, 1);
        IsDiscount.Value = P_Bl_IsDiscount;
        myCmd.Parameters.Add(IsDiscount);

        SqlParameter returnValue = myCmd.Parameters.Add("returnValue", SqlDbType.Int, 4);
        returnValue.Direction = ParameterDirection.ReturnValue;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);

        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();
        }
        return Convert.ToInt32(returnValue.Value.ToString());

    }
    /// <summary>
    /// 获取图书信息的数据集
    /// </summary>
    /// <param name="P_Str_srcTable">图书信息表</param>
    /// <returns>返回图书信息的数据集</returns>
    public DataSet GetBookInfoDs(string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_GetBookInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //执行过程
        myConn.Open();
        myCmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        myCmd.Dispose();
        myConn.Dispose();
        return ds;
    }
    /// <summary>
    /// 获取指定图书信息的数据集
    /// </summary>
    /// <param name="P_Int_BookID">指定图书的ID</param>
    /// <param name="P_Str_srcTable">图书信息表</param>
    /// <returns>返回指定图书信息的数据集</returns>
    public DataSet GetBookInfoByIDDs(int P_Int_BookID, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_GetBookInfoByID", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter BookID = new SqlParameter("@BookID", SqlDbType.BigInt, 8);
        BookID.Value = P_Int_BookID;
        myCmd.Parameters.Add(BookID);
        //执行过程
        myConn.Open();
        myCmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        myCmd.Dispose();
        myConn.Dispose();
        return ds;
    }
    /// <summary>
    /// 获取搜索图书信息的数据集
    /// </summary>
    /// <param name="P_Str_srcTable">图书信息表</param>
    /// <param name="P_Str_keywords">搜索的关键字</param>
    /// <returns>返回搜索图书信息的数据集</returns>
    public DataSet SearchBookInfoDs(string P_Str_srcTable, string P_Str_keywords)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_SearchBookInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter keywords = new SqlParameter("@keywords", SqlDbType.VarChar, 50);
        keywords.Value = P_Str_keywords;
        myCmd.Parameters.Add(keywords);

        //执行过程
        myConn.Open();
        myCmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        myCmd.Dispose();
        myConn.Dispose();
        return ds;
    }
    /// <summary>
    /// 删除指定的图书信息
    /// </summary>
    /// <param name="P_Int_BookID">指定图书的编号</param>
    public void DeleteBookInfo(int P_Int_BookID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_DeleteBookInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter BookID = new SqlParameter("@BookID", SqlDbType.BigInt, 8);
        BookID.Value = P_Int_BookID;
        myCmd.Parameters.Add(BookID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    public void UpdateGInfo(int P_Int_ClassID, string P_Str_BookName, string P_Str_BookIntroduce, string P_Str_ISBN, string P_Str_PageNum, string P_Str_Publisher, string P_Str_PublishDate, string P_Str_Author, string P_Str_BookUrl, float P_Flt_MarketPrice, float P_Flt_MemberPrice, bool P_Bl_Isrefinement, bool P_Bl_IsHot, bool P_Bl_IsDisCount, int P_Int_BookID)
    {

        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_UpdateBookInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ClassID = new SqlParameter("@ClassID", SqlDbType.BigInt, 8);
        ClassID.Value = P_Int_ClassID;
        myCmd.Parameters.Add(ClassID);

        SqlParameter BookName = new SqlParameter("@BookName", SqlDbType.VarChar, 50);
        BookName.Value = P_Str_BookName;
        myCmd.Parameters.Add(BookName);

        SqlParameter BookIntroduce = new SqlParameter("@BookIntroduce", SqlDbType.NText, 1024);
        BookIntroduce.Value = P_Str_BookIntroduce;
        myCmd.Parameters.Add(BookIntroduce);

        SqlParameter ISBN = new SqlParameter("@ISBN", SqlDbType.VarChar, 20);
        ISBN.Value = P_Str_ISBN;
        myCmd.Parameters.Add(ISBN);

        SqlParameter PageNum = new SqlParameter("@PageNum", SqlDbType.VarChar, 20);
        PageNum.Value = P_Str_PageNum;
        myCmd.Parameters.Add(PageNum);

        SqlParameter Publisher = new SqlParameter("@Publisher", SqlDbType.VarChar, 100);
        Publisher.Value = P_Str_Publisher;
        myCmd.Parameters.Add(Publisher);

        SqlParameter PublishDate = new SqlParameter("@PublishDate", SqlDbType.VarChar, 20);
        PublishDate.Value = P_Str_PublishDate;
        myCmd.Parameters.Add(PublishDate);

        SqlParameter Author = new SqlParameter("@Author", SqlDbType.VarChar, 50);
        Author.Value = P_Str_Author;
        myCmd.Parameters.Add(Author);

        SqlParameter BookUrl = new SqlParameter("@BookUrl", SqlDbType.VarChar, 50);
        BookUrl.Value = P_Str_BookUrl;
        myCmd.Parameters.Add(BookUrl);

        SqlParameter MarketPrice = new SqlParameter("@MarketPrice", SqlDbType.Float, 8);
        MarketPrice.Value = P_Flt_MarketPrice;
        myCmd.Parameters.Add(MarketPrice);

        SqlParameter MemberPrice = new SqlParameter("@MemberPrice", SqlDbType.Float, 8);
        MemberPrice.Value = P_Flt_MemberPrice;
        myCmd.Parameters.Add(MemberPrice);

        SqlParameter Isrefinement = new SqlParameter("@Isrefinement", SqlDbType.Bit, 1);
        Isrefinement.Value = P_Bl_Isrefinement;
        myCmd.Parameters.Add(Isrefinement);

        SqlParameter IsHot = new SqlParameter("@IsHot", SqlDbType.Bit, 1);
        IsHot.Value = P_Bl_IsHot;
        myCmd.Parameters.Add(IsHot);

        SqlParameter IsDiscount = new SqlParameter("@IsDiscount", SqlDbType.Bit, 1);
        IsDiscount.Value = P_Bl_IsDisCount;
        myCmd.Parameters.Add(IsDiscount);

        SqlParameter BookID = new SqlParameter("@BookID", SqlDbType.BigInt, 8);
        BookID.Value = P_Int_BookID;
        myCmd.Parameters.Add(BookID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);

        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();
        }
    }

    /// <summary>
    /// 添加管理员
    /// </summary>
    /// <param name="P_Str_Admin">管理员名</param>
    /// <returns></returns>
    public int AddAdmin(string P_Str_Admin, string P_Str_Password)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_AddAdmin", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter Admin = new SqlParameter("@Admin", SqlDbType.VarChar, 50);
        Admin.Value = P_Str_Admin;
        myCmd.Parameters.Add(Admin);

        SqlParameter Password = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        Password.Value = P_Str_Password;
        myCmd.Parameters.Add(Password);

        SqlParameter returnValue = myCmd.Parameters.Add("returnValue", SqlDbType.Int, 4);
        returnValue.Direction = ParameterDirection.ReturnValue;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        int P_Int_returnValue = Convert.ToInt32(returnValue.Value.ToString());
        return P_Int_returnValue;
    }

    /// <summary>
    /// 判断用户是否存在
    /// </summary>
    /// <param name="P_Str_Name">用户名字</param>
    /// <returns></returns>
    public bool CheckU(string P_Str_Name)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_CheckUser", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;

        //添加参数
        SqlParameter Name = new SqlParameter("@Name", SqlDbType.VarChar, 50);
        Name.Value = P_Str_Name;
        myCmd.Parameters.Add(Name);

        SqlParameter returnValue = myCmd.Parameters.Add("returnValue", SqlDbType.Int, 4);
        returnValue.Direction = ParameterDirection.ReturnValue;
        //执行过程
        myConn.Open();
        try { myCmd.ExecuteNonQuery(); }
        catch (Exception ex) { throw (ex); }
        finally
        {
            myCmd.Dispose();
            myConn.Close();
        }
        int P_Int = Convert.ToInt32(returnValue.Value.ToString());
        if (P_Int > 0) { return true; }
        else { return false; }
    }

    /// <summary>
    /// 判断管理员是否存在
    /// </summary>
    /// <param name="P_Str_Name">管理员名字</param>
    /// <returns></returns>
    public bool CheckA(string P_Str_Name)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_CheckAdmin", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;

        //添加参数
        SqlParameter Name = new SqlParameter("@Name", SqlDbType.VarChar, 50);
        Name.Value = P_Str_Name;
        myCmd.Parameters.Add(Name);

        SqlParameter returnValue = myCmd.Parameters.Add("returnValue", SqlDbType.Int, 4);
        returnValue.Direction = ParameterDirection.ReturnValue;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();
        }
        int P_Int = Convert.ToInt32(returnValue.Value.ToString());
        if (P_Int > 0) { return true; }
        else { return false; }
    }

    /// 判断管理员是否存在
    /// </summary>
    /// <param name="P_Str_Name">管理员名字</param>
    /// <param name="P_Str_Password">管理员密码</param>
    /// <returns></returns>
    public int AExists(string P_Str_Name, string P_Str_Password)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_AdminExists", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter Name = new SqlParameter("@Name", SqlDbType.VarChar, 50);
        Name.Value = P_Str_Name;
        myCmd.Parameters.Add(Name);

        SqlParameter Password = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        Password.Value = P_Str_Password;
        myCmd.Parameters.Add(Password);

        SqlParameter returnValue = myCmd.Parameters.Add("returnValue", SqlDbType.Int, 4);
        returnValue.Direction = ParameterDirection.ReturnValue;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();
        }
        int P_Int_returnValue = Convert.ToInt32(returnValue.Value.ToString());
        return P_Int_returnValue;
    }
    /// <summary>
    /// 返回管理员信息
    /// </summary>
    /// <param name="P_Str_Name">管理员名</param>
    /// <param name="P_Str_Password">管理员密码</param>
    /// <param name="P_Str_srcTable">信息表名</param>
    /// <returns></returns>
    public DataSet ReturnAIDs(string P_Str_Name, string P_Str_Password, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_GetAInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter Name = new SqlParameter("@Name", SqlDbType.VarChar, 50);
        Name.Value = P_Str_Name;
        myCmd.Parameters.Add(Name);

        SqlParameter Password = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        Password.Value = P_Str_Password;
        myCmd.Parameters.Add(Password);

        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;

    }
    /// <summary>
    /// 获取所有管理员信息
    /// </summary>
    /// <param name="P_Str_srcTable">管理员信息表名</param>
    /// <returns>返回所有管理员信息的数据集</returns>
    public DataSet ReturnAdminIDs(int adminID, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_GetAdminInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter AdminID = new SqlParameter("@AdminID", SqlDbType.BigInt, 8);
        AdminID.Value = adminID;
        myCmd.Parameters.Add(AdminID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;

    }
    /// <summary>
    /// 删除指定管理员信息
    /// </summary>
    /// <param name="P_Int_AdminID">管理员编号</param>
    public void DeleteAdminInfo(int P_Int_AdminID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_DeleteAdminInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter AdminID = new SqlParameter("@AdminID", SqlDbType.BigInt, 8);
        AdminID.Value = P_Int_AdminID;
        myCmd.Parameters.Add(AdminID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    public void UpdateAdminInfo(int P_Int_AdminID, string P_Str_Admin, string P_Str_Password)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_UpdateAdminInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter AdminID = new SqlParameter("@AdminID", SqlDbType.BigInt, 8);
        AdminID.Value = P_Int_AdminID;
        myCmd.Parameters.Add(AdminID);

        SqlParameter Admin = new SqlParameter("@Admin", SqlDbType.VarChar, 50);
        Admin.Value = P_Str_Admin;
        myCmd.Parameters.Add(Admin);

        SqlParameter Password = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        Password.Value = P_Str_Password;
        myCmd.Parameters.Add(Password);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }

    /// <summary>
    /// 获取图像信息
    /// </summary>
    /// <param name="P_Str_srcTable">图像信息</param>
    /// <returns>返回图像信息数据集</returns>
    public DataSet ReturnImagerDs(string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_GetImageInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;

    }
    /// <summary>
    /// 向图像表中插入信息
    /// </summary>
    /// <param name="P_Str_ImageName">图像名</param>
    /// <param name="P_Int_ImageUrl">图像路径</param>
    public void InsertImage(string P_Str_ImageName, string P_Str_ImageUrl)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_InsertImageInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ImageName = new SqlParameter("@ImageName", SqlDbType.VarChar, 50);
        ImageName.Value = P_Str_ImageName;
        myCmd.Parameters.Add(ImageName);

        SqlParameter ImageUrl = new SqlParameter("@ImageUrl", SqlDbType.VarChar, 200);
        ImageUrl.Value = P_Str_ImageUrl;
        myCmd.Parameters.Add(ImageUrl);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();
        }
    }
    /// <summary>
    /// 删除图片表中的信息
    /// </summary>
    /// <param name="P_Int_ImageID">图片表中ID</param>
    public void DeleteImage(int P_Int_ImageID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_DeleteImageInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ImageID = new SqlParameter("@ImageID", SqlDbType.BigInt, 8);
        ImageID.Value = P_Int_ImageID;
        myCmd.Parameters.Add(ImageID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }

    public DataSet ReturnMemberDs(string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_GetAllUserInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;
    }
    /// <summary>
    /// 删除指定会员的信息
    /// </summary>
    /// <param name="P_Int_MemberID">会员ID</param>
    public void DeleteMemberInfo(int P_Int_MemberID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_DeleteMemberInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter MemberID = new SqlParameter("@MemberID", SqlDbType.BigInt, 8);
        MemberID.Value = P_Int_MemberID;
        myCmd.Parameters.Add(MemberID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }

    /// <summary>
    /// 获取配送方式的数据集
    /// </summary>
    /// <param name="P_Str_srcTable">配送方式表的信息</param>
    /// <returns>返回配送方式的数据集</returns>
    public DataSet ReturnShipDs(string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_GetShipInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;
    }
    /// <summary>
    /// 返回指定配送方式信息的数据集
    /// </summary>
    /// <param name="P_Int_ShipID">配送方式ID</param>
    /// <param name="P_Str_srcTable">配送方式信息</param>
    /// <returns></returns>
    public DataSet ReturnShipDsByID(int P_Int_ShipID, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_GetShipInfoByID", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ShipID = new SqlParameter("@ShipID", SqlDbType.BigInt, 8);
        ShipID.Value = P_Int_ShipID;
        myCmd.Parameters.Add(ShipID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;
    }
    /// <summary>
    /// 删除指定配送方式信息
    /// </summary>
    /// <param name="P_Int_ShipID">指定配送方式的ID</param>
    public void DeleteShipInfo(int P_Int_ShipID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_DeleteShipInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ShipID = new SqlParameter("@ShipID", SqlDbType.BigInt, 8);
        ShipID.Value = P_Int_ShipID;
        myCmd.Parameters.Add(ShipID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    /// <summary>
    /// 返回指定类别的名称
    /// </summary>
    /// <param name="P_Int_ClassID">指定类别的ID</param>
    /// <returns></returns>
    public string GetClass(int P_Int_ClassID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_GetClassName", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ClassID = new SqlParameter("@ClassID", SqlDbType.Int, 8);
        ClassID.Value = P_Int_ClassID;
        myCmd.Parameters.Add(ClassID);
        //执行过程
        myConn.Open();
        string P_Str_Class = Convert.ToString(myCmd.ExecuteScalar());
        myCmd.Dispose();
        myConn.Close();
        return P_Str_Class;
    }
    public void InsertShip(string P_Str_ShipWay, float P_Flt_ShipFee)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_InsertShipInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ShipWay = new SqlParameter("@ShipWay", SqlDbType.VarChar, 50);
        ShipWay.Value = P_Str_ShipWay;
        myCmd.Parameters.Add(ShipWay);

        SqlParameter ShipFee = new SqlParameter("@ShipFee", SqlDbType.Float, 8);
        ShipFee.Value = P_Flt_ShipFee;
        myCmd.Parameters.Add(ShipFee);

        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    public void UpdateShip(int P_Int_ShipID, string P_Str_ShipWay, float P_Flt_ShipFee)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_UpdateShipInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ShipID = new SqlParameter("@ShipID", SqlDbType.BigInt, 8);
        ShipID.Value = P_Int_ShipID;
        myCmd.Parameters.Add(ShipID);

        SqlParameter ShipWay = new SqlParameter("@ShipWay", SqlDbType.VarChar, 50);
        ShipWay.Value = P_Str_ShipWay;
        myCmd.Parameters.Add(ShipWay);

        SqlParameter ShipFee = new SqlParameter("@ShipFee", SqlDbType.Float, 8);
        ShipFee.Value = P_Flt_ShipFee;
        myCmd.Parameters.Add(ShipFee);

        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }

    /// <summary>
    /// 获取支付方式的数据集
    /// </summary>
    /// <param name="P_Str_srcTable">支付方式表的信息</param>
    /// <returns>返回支付方式的数据集</returns>
    public DataSet ReturnPayDs(string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_GetPayInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;
    }
    /// <summary>
    /// 返回指定支付方式信息的数据集
    /// </summary>
    /// <param name="P_Int_PayID">支付方式ID</param>
    /// <param name="P_Str_srcTable">支付方式信息</param>
    /// <returns></returns>
    public DataSet ReturnPayDsByID(int P_Int_PayID, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_GetPayInfoByID", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter PayID = new SqlParameter("@PayID", SqlDbType.BigInt, 8);
        PayID.Value = P_Int_PayID;
        myCmd.Parameters.Add(PayID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;
    }
    /// <summary>
    /// 删除指定支付方式信息
    /// </summary>
    /// <param name="P_Int_PayID">指定支付方式的ID</param>
    public void DeletePayInfo(int P_Int_PayID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_DeletePayInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter PayID = new SqlParameter("@PayID", SqlDbType.BigInt, 8);
        PayID.Value = P_Int_PayID;
        myCmd.Parameters.Add(PayID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    public void InsertPay(string P_Str_PayWay)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_InsertPayInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter PayWay = new SqlParameter("@PayWay", SqlDbType.VarChar, 50);
        PayWay.Value = P_Str_PayWay;
        myCmd.Parameters.Add(PayWay);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    public void UpdatePay(int P_Int_PayID, string P_Str_PayWay)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_UpdatePayInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter PayID = new SqlParameter("@PayID", SqlDbType.BigInt, 8);
        PayID.Value = P_Int_PayID;
        myCmd.Parameters.Add(PayID);

        SqlParameter PayWay = new SqlParameter("@PayWay", SqlDbType.VarChar, 50);
        PayWay.Value = P_Str_PayWay;
        myCmd.Parameters.Add(PayWay);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }

    /// <summary>
    /// 查询所有配送地点信息
    /// </summary>
    /// <param name="P_Str_srcTable">地点表信息</param>
    /// <returns>返回所有配送地点信息数据集</returns>
    public DataSet ReturnAreaDs(string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_GetAreaInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;
    }
    /// <summary>
    /// 删除指定地点的信息
    /// </summary>
    /// <param name="P_Int_AreaID">地点编号</param>
    public void DeleteAreaInfo(int P_Int_AreaID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_DeleteAreaInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter AreaID = new SqlParameter("@AreaID", SqlDbType.BigInt, 8);
        AreaID.Value = P_Int_AreaID;
        myCmd.Parameters.Add(AreaID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    /// <summary>
    /// 查询指定地点编号信息的数据集
    /// </summary>
    /// <param name="P_Int_AreaID">地点编号</param>
    /// <param name="P_Str_srcTable">地点数据表</param>
    /// <returns>返回指定地点编号信息的数据集</returns>
    public DataSet ReturnAreaDsByID(int P_Int_AreaID, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_GetAreaInfoByID", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter AreaID = new SqlParameter("@AreaID", SqlDbType.BigInt, 8);
        AreaID.Value = P_Int_AreaID;
        myCmd.Parameters.Add(AreaID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;
    }
    public void InsertArea(string P_Str_AreaName, int P_Int_AreaKM)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_InsertAreaInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter AreaName = new SqlParameter("@AreaName", SqlDbType.VarChar, 50);
        AreaName.Value = P_Str_AreaName;
        myCmd.Parameters.Add(AreaName);

        SqlParameter AreaKM = new SqlParameter("@AreaKM", SqlDbType.Int, 4);
        AreaKM.Value = P_Int_AreaKM;
        myCmd.Parameters.Add(AreaKM);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    public void UpdateArea(int P_Int_AreaID, string P_Str_AreaName, int P_Int_AreaKM)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_UpdateAreaInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter AreaID = new SqlParameter("@AreaID", SqlDbType.BigInt, 8);
        AreaID.Value = P_Int_AreaID;
        myCmd.Parameters.Add(AreaID);

        SqlParameter AreaName = new SqlParameter("@AreaName", SqlDbType.VarChar, 50);
        AreaName.Value = P_Str_AreaName;
        myCmd.Parameters.Add(AreaName);

        SqlParameter AreaKM = new SqlParameter("@AreaKM", SqlDbType.Int, 4);
        AreaKM.Value = P_Int_AreaKM;
        myCmd.Parameters.Add(AreaKM);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    /// <summary>
    /// 用来将字符串保留到指定长度，将超出部分用“...”代替。
    /// </summary>
    /// <param name="sString">sString原字符串。</param>
    /// <param name="nLeng">nLeng长度。</param>
    /// <returns>处理后的字符串。</returns>
    public string SubStr(string sString, int nLeng)
    {
        if (sString.Length <= nLeng)
        {
            return sString;
        }
        int nStrLeng = nLeng - 3;
        string sNewStr = sString.Substring(0, nStrLeng);
        sNewStr = sNewStr + "...";
        return sNewStr;
    }
    /// <summary>
    /// 用来截取小数点后nleng位
    /// </summary>
    /// <param name="sString">sString原字符串。</param>
    /// <param name="nLeng">nLeng长度。</param>
    /// <returns>处理后的字符串。</returns>
    public string VarStr(string sString, int nLeng)
    {
        int index = sString.IndexOf(".");
        if (index == -1 || index + 2 >= sString.Length)
            return sString;
        else
            return sString.Substring(0, (index + nLeng + 1));
    }
}