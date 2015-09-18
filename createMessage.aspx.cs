using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services.Protocols;


public partial class createMessage : System.Web.UI.Page
{
    Operation operation = new Operation();
    DateTime dt = DateTime.Now;

    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!Page.IsPostBack)
        {
           txtID.Text = dt.Year.ToString() + dt.Month.ToString() + dt.Day.ToString() + dt.Hour.ToString() + dt.Minute.ToString() + dt.Second.ToString();
           txtSendMan.Text = Request.QueryString["usercode"].ToString();
           
           DataSet ds = new DataSet();
           ds = operation.SelectModel();
           DropDownList1.DataSource = ds.Tables["lpprpmsmodel"].DefaultView;
           DropDownList1.DataValueField = ds.Tables["lpprpmsmodel"].Columns[0].ColumnName;
           DropDownList1.DataTextField = ds.Tables["lpprpmsmodel"].Columns[1].ColumnName;
           DropDownList1.DataBind();
           DropDownList1.Items.Insert(0, new ListItem("<-- 请选择 -->", "0"));


        }
    }

    protected void BtnSend_Click(object sender, EventArgs e)
    {
        DateTime opt = DateTime.Now;
        DataSet ds = new DataSet();

        ds = operation.SelectMessage(txtID.Text.Trim());     //查询在数据库中是否有过记录
        int count = ds.Tables["lpprpmssm"].Rows.Count;       //通过查询返回的记录数判断是否有过相同短信编码的记录


        if (count == 0)
        {
            operation.InsertMessage(txtID.Text.Trim(), txtSendMan.Text.Trim(), opt, DropDownList1.Text.ToString(), txtInfo.Text.Trim(), txtPhone.Text.Trim(), txtLinkMan.Text.Trim(), 1, opt);
        }
        else
        {
            operation.UpdateMessage(txtID.Text.Trim(), txtPhone.Text.Trim(), DropDownList1.Text.ToString(), txtInfo.Text.Trim(), txtLinkMan.Text.Trim(), opt, 1, opt);
        } 


        //发送短信
        string[] phoneArray = new string[1];
        phoneArray[0] = txtPhone.Text.ToString();
        SMService.SMsgService sm = new SMService.SMsgService();
        sm.sendSM("isp", "isp", "pIcc4404", phoneArray, txtInfo.Text.ToString(), 0);

        WebMessageBox.Show("发送成功", "createMessage.aspx?usercode=" + Request.QueryString["usercode"].ToString());
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        
        
        DateTime opt = DateTime.Now; 
        DataSet ds = new DataSet();
        ds = operation.SelectMessage(txtID.Text.Trim());     //查询在数据库中是否有过记录
        int count = ds.Tables["lpprpmssm"].Rows.Count;       //通过查询返回的记录数判断是否有过相同短信编码的记录
        

        if ( count == 0 )
        {
            operation.InsertMessage(txtID.Text.Trim(), txtSendMan.Text.Trim(), opt, DropDownList1.Text.ToString(), txtInfo.Text.Trim(), txtPhone.Text.Trim(), txtLinkMan.Text.Trim(), 0, opt);
        }
        else
        {
            operation.UpdateMessage(txtID.Text.Trim(), txtPhone.Text.Trim(), DropDownList1.Text.ToString(), txtInfo.Text.Trim(), txtLinkMan.Text.Trim(), opt, 0, opt);
        }

        saveLbl.Text = "已保存";
        

    }

    protected void BtnClose_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Response.Write("<script language='javascript' type='text/javascript'>location.href='" + "createMessage.aspx?usercode=" + Request.QueryString["usercode"].ToString() + "'</script>");
        HttpContext.Current.Response.Write("<script>history.go(-1)</script>");
        HttpContext.Current.Response.End();
    }

    protected void DDLChange_Click(object sender, EventArgs s)
    {

        //确定短信的前缀
        DataSet ds = operation.SelectPhone(Request.QueryString["usercode"].ToString());
        int searchnum = ds.Tables["lpprpmssender"].Rows.Count;
        string username;                         //前缀中的名字
        string userphone;                        //前缀中的电话号码
        if (searchnum != 0)
        {
            username = ds.Tables["lpprpmssender"].Rows[0][1].ToString();
            userphone = ds.Tables["lpprpmssender"].Rows[0][2].ToString();
        }
        else
        {
            username = "";
            userphone = "";
        }
        string smprefix = "尊敬的客户，您好！您的报案我司已接收，请按以下清单准备资料，如有任何问题，请直接联系：" + 
            username + "，联系电话：" + userphone + "。\n";
        string smmodelcode = DropDownList1.Text.ToString();


        if (DropDownList1.SelectedIndex == 0)
        {
            txtInfo.Text = smprefix;
        }
        else
        {
            DataSet ds1 = operation.SelectModel(smmodelcode);
            //DataSet ds1 = operation.SelectPhone(txtSendMan.Text.ToString());
            //string name = ds1.Tables[0].Rows[0][0].ToString();
            //string number = ds1.Tables[0].Rows[0][1].ToString();

            txtInfo.Text = smprefix + ds1.Tables[0].Rows[0][2].ToString();
        }
    }

}