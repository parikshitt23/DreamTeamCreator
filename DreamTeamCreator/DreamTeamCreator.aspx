<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DreamTeamCreator.aspx.cs" Inherits="DreamTeamCreator.DreamTeamCreator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/><br/>
    <br/><br/>
    <div style="float:left; border:solid red 1px;">
    <asp:GridView ID="NextMatchGridView" runat="server"></asp:GridView>

    <asp:Button ID="AddPlayer" runat="server" Text="Add Player" OnClick="AddPlayer_Click"/>
    <asp:Button ID="NextMatchButton" runat="server" Text="Next Match" OnClick="NextMatch_Click"/>
        <asp:Button ID="PlayerPerformanceButton" runat="server" Text="View Player Performance" OnClick="PlayerPerformanceButton_Click"/>
    <asp:GridView ID="PlayersGridView" runat="server">
        <Columns>   
             <asp:templatefield HeaderText="Select Player">
                    <itemtemplate>
                        <asp:checkbox ID="playerSelectCheckBox" CssClass="gridCB"  runat="server"></asp:checkbox>
                    </itemtemplate>
           </asp:templatefield>
             </Columns>
    </asp:GridView>
        </div>

    <div style="float:right;border:solid red 1px;">
<asp:Button ID="SimMatch" runat="server" Text="Sim Match" OnClick="SimMatch_Click"/>
    </div>

    <div style="float:right;border:solid red 1px;">
<asp:GridView ID="SelectedTeamGridView" runat="server"></asp:GridView>
    </div>
</asp:Content>
