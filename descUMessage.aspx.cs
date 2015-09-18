using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class descUMessage : System.Web.UI.Page
{
    Operation operation = new Operation();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataSet ds = operation.SelectMessage(Request.QueryString["id"].ToString());     //根据短信编号查询短信
            
            txtID.Text = Request.QueryString["id"].ToString();
            txtLinkMan.Text = ds.Tables[0].Rows[0][6].ToString();
            txtPhone.Text = ds.Tables[0].Rows[0][5].ToString();
            txtInfo.Text = ds.Tables[0].Rows[0][4].ToString();
            txtSendMan.Text = ds.Tables[0].Rows[0][1].ToString();

            if (ds.Tables[0].Rows[0][3].ToString() == "0")
            {
                txtModel.Text = "";
            }
            else
            {
                int count = operation.SelectModel(ds.Tables[0].Rows[0][3].ToString()).Tables[0].Rows.Count;
                if (count != 0)     //检测是否有该模板，有则转化为相应模板名称，否则显示空
                {
                    txtModel.Text = operation.SelectModel(ds.Tables[0].Rows[0][3].ToString()).Tables[0].Rows[0][1].ToString();
                }
                else
                {
                    txtModel.Text = "";
                }
                
            }
            

            ds = operation.SelectModel();
            DropDownList1.DataSource = ds.Tables["lpprpmsmodel"].DefaultView;
            DropDownList1.DataValueField = ds.Tables["lpprpmsmodel"].Columns[0].ColumnName;
            DropDownList1.DataTextField = ds.Tables["lpprpmsmodel"].Columns[1].ColumnName;
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("<-- 请选择 -->", "0"));

            //DropDownList1.SelectedValue = ds.Tables[0].Rows[0][3].ToString();
            //DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByValue(ds.Tables[0].Rows[0][3].ToString()));
            //DropDownList1.Items.FindByValue(ds.Tables[0].Rows[0][3].ToString()).Selected = true;      
 
            //DropDownList1.SelectedValue = ds.Tables[0].Rows[0][3].ToString();
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

        WebMessageBox.Show("发送成功", "listUMessage.aspx?usercode=" + txtSendMan.Text.Trim());
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        DateTime opt = DateTime.Now;
        DataSet ds = new DataSet();
        ds = operation.SelectMessage(txtID.Text.Trim());     //查询在数据库中是否有过记录
        int count = ds.Tables["lpprpmssm"].Rows.Count;       //通过查询返回的记录数判断是否有过相同短信编码的记录


        if (count == 0)
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
        WebMessageBox.Show("放弃编辑！", "listUMessage.aspx?usercode=" + txtSendMan.Text.Trim());
    }

    protected void DDLChange_Click(object sender, EventArgs s)
    {

        //确定短信的前缀
        DataSet ds = operation.SelectPhone(txtSendMan.Text.ToString());
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

        //string smmodelcode = DropDownList1.Text.ToString();

        //DataSet ds = operation.SelectModel(smmodelcode);
        //txtInfo.Text = ds.Tables[0].Rows[0][2].ToString();

    }

}