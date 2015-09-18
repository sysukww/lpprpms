using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class listSMessage : System.Web.UI.Page
{
    Operation operation = new Operation(); //业务类对象

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            GridViewBind();
        }
    }

    /// <summary>
    /// 绑定未发送短信到GridViev控件
    /// </summary>
    private void GridViewBind()
    {
        if (txtEndtime.Text.ToString() == "" || txtStarttime.Text.ToString() == "")
        {
            GridView1.DataSource = operation.SelectMessage(1);
            GridView1.DataBind();
            lblPageSum.Text = "当前页为　" + (GridView1.PageIndex + 1) + " / " + GridView1.PageCount + "　页";
        }
        else
        {
            string[] st = txtStarttime.Text.ToString().Split('-');
            string[] et = txtEndtime.Text.ToString().Split('-');

            DateTime starttime = new DateTime(Convert.ToInt32(st[0]), Convert.ToInt32(st[1]), Convert.ToInt32(st[2]));
            DateTime tempendtime = new DateTime(Convert.ToInt32(et[0]), Convert.ToInt32(et[1]), Convert.ToInt32(et[2]));
            DateTime endtime = tempendtime.AddDays(1);
           

            GridView1.DataSource = operation.SelectMessage(starttime, endtime, 1);
            GridView1.DataBind();
            //显示当前页数
            lblPageSum.Text = "当前页为　" + (GridView1.PageIndex + 1) + " / " + GridView1.PageCount + "　页";
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //高亮显示指定行
            e.Row.Attributes.Add("onMouseOver", "Color=this.style.backgroundColor;this.style.backgroundColor='#FFF000'");
            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=Color;");
            //多余字　使用...显示
            e.Row.Cells[3].Text = StringFormat.Out(e.Row.Cells[3].Text, 18);

        }
    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string id = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();
        Response.Write("<script>location.href='descSMessage.aspx?id=" + id + "'</script>");
        //Response.Write("<script>history.go(-1)</script>");
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridViewBind();
    }



    protected void btnStarttime_Click(object sender, EventArgs e)
    {
        LayerCC1.Visible = !LayerCC1.Visible;

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txtStarttime.Text = CaleStarttime.SelectedDate.ToString("yyyy-MM-dd");
        LayerCC1.Visible = false;
    }

    protected void btnEndtime_Click(object sender, EventArgs e)
    {
        LayerCC2.Visible = !LayerCC2.Visible;

    }
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        txtEndtime.Text = CaleEndtime.SelectedDate.ToString("yyyy-MM-dd");
        LayerCC2.Visible = false;
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        GridViewBind();
    }

    protected void BtnExport_Click(object sender, EventArgs e)
    {
        string[] st = txtStarttime.Text.ToString().Split('-');
        string[] et = txtEndtime.Text.ToString().Split('-');

        DateTime starttime = new DateTime(Convert.ToInt32(st[0]), Convert.ToInt32(st[1]), Convert.ToInt32(st[2]));
        DateTime tempendtime = new DateTime(Convert.ToInt32(et[0]), Convert.ToInt32(et[1]), Convert.ToInt32(et[2]));
        DateTime endtime = tempendtime.AddDays(1);

        DataSet ds = new DataSet();
        ds = operation.SelectMessage(starttime, endtime, 1);
        ds.Tables[0].Columns.Remove("smmodelcode");
        ds.Tables[0].Columns.Remove("state");
        ds.Tables[0].Columns.Remove("operatetimeforhis");

        ds.Tables[0].Columns[0].ColumnName = "短信编号";
        ds.Tables[0].Columns[1].ColumnName = "发送人";
        ds.Tables[0].Columns[2].ColumnName = "发送时间";
        ds.Tables[0].Columns[3].ColumnName = "短信内容";
        ds.Tables[0].Columns[4].ColumnName = "接收号码";
        ds.Tables[0].Columns[5].ColumnName = "接收人";

        DateTime dt = DateTime.Now;
        string dts = dt.Year.ToString() + dt.Month.ToString() + dt.Day.ToString() + dt.Hour.ToString() + dt.Minute.ToString() + dt.Second.ToString() + ".xls";
        ExportResult(ds, dts );
    }

    public void ExportResult(DataSet ds,string excelName)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Charset = "";
        HttpContext.Current.Response.ContentType = "application/vnd.ms-xls";
        StringWriter stringWrite = new StringWriter();
        HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        DataGrid dg = new DataGrid();
        dg.DataSource = ds;
        dg.DataBind();
        dg.RenderControl(htmlWrite);
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(excelName));
　　　　HttpContext.Current.Response.Write(stringWrite.ToString());
        HttpContext.Current.Response.End();
    }

}