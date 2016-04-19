using System;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections;
using System.Web.UI;

namespace DreamTeamCreator.AnonUsers
{
    public partial class Bowlers : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
                
        }



        protected void Search_Click(object sender, EventArgs e)
        {

            string oracleConnectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
            OracleConnection con = new OracleConnection(oracleConnectionString);
            int ab = con.ConnectionTimeout;
          
            try
            {
                string query = QueryBuilderClass.BowlerQueryBuilder(DropTeam, EconomyDrop, Wickets_Taken, Name);
                OracleCommand cmd = new OracleCommand(query, con);
                con.Open();
                OracleConnection.ClearAllPools();
                OracleDataReader rdr = cmd.ExecuteReader();
                BowlerSearchRes.DataSource = rdr;
                BowlerSearchRes.DataBind();
            }
            catch (OracleException ex)
            {
                Response.Write("<br>/" + "<br>/" + "<br>/" + "<br>/" + "<br>/" + ex);
            }
            finally
            {
                con.Close();
            }

        }

        protected void BowlerSearchRes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BowlerSearchRes_SelectedIndexChanging(object sender,GridViewSelectEventArgs e)
        {
            GridViewRow row = BowlerSearchRes.Rows[e.NewSelectedIndex];
            var m_values = this.GetValues(row);
        }

        public IDictionary<string, object> GetValues(GridViewRow row)
        {
            IOrderedDictionary dictionary = new OrderedDictionary();

            foreach (Control control in row.Controls)
            {
                DataControlFieldCell cell = control as DataControlFieldCell;

                if ((cell != null) && cell.Visible)
                {
                    cell.ContainingField.ExtractValuesFromCell
                    (dictionary, cell, row.RowState, true);
                }
            }

            IDictionary<string, object> values = new Dictionary<string, object>();

            foreach (DictionaryEntry de in dictionary)
            {
                values[de.Key.ToString()] = de.Value;
            }

            return values;
        }

        protected void Add_Click(object sender, EventArgs e)
        {

            List<string> BowlerNames = new List<string>();
            foreach (GridViewRow row in BowlerSearchRes.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("cbSelect");

                if (check.Checked)
                {
                    BowlerNames.Add(row.Cells[2].Text);
                }
            }
            List<string> BowlerNames1 = BowlerNames;
        }

        protected void ViewDetails_Click(object sender, EventArgs e)
        {
            Button viewDetailsButton = sender as Button;
            int rowIndex = Convert.ToInt32(viewDetailsButton.Attributes["RowIndex"]);
            string bowlerName = BowlerSearchRes.Rows[rowIndex].Cells[2].Text;
            Session["BowlerName"] = bowlerName;
            Response.Redirect("~/AnonUsers/BowlerDetails");
         } 
    }
}