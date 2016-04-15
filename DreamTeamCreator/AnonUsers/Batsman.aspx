<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Batsman.aspx.cs" Inherits="DreamTeamCreator.AnonUsers.Batsman" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <br/>
    <br/>
    <br/>
    <br/>
   <table draggable="true">
       <tr>
           <td>Team</td>
           <td><asp:DropDownList runat="server" ID="DropDownList1">
               </asp:DropDownList>
           </td>
       </tr>
       <tr>
           <td>Name</td>
           <td>
               <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
           <td>&nbsp;</td>
       </tr>
       <tr>
           <td>Average</td>
           <td>
               <asp:DropDownList ID="DropDownList2" runat="server">
                   <asp:ListItem>Select Average...</asp:ListItem>
                   <asp:ListItem>&gt;=0 &lt;10</asp:ListItem>
                   <asp:ListItem>&gt;=10 &lt;20</asp:ListItem>
                   <asp:ListItem>&gt;=20 &lt;30</asp:ListItem>
                   <asp:ListItem>&gt;=30 &lt;40</asp:ListItem>
                   <asp:ListItem>&gt;=40</asp:ListItem>
               </asp:DropDownList>
           </td>
       </tr>
       <tr>
           <td>Strike Rate</td>
           <td>
               <asp:DropDownList ID="DropDownList3" runat="server">
                    <asp:ListItem>Select Strike Rate...</asp:ListItem>
                    <asp:ListItem>&gt;=0 &lt;20</asp:ListItem>
                    <asp:ListItem>&gt;=20 &lt;40</asp:ListItem>
                    <asp:ListItem>&gt;=40 &lt;60</asp:ListItem>
                    <asp:ListItem>&gt;=60 &lt;80</asp:ListItem>
                    <asp:ListItem>&gt;=80 &lt;100</asp:ListItem>
                    <asp:ListItem>&gt;=100 &lt;120</asp:ListItem>
                    <asp:ListItem>&gt;=120 &lt;140</asp:ListItem>
                    <asp:ListItem>&gt;=140 &lt;160</asp:ListItem>
                    <asp:ListItem>&gt;=160 &lt;180</asp:ListItem>
                    <asp:ListItem>&gt;=180 &lt;200</asp:ListItem>
                    <asp:ListItem>&gt;=200</asp:ListItem>
              </asp:DropDownList>
           </td>
       </tr>
       <tr>
           <td>
               <asp:CheckBox ID="CheckBox1" runat="server" />Half Centuries
           </td>
           <td>
           </td>
           <td>
           </td>
           <td>
               <asp:CheckBox ID="CheckBox2" runat="server" />Full Centuries
           </td>
       </tr>
   </table>

    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        
</asp:Content>
