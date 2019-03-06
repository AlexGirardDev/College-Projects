<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="progressmap.aspx.cs" Inherits="BuggedOut.progressmap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="lblCallofHonor" runat="server" Text="Call of Honor" 
            Font-Bold="True" Font-Size="Medium" ForeColor="#E8E8E8"></asp:Label>
        <br />
        <div class="ProgressBack">
            <asp:Panel ID="pnlCoh" runat="server" BackColor="#009933" Height="50px" 
                ForeColor="White">
            </asp:Panel>
        </div>
        <br />
        <asp:Label ID="lblwpc" runat="server" Text="World of PeaceCraft" 
            Font-Bold="True" Font-Size="Medium" ForeColor="#E8E8E8"></asp:Label>
        <br />
        <div class="ProgressBack">
            <asp:Panel ID="pnlWpa" runat="server" BackColor="#009933" Height="50px" 
                ForeColor="White">
            </asp:Panel>            
        </div>
        <br />
        <asp:Label ID="lblSlightlyAgitatedBovine" runat="server" 
            Text="Slightly Agitated Bovine" Font-Bold="True" Font-Size="Medium" 
            ForeColor="#E8E8E8"></asp:Label>
        <br />
        <div class="ProgressBack">
            <asp:Panel ID="pnlSab" runat="server" BackColor="#009933" Height="50px" 
                ForeColor="White">
            </asp:Panel>  
        </div>
        <br />
        <asp:Label ID="lblCarCraft4" runat="server" Text="CarCraft4" Font-Bold="True" 
            Font-Size="Medium" ForeColor="#E8E8E8"></asp:Label>
        <br />
        <div class="ProgressBack">
            <asp:Panel ID="pnlCc4" runat="server" BackColor="#009933" Height="50px" 
                ForeColor="White">
            </asp:Panel>  
        </div>
     </div>
    
</asp:Content>
