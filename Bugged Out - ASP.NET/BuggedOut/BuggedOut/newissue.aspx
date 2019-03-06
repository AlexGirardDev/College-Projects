<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="newissue.aspx.cs" Inherits="BuggedOut.newissue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style3
        {
            width: 100%;
        }
        .style4
        {
            width: 747px;
        }
        .style10
        {
            width: 307px;
            border: solid 2px black;
        }
        .style12
        {
            width: 508px;
            height: 26px;
            border: solid 2px black;
        }
        .style13
        {
            width: 307px;
            height: 26px;
        }
        .style14
        {
            height: 26px;
            border: solid 2px black;
        }
        .style15
        {
            width: 508px;
            border: solid 2px black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style3" style="border-collapse: collapse">
        <tr>
            <td class="style15" bgcolor="#666672" style="padding: 5px">
        <asp:Label ID="Label2" runat="server" Text="Project Name" CssClass="headings" 
                    style="color: #FFFFFF" EnableTheming="True"></asp:Label>
            &nbsp;
                <asp:Label ID="lblProjNameError" runat="server" 
                    ForeColor="#FF5959"></asp:Label>
            </td>
            <td class="style10" bgcolor="#666672" style="padding: 5px">
        <asp:Label ID="Label5" runat="server" Text="Category" CssClass="headings" 
                    style="color: #FFFFFF" EnableTheming="True"></asp:Label>
            &nbsp;
                <asp:Label ID="lblCategoryError" runat="server" ForeColor="#FF5959"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style12" bgcolor="#A9A9B0" style="padding: 10px">
            <asp:DropDownList ID="drpLstProjName" runat="server" Height="27px" Width="417px">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Call Of Honor</asp:ListItem>
                <asp:ListItem>World Of Peacecraft</asp:ListItem>
                <asp:ListItem>Slightly Agitated Bovine</asp:ListItem>
                <asp:ListItem>CarCraft 4</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td class="style13" bgcolor="#A9A9B0" style="padding: 10px">
            <asp:DropDownList ID="drpLstCategory" runat="server" Height="27px" Width="305px">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Graphics</asp:ListItem>
                <asp:ListItem>Multiplayer</asp:ListItem>
                <asp:ListItem>Single Player</asp:ListItem>
                <asp:ListItem>Audio</asp:ListItem>
                <asp:ListItem>AI</asp:ListItem>
                <asp:ListItem>Physics</asp:ListItem>
            </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style15" bgcolor="#666672" style="padding: 5px">
        <asp:Label ID="Label3" runat="server" Text="Created By  " CssClass="headings" 
                    style="color: #FFFFFF"></asp:Label>
            &nbsp;
                <asp:RequiredFieldValidator ID="createByRequiredFieldValidator" runat="server" 
                    ControlToValidate="txtCreatedBy" ErrorMessage="Please enter your name" 
                    ForeColor="#FF5959" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                    ControlToValidate="txtCreatedBy" Display="Dynamic" 
                    ErrorMessage="Created by contains invalid characters" ForeColor="#FF5959" 
                    ValidationExpression="^[A-Za-z]+$"></asp:RegularExpressionValidator>
            </td>
            <td class="style10" bgcolor="#666672" style="padding: 5px">
        <asp:Label ID="Label7" runat="server" Text="Status" CssClass="headings" 
                    style="color: #FFFFFF" EnableTheming="True"></asp:Label>
            &nbsp;
                <asp:Label ID="lblStatusError" runat="server" 
                    ForeColor="#FF5959"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style15" bgcolor="#A9A9B0" style="padding: 10px">
        <asp:TextBox ID="txtCreatedBy" runat="server" height="22px" width="409px" 
                    MaxLength="30"></asp:TextBox>
            </td>
            <td class="style10" bgcolor="#A9A9B0" style="padding: 10px">
            <asp:DropDownList ID="drpLstStatus" runat="server" Width="305px" height="27px">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Open</asp:ListItem>
                <asp:ListItem>Acknowledged</asp:ListItem>
                <asp:ListItem>Resolved</asp:ListItem>
                <asp:ListItem>Closed</asp:ListItem>
            </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style15" bgcolor="#666672">
        <asp:Label ID="Label4" runat="server" Text="Assigned To" CssClass="headings" 
                    style="color: #FFFFFF" EnableTheming="True"></asp:Label>
            &nbsp;
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtAssignedTo" 
                    ErrorMessage="Assign To contains invalid characters" ForeColor="#FF5959" 
                    ValidationExpression="^[A-Za-z]+$"></asp:RegularExpressionValidator>
            </td>
            <td class="style10" bgcolor="#666672" style="padding: 5px">
        <asp:Label ID="Label6" runat="server" Text="Priority" CssClass="headings" 
                    style="color: #FFFFFF" EnableTheming="True"></asp:Label>
            &nbsp;
                <asp:Label ID="lblPriorityError" runat="server" 
                    ForeColor="#FF5959"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style15" bgcolor="#A9A9B0" style="padding: 10px">
        <asp:TextBox ID="txtAssignedTo" runat="server" Width="409px" MaxLength="30"></asp:TextBox>
            </td>
            <td class="style10" bgcolor="#A9A9B0" style="padding: 10px">
            <asp:DropDownList ID="drpLstPriority" runat="server" Width="307px" height="28px">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem Value="0">Low</asp:ListItem>
                <asp:ListItem Value="1">Normal</asp:ListItem>
                <asp:ListItem Value="2">High</asp:ListItem>
                <asp:ListItem Value="3">Urgent</asp:ListItem>
            </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style14" bgcolor="#666672" colspan="2" style="padding: 5px">
        <asp:Label ID="Label8" runat="server" Text="Title" CssClass="headings" 
                    style="color: #FFFFFF" EnableTheming="True"></asp:Label>
            &nbsp;
                <asp:RequiredFieldValidator ID="titleRequiredFieldValidator" runat="server" 
                    ControlToValidate="txtTitle" ErrorMessage="Please enter a title" 
                    ForeColor="#FF5959" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="txtTitle" Display="Dynamic" 
                    ErrorMessage="Title contains invalid characters" ForeColor="#FF5959" 
                    ValidationExpression="^[A-Za-z0-9,. ]+$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style11" bgcolor="#A9A9B0" colspan="2" 
                style="padding: 10px; border: 2px solid black">
        <asp:TextBox ID="txtTitle" runat="server" Width="409px" MaxLength="30" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style11" bgcolor="#666672" colspan="2" 
                style="padding: 5px; border: 2px solid black">
        <asp:Label ID="Label9" runat="server" Text="Description" CssClass="headings" 
                    style="color: #FFFFFF" EnableTheming="True"></asp:Label>
    &nbsp;<asp:Label ID="lblDescError" runat="server" ForeColor="#FF5959"></asp:Label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="txtDescBox" 
                    ErrorMessage="Description contains invalid characters" ForeColor="#FF5959" 
                    ValidationExpression="^[A-Za-z0-9,\-. \s]+$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style11" bgcolor="#A9A9B0" colspan="2" 
                style="padding: 10px; border: 2px solid black">
        <asp:TextBox ID="txtDescBox" runat="server" Height="49px" Width="100%" 
            TextMode="MultiLine" MaxLength="255" ></asp:TextBox>
            </td>
        </tr>
    </table>
    <table class="style3" style="border-collapse: collapse">
        <tr bgcolor="#666672" 
            
            style="padding: 10px; border-style: none solid solid solid; border-width: 2px; border-color: black;">
            <td class="style4">
                &nbsp;</td>
            <td style="padding: 5px">
                <asp:Button ID="submitIssue" runat="server" 
                    style="margin-left: 67px" Text="Submit" Width="88px" Height="28px" 
                    onclick="submitIssue_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
