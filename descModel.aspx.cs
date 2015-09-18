using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class descModel : System.Web.UI.Page
{
    Operation operation = new Operation();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            DataSet ds = operation.SelectModel(Request.QueryString["id"].ToString());

            smmodelcode.Text = Request.QueryString["id"].ToString();

            txtTitle.Text = ds.Tables[0].Rows[0][1].ToString();

            txtDesc.Text = ds.Tables[0].Rows[0][2].ToString();

        }


    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        DateTime datetime = DateTime.Now;
        operation.UpdateModel(smmodelcode.Text.Trim(), txtTitle.Text.Trim(), txtDesc.Text.Trim(), datetime);
        WebMessageBox.Show("修改成功！","listModel.aspx");     //修改成功后关闭窗口
    }

    protected void BtnReturn_Click(object sender, EventArgs e)
    {
        WebMessageBox.Show("放弃修改！", "listModel.aspx");     //修改成功后关闭窗口
    }
}