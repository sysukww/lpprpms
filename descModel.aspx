<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"  AutoEventWireup="true" CodeFile="descModel.aspx.cs" Inherits="descModel" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="contentType1" >
        <div style="margin-bottom:10px;">&nbsp;模板详细</div>
        <hr style=" height:2px;border:none;border-top:2px solid #ff6a00;margin-bottom:30px;" />
        <table>
                <tr>
                    <td style="width: 100px; height: 30px; font-size:13px;">
                        模板编号：</td>
                    <td style="width: 205px; height: 30px">
                        <asp:Label ID="smmodelcode" runat="server" Width="361px"></asp:Label></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 30px; font-size:13px;">
                        模板名称：</td>
                    <td style="width: 205px; height: 30px">
                        <asp:TextBox ID="txtTitle" runat="server" Width="600px"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                                    ErrorMessage="* 必填项" ValidationGroup="ValidataGroup1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 85px; font-size:13px;">
                        模板内容：</td>
                    <td style="height: 85px;width:205px">
                        <asp:TextBox ID="txtDesc" runat="server" Height="250px" TextMode="MultiLine" Width="600px"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDesc"
                                    ErrorMessage="* 必填项" ValidationGroup="ValidataGroup1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 24px">
                    </td>
                    <td align="center" style="width: 205px; height: 24px">
                        &nbsp;
                        <asp:Button ID="ReturnBtn" runat="server" OnClick="BtnReturn_Click" Text="返回" />
                        <asp:Button ID="updateBtn" runat="server" OnClick="BtnUpdate_Click" Text="保存" ValidationGroup="ValidataGroup1"/>
                    </td>
                    <td style="width: 124px; height: 24px">
                    </td>
                    <td style="height: 24px">
                    </td>
                </tr>
            </table>
            <a href="javascript:go()"></a>
        </div>
</asp:Content>