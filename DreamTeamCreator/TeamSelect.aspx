<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TeamSelect.aspx.cs" Inherits="DreamTeamCreator.TeamSelect" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <br><br>
   <br><br> 
    <p>
    
        
       
    
    
        <asp:GridView ID="GridView1" runat="server">
            <Columns>
            <asp:templatefield HeaderText="Select">
                    <itemtemplate>
                        <asp:checkbox ID="cbSelect" CssClass="gridCB" onClick="SelectedPlayer()" runat="server"></asp:checkbox>
                    </itemtemplate>
           </asp:templatefield>
            </Columns>
        </asp:GridView>
        
        
    
        
       
    
    
    </p>
</asp:Content>
