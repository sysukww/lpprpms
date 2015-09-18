using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class createModel : System.Web.UI.Page
{

    Operation operation = new Operation();　//声明业务层类对象
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        DateTime datetime = DateTime.Now;

        string smmodelcode = datetime.Year.ToString() + datetime.Month.ToString() + datetime.Day.ToString() + datetime.Hour.ToString() + datetime.Minute.ToString()+ datetime.Second.ToString();
        operation.InsertModel(smmodelcode ,txtTitle.Text.Trim(), txtDesc.Text.Trim(), datetime );
        WebMessageBox.Show("模板保存成功！", "createModel.aspx");
    }

    protected void BtnClose_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Response.Write("<script language='javascript' type='text/javascript'>location.href='" + "createModel.aspx" + "'</script>");
        HttpContext.Current.Response.Write("<script>history.go(-1)</script>");
        HttpContext.Current.Response.End();
    } 
}