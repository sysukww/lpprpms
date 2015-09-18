<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"  AutoEventWireup="true" CodeFile="listSMessage.aspx.cs" Inherits="listSMessage"  EnableEventValidation="false"  %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="contentType2">


    <div style="margin-bottom:10px;">&nbsp;统计报表</div>
    <hr style=" height:2px;border:none;border-top:2px solid #ff6a00;margin-bottom:30px;" />

        <asp:Panel ID="Panel1" runat="server" Height="27px" Width="769px" >
            开始日期：
            <asp:TextBox ID="txtStarttime" runat="server" Enabled="false"></asp:TextBox>
            <asp:ImageButton ID="BtnStarttime" ImageUrl="~/images/can.jpg" runat="server" OnClick="btnStarttime_Click"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtStarttime"
                                    ErrorMessage="开始时间不能为空" style="font-size:15px;" ValidationGroup="ValidataGroup1"></asp:RequiredFieldValidator>
            <div id="LayerCC1" style="left: 550px; width: 189px; top:600px; position: absolute; top: 55px;
                height: 191px; background-color: white" visible="false" runat="server">
                <asp:Calendar ID="CaleStarttime" runat="server" BackColor="White" BorderColor="#3366CC"
                    BorderWidth="1px" CellPadding="1" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399"
                    Height="200px" OnSelectionChanged="Calendar1_SelectionChanged" Width="220px">
                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                    <WeekendDayStyle BackColor="#CCCCFF" />
                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
                        Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                </asp:Calendar>
            </div>
            <br />
            结束日期：
            <asp:TextBox ID="txtEndtime" runat="server" Enabled="false"></asp:TextBox>
            <asp:ImageButton ID="BtnEndtime" runat="server" OnClick="btnEndtime_Click" ImageUrl="~/images/can.jpg" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEndtime"
                              ErrorMessage="结束时间不能为空" style="font-size:15px;" ValidationGroup="ValidataGroup1"></asp:RequiredFieldValidator>
            <div id="LayerCC2" style="left: 850px; width: 189px;top:300px; position: absolute; top: 55px;
                height: 191px; background-color: white" visible="false" runat="server">
                <asp:Calendar ID="CaleEndtime" runat="server" BackColor="White" BorderColor="#3366CC"
                    BorderWidth="1px" CellPadding="1" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399"
                    Height="200px" OnSelectionChanged="Calendar2_SelectionChanged" Width="220px">
                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                    <WeekendDayStyle BackColor="#CCCCFF" />
                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
                        Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                </asp:Calendar>
            </div>

            <asp:Button ID="BtnSearch" runat="server" OnClick="BtnSearch_Click" Text="查询" ValidationGroup="ValidataGroup1"/>
            <asp:Button ID="BtnExport" runat="server" OnClick="BtnExport_Click" Text="导出" ValidationGroup="ValidataGroup1"/>
        </asp:Panel>


    <asp:Panel ID="panel2" runat="server" Height="27px" Width="769px">

    </asp:Panel>




    <div id="list1" align="right">
        <asp:Label ID="lblPageSum" runat="server" Text="当前页为　1 / 10　页" style="font-size:15px;"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CellPadding="3" ForeColor="#333333" GridLines="None" Height="1px" OnPageIndexChanging="GridView1_PageIndexChanging"
            OnRowDataBound="GridView1_RowDataBound"
            OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="800px" PageSize="6" DataKeyNames="smcode">
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
                <asp:BoundField DataField="operatetimeforhis" HeaderText="发送时间">
                    <ItemStyle Width="90px" HorizontalAlign="Left" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:CommandField HeaderText="详细信息" SelectText="详细" ShowSelectButton="True">
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

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">

</asp:Content>


