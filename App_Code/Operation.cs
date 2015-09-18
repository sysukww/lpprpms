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

using System.Web.UI;

/// <summary>
/// Operation 平台业务流程类（封装所有业务方法）
/// 短信以及短信模板的增删查改以及分页显示的操作类
/// </summary>
public class Operation
{
    public Operation()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    DataBase data = new DataBase();


    
    #region  新增短信信息
    /// <summary>
    /// 新增短信信息
    /// </summary>
    /// <param name="smcode">短信编码</param>
    /// <param name="sendercode">短信发送人hr代码</param>
    /// <param name="sendtime">发送时间</param>
    /// <param name="smmodelcode">模板代码</param>
    /// <param name="smcontent">短信内容</param>
    /// <param name="receivernumber">短信接收号码</param>
    /// <param name="receivername">短信接收人</param>
    /// <param name="state">短信状态</param>
    /// <param name="operatetimeforhis">更改时间</param>
    public void InsertMessage(string smcode, string sendercode, DateTime sendtime, string smmodelcode, string smcontent, string receivernumber, string receivername, int state, DateTime operatetimeforhis)
    {
        SqlParameter[] parms ={ 
            data.MakeInParam("@smcode",SqlDbType.VarChar,50,smcode),
            data.MakeInParam("@sendercode",SqlDbType.VarChar,50,sendercode),
            data.MakeInParam("@sendtime",SqlDbType.DateTime,0,sendtime),
            data.MakeInParam("@smmodelcode",SqlDbType.VarChar,50,smmodelcode),    
            data.MakeInParam("@smcontent",SqlDbType.VarChar,-1,smcontent),
            data.MakeInParam("@receivernumber",SqlDbType.VarChar,20,receivernumber),
            data.MakeInParam("@receivername",SqlDbType.VarChar,20,receivername),
            data.MakeInParam("@state",SqlDbType.Int,0,state),
            data.MakeInParam("@operatetimeforhis", SqlDbType.DateTime, 0, operatetimeforhis )
        };
        int i = data.RunProc("INSERT INTO lpprpmssm (smcode, sendercode, sendtime, smmodelcode, smcontent, receivernumber, receivername, state, operatetimeforhis) VALUES (@smcode, @sendercode,@sendtime,@smmodelcode, @smcontent, @receivernumber, @receivername, @state, @operatetimeforhis)", parms);
    }
    #endregion

    #region  修改短信信息
    /// <summary>
    /// 修改短信信息
    /// 功能：能够修改短信的接收人号码、使用的模板编号、短信内容、接收人名称、发送时间以及状态
    /// </summary>
    /// <param name="smcode">短信编码</param>
    /// <param name="receivername">接收人名称</param>
    /// <param name="receivernumber">接收人号码</param>
    /// <param name="smmodelcode">短信模板编号</param>
    /// <param name="smcontent">短信内容</param>
    /// <param name="sendtime">发送时间</param>
    /// <param name="state">状态（存草稿与已发送两种状态）</param>
    /// <param name="operatetimeforhis">更改时间</param>
    public void UpdateMessage(string smcode, string receivernumber, string smmodelcode, string smcontent, string receivername, DateTime sendtime, int state, DateTime operatetimeforhis)
    {
        int i;

        i = data.RunProc("UPDATE lpprpmssm SET receivernumber = '" + receivernumber + "', smmodelcode = '" + smmodelcode + "', smcontent='" + smcontent + "', receivername='" + receivername + "', sendtime= '" + sendtime + "', state=" + state + ", operatetimeforhis='" + operatetimeforhis + "' WHERE (smcode = '" + smcode + "')");
    }
    #endregion

    #region  删除短信信息
    /// <summary>
    /// 删除指定编号的短信信息
    /// </summary>
    /// <param name="smcode">短信编号</param>
    public void DeleteMessage(string smcode)
    {
        int d = data.RunProc("Delete from lpprpmssm where smcode='" + smcode + "'");
    }

    #endregion

