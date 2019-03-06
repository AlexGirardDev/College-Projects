<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="issueinfo.aspx.cs" Inherits="BuggedOut.viewissue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="border: 6px solid #788083;" width="100%">
    <tr>
        <td align="center" class="issueHeader" height="30px" width="25%">
            Issue ID</td>
        <td align="center" class="issueHeader" height="30px" width="25%">
            Project Name</td>
        <td align="center" class="issueHeader" height="30px" width="25%">
            Created By</td>
        <td align="center" class="issueHeader" height="30px" width="25%">
            Assigned To</td>
    </tr>
    <tr>
        <td align="center" class="issueInfo" height="30px" width="25%">
            <asp:Label ID="lblIssueID" runat="server"></asp:Label>
        </td>
        <td align="center" class="issueInfo" height="30px" width="25%">
            <asp:DropDownList ID="drpLstProjName" runat="server">
                <asp:ListItem>Call Of Honor</asp:ListItem>
                <asp:ListItem>World Of Peacecraft</asp:ListItem>
                <asp:ListItem>Slightly Agitated Bovine</asp:ListItem>
                <asp:ListItem>CarCraft 4</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td align="center" class="issueInfo" height="30px" width="25%">
            <asp:Label ID="lblCreatedBy" runat="server"></asp:Label>
        </td>
        <td align="center" class="issueInfo" height="30px" width="25%">
            <asp:TextBox ID="txtAssignedTo" runat="server" MaxLength="30"></asp:TextBox>
        </td>
    </tr>
    </table>

    <table style="border: 6px solid #788083;" width="100%">
    <tr>
        <td align="center" class="issueHeader" width="20%">
            Category</td>
        <td align="center" class="issueHeader" width="20%">
            Status</td>
        <td align="center" class="issueHeader" width="20%">
            Priority</td>
        <td align="center" class="issueHeader" width="20%">
            Date Created</td>
        <td align="center" class="issueHeader" width="20%">
            Last Modified</td>
    </tr>
    <tr>
        <td align="center" class="issueInfo" height="30px" width="20%">
            <asp:DropDownList ID="drpLstCategory" runat="server">
                <asp:ListItem>Graphics</asp:ListItem>
                <asp:ListItem>Multiplayer</asp:ListItem>
                <asp:ListItem>Single Player</asp:ListItem>
                <asp:ListItem>Audio</asp:ListItem>
                <asp:ListItem>AI</asp:ListItem>
                <asp:ListItem>Physics</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td align="center" class="issueInfo" height="30px" width="20%">
            <asp:DropDownList ID="drpLstStatus" runat="server">
                <asp:ListItem>Open</asp:ListItem>
                <asp:ListItem>Acknowledged</asp:ListItem>
                <asp:ListItem>Resolved</asp:ListItem>
                <asp:ListItem>Closed</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td align="center" class="issueInfo" height="30px" width="20%">
            <asp:DropDownList ID="drpLstPriority" runat="server">
                <asp:ListItem Value="0">Low</asp:ListItem>
                <asp:ListItem Value="1">Normal</asp:ListItem>
                <asp:ListItem Value="2">High</asp:ListItem>
                <asp:ListItem Value="3">Urgent</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td align="center" class="issueInfo" height="30px" width="20%">
            <asp:Label ID="lblDateCreated" runat="server"></asp:Label>
        </td>
        <td align="center" class="issueInfo" height="30px" width="20%">
            <asp:Label ID="lblLastUpdate" runat="server"></asp:Label>
        </td>
    </tr>
    </table>
<table style="border: 6px solid #788083;" width="100%">
    <tr>
        <td align="center" class="issueHeader" height="30px" width="25%">
            Summary</td>
        <td align="left" class="issueInfo" height="30px" 
            style="width: 50%; padding-left: 2%;">
            <asp:TextBox ID="txtSummary" runat="server" MaxLength="64" 
                style="font-size: small; font-family: Arial, Helvetica, sans-serif" Width="98%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="center" class="issueHeader" height="30px" width="25%">
            Details<br />
            <br />
            <asp:Label ID="lblLengthError" runat="server" Font-Bold="False" 
                Font-Size="Small"></asp:Label>
        </td>
        <td align="left" class="issueInfo" height="30px" 
            style="width: 50%; padding-left: 2%;">
            <asp:TextBox ID="txtDetails" runat="server" MaxLength="255" Rows="5" 
                style="font-family: Arial, Helvetica, sans-serif; font-size: small" 
                TextMode="MultiLine" Width="98%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" class="issueFooter" colspan="2" height="45px" width="25%" 
            valign="middle">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="txtAssignedTo" 
                ErrorMessage="Assigned To contains invaild characters" Font-Bold="False" 
                ForeColor="White" ValidationExpression="^[A-Za-z0-9,._ \s]+$" 
                Display="Dynamic" Font-Size="Small"></asp:RegularExpressionValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                ControlToValidate="txtDetails" Display="Dynamic" 
                ErrorMessage="Details contains invalid characters" Font-Bold="False" 
                Font-Size="Small" ForeColor="White" 
                ValidationExpression="^[A-Za-z0-9,.\- \s]+$"></asp:RegularExpressionValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                ControlToValidate="txtSummary" Display="Dynamic" 
                ErrorMessage="Summary contains invalid characters" Font-Bold="False" 
                Font-Size="Small" ForeColor="White" ValidationExpression="^[A-Za-z0-9,._ \s]+$"></asp:RegularExpressionValidator>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtSummary" Display="Dynamic" 
                ErrorMessage="Summary required" Font-Size="Small" ForeColor="White"></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="cmdEditIssue" runat="server" CssClass="editButton" 
                Text="Update Issue" Font-Bold="True" onclick="cmdEditIssue_Click" 
                Width="123px" />
        </td>
    </tr>
</table>

    <br />
    <br />

    <asp:GridView ID="updateGridView" runat="server" AutoGenerateColumns="False" 
        BorderColor="#788083" BorderStyle="Solid" BorderWidth="6px" Width="100%" 
        BackColor="#D2B38C" 
        style="border-style: solid; border-width: 2px; border-color: black;">
        <Columns>
            <asp:BoundField DataField="updateDate" HeaderText="Date Modified" 
                SortExpression="updateDate">
            <HeaderStyle Width="25%" BackColor="#616171" BorderColor="Black" 
                BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" Font-Size="Large" 
                ForeColor="White" Height="30px" />
            <ItemStyle BorderColor="#2C2C2C" BorderStyle="Solid" BorderWidth="2px" 
                BackColor="#B5B5BE" ForeColor="Black" Height="25px" />
            </asp:BoundField>
            <asp:BoundField DataField="updatedField" HeaderText="Updated Field" 
                SortExpression="updatedField">
            <HeaderStyle Height="0px" Width="25%" BackColor="#616171" BorderColor="Black" 
                BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" Font-Overline="False" 
                Font-Size="Large" ForeColor="White" />
            <ItemStyle BorderColor="#2C2C2C" BorderStyle="Solid" BorderWidth="2px" 
                BackColor="#B5B5BE" ForeColor="Black" />
            </asp:BoundField>
            <asp:BoundField DataField="updateDescription" HeaderText="Change" 
                SortExpression="updateDescription">
            <HeaderStyle Height="0px" Width="50%" BackColor="#616171" BorderColor="Black" 
                BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" Font-Size="Large" 
                ForeColor="White" />
            <ItemStyle BorderColor="#2C2C2C" BorderStyle="Solid" BorderWidth="2px" 
                BackColor="#B5B5BE" ForeColor="Black" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    
</asp:Content>
