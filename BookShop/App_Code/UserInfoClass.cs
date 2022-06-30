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
/// UserInfoClass 的摘要说明
/// </summary>
public class UserInfoClass
{
    DBClass dbObj = new DBClass();
    public UserInfoClass()
    {
    }

    /// <summary>
    /// 判断用户是否存在
    /// </summary>
    /// <param name="P_Str_Name">会员登录名</param>
    /// <param name="P_Str_Password">会员登录密码</param>
    /// <returns></returns>
    public int UserExists(string P_Str_Name, string P_Str_Password)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_UserExists", myConn);
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
    /// 获取会员信息
    /// </summary>
    /// <param name="P_Str_Name">会员登录名</param>
    /// <param name="P_Str_Password">会员登录密码</param>
    /// <param name="P_Str_srcTable">查询表信息</param>
    /// <returns></returns>
    public DataSet ReturnUIDs(string P_Str_Name, string P_Str_Password, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_GetUserInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter Name = new SqlParameter("@Name", SqlDbType.VarChar, 50);
        Name.Value = P_Str_Name;
        myCmd.Parameters.Add(Name);

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
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;

    }
    //***************************************注册界面************************************************************
    /// <summary>
    /// 向用户表中插入信息
    /// </summary>
    /// <param name="P_Str_Name">会员名</param>
    /// <param name="P_Bl_Sex">性别</param>
    /// <param name="P_Str_Password">密码</param>
    /// <param name="P_Str_TrueName">真实姓名</param>
    /// <param name="P_Str_Questions">找回密码问题</param>
    /// <param name="P_Str_Answers">找回密码答案</param>
    /// <param name="P_Str_Phonecode">电话号码</param>
    /// <param name="P_Str_Emails">E_Mail</param>
    /// <param name="P_Str_City">会员所在城市</param>
    /// <param name="P_Str_Address">会员详细地址</param>
    /// <param name="P_Str_PostCode">邮编</param>
    /// <param name="P_Flt_AdvancePayment">预付金额</param>
    /// <param name="P_Date_LoadDate">登录日期</param>
    public int AddUInfo(string P_Str_Name, bool P_Bl_Sex, string P_Str_Password, string P_Str_TrueName, string P_Str_Questions, string P_Str_Answers, string P_Str_Phonecode, string P_Str_Emails, string P_Str_City, string P_Str_Address, string P_Str_PostCode)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_InsertUInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter Name = new SqlParameter("@Name", SqlDbType.VarChar, 50);
        Name.Value = P_Str_Name;
        myCmd.Parameters.Add(Name);

        SqlParameter sex = new SqlParameter("@sex", SqlDbType.Bit, 1);
        sex.Value = P_Bl_Sex;
        myCmd.Parameters.Add(sex);

        SqlParameter Password = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        Password.Value = P_Str_Password;
        myCmd.Parameters.Add(Password);

        SqlParameter TrueName = new SqlParameter("@TrueName", SqlDbType.VarChar, 50);
        TrueName.Value = P_Str_TrueName;
        myCmd.Parameters.Add(TrueName);

        SqlParameter Questions = new SqlParameter("@Questions", SqlDbType.VarChar, 50);
        Questions.Value = P_Str_Questions;
        myCmd.Parameters.Add(Questions);

        SqlParameter Answers = new SqlParameter("@Answers", SqlDbType.VarChar, 50);
        Answers.Value = P_Str_Answers;
        myCmd.Parameters.Add(Answers);

        SqlParameter Phonecode = new SqlParameter("@Phonecode", SqlDbType.VarChar, 20);
        Phonecode.Value = P_Str_Phonecode;
        myCmd.Parameters.Add(Phonecode);

        SqlParameter Emails = new SqlParameter("@Emails", SqlDbType.VarChar, 50);
        Emails.Value = P_Str_Emails;
        myCmd.Parameters.Add(Emails);

        SqlParameter City = new SqlParameter("@City", SqlDbType.VarChar, 50);
        City.Value = P_Str_City;
        myCmd.Parameters.Add(City);

