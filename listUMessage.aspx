<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"  AutoEventWireup="true" CodeFile="listUMessage.aspx.cs" Inherits="listUMessage" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="contentType2">


    <div style="margin-bottom:10px;">&nbsp;草稿箱</div>
    <hr style=" height:2px;border:none;border-top:2px solid #ff6a00;margin-bottom:30px;" />

    <div id="list1" align="right">
        <asp:Label ID="lblPageSum" runat="server" Text="当前页为　1 / 10　页" style="font-size:15px;"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CellPadding="3" ForeColor="#333333" GridLines="None" Height="1px" OnPageIndexChanging="GridView1_PageIndexChanging"
            OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting"
            OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="800px" PageSize="7" DataKeyNames="smcode">
            <PagerSettings FirstPageText="首页" LastPageText="末页" Mode="NextPreviousFirstLast"
                NextPageText="下一页" PreviousPageText="上一页" />
            <EmptyDataRowStyle Font-Size="Smaller" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" Font-Size="Small" />
            <Columns>
                <asp:BoundField DataField="smcode" HeaderText="短信编号">
                    <ItemStyle Width="100px" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="receivername" HeaderText="接收人名称">
                    <ItemStyle  Width="100px" HorizontalAlign="Left" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="receivernumber" HeaderText="接收人手机">
                    <HeaderStyle Width="110px" HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left"  Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="smcontent" HeaderText="短信内容">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left"   />
                </asp:BoundField>
                <asp:BoundField DataField="operatetimeforhis" HeaderText="更新时间">
                    <ItemStyle Width="90px" HorizontalAlign="Left" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:CommandField HeaderText="详细信息" SelectText="详细" ShowSelectButton="True">
                    <ItemStyle HorizontalAlign="Center" Width="90px" />
                </asp:CommandField>
                <asp:CommandField HeaderText="删除信息" ShowDeleteButton="True">
                    <ItemStyle HorizontalAlign="Center" Width="90px" />
                </asp:CommandField>
            </Columns>
            <RowStyle BackColor="#E3EAEB" Font-Size="Smaller" />
            <EditRowStyle BackColor="#7C6F57" Font-Size="Smaller" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="False" ForeColor="#333333" Font-Size="Smaller" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Right" Font-Size="Smaller" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" Font-Size="Smaller" />
            <AlternatingRowStyle BackColor="White" Font-Size="Smaller" />
        </asp:GridView>
    </div>

    </div>
</asp:Content>

