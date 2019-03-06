<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="advancedSearch.aspx.cs" Inherits="BuggedOut.advancedSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style3
        {
            width: 100%;
            border-collapse: collapse;
        }
        
        .tdTitle
        {
            border-width: 2px;
	        border-style: solid;
	        border-color: black;
            font-weight: bold;
            padding: 5px;
            color: #FFFFFF;
            background-color: #B5B5BE;
            font-size: 1.5em;
        }
        
        .tdInfo
        {
            border-width: 2px;
	        border-style: solid;
	        border-color: black;
            padding: 5px;
            color: #FFFFFF;
            background-color: #616171;            
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style3" cellspacing="0">
        <tr>
            <td align="center" width="33%" class="tdTitle">
                Project Name</td>
            <td align="center" width="33%" class="tdTitle">
                Created By</td>
            <td align="center" width="33%" class="tdTitle">
                Assigned To</td>
        </tr>
        <tr>
            <td align="center" width="33%" class="tdInfo">
            <asp:DropDownList ID="drpLstProjName" runat="server" Width="158px" 
                    style="width: 159px">
                <asp:ListItem>Any</asp:ListItem>
                <asp:ListItem>Call Of Honor</asp:ListItem>
                <asp:ListItem>World Of Peacecraft</asp:ListItem>
                <asp:ListItem>Slightly Agitated Bovine</asp:ListItem>
                <asp:ListItem>CarCraft 4</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td align="center" width="33%" class="tdInfo">
                <asp:TextBox ID="txtCreatedBy" runat="server" Width="158px" 
                    style="width: 155px"></asp:TextBox>
            </td>
            <td align="center" width="33%" class="tdInfo">
                <asp:TextBox ID="txtAssignedTo" runat="server" Width="158px" 
                    style="width: 155px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" width="33%" class="tdTitle">
                Category</td>
            <td align="center" width="33%" class="tdTitle">
                Priority</td>
            <td align="center" width="33%" class="tdTitle">
                Status</td>
        </tr>
        <tr>
            <td align="center" width="33%" class="tdInfo">
            <asp:DropDownList ID="drpLstCategory" runat="server" Height="22px" Width="158px" 
                    style="width: 159px">
                <asp:ListItem>Any</asp:ListItem>
                <asp:ListItem>Graphics</asp:ListItem>
                <asp:ListItem>Multiplayer</asp:ListItem>
                <asp:ListItem>Single Player</asp:ListItem>
                <asp:ListItem>Audio</asp:ListItem>
                <asp:ListItem>AI</asp:ListItem>
                <asp:ListItem>Physics</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td align="center" width="33%" class="tdInfo">
            <asp:DropDownList ID="drpLstPriority" runat="server" Width="158px" height="22px" 
                    style="width: 159px">
                <asp:ListItem>Any</asp:ListItem>
                <asp:ListItem Value="0">Low</asp:ListItem>
                <asp:ListItem Value="1">Normal</asp:ListItem>
                <asp:ListItem Value="2">High</asp:ListItem>
                <asp:ListItem Value="3">Urgent</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td align="center" width="33%" class="tdInfo">
            <asp:DropDownList ID="drpLstStatus" runat="server" Width="159px" height="22px" 
                    style="width: 159px">
                <asp:ListItem>Any</asp:ListItem>
                <asp:ListItem>Open</asp:ListItem>
                <asp:ListItem>Acknowledged</asp:ListItem>
                <asp:ListItem>Resolved</asp:ListItem>
                <asp:ListItem>Closed</asp:ListItem>
            </asp:DropDownList>
            </td>
        </tr>
    </table>
    <br />
    <table class="style3" cellspacing="0">
        <tr>
            <td align="center" class="tdTitle">
                Issue Title</td>
        </tr>
        <tr>
            <td align="center" class="tdInfo">
                <asp:TextBox ID="txtIssuesTitle" runat="server" Width="789px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table class="style3" 
        style="background-color: #B8BBC6; border-style: none solid solid solid; border-width: 2px; border-color: black">
        <tr>
            <td width="90%" align="right" valign="bottom">
                <asp:Label ID="lblResults" runat="server" Font-Size="Medium" ForeColor="White"></asp:Label>
            </td>
            <td align="right" style="padding-top: 5px">
    <asp:Button ID="cmdASearch" runat="server" Height="30px" 
        onclick="cmdASearch_Click" Text="Search" Width="75px" />
            </td>
        </tr>
    </table>
</asp:Content>
