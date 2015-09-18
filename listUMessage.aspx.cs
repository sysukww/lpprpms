﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class listUMessage : System.Web.UI.Page
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
        string ucode = Request.QueryString["usercode"].ToString();                     //获取相应的用户代码
        GridView1.DataSource = operation.SelectMessage(0, ucode);
        GridView1.DataBind();
        //显示当前页数
        lblPageSum.Text = "当前页为　" + (GridView1.PageIndex + 1) + " / " + GridView1.PageCount + "　页";
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
            //删除指定行数据时，弹出询问对话框
            ((LinkButton)(e.Row.Cells[6].Controls[0])).Attributes.Add("onclick", "return confirm('是否删除当前行数据！')");
        }
    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string id = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();
        Response.Write("<script>location.href='descUMessage.aspx?id=" + id + "'</script>");
        //Response.Write("<script>history.go(-1)</script>");
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridViewBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        operation.DeleteMessage(GridView1.DataKeys[e.RowIndex].Value.ToString());
       //WebMessageBox.Show(GridView1.DataKeys[e.RowIndex].Value.ToString());
        GridViewBind();
    }
}