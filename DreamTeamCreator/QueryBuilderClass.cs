using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace DreamTeamCreator
{
    public static class QueryBuilderClass
    {
        public static string DropTeamSelect(DropDownList DropTeam)
        {
            
                if (!DropTeam.SelectedValue.Equals('0'))
                {
                   return  DropTeam.SelectedValue;
                }

            return "";
        }

        public static string DropDownSelect(DropDownList DropDown)
        {
            if (!DropDown.SelectedValue.Equals("0"))
            {
                return DropDown.Text;
            }
            return "";
        }

     

        //if return of below funtion is single digit, check the 1st character of input string to see if its the lower limit or the upper limit
        public static List<int> split_input_range(string input)
        {
            List<int> range = new List<int>();
            string[] range_parse = input.Split(' ');
            if (range_parse.Length > 1)
            {
                range.Add(Int32.Parse(Regex.Match(range_parse[0], @"\d+").Value));
                range.Add(Int32.Parse(Regex.Match(range_parse[2], @"\d+").Value));
            }
            else
            {
                range.Add(Int32.Parse(Regex.Match(range_parse[0], @"\d+").Value));
            }
            return range;
        }

        public static string BowlerQueryBuilder(DropDownList DropTeam, DropDownList EconomyDrop, DropDownList Wickets_Taken, TextBox Name) {
            List<String> conditions = new List<string>();

            string master_q = "";
            string search_q = "";
            string econ_f = "";
            string wickets_f = "";
            string player_f = ""; //data filtering conditions

            string econrange = DropDownSelect(EconomyDrop);
            string wicketsrange = DropDownSelect(Wickets_Taken);
            

            master_q = "select * from (select distinct season,bowler,sum(wickets_taken) wickets_taken,sum(economy) economy from (select distinct season, bowler, 0 as wickets_taken, cast((sum(run_scored) / (count(*) / 6)) as numeric(15, 2)) as economy from ball_by_ball where season <> '2015' group by season, bowler union all select distinct season, bowler, count(*) as wickets_taken, 0 as economy from ball_by_ball where out_decision <> '*' and season <> '2015' group by season, bowler) A group by A.season,A.bowler) all_data";

            if (!string.IsNullOrWhiteSpace(Name.Text))
            {
                player_f = "bowler like '%" + Name.Text + "%' ";
                conditions.Add(player_f);
            }

            if (!string.IsNullOrEmpty(econrange))
            {
                //int high,low;
                List<int> range = split_input_range(econrange);
                if (range.ToArray().Length == 1)
                {
                    econ_f = "economy " + econrange + " ";
                }
                else
                {
                    econ_f = "economy >=" + range[0] + " and economy < " + range[1] + " ";
                }
                conditions.Add(econ_f);
            }

            if (!string.IsNullOrEmpty(wicketsrange))
            {
                //int high,low;
                List<int> range = split_input_range(wicketsrange);
                if (range.ToArray().Length == 1)
                {
                    wickets_f = "wickets_taken " + wicketsrange + " ";
                }
                else
                {
                    wickets_f = "wickets_taken >=" + range[0] + " and wickets_taken < " + range[1] + " ";
                }
                conditions.Add(wickets_f);
            }

            search_q = master_q;
            for (int k = 0; k < conditions.ToArray().Length; k++)
            {
                if (k == 0)
                {
                    search_q += " where " + conditions[k];
                }
                else
                {
                    search_q += " and " + conditions[k];
                }
            }

            return search_q;

        }

        public static string BatsmanQueryBuilder(DropDownList BattingTeamNameDropDown, DropDownList BattingAverageDropDown, DropDownList BattingStrikeRateDropDown, TextBox BatsmanNameTextBox, CheckBox HalfCenturyCheckBox, CheckBox CenturyCheckbox) {
            List<String> conditions = new List<string>();

            string master_q = "";
            string search_q = "";
            string average_f = "";
            string striker_rate_f = "";
            string player_f = ""; //data filtering conditions

            master_q = "SELECT * FROM (SELECT DISTINCT SEASON,STRIKE_BAT,SUM(AVG) AVG,SUM(SR) SR FROM (SELECT DISTINCT A.SEASON, A.STRIKE_BAT, CAST(RUNS / OUTS AS NUMBER(15, 2)) AS AVG, 0 AS SR FROM (SELECT DISTINCT SEASON, STRIKE_BAT, SUM(RUN_SCORED) AS runs FROM NIGUPTA.BALL_BY_BALL WHERE SEASON <> '2015' GROUP BY STRIKE_BAT, SEASON) A inner join (SELECT DISTINCT SEASON, STRIKE_BAT, count(*) AS outs FROM NIGUPTA.BALL_BY_BALL WHERE SEASON <> '2015' and out_decision <> '*' GROUP BY STRIKE_BAT, SEASON) B ON A.SEASON = B.SEASON AND A.STRIKE_BAT = B.STRIKE_BAT UNION ALL SELECT DISTINCT SEASON, STRIKE_BAT, 0 AS AVG, CAST(SUM(RUN_SCORED) / COUNT(*) AS NUMBER(15, 4)) * 100 AS SR FROM NIGUPTA.BALL_BY_BALL WHERE SEASON <> '2015' GROUP BY STRIKE_BAT, SEASON) Data1 GROUP BY STRIKE_BAT, SEASON) ALL_DATA";

            string averageRange = DropDownSelect(BattingAverageDropDown);
            string strikeRateRange = DropDownSelect(BattingStrikeRateDropDown);


            if (!string.IsNullOrWhiteSpace(BatsmanNameTextBox.Text))
            {
                player_f = "STRIKE_BAT like '%" + BatsmanNameTextBox.Text + "%' ";
                conditions.Add(player_f);
            }

            if (!string.IsNullOrEmpty(averageRange))
            {
                //int high,low;
                List<int> range = split_input_range(averageRange);
                if (range.ToArray().Length == 1)
                {
                    average_f = "AVERAGE " + averageRange + " ";
                }
                else
                {
                    average_f = "AVERAGE >=" + range[0] + " and AVERAGE < " + range[1] + " ";
                }
                conditions.Add(average_f);
            }

            if (!string.IsNullOrEmpty(strikeRateRange))
            {
                //int high,low;
                List<int> range = split_input_range(strikeRateRange);
                if (range.ToArray().Length == 1)
                {
                    striker_rate_f = "SR " + strikeRateRange + " ";
                }
                else
                {
                    striker_rate_f = "SR >=" + range[0] + " and SR < " + range[1] + " ";
                }
                conditions.Add(striker_rate_f);
            }

            search_q = master_q;
            for (int k = 0; k < conditions.ToArray().Length; k++)
            {
                if (k == 0)
                {
                    search_q += " where " + conditions[k];
                }
                else
                {
                    search_q += " and " + conditions[k];
                }
            }

            return search_q;


        }


    }
}