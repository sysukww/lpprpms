<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"  AutoEventWireup="true" CodeFile="descSMessage.aspx.cs" Inherits="descSMessage"%>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1">
    <div></div>
    <div id="contentType1">
        <table>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td>
                    <table class="txt">
                        <tr>
                            <td style="width: 85px" align="right">
                                短信编号：</td>
                            <td style="width: 336px" align="left">
                                <asp:Label ID="txtID" runat="server"></asp:Label></td>
                            <td style="width: 89px"></td>
                        </tr>
                        <tr>
                            <td style="width:100px; height: 24px;" align="right">
                                联系人号码：</td>
                            <td style="width: 336px; height: 24px;" align="left">
                                <asp:Label ID="txtPhone" runat="server"></asp:Label></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td style="width: 85px" align="right">
                                已选模板：</td>
                            <td style="width: 336px" align="left">
                                <asp:Label ID="txtModel" runat="server" style="width:300px;"></asp:Label></td>
                            <td style="width: 89px"></td>
                        </tr>
                        <tr>
                            <td style="width: 85px;"align="right">
                                信息内容：</td>
                            <td style="width: 336px" align="left">
                                <asp:TextBox ID="txtInfo" runat="server" Height="250px" TextMode="MultiLine" Width="530px"></asp:TextBox></td>
                            <td style="width: 89px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 85px" align="right">
                                联系人：</td>
                            <td style="width: 336px" align="left">
                                <asp:Label ID="txtLinkMan" runat="server"></asp:Label></td>
                            <td style="width: 89px"></td>
                        </tr>
                        <tr>
                            <td style="width: 85px; height: 24px;" align="right">
                                发送人：</td>
                            <td style="width: 336px; height: 24px;" align="left">
                                <asp:Label ID="txtSendMan" runat="server" Text="发送人"></asp:Label></td>
                            <td style="width: 89px; height: 24px;"></td>
                        </tr>
                        <tr>
                            <td style="width: 85px; height: 24px;" align="right">
                                发送时间：</td>
                            <td style="width: 336px; height: 24px;" align="left">
                                <asp:Label ID="txtSendTime" runat="server" Text="发送时间"></asp:Label></td>
                            <td style="width: 89px; height: 24px;"></td>
                        </tr>
                        <tr>
                            <td style="width: 85px; height: 5px">
                            </td>
                            <td style="width: 336px; height: 5px">
                            </td>
                            <td style="width: 89px; height: 5px">
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="closeBtn" runat="server" text="关闭" OnClick="BtnClose_Click" />
                </td>
                </tr>
                <tr>
                   <td height="2">
                   </td>
                </tr>
            </table>
    </div>
</asp:Content>

