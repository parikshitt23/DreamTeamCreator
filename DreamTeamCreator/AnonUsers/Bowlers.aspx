<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Bowlers.aspx.cs" Inherits="DreamTeamCreator.AnonUsers.Bowlers"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br></br>
<br></br>
<table style="width: 100%;">
<tr>
    <td>Team:</td>
    <td>
        <asp:DropDownList ID="DropTeam" runat="server">
            <asp:ListItem Text="Select Team.."  Value="0" Selected="True"></asp:ListItem>
            <asp:ListItem Text="Chennai Super Kings"  Value="1"></asp:ListItem>
            <asp:ListItem Text="Deccan Chargers"  Value="2"></asp:ListItem>
            <asp:ListItem Text="Delhi Daredevils"  Value="3"></asp:ListItem>
            <asp:ListItem Text="Kings XI Punjab"  Value="4"></asp:ListItem>
            <asp:ListItem Text="Kochi Tuskers Kerala"  Value="5"></asp:ListItem>
            <asp:ListItem Text="Kolkata Knight Riders"  Value="6"></asp:ListItem>
            <asp:ListItem Text="Mumbai Indians"  Value="7"></asp:ListItem>
            <asp:ListItem Text="Pune Warriors"  Value="8"></asp:ListItem>
            <asp:ListItem Text="Rajasthan Royals"  Value="9"></asp:ListItem>
            <asp:ListItem Text="Royal Challengers Bangalore"  Value="10"></asp:ListItem>
            <asp:ListItem Text="Sunrisers Hyderabad"  Value="11"></asp:ListItem>
        </asp:DropDownList>
    </td>
    <td>Bowler:</td>
    <td>
        <asp:TextBox ID="Name" runat="server" placeholder="Bowler Name"></asp:TextBox>
    </td>
</tr>
<tr>
    <td>Economy Range:</td>
    <td>
        <asp:DropDownList ID="EconomyDrop" runat="server">
            <asp:ListItem Text="Select Range.."  Value="0" Selected="True"></asp:ListItem>
            <asp:ListItem>&lt;4</asp:ListItem>
            <asp:ListItem>&gt;=4 and &lt;5</asp:ListItem>
            <asp:ListItem>&gt;=5 and &lt;6</asp:ListItem>
            <asp:ListItem>&gt;=6 and &lt;7</asp:ListItem>
            <asp:ListItem>&gt;=7 and &lt;8</asp:ListItem>
            <asp:ListItem>&gt;=8 and &lt;9</asp:ListItem>
            <asp:ListItem>&gt;=9 and &lt;10</asp:ListItem>
            <asp:ListItem>&gt;=10 and &lt;11</asp:ListItem>
            <asp:ListItem>&gt;=11 and &lt;15</asp:ListItem>
            <asp:ListItem>&gt;=15 and &lt;20</asp:ListItem>
            <asp:ListItem>&gt;=20</asp:ListItem>
        </asp:DropDownList>
    </td>
    <td>Wickets Taken:</td>
    <td>
        <asp:DropDownList ID="Wickets_Taken" runat="server">
            <asp:ListItem Text="Select Range.."  Value="0" Selected="True"></asp:ListItem>
            <asp:ListItem>&lt;5</asp:ListItem>
            <asp:ListItem>&gt;=5 and &lt;10</asp:ListItem>
            <asp:ListItem>&gt;=10 and &lt;15</asp:ListItem>
            <asp:ListItem>&gt;=15 and &lt;20</asp:ListItem>
            <asp:ListItem>&gt;=20 and &lt;25</asp:ListItem>
            <asp:ListItem>&gt;=25</asp:ListItem>
        </asp:DropDownList>
    </td>
</tr>
<tr>
    <td><asp:Button ID="Submit" runat="server" Text="Search" OnClick="Search_Click"/></td>
</tr>
</table>
    <br />
    <asp:Button ID="Add" runat="server" Text="Add Player" OnClick="Add_Click"/>
    <br />
    <asp:GridView ID="BowlerSearchRes" runat="server" OnSelectedIndexChanged="BowlerSearchRes_SelectedIndexChanged">
        <Columns>
            

            <asp:templatefield HeaderText="View Details">
                    <itemtemplate>
                        <asp:Button ID="ViewDetails" runat="server" Text="View Details" OnClick="ViewDetails_Click" RowIndex="<%# Container.DisplayIndex %>" />
                    </itemtemplate>
           </asp:templatefield>

          
        </Columns>
    </asp:GridView>
</asp:Content>