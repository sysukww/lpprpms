<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"  AutoEventWireup="true" CodeFile="createMessage.aspx.cs" Inherits="createMessage" %>

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
                            <td></td>
                            <td style="width: 336px" align="left">
                                <asp:TextBox ID="txtID" runat="server" style="width:560px;" Visible="false"></asp:TextBox></td>
                            <td style="width: 89px"></td>
                        </tr>
                        <tr>
                            <td style="width:100px; height: 24px;" align="right">
                                联系人号码：</td>
                            <td style="width: 336px; height: 24px;" align="left">
                                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPhone"
                                    ErrorMessage="格式：11位数字" ValidationExpression="\d{11}" ValidationGroup="ValidataGroup1"></asp:RegularExpressionValidator></td>  
                            <td style="width: 89px; height: 24px;">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPhone"
                                    ErrorMessage="* 必填项" ValidationGroup="ValidataGroup1"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 85px ;"align="right">
                                模板选择：</td>
                            <td style="width:336px;" align="left">
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="300px" OnSelectedIndexChanged="DDLChange_Click" AutoPostBack="true">
                                    <asp:ListItem>预备项目</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 89px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 85px;"align="right">
                                信息内容：</td>
                            <td style="width: 336px" align="left">
                                <asp:TextBox ID="txtInfo" runat="server" Height="250px" TextMode="MultiLine" Width="560px"></asp:TextBox></td>
                            <td style="width: 89px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtInfo"
                                    ErrorMessage="* 必填项" ValidationGroup="ValidataGroup1"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 85px" align="right">
                                联系人：</td>
                            <td style="width: 336px" align="left">
                                <asp:TextBox ID="txtLinkMan" runat="server"></asp:TextBox></td>
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
                            <td style="width: 85px; height: 20px">
                            </td>
                            <td style="width: 336px; height: 20px">
                            </td>
                            <td style="width: 89px; height: 20px">
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="sendBtn" runat="server" text="发送" OnClick="BtnSend_Click" ValidationGroup="ValidataGroup1"/>
                    <asp:Button ID="saveBtn" runat="server" text="保存" OnClick="BtnSave_Click" />
                    <asp:Button ID="closeBtn" runat="server" text="重置" OnClick="BtnClose_Click" />
                    &nbsp;
                    <asp:Label ID="saveLbl" runat="server" Text="" style="font-size:15px; color:red;"></asp:Label>
                </td>
                </tr>
                <tr>
                   <td height="2">
                   </td>
                </tr>
            </table>
    </div>
</asp:Content>

