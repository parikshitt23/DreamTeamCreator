<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Batsman.aspx.cs" Inherits="DreamTeamCreator.AnonUsers.Batsman" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <br/>
    <br/>
    <br/>
    <br/>
   <table draggable="true">
       <tr>
           <td>Team</td>
           <td><asp:DropDownList runat="server" ID="BattingTeamNameDropDown">
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
       </tr>
       <tr>
           <td>Name</td>
           <td>
               <asp:TextBox ID="BatsmanNameTextBox" runat="server"></asp:TextBox></td>
           <td>&nbsp;</td>
       </tr>
       <tr>
           <td>Average</td>
           <td>
               <asp:DropDownList ID="BattingAverageDropDown" runat="server">
                   <asp:ListItem Value="0">Select Average...</asp:ListItem>
                   <asp:ListItem>&gt;=0 and &lt;10</asp:ListItem>
                   <asp:ListItem>&gt;=10 and &lt;20</asp:ListItem>
                   <asp:ListItem>&gt;=20 and &lt;30</asp:ListItem>
                   <asp:ListItem>&gt;=30 and &lt;40</asp:ListItem>
                   <asp:ListItem>&gt;=40</asp:ListItem>
               </asp:DropDownList>
           </td>
       </tr>
       <tr>
           <td>Strike Rate</td>
           <td>
               <asp:DropDownList ID="BattingStrikeRateDropDown" runat="server">
                    <asp:ListItem Value="0">Select Strike Rate...</asp:ListItem>
                    <asp:ListItem>&gt;=0 and &lt;20</asp:ListItem>
                    <asp:ListItem>&gt;=20 and &lt;40</asp:ListItem>
                    <asp:ListItem>&gt;=40 and &lt;60</asp:ListItem>
                    <asp:ListItem>&gt;=60 and &lt;80</asp:ListItem>
                    <asp:ListItem>&gt;=80 and &lt;100</asp:ListItem>
                    <asp:ListItem>&gt;=100 and &lt;120</asp:ListItem>
                    <asp:ListItem>&gt;=120 and &lt;140</asp:ListItem>
                    <asp:ListItem>&gt;=140 and &lt;160</asp:ListItem>
                    <asp:ListItem>&gt;=160 and &lt;180</asp:ListItem>
                    <asp:ListItem>&gt;=180 and &lt;200</asp:ListItem>
                    <asp:ListItem>&gt;=200</asp:ListItem>
              </asp:DropDownList>
           </td>
       </tr>
   </table>
    <asp:Button ID="Submit" runat="server" Text="Search" OnClick="BatsmanSearch_Click"/>
    <asp:GridView ID="BatsmanSearchResult" runat="server" OnSelectedIndexChanged="BatsmanSearchRes_SelectedIndexChanged">
        <Columns>
            <asp:templatefield HeaderText="View Details">
                    <itemtemplate>
                        <asp:Button ID="ViewDetails" runat="server" Text="View Details" OnClick="ViewDetails_Click" RowIndex="<%# Container.DisplayIndex %>" />
                    </itemtemplate>
           </asp:templatefield>
        </Columns>
    </asp:GridView>
        
</asp:Content>
