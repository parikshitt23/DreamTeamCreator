<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BatsmanDetails.aspx.cs" Inherits="DreamTeamCreator.AnonUsers.BatsmanDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />    <br />    <br />    <br />
    <h3><asp:Label runat="server" Text="Batsman Details Page" ID="BatsmanPageHeading"></asp:Label></h3>
    <br /><br />
    <b>NUMBER OF DUCKS (0 SCORES) SCORED: </b><asp:Label runat="server"  ID="DucksLabel" Text="-"></asp:Label>
    <br /><br />
    <b>CENTURIES AND HALF CENTURIES SCORED: </b>
    <br />
    <table border="1">
        <tr>
            <td>Half Centuries</td>
            <td>Centuries</td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="HalfCenturiesLabel" Text="-"></asp:Label></td>
            <td><asp:Label runat="server" ID="CenturiesLabel" Text="-"></asp:Label></td>
        </tr>
    </table>
    <br />
    <b>BEST BATTING PERFORMACE: </b>
    <br />
    <table border="1">
        <tr>
            <td>Season</td>
             <td>Maximum Runs Scored</td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="SeasonLabel" Text="-"></asp:Label></td>
            <td><asp:Label runat="server" ID="MaximumRunsScoredLabel" Text="-"></asp:Label></td>
        </tr>
    </table>
    <br />
    <b>MOST NUMBER OF RUN-OUTS: </b><asp:Label runat="server" ID="RunOutsLabel" Text="-"></asp:Label>
    <br /><br />
    <b>MAXIMUM NO OF BALLS PLAYED: </b>
    <table border="1">
        <tr>
            <td>Season</td>
             <td>Balls Played</td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="SeasonLabel1" Text="-"></asp:Label></td>
            <td><asp:Label runat="server" ID="BallsPlayedLabel" Text="-"></asp:Label></td>
        </tr>
    </table>
    <br />
    <b>MAXIMUM NO OF 4'S SCORED: </b>
    <table border="1">
        <tr>
            <td>Season</td>
            <td>Number of Fours</td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="SeasonLabel2" Text="-"></asp:Label></td>
            <td><asp:Label runat="server" ID="NumberOfFoursLabel" Text="-"></asp:Label></td>
        </tr>
    </table>
    <br />
    <b>MAXIMUM NO OF 6'S SCORED: </b>
    <table border="1">
        <tr>
            <td>Season</td>
            <td>Number of Sixes</td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="SeasonLabel3" Text="-"></asp:Label></td>
            <td><asp:Label runat="server" ID="NumberOfSixesLabel" Text="-"></asp:Label></td>
        </tr>
    </table>
    <br />  
</asp:Content>
