<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Batsman.aspx.cs" Inherits="DreamTeamCreator.AnonUsers.Batsman" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Stylesheet1.css"/>
  <br/>
    <br/>
    <br/>
    <br/>
   <table draggable="true">
       <tr>
           <td class ="style6">Team</td>
           <td class ="style6"><asp:DropDownList runat="server" ID="DropDownList1">
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
       <tr>
            <td><asp:Button ID="Submit" runat="server" Text="Search" OnClick="Search_Click"/></td>
       </tr>
   </table>
   <br />
   <asp:GridView ID="GridView1" ClientIDMode="Static" runat="server">
       <Columns>
           <asp:templatefield HeaderText="Select">
                    <itemtemplate>
                        <asp:checkbox ID="cbSelect" CssClass="gridCB" ClientIDMode="Static" runat="server"></asp:checkbox>
                    </itemtemplate>
           </asp:templatefield>
           <asp:ButtonField ButtonType="Button" CommandName="Cancel" HeaderText="View Details" ShowHeader="True" Text="Button" />
       </Columns>
    </asp:GridView>    
    
    <script type="text/javascript">
        function TextboxAutoEnableAndDisable(Row) {
  // Get current "active" row of the GridView.
            var GridView = document.getElementById('GridView1');
  var currentGridViewRow = GridView.rows[Row + 1];

  // Get the two controls of our interest.
  var rowTextBox = currentGridViewRow.cells[2].getElementsByTagName("PLAYERNAME")[0];
  var rowCheckbox = currentGridViewRow.cells[0].getElementsByTagName("Select")[0];

  // If the clicked checkbox is unchecked.
  if( rowCheckbox.checked === true) {
    // Empty textbox and make it disabled
      alert("hello");
  }

  // To be here means the row checkbox is checked, therefore make it enabled.
  //rowTextBox.disabled = false;
}

 </script> 
</asp:Content>