    #region  查询短信信息
    /// <summary>
    /// 按短信状态以及发送人代码查询短信
    /// </summary>
    /// <param name="sendercode">短信发送人hr代码</param>
    /// <param name="state">短信状态</param>
    /// <returns>返回查询结果DataSet数据集</returns>
    public DataSet SelectMessage(int state, string sendercode)
    {
        SqlParameter[] parms ={
            data.MakeInParam("@state", SqlDbType.Int, 0, state ),
            data.MakeInParam("@sendercode", SqlDbType.VarChar, 50, sendercode)};
        return data.RunProcReturn("SELECT smcode, sendercode, sendtime, smmodelcode, smcontent, receivernumber, receivername, state, operatetimeforhis FROM lpprpmssm where state=@state and sendercode=@sendercode ORDER BY operatetimeforhis DESC", parms, "lpprpmssm");
    }
    /// <summary>
    /// 按短信状态查询短信
    /// （在业务上是用于查询已发送短信）
    /// </summary>
    /// <param name="state">短信状态( 0 代表存草稿状态，1 代表已发送状态)</param>
    /// <returns>返回查询结果DataSet数据集</returns>
    public DataSet SelectMessage(int state )
    {
        SqlParameter[] parms ={ 
            data.MakeInParam("@state", SqlDbType.Int, 0, state)
        };
        return data.RunProcReturn("SELECT smcode, sendercode, sendtime, smmodelcode, smcontent, receivernumber, receivername, state, operatetimeforhis FROM lpprpmssm where state=@state ORDER BY sendtime DESC", parms, "lpprpmssm");
    }
    /// <summary>
    /// 按照短信编号查询短信
    /// </summary>
    /// <param name="smcode">短信编码</param>
    /// <returns>返回查询结果DataSet数据集</returns>
    public DataSet SelectMessage(string smcode)
    {
        SqlParameter[] parms ={ 
            data.MakeInParam("@smcode", SqlDbType.VarChar, 50, smcode)
        };
        return data.RunProcReturn("SELECT smcode, sendercode, sendtime, smmodelcode, smcontent, receivernumber, receivername, state, operatetimeforhis FROM lpprpmssm where smcode=@smcode", parms, "lpprpmssm");
    }

    /// <summary>
    /// 按照时间段查询短信
    /// </summary>
    /// <param name="starttime">查询的开始时间</param>
    /// <param name="endtime">查询的结束时间</param>
    /// <param name="state">状态</param>
    /// <returns>返回查询结果DataSet数据集</returns>
    public DataSet SelectMessage(DateTime starttime, DateTime endtime, int state)
    {
        SqlParameter[] parms ={ 
            data.MakeInParam("@starttime", SqlDbType.DateTime, 0, starttime),
            data.MakeInParam("@endtime", SqlDbType.DateTime, 0, endtime),
            data.MakeInParam("@state", SqlDbType.Int, 0, state)
        };
        return data.RunProcReturn("SELECT smcode, sendercode, sendtime, smmodelcode, smcontent, receivernumber, receivername, state, operatetimeforhis FROM lpprpmssm where sendtime between @starttime and @endtime and state = @state ORDER BY sendtime DESC", parms, "lpprpmssm");
    }

    /// <summary>
    /// 按照开始时间查询短信
    /// </summary>
    /// <param name="searchtime">查询的开始时间</param>
    /// <param name="state">状态</param>
    /// <param name="nullstate">null的状态</param>
    /// <returns>返回查询结果DataSet数据集</returns>
    public DataSet SelectMessage(DateTime searchtime,int state, int nullstate)
    {
        SqlParameter[] parms ={ 
            data.MakeInParam("@searchtime", SqlDbType.DateTime, 0, searchtime),
            data.MakeInParam("@state", SqlDbType.Int, 0, state)
        };
        if (nullstate == 0)
        {
            return data.RunProcReturn("SELECT smcode, sendercode, sendtime, smmodelcode, smcontent, receivernumber, receivername, state, operatetimeforhis FROM lpprpmssm where sendtime >= @searchtime and state = @state ORDER BY sendtime DESC", parms, "lpprpmssm");
        }
        else 
        {
            return data.RunProcReturn("SELECT smcode, sendercode, sendtime, smmodelcode, smcontent, receivernumber, receivername, state, operatetimeforhis FROM lpprpmssm where sendtime <= @searchtime and state = @state ORDER BY sendtime DESC", parms, "lpprpmssm");
        }
    }
    #endregion

    /**
     * 草稿箱业务模块
     */
     
    #region 新增短信模板

