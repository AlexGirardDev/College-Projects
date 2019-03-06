<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="BuggedOut.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style3
        {
            width: 100%;
        }
        .style4
        {
            height: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 100%">
        <table class="style3">
            <tr style="vertical-align: top">
                <td width="45%">
                    <table class="style3" cellspacing="0">
                        <tr>
                            <td class="style4" width="45%" align="center" valign="middle" 
                    style="background-color: #666672; font-size: medium; color: #E4E4E4; font-weight: bold; border-width: 2px 2px 0px 2px; border-style: solid; border-color: black">
                                Your Issues</td>
                        </tr>
                        <tr>
                            <td width="45%" align="center" style="border: 2px solid black" 
                    bgcolor="#A9A9B0">
                    <asp:GridView ID="gridViewYourIssues" runat="server" Height="100%" Width="100%" 
                                    AutoGenerateColumns="False" DataKeyNames="issueID">
                        <Columns>
                            <asp:HyperLinkField DataNavigateUrlFields="issueID" 
                                DataNavigateUrlFormatString="issueinfo.aspx?issueID={0}" 
                                DataTextField="issueID" HeaderText="Issue ID">
                            <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" 
                                Font-Bold="True" ForeColor="#2C2C2C" Width="35%" />
                            <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" 
                                ForeColor="#5C91DE" HorizontalAlign="Center" />
                            </asp:HyperLinkField>
                            <asp:BoundField DataField="issueTitle" HeaderText="Issue Title" 
                                SortExpression="issueTitle">
                            <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" 
                                Font-Bold="True" ForeColor="#2C2C2C" Width="65%" />
                            <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" 
                                ForeColor="White" Height="20px" />
                            </asp:BoundField>
                        </Columns>
                        <RowStyle ForeColor="Black" />
                    </asp:GridView>
                    <asp:Label ID="lblNotFound" runat="server" Font-Bold="True" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="10%">
                    &nbsp;</td>
                <td width="45%" valign="top">
                    <table class="style3" cellspacing="0">
                        <tr>
                            <td class="style4" width="45%" align="center" valign="middle" 
                    style="background-color: #666672; font-size: medium; color: #E4E4E4; font-weight: bold; border-width: 2px 2px 0px 2px; border-style: solid; border-color: black">
                                Recently Updated</td>
                        </tr>
                        <tr>
                            <td width="45%" align="center" style="border: 2px solid black" 
                    bgcolor="#A9A9B0">
                    <asp:GridView ID="gridViewRecentUpdates" runat="server" Height="100%" Width="100%" 
                                    AutoGenerateColumns="False" DataKeyNames="issueID">
                        <Columns>
                            <asp:HyperLinkField DataNavigateUrlFields="issueID" 
                                DataNavigateUrlFormatString="issueinfo.aspx?issueID={0}" 
                                DataTextField="issueID" HeaderText="Issue ID">
                            <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" 
                                Font-Bold="True" ForeColor="#2C2C2C" Width="25%" />
                            <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" 
                                ForeColor="#478ADC" Height="20px" HorizontalAlign="Center" />
                            </asp:HyperLinkField>
                            <asp:BoundField DataField="issueTitle" HeaderText="Issue Title" 
                                SortExpression="issueTitle">
                            <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" 
                                Font-Bold="True" ForeColor="#2C2C2C" Width="65%" />
                            <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" 
                                ForeColor="White" Height="20px" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
