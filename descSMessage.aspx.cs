using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class descSMessage : System.Web.UI.Page
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
            txtSendTime.Text = ds.Tables[0].Rows[0][2].ToString();

            if (ds.Tables[0].Rows[0][3].ToString() == "0")
            {
                txtModel.Text = "没有使用短信模板";
            }
            else
            {
                int count = operation.SelectModel(ds.Tables[0].Rows[0][3].ToString()).Tables[0].Rows.Count;
                if (count != 0)     //检测是否有该模板，有则转化为相应模板名称，否则显示该模板已经过期
                {
                    txtModel.Text = operation.SelectModel(ds.Tables[0].Rows[0][3].ToString()).Tables[0].Rows[0][1].ToString();
                }
                else
                {
                    txtModel.Text = "该模板已被删除";
                }
            }
        }
    }


    protected void BtnClose_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Response.Write("<script language='javascript' type='text/javascript'>location.href='" + "listSMessage.aspx" + "'</script>");
        HttpContext.Current.Response.Write("<script>history.go(-1)</script>");
        HttpContext.Current.Response.End();
    }

}