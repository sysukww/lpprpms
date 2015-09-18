<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"  AutoEventWireup="true" CodeFile="createModel.aspx.cs" Inherits="createModel" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="contentType1" >
        <div style="margin-bottom:10px;">&nbsp;模板新增</div>
        <hr style=" height:2px;border:none;border-top:2px solid #ff6a00;margin-bottom:30px;" />
        <table>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td>
                    <table class="txt">
                        <tr>
                            <td style="width: 85px" align="right">
                                标题：</td>
                            <td style="width: 336px" align="left">
                                <asp:TextBox ID="txtTitle" runat="server" style="width:600px"></asp:TextBox></td>
                            <td style="width: 89px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                                    ErrorMessage="* 必填项"  ValidationGroup="ValidataGroup1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 85px;"align="right">
                                内容：</td>
                            <td style="width: 336px" align="left">
                                <asp:TextBox ID="txtDesc" runat="server" Height="250px" TextMode="MultiLine" Width="600px"></asp:TextBox></td>
                            <td style="width: 89px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDesc"
                                    ErrorMessage="* 必填项"  ValidationGroup="ValidataGroup1"></asp:RequiredFieldValidator></td>
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
                    <div style="background-color:#bec0c4; padding:10px;">
                    <asp:Button ID="saveBtn" runat="server" text="保存" OnClick="BtnSave_Click"  ValidationGroup="ValidataGroup1"/>
                    <asp:Button ID="closeBtn" runat="server" text="重置" OnClick="BtnClose_Click"/>
                    </div>
                </td>
                </tr>
                <tr>
                   <td height="2">
                   </td>
                </tr>
            </table>
    </div>
</asp:Content>

