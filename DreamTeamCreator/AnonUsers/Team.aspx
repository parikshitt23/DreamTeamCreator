<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Team.aspx.cs" Inherits="DreamTeamCreator.AnonUsers.Team" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />    <br />    <br />    <br />

     <asp:DropDownList ID="DropTeam" runat="server" OnSelectedIndexChanged="DropTeam_SelectedIndexChanged" AutoPostBack="true">
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
    <br/>
    <h3> <asp:Label ID="TeamNameLabel" runat="server" Text=""></asp:Label></h3>
    <div runat="server" id="TeamDetailsDiv">

        <label>
WINNING PERCENTAGE OF TEAMS AFTER SCORING 80 OR MORE RUNS IN FIRST 10 OVERS</label>
    <table>
        <tr>
            <td>Matches Won</td>
            <td>Matches Lost</td>
            <td>Win Percentage</td>

        </tr>
        <tr>
            <td>
                <asp:Label ID="winNumberLabel" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="loseNumberLabel" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="winPercentageLabel" runat="server" Text=""></asp:Label></td>
        </tr>
        
    </table>
<br/>
        <label>
HIGHEST WINNING PERCENTAGE OF TEAMS WHO WON THE MATCHES WHILE CHASING WHEN THEY HAD WON THE TOSS AND DECIDED TO FIELD FIRST</label>
        <table >
             <tr>
            <td>Successfull Chases</td>
            <td>Failed Chases</td>
            <td>Win Percentage</td>

        </tr>

            <tr>
            <td>
                <asp:Label ID="successfulChasesLabel" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="failedChasesLabel" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="winPercentageAfterTossWin" runat="server" Text=""></asp:Label></td>
        </tr>
        </table>
<br/>
<label>
TOTAL NUMBER OF ALL OUTS FOR A TEAM : </label><asp:Label ID="totalNumberOfAllOutsLabel" runat="server" Text=""></asp:Label><br/>

        <label>
TEAMS ALL TIME RANKING ACCORDING TO HOME GROUND STRENGTH</label><br/>
        <table >
             <tr>
            <td>Home Wins</td>
            <td>Home Loses</td>
            <td>Win Percentage</td>

        </tr>

            <tr>
            <td>
                <asp:Label ID="homeWinsLabel" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="homeLoseLabel" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="homeWinPercentageLabels" runat="server" Text=""></asp:Label></td>
        </tr>
        </table>

        <br/>
<label>
MAXIMUM NO OF BOUNDARIES SCORED BY A TEAM IN AN INNING : </label><asp:Label ID="maxBoundariesInningsLabel" runat="server" Text=""></asp:Label><br/>

                <label>
HIGHEST TEAM TOTALS IN AN INNING</label><br/>
        <table >
             <tr>
            <td>Highest Runs Scored</td>
            <td>Season</td>
        </tr>
            <tr>
            <td>
                <asp:Label ID="highestRunsScoredLabel" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="SeasonLabel" runat="server" Text=""></asp:Label></td>
        </tr>
        </table>
    </div>
</asp:Content>