        SqlParameter Address = new SqlParameter("@Address", SqlDbType.VarChar, 200);
        Address.Value = P_Str_Address;
        myCmd.Parameters.Add(Address);

        SqlParameter PostCode = new SqlParameter("@PostCode", SqlDbType.Char, 10);
        PostCode.Value = P_Str_PostCode;
        myCmd.Parameters.Add(PostCode);

        SqlParameter MemberId = myCmd.Parameters.Add("@MemberId", SqlDbType.BigInt, 8);
        MemberId.Direction = ParameterDirection.Output;
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
        return Convert.ToInt32(MemberId.Value.ToString());

    }
    /// <summary>
    /// 修改会员充值
    /// </summary>
    /// <param name="P_Int_MemberID">会员ID</param>
    /// <param name="P_Flt_AdvancePayment">充值金额</param>
    public void UpdateAP(int P_Int_MemberID, float P_Flt_AdvancePayment)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_UpdateAP", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter MemberID = new SqlParameter("@MemberID", SqlDbType.BigInt, 8);
        MemberID.Value = P_Int_MemberID;
        myCmd.Parameters.Add(MemberID);

        SqlParameter AdvancePayment = new SqlParameter("@AdvancePayment", SqlDbType.Float, 8);
        AdvancePayment.Value = P_Flt_AdvancePayment;
        myCmd.Parameters.Add(AdvancePayment);
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
    //********************************更新用户信息*************************************************
    /// <summary>
    /// 获取会员信息
    /// </summary>
    /// <param name="P_Int_MemberID">会员编号</param>
    /// <param name="P_Str_srcTable">表的信息</param>
    /// <returns></returns>
    public DataSet ReturnUIDsByID(int P_Int_MemberID, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_GetUIByID", myConn);
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
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;
    }
    /// <summary>
    /// 修改会员表中的信息
    /// </summary>
    /// <param name="P_Str_Name">会员名</param>
    /// <param name="P_Bl_Sex">性别</param>
    /// <param name="P_Str_Password">密码</param>
    /// <param name="P_Str_TrueName">真实姓名</param>
    /// <param name="P_Str_Questions">找回密码问题</param>
    /// <param name="P_Str_Answers">找回密码答案</param>
    /// <param name="P_Str_Phonecode">电话号码</param>
    /// <param name="P_Str_Emails">E_Mail</param>
    /// <param name="P_Str_City">会员所在城市</param>
    /// <param name="P_Str_Address">会员详细地址</param>
    /// <param name="P_Str_PostCode">邮编</param>
    /// <param name="P_Flt_AdvancePayment">预付金额</param>
    /// <param name="P_Date_LoadDate">登录日期</param>
    public void UpdateUInfo(string P_Str_Name, bool P_Bl_Sex, string P_Str_Password, string P_Str_TrueName, string P_Str_Questions, string P_Str_Answers, string P_Str_Phonecode, string P_Str_Emails, string P_Str_City, string P_Str_Address, string P_Str_PostCode, int P_Int_MemberID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        myConn.Open();
        SqlCommand myCmd = new SqlCommand("Pr_UpdateUIbyID", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter Name = new SqlParameter("@Name", SqlDbType.VarChar, 50);
        Name.Value = P_Str_Name;
        myCmd.Parameters.Add(Name);

        SqlParameter sex = new SqlParameter("@Sex", SqlDbType.Bit, 1);
        sex.Value = P_Bl_Sex;
        myCmd.Parameters.Add(sex);

        SqlParameter Password = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        Password.Value = P_Str_Password;
        myCmd.Parameters.Add(Password);

        SqlParameter TrueName = new SqlParameter("@TrueName", SqlDbType.VarChar, 50);
        TrueName.Value = P_Str_TrueName;
        myCmd.Parameters.Add(TrueName);

        SqlParameter Questions = new SqlParameter("@Questions", SqlDbType.VarChar, 50);
        Questions.Value = P_Str_Questions;
        myCmd.Parameters.Add(Questions);

        SqlParameter Answers = new SqlParameter("@Answers", SqlDbType.VarChar, 50);
        Answers.Value = P_Str_Answers;
        myCmd.Parameters.Add(Answers);

        SqlParameter Phonecode = new SqlParameter("@Phonecode", SqlDbType.VarChar, 20);
        Phonecode.Value = P_Str_Phonecode;
        myCmd.Parameters.Add(Phonecode);

        SqlParameter Emails = new SqlParameter("@Emails", SqlDbType.VarChar, 50);
        Emails.Value = P_Str_Emails;
        myCmd.Parameters.Add(Emails);

        SqlParameter City = new SqlParameter("@City", SqlDbType.VarChar, 50);
        City.Value = P_Str_City;
        myCmd.Parameters.Add(City);

        SqlParameter Address = new SqlParameter("@Address", SqlDbType.VarChar, 200);
        Address.Value = P_Str_Address;
        myCmd.Parameters.Add(Address);

        SqlParameter PostCode = new SqlParameter("@PostCode", SqlDbType.Char, 10);
        PostCode.Value = P_Str_PostCode;
        myCmd.Parameters.Add(PostCode);

        SqlParameter MemberId = new SqlParameter("@MemberId", SqlDbType.BigInt, 8);
        MemberId.Value = P_Int_MemberID;
        myCmd.Parameters.Add(MemberId);
        //执行过程
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
    /// 图书功能菜单导航
    /// </summary>
    /// <param name="dlName">图书类别信息</param>
    public void DLClassBind(DataList dlName)
    {
        string P_Str_SqlStr = "select * from Class";
        SqlConnection myConn = dbObj.GetConnection();
        SqlDataAdapter da = new SqlDataAdapter(P_Str_SqlStr, myConn);
        DataSet ds = new DataSet();
        da.Fill(ds, "Class");
        dlName.DataSource = ds.Tables["Class"].DefaultView;
        dlName.DataBind();
    }

    /// <summary>
    /// 绑定图书信息(精品推荐　热销图书 打折图书)
    /// </summary>
    /// <param name="P_Int_Deplay">(精品推荐 热销图书 打折图书)三种类别的标志</param>
    /// <param name="P_Str_srcTable">表信息</param>
    /// <param name="DLName">绑定控件名</param>
    public void DGIBind(int P_Int_Deplay, string P_Str_srcTable, DataList DLName)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_DeplayBookInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter Deplay = new SqlParameter("@Deplay", SqlDbType.Int, 4);
        Deplay.Value = P_Int_Deplay;
        myCmd.Parameters.Add(Deplay);
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
        DLName.DataSource = ds.Tables[P_Str_srcTable].DefaultView;
        DLName.DataBind();
    }
    /// <summary>
    /// 以搜索的关键字绑定图书信息
    /// </summary>
    /// <param name="P_Int_ClassID">搜索的关键字</param>
    /// <param name="P_Str_srcTable">表信息</param>
    /// <param name="DLName">绑定控件名</param>
    public void DCSearchBind(string SearchName, string srcTable, DataList DLName)
    {
        SqlConnection conn = dbObj.GetConnection();
        SqlCommand cmd = new SqlCommand("select * from BookInfo where BookName like '%"+SearchName+"%'",conn);
        cmd.CommandType = CommandType.Text;
        //执行过程
        conn.Open();
        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            cmd.Dispose();
            conn.Close();
        }
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds,srcTable);
        DLName.DataSource = ds.Tables[srcTable].DefaultView;
        DLName.DataBind();
    }
    /// <summary>
    /// 以图书类别分类绑定图书信息
    /// </summary>
    /// <param name="P_Int_ClassID">图书类别编号</param>
    /// <param name="P_Str_srcTable">表信息</param>
    /// <param name="DLName">绑定控件名</param>
    public void DCGIBind(int P_Int_ClassID, string P_Str_srcTable, DataList DLName)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_DeplayBookInfoByC", myConn);
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
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        DLName.DataSource = ds.Tables[P_Str_srcTable].DefaultView;
        DLName.DataBind();
    }
    //**************************购物车**********************************************************
    /// <summary>
    /// 向购物车中添加信息
    /// </summary>
    /// <param name="P_Int_BookID">图书编号</param>
    /// <param name="P_Flt_MemberPrice">会员价格</param>
    /// <param name="P_Int_MemberID">会员编号</param>
    public void AddShopCart(int P_Int_BookID, float P_Flt_MemberPrice, int P_Int_MemberID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_InsertShopCart", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter BookID = new SqlParameter("@BookID", SqlDbType.BigInt, 8);
        BookID.Value = P_Int_BookID;
        myCmd.Parameters.Add(BookID);

        SqlParameter MemberPrice = new SqlParameter("@SumPrice", SqlDbType.Float, 8);
        MemberPrice.Value = P_Flt_MemberPrice;
        myCmd.Parameters.Add(MemberPrice);

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
    /// 显示购物车中的信息
    /// </summary>
    /// <param name="P_Str_srcTable">信息表名</param>
    /// <param name="gvName">控件名</param>
    /// <param name="P_Int_MemberID">会员编号</param>
    public void SCIBind(string P_Str_srcTable, GridView gvName, int P_Int_MemberID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_GetShopCart", myConn);
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
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        gvName.DataSource = ds.Tables[P_Str_srcTable].DefaultView;
        gvName.DataBind();

    }
    /// <summary>
    /// 返回合计总数的Ds
    /// </summary>
    /// <param name="P_Str_srcTable">信息表名</param>
    /// <param name="P_Int_MemberID">员工编号</param>
    /// <returns>返回合计总数的Ds</returns>
    public DataSet ReturnTotalDs(int P_Int_MemberID, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_TotalInfo", myConn);
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
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;

    }
    /// <summary>
    /// 删除购物车中的信息
    /// </summary>
    /// <param name="P_Int_MemberID">会员编号</param>
    public void DeleteShopCart(int P_Int_MemberID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_DeleteShopCart", myConn);
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
    ///  删除指定购物车中的信息
    /// </summary>
    /// <param name="P_Int_MemberID">会员编号</param>
    /// <param name="P_Int_CartID">图书编号</param>
    public void DeleteShopCartByID(int P_Int_MemberID, int P_Int_CartID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_DeleteSCByID", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter MemberID = new SqlParameter("@MemberID", SqlDbType.BigInt, 8);
        MemberID.Value = P_Int_MemberID;
        myCmd.Parameters.Add(MemberID);

        SqlParameter CartID = new SqlParameter("@CartID", SqlDbType.BigInt, 8);
        CartID.Value = P_Int_CartID;
        myCmd.Parameters.Add(CartID);
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
    /// 当购物车中图书数量改变时，修改购物车中的信息
    /// </summary>
    /// <param name="P_Int_MemberID">会员ID号</param>
    /// <param name="P_Int_CartID">图书编号</param>
    /// <param name="P_Int_Num">图书数量</param>
    public void UpdateSCI(int P_Int_MemberID, int P_Int_CartID, int P_Int_Num)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_UpdateSC", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter MemberID = new SqlParameter("@MemberID", SqlDbType.BigInt, 8);
        MemberID.Value = P_Int_MemberID;
        myCmd.Parameters.Add(MemberID);

        SqlParameter CartID = new SqlParameter("@CartID", SqlDbType.BigInt, 8);
        CartID.Value = P_Int_CartID;
        myCmd.Parameters.Add(CartID);

        SqlParameter Num = new SqlParameter("@Num", SqlDbType.BigInt, 8);
        Num.Value = P_Int_Num;
        myCmd.Parameters.Add(Num);
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
    //*********************************结账********************************************************
    public void ddlCityBind(DropDownList ddlName)
    {
        SqlConnection myConn = dbObj.GetConnection();
        string P_Str_Sqlstr = "select * from Area";
        SqlDataAdapter da = new SqlDataAdapter(P_Str_Sqlstr, myConn);
        DataSet ds = new DataSet();
        da.Fill(ds, "Area");
        ddlName.DataSource = ds.Tables["Area"].DefaultView;
        ddlName.DataTextField = ds.Tables["Area"].Columns[1].ToString();
        ddlName.DataValueField = ds.Tables["Area"].Columns[2].ToString();
        ddlName.DataBind();
    }
    public void ddlShipBind(DropDownList ddlName)
    {
        SqlConnection myConn = dbObj.GetConnection();
        string P_Str_Sqlstr = "select * from ShipType";
        SqlDataAdapter da = new SqlDataAdapter(P_Str_Sqlstr, myConn);
        DataSet ds = new DataSet();
        da.Fill(ds, "Ship");
        ddlName.DataSource = ds.Tables["Ship"].DefaultView;
        ddlName.DataTextField = ds.Tables["Ship"].Columns[1].ToString();
        ddlName.DataValueField = ds.Tables["Ship"].Columns[0].ToString();
        ddlName.DataBind();
    }
    public void ddlPayBind(DropDownList ddlName)
    {
        SqlConnection myConn = dbObj.GetConnection();
        string P_Str_Sqlstr = "select * from PayType";
        SqlDataAdapter da = new SqlDataAdapter(P_Str_Sqlstr, myConn);
        DataSet ds = new DataSet();
        da.Fill(ds, "Pay");
        ddlName.DataSource = ds.Tables["Pay"].DefaultView;
        ddlName.DataTextField = ds.Tables["Pay"].Columns[1].ToString();
        ddlName.DataValueField = ds.Tables["Pay"].Columns[0].ToString();
        ddlName.DataBind();
    }
    public int AddOrderInfo(float P_Flt_BookFee, float P_Flt_ShipFee, int P_Int_ShipType, int P_Int_PayType, int P_Int_MemberID, string P_Str_RName, string P_Str_RPhone, string P_Str_RPostCode, string P_Str_RAddress, string P_Str_REmails)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_InsertOrderInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;

        //添加参数
        SqlParameter BookFee = new SqlParameter("@BookFee", SqlDbType.Float, 8);
        BookFee.Value = P_Flt_BookFee;
        myCmd.Parameters.Add(BookFee);

        SqlParameter ShipFee = new SqlParameter("@ShipFee", SqlDbType.Float, 8);
        ShipFee.Value = P_Flt_ShipFee;
        myCmd.Parameters.Add(ShipFee);

        SqlParameter ShipType = new SqlParameter("@ShipType", SqlDbType.Int, 4);
        ShipType.Value = P_Int_ShipType;
        myCmd.Parameters.Add(ShipType);

        SqlParameter PayType = new SqlParameter("@PayType", SqlDbType.Int, 4);
        PayType.Value = P_Int_PayType;
        myCmd.Parameters.Add(PayType);

        SqlParameter MemberID = new SqlParameter("@MemberID ", SqlDbType.BigInt, 8);
        MemberID.Value = P_Int_MemberID;
        myCmd.Parameters.Add(MemberID);

        SqlParameter RName = new SqlParameter("@RName", SqlDbType.VarChar, 50);
        RName.Value = P_Str_RName;
        myCmd.Parameters.Add(RName);

        SqlParameter RPhone = new SqlParameter("@RPhone", SqlDbType.VarChar, 50);
        RPhone.Value = P_Str_RPhone;
        myCmd.Parameters.Add(RPhone);

        SqlParameter RPostCode = new SqlParameter("@RPostCode", SqlDbType.Char, 10);
        RPostCode.Value = P_Str_RPostCode;
        myCmd.Parameters.Add(RPostCode);

        SqlParameter RAddress = new SqlParameter("@RAddress", SqlDbType.VarChar, 200);
        RAddress.Value = P_Str_RAddress;
        myCmd.Parameters.Add(RAddress);

        SqlParameter REmails = new SqlParameter("@REmails", SqlDbType.VarChar, 50);
        REmails.Value = P_Str_REmails;
        myCmd.Parameters.Add(REmails);

        SqlParameter OrderID = myCmd.Parameters.Add("@OrderID", SqlDbType.BigInt, 8);
        OrderID.Direction = ParameterDirection.Output;

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
        return Convert.ToInt32(OrderID.Value);


    }
    public void AddBuyInfo(int P_Int_BookID, int P_Int_Num, int P_Int_OrderID, float P_Flt_SumPrice, int P_Int_MemberID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_InsertBuy", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter BookID = new SqlParameter("@BookID", SqlDbType.BigInt, 4);
        BookID.Value = P_Int_BookID;
        myCmd.Parameters.Add(BookID);

        SqlParameter Num = new SqlParameter("@Num", SqlDbType.Int, 4);
        Num.Value = P_Int_Num;
        myCmd.Parameters.Add(Num);

        SqlParameter OrderID = new SqlParameter("@OrderID", SqlDbType.BigInt, 8);
        OrderID.Value = P_Int_OrderID;
        myCmd.Parameters.Add(OrderID);

        SqlParameter SumPrice = new SqlParameter("@SumPrice", SqlDbType.Float, 8);
        SumPrice.Value = P_Flt_SumPrice;
        myCmd.Parameters.Add(SumPrice);

        SqlParameter MemberID = new SqlParameter("@MemberID ", SqlDbType.BigInt, 8);
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
    /// 查询购物车中的信息
    /// </summary>
    /// <param name="P_Int_MemberID">会员ID</param>
    /// <param name="P_Str_srcTable">信息表</param>
    /// <returns>返回购物车中的信息的数据集</returns>
    public DataSet ReturnSCDs(int P_Int_MemberID, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_GetSCI", myConn);
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
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;

    }
    /// <summary>
    /// 当购物车中的信息已生成订单后，删除购物车中的信息
    /// </summary>
    /// <param name="P_Int_MemberID">会员ID</param>
    public void DeleteSCInfo(int P_Int_MemberID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_DeleteSC", myConn);
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
    ///　获取运输费用
    /// </summary>
    /// <param name="P_Int_BookID">图书ID</param>
    /// <param name="P_Str_ShipWay">运输方式</param>
    /// <returns>返回运输费用</returns>
    public float GetSFValue(string P_Str_ShipWay)
    {

        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_BookSF", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数

        SqlParameter ShipWay = new SqlParameter("@ShipWay", SqlDbType.VarChar, 50);
        ShipWay.Value = P_Str_ShipWay;
        myCmd.Parameters.Add(ShipWay);

        SqlParameter returnValue = myCmd.Parameters.Add("returnvalue", SqlDbType.Float, 8);
        returnValue.Direction = ParameterDirection.ReturnValue;
        //执行过程
        myConn.Open();
        myCmd.ExecuteScalar();
        try
        {
            if (Convert.ToInt32(returnValue.Value) == 100)
                return 100;
            else
            {
                float P_Flt_SF = float.Parse(myCmd.ExecuteScalar().ToString());
                return P_Flt_SF;
            }

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
    /// 用会员卡结账时，对会员卡的修改
    /// </summary>
    /// <param name="P_Int_MemberID">会员ID</param>
    /// <param name="P_Flt_BookFee">图书总费用</param>
    /// <param name="P_Flt_ShipFee">运输费用</param>
    /// <returns>查看会员卡中的钱是否能购买图书</returns>
    public int IsUserCart(int P_Int_MemberID, float P_Flt_BookFee, float P_Flt_ShipFee)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Pr_IsUserCart", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter MemberID = new SqlParameter("@MemberID", SqlDbType.BigInt, 8);
        MemberID.Value = P_Int_MemberID;
        myCmd.Parameters.Add(MemberID);

        SqlParameter BookFee = new SqlParameter("@BookFee", SqlDbType.Float, 8);
        BookFee.Value = P_Flt_BookFee;
        myCmd.Parameters.Add(BookFee);

        SqlParameter ShipFee = new SqlParameter("@ShipFee", SqlDbType.Float, 8);
        ShipFee.Value = P_Flt_ShipFee;
        myCmd.Parameters.Add(ShipFee);

        SqlParameter returnValue = myCmd.Parameters.Add("returnvalue", SqlDbType.Float, 8);
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
        return int.Parse(returnValue.Value.ToString());

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