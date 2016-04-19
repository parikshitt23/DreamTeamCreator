<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BowlerDetails.aspx.cs" Inherits="DreamTeamCreator.AnonUsers.BowlerDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/><br/><br/><br/>

    <h3><asp:Label runat="server" Text="Bowler Details Page" ID="BowlerPageHeading"></asp:Label></h3>

    <table>
        <tr>
            <td><b>Bowler all records:</b></td>
            <td><asp:Label runat="server" ID="Label2"></asp:Label></td>
        </tr>
        <tr>
            <td>Wickets</td>
            <td><asp:Label runat="server" ID="WicketsLabel2"></asp:Label></td>
        </tr>
        <tr>
            <td>Runs Conceded</td>
            <td><asp:Label runat="server" ID="RunsConcededLabel2"></asp:Label></td>
        </tr>
        <tr>
            <td>Balls Bowled</td>
            <td><asp:Label runat="server" ID="BallsBowledLabel"></asp:Label></td>
        </tr>
        <tr>
            <td>Average</td>
            <td><asp:Label runat="server" ID="AverageLabel"></asp:Label></td>
        </tr>
        <tr>
            <td>Strike Rate</td>
            <td><asp:Label runat="server" ID="StrikeRateLabel"></asp:Label></td>
        </tr>
        <tr>
            <td>Economy Rate</td>
            <td><asp:Label runat="server" ID="EconomyRateLabel"></asp:Label></td>
        </tr>
        <tr>
            <td><b>Best career performance:</b></td>
            <td><asp:Label runat="server"  ID="Label1"></asp:Label></td>
        </tr>
        <tr>
            <td>Wickets</td>
            <td><asp:Label runat="server"  ID="WicketsLabel"></asp:Label></td>
        </tr>
        <tr>
            <td>Runs Conceded</td>
            <td><asp:Label runat="server" ID="RunsConcededLabel"></asp:Label></td>
        </tr>
        <tr>
            <td><b>Worst batsman to bowl to:</b></td>
            <td><asp:Label runat="server"  ID="Label3"></asp:Label></td>
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
        
        <tr>
            <td><b>Best batsman to bowl to: </b></td>
            <td><asp:Label runat="server" ID="Label4"></asp:Label></td>
        </tr>
        <tr>
            <td>Batsman</td>
            <td><asp:Label runat="server" ID="BestBatsmanLabel"></asp:Label></td>
        </tr>
        <tr>
            <td>Wickets</td>
            <td><asp:Label runat="server" ID="BestBatsmanWicketsLabel"></asp:Label></td>
        </tr>
        <tr>
            <td><b>Bowled Wickets:</b></td>
            <td><asp:Label runat="server" ID="BowledLabel"></asp:Label></td>
        </tr>
        <tr>
            <td><b>Maximum 4's conceded in an Inning:</b></td>
            <td><asp:Label runat="server" ID="inningFourLabel"></asp:Label></td>
        </tr>
        <tr>
            <td><b>Maximum 6's conceded in an inning:</b></td>
            <td><asp:Label runat="server" ID="inningSixLabel"></asp:Label></td>
        </tr>
        <%--<tr>
            <td>Season Best:</td>
            <td><asp:Label runat="server" ID="SeasonBestLabel"></asp:Label></td>
        </tr>
        <tr>
            <td>Wickets</td>
            <td><asp:Label runat="server" ID="seasonWicketsLabel"></asp:Label></td>
        </tr>--%>
        
    </table>
</asp:Content>
