<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="viewissues.aspx.cs" Inherits="BuggedOut.viewissues" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style3
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="issueID" PageSize="30" Width="100%">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="issueID" 
                DataNavigateUrlFormatString="issueinfo.aspx?issueID={0}" 
                DataTextField="issueID" HeaderText="Issue ID" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="issueTitle" HeaderText="Issue Title" 
                SortExpression="issueTitle">
            <ItemStyle Width="25%" />
            </asp:BoundField>
            <asp:BoundField DataField="projectName" HeaderText="Project Name" 
                SortExpression="projectName">
            </asp:BoundField>
            <asp:BoundField DataField="category" HeaderText="Category" 
                SortExpression="category" />
            <asp:BoundField DataField="priority" HeaderText="Priority" 
                SortExpression="priority" />
            <asp:BoundField DataField="status" HeaderText="Status" 
                SortExpression="status" />
        </Columns>
        <EditRowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" />
        <HeaderStyle BackColor="#63636E" BorderColor="Black" BorderStyle="Solid" 
            BorderWidth="2px" ForeColor="White" Font-Size="Medium" Height="35px" />
        <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" 
            Font-Bold="True" ForeColor="Black" Height="30px" />
    </asp:GridView>

    <br />
    <table class="style3" style="font-weight: bold; font-size: medium">
        <tr>
            <td style="border-style: solid; border-width: 2px; border-color: black; padding: 5px; color: black" 
                align="center" bgcolor="#D45354" width="25%">
                Open</td>
            <td style="border-style: solid; border-width: 2px; border-color: black; padding: 5px; color: black" 
                align="center" bgcolor="#2FCAD8" width="25%">
                Acknowledged</td>
            <td style="border-style: solid; border-width: 2px; border-color: black; padding: 5px; color: black" 
                align="center" bgcolor="#A9DC3A" width="25%">
                Resolved</td>
            <td style="border-style: solid; border-width: 2px; border-color: black; padding: 5px; color: black" 
                align="center" bgcolor="#818B85" width="25%">
                Closed</td>
        </tr>
    </table>

</asp:Content>