    /// <summary>
    /// 新增短信模板
    /// </summary>
    /// <param name="smmodelcode">模板编号</param>
    /// <param name="smmodelname">模板名称</param>
    /// <param name="smmodeldesc">模板内容</param>
    /// <param name="inserttimeforhis">模板新建时间</param>
    public void InsertModel(string smmodelcode, string smmodelname, string smmodeldesc, DateTime inserttimeforhis)
    {
        SqlParameter[] parms ={ 
            data.MakeInParam("@smmodelcode",SqlDbType.VarChar,50,smmodelcode),
            data.MakeInParam("@smmodelname",SqlDbType.VarChar,50,smmodelname),
            data.MakeInParam("@smmodeldesc",SqlDbType.VarChar,-1,smmodeldesc),
            data.MakeInParam("@inserttimeforhis",SqlDbType.VarChar,0,inserttimeforhis),
            data.MakeInParam("@operatetimeforhis",SqlDbType.VarChar,0,inserttimeforhis)      //模板新增时，插入时间与更新时间一样
        };
        int i = data.RunProc("INSERT INTO lpprpmsmodel (smmodelcode, smmodelname, smmodeldesc, inserttimeforhis, operatetimeforhis) VALUES (@smmodelcode, @smmodelname,@smmodeldesc,@inserttimeforhis,@operatetimeforhis)", parms);
    }
    #endregion

    #region  删除短信模板
    /// <summary>
    /// 删除模板信息
    /// </summary>
    /// <param name="smmodelcode">要删除模板的编号</param>
    public void DeleteModel(string smmodelcode)
    {
        int d = data.RunProc("Delete from lpprpmsmodel where smmodelcode='" + smmodelcode + "'");
    }
    #endregion

    #region  查询短信模板
    /// <summary>
    /// 显示所有的短信模板
    /// </summary>
    /// <returns>返回DataSet结果集</returns>
    public DataSet SelectModel()
    {
        return data.RunProcReturn("Select * from lpprpmsmodel order by smmodelname desc", "lpprpmsmodel");
    }
    /// <summary>
    /// 根据短信模板编号查询短信模板
    /// </summary>
    /// <param name="smmodelcode">短信模板编号</param>
    /// <returns>返回DataSet结果集</returns>
    public DataSet SelectModel(string smmodelcode)
    {
        return data.RunProcReturn("Select * from lpprpmsmodel where smmodelcode='" + smmodelcode + "'", "lpprpmsmodel");
    }

    #endregion

    #region  修改短信模板
    /// <summary>
    /// 修改短信模板
    /// </summary>
    /// <param name="smmodelcode">短信模板编号</param>
    /// <param name="smmodelname">短信模板名称</param>
    /// <param name="smmodeldesc">短信模板内容</param>
    /// <param name="operatetimeforhis">短信模板更新时间</param>
    public void UpdateModel(string smmodelcode, string smmodelname, string smmodeldesc, DateTime operatetimeforhis)
    {
        int i;

        i = data.RunProc("UPDATE lpprpmsmodel SET smmodelname = '" + smmodelname + "', smmodeldesc = '" + smmodeldesc + "', operatetimeforhis='" +operatetimeforhis+ "' WHERE (smmodelcode = '" + smmodelcode + "')");
    }
    #endregion

    #region  分页设置绑定（短信模板）
    /// <summary>
    /// 绑定DataList控件，并且设置分页
    /// </summary>
    /// <param name="infoKey">查询的关键字（如果为空，则查询所有）</param>
    /// <param name="currentPage">当前页</param>
    /// <param name="PageSize">每页显示数量</param>
    /// <returns>返回PagedDataSource对象</returns>
    public PagedDataSource PageDataListBind(string infoKey, int currentPage,int PageSize)
    {
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = SelectModel().Tables[0].DefaultView; //将查询结果绑定到分页数据源上。
        pds.AllowPaging = true;　　　　　　　　　　//允许分页
        pds.PageSize = PageSize;　　　　　　　　 　//设置每页显示的页数
        pds.CurrentPageIndex = currentPage - 1;　  //设置当前页
        return pds;
    }
    #endregion


    /**
     * 短信处理人管理
     */


    #region 发送人联系方式查询
    /// <summary>
    /// 绑定DataList控件，并且设置分页
    /// </summary>
    /// <param name="sendercode">发送人HR代码</param>
    /// <returns>返回string</returns>
    public DataSet SelectPhone(string sendercode)
    {
        SqlParameter[] parms ={ 
            data.MakeInParam("@sendercode",SqlDbType.VarChar,50,sendercode)};

        return data.RunProcReturn("select * from lpprpmssender where sendercode=@sendercode", parms, "lpprpmssender");
    }
    #endregion

}
