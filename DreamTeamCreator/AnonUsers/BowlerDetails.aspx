<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BowlerDetails.aspx.cs" Inherits="DreamTeamCreator.AnonUsers.BowlerDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/><br/><br/><br/>

    <h3><asp:Label runat="server" Text="Bowler Details Page" ID="BowlerPageHeading"></asp:Label></h3>

    <table>
        <tr>
            <td>Wickets</td>
            <td><asp:Label runat="server"  ID="WicketsLabel"></asp:Label></td>
        </tr>
        <tr>
            <td>Runs Conceded</td>
            <td><asp:Label runat="server" ID="RunsConcededLabel"></asp:Label></td>
        </tr>
        <tr>
            <td>Batsman Name</td>
            <td><asp:Label runat="server" ID="WorstBatsmanLabel"></asp:Label></td>
        </tr>
        <tr>
            <td>Fours</td>
            <td><asp:Label runat="server" ID="FoursLabel"></asp:Label></td>
        </tr>
        <tr>
            <td>Sixes</td>
            <td><asp:Label runat="server" ID="SixesLabel"></asp:Label></td>
        </tr>
    </table>
</asp:Content>
