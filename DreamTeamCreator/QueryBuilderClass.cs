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
            string team_f = "";
            string econ_f = "";
            string wickets_f = "";
            string player_f = "";//data filtering conditions

            string econrange = DropDownSelect(EconomyDrop);
            string wicketsrange = DropDownSelect(Wickets_Taken);
            string selectedTeam = DropDownSelect(DropTeam);

            master_q = "select season as Season,bowler as Bowler,wickets_taken as Wickets_Taken,economy as Economy from ( select distinct C.team_id,A.season,A.bowler,sum(wickets_taken) wickets_taken,sum(economy) economy from (select distinct season, bowler, 0 as wickets_taken, cast((sum(run_scored) / (count(*) / 6)) as numeric(15, 2)) as economy from ball_by_ball where season <> '2015' group by season, bowler union all select distinct season, bowler, count(*) as wickets_taken, 0 as economy from ball_by_ball where out_decision <> '*' and season <> '2015' group by season, bowler) A inner join (select * from PLAYER_IDS where player_id<>'372') B on A.bowler=B.PLAYERNAME inner join team_players_map C on B.PLAYER_ID=c.player_id and C.season=A.season group by A.season,A.bowler,C.team_id) all_data";

            if (!string.IsNullOrEmpty(selectedTeam))
            {
                team_f = "team_id =" + selectedTeam + "";
                conditions.Add(team_f);
            }

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
            if (conditions.ToArray().Length != 0)
            {
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
            }
            else {
                search_q += " ORDER BY WICKETS_TAKEN DESC, ECONOMY DESC";
            }
            

            return search_q;

        }

        public static string BatsmanQueryBuilder(DropDownList BattingTeamNameDropDown, DropDownList BattingAverageDropDown, DropDownList BattingStrikeRateDropDown, TextBox BatsmanNameTextBox) {
            List<String> conditions = new List<string>();

            string master_q = "";
            string search_q = "";
            string team_f = "";
            string average_f = "";
            string striker_rate_f = "";
            string player_f = ""; //data filtering conditions

            master_q = "SELECT season as Season,strike_bat as Strike_Batsman,avg as Average,sr as Strike_Rate FROM (SELECT DISTINCT C.team_id,DATA1.SEASON,DATA1.STRIKE_BAT,SUM(AVG) AVG,SUM(SR) SR FROM (SELECT DISTINCT A.SEASON, A.STRIKE_BAT, CAST(RUNS / OUTS AS NUMBER(15, 2)) AS AVG, 0 AS SR FROM (SELECT DISTINCT SEASON, STRIKE_BAT, SUM(RUN_SCORED) AS runs FROM NIGUPTA.BALL_BY_BALL WHERE SEASON <> '2015' GROUP BY STRIKE_BAT, SEASON) A inner join (SELECT DISTINCT SEASON, STRIKE_BAT, count(*) AS outs FROM NIGUPTA.BALL_BY_BALL WHERE SEASON <> '2015' and out_decision <> '*' GROUP BY STRIKE_BAT, SEASON) B ON A.SEASON = B.SEASON AND A.STRIKE_BAT = B.STRIKE_BAT UNION ALL SELECT DISTINCT SEASON, STRIKE_BAT, 0 AS AVG, CAST(SUM(RUN_SCORED) / COUNT(*) AS NUMBER(15, 4)) * 100 AS SR FROM NIGUPTA.BALL_BY_BALL WHERE SEASON <> '2015' GROUP BY STRIKE_BAT, SEASON) Data1 inner join PLAYER_IDS B on Data1.STRIKE_BAT=B.PLAYERNAME inner join team_players_map C on B.PLAYER_ID=c.player_id and C.season=DATA1.season GROUP BY DATA1.STRIKE_BAT,DATA1.SEASON,C.TEAM_ID) ALL_DATA";

            string averageRange = DropDownSelect(BattingAverageDropDown);
            string strikeRateRange = DropDownSelect(BattingStrikeRateDropDown);
            string selectedTeam = DropDownSelect(BattingTeamNameDropDown);

            if (!string.IsNullOrEmpty(selectedTeam))
            {
                team_f = "team_id =" + selectedTeam + "";
                conditions.Add(team_f);
            }

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
            if (conditions.ToArray().Length != 0)
            {
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
            }
            else {
                search_q += " order by avg desc,sr desc";
            }            

            return search_q;
        }

        public static string NextMatchQueryBuilder(int matchNumber) {

            return "SELECT TEAM_HOME, 'VS' ,TEAM_AWAY FROM MATCH_LIST WHERE SEASON = '2015' AND MATCH_NO = "+ matchNumber;
        }

        public static string NextMatchPlayerSelectionQueryBuilder(string homeTeamString, string awayTeamString) {

            return "SELECT PLAYERNAME , PLAYERROLE  FROM PLAYER_IDS WHERE PLAYER_ID IN (SELECT PLAYER_ID FROM TEAM_PLAYERS_MAP WHERE TEAM_ID IN (SELECT TEAM_ID FROM TEAM_IDS WHERE TEAMS = '" + homeTeamString + "' OR TEAMS = '" + awayTeamString + "') AND SEASON = '2015')";
        }

        public static Dictionary<string, string> BowlerDetailsQueryBuilder(string bowlerName) {

            Dictionary<string, string> bowlerDetailsQueryMap = new Dictionary<string, string>();
            bowlerDetailsQueryMap.Add("boundariesAgainstQuery", "select * from (select batsman, bowler, sixes, fours, sixes + fours as total_boundaries from (select s.strike_bat as batsman, s.bowler as bowler, s.sixes as sixes, f.fours as fours from( select strike_bat, bowler, count(run_scored)as sixes  from ball_by_ball  where run_scored = '6' group by strike_bat, bowler) s, (select strike_bat, bowler, count(run_scored)as fours  from ball_by_ball where run_scored = '4' group by strike_bat, bowler) f where s.strike_bat = f.strike_bat and s.bowler = f.bowler) order by total_boundaries desc, sixes desc, fours desc) all_data where ROWNUM = 1 AND Bowler = '"+bowlerName+"'");
            bowlerDetailsQueryMap.Add("wicketsRunsQuery", "select * from (select bowler, max(wickets) as wickets, min(runs_conceded) as runs_conceded from (select x.season as season, x.match_id as match_id, x.bowler as bowler, x.wickets as wickets, y.runs_conceded as runs_conceded from(select season, match_id, bowler, count(out_decision) as wickets from ball_by_ball where out_decision != '*' group by season, match_id, bowler) x, (select season, match_id, bowler, sum(run_scored) as runs_conceded from ball_by_ball group by season, match_id, bowler) y where x.season = y.season and x.match_id = y.match_id and x.bowler = y.bowler) group by bowler order by wickets desc, runs_conceded asc) all_data where Bowler = '" + bowlerName + "'");
            bowlerDetailsQueryMap.Add("bowlerAllRecordsQuery", "select * from (SELECT W.BOWLER AS BOWLER, W.WICKETS AS WICKETS, R.RUNS_CONCEDED AS RUNS_CONCEDED, N.NO_OF_BALLS AS BALLS_BOWLED, TRUNC((R.RUNS_CONCEDED / W.WICKETS),2) AS AVERAGE, TRUNC((N.NO_OF_BALLS / W.WICKETS),2) AS STRIKE_RATE, TRUNC(((R.RUNS_CONCEDED/N.NO_OF_BALLS)*6),2) AS ECONOMY_RATE   FROM (  SELECT BOWLER, SUM(RUN_SCORED) AS RUNS_CONCEDED FROM BALL_BY_BALL GROUP BY  BOWLER) R,  (SELECT BOWLER,  COUNT(*) AS WICKETS  FROM ( SELECT  BOWLER FROM BALL_BY_BALL WHERE OUT_DECISION != '*' ) GROUP BY BOWLER  ) W, ( SELECT BOWLER, COUNT(*) AS NO_OF_BALLS FROM BALL_BY_BALL GROUP BY  BOWLER) N WHERE R.BOWLER = W.BOWLER AND R.BOWLER = N.BOWLER ORDER BY WICKETS DESC) all_data where Bowler = '" + bowlerName + "'");
            bowlerDetailsQueryMap.Add("bestBatsmanQuery", "select * from (SELECT BOWLER, STRIKE_BAT AS BATSMAN, COUNT(OUT_DECISION) AS DISMISSALS FROM BALL_BY_BALL WHERE OUT_DECISION != '*' GROUP BY BOWLER, STRIKE_BAT ORDER BY COUNT(OUT_DECISION) DESC) all_data where ROWNUM = 1 AND Bowler = '" + bowlerName + "'");
            bowlerDetailsQueryMap.Add("bowledWicketsQuery", "select * from (SELECT BOWLER, COUNT(DISMISSAL) AS BOWLED FROM IPL_MASTER_DATA WHERE DISMISSAL = 'bowled' GROUP BY BOWLER ORDER BY BOWLED DESC) all_data where Bowler = '" + bowlerName + "'");
            bowlerDetailsQueryMap.Add("inningFourConcededQuery", "select * from ( SELECT SEASON, MATCH_NO, INN_NO, BOWLER, COUNT(*) AS NO_OF_4 FROM IPL_MASTER_DATA WHERE RUNS_SCORED = 4 GROUP BY SEASON, MATCH_NO, INN_NO, BOWLER ORDER BY NO_OF_4 DESC) all_data where ROWNUM = 1 AND Bowler = '" + bowlerName + "'");
            bowlerDetailsQueryMap.Add("inningSixConcededQuery", "select * from (  SELECT SEASON, MATCH_NO, INN_NO, BOWLER, COUNT(*) AS NO_OF_6 FROM IPL_MASTER_DATA WHERE RUNS_SCORED = 6 GROUP BY SEASON, MATCH_NO, INN_NO, BOWLER ORDER BY NO_OF_6 DESC) all_data where ROWNUM = 1 AND Bowler = '" + bowlerName + "'");
            //bowlerDetailsQueryMap.Add("seasonBestQuery", "select * from ( SELECT SEASON, BOWLER, COUNT(OUT_DECISION) AS WICKETS FROM BALL_BY_BALL WHERE OUT_DECISION != '*' GROUP BY SEASON, BOWLER ORDER BY WICKETS DESC) all_data where ROWNUM = 1 AND Bowler = '" + bowlerName + "'");





            return bowlerDetailsQueryMap;
        }

        public static Dictionary<string, string> TeamDetailsQueryBuilder(string teamName) {

            Dictionary<string, string> teamDetailsQueryMap = new Dictionary<string, string>();
            teamDetailsQueryMap.Add("winPercentage", "SELECT * FROM (SELECT W.BATTING_TEAM, W.WINS, D.DEFEATS, TRUNC((W.WINS/(W.WINS+D.DEFEATS)*100), 2) AS WIN_PERCENTAGE FROM ( SELECT BATTING_TEAM, COUNT(*) AS WINS FROM ( SELECT * FROM ( SELECT SEASON, MATCH_NO, INN_NO, BATTING_TEAM, SUM(RUNS_SCORED) AS RUNS FROM IPL_MASTER_DATA WHERE BALL_NO BETWEEN 0.0 AND 10.0  AND BATTING_TEAM = WINNER GROUP BY SEASON, MATCH_NO, INN_NO, BATTING_TEAM ) WHERE RUNS > 80 ) GROUP BY BATTING_TEAM) W, (SELECT BATTING_TEAM, COUNT(*) AS DEFEATS FROM ( SELECT * FROM ( SELECT SEASON, MATCH_NO, INN_NO, BATTING_TEAM, SUM(RUNS_SCORED) AS RUNS FROM IPL_MASTER_DATA WHERE BALL_NO BETWEEN 0.0 AND 10.0  AND BATTING_TEAM != WINNER GROUP BY SEASON, MATCH_NO, INN_NO, BATTING_TEAM ) WHERE RUNS > 80 ) GROUP BY BATTING_TEAM ) D WHERE W.BATTING_TEAM = D.BATTING_TEAM ORDER BY WIN_PERCENTAGE DESC) ALL_DATA WHERE BATTING_TEAM ='"+teamName+"'");
            teamDetailsQueryMap.Add("winPercentageChasingMatch", "SELECT * FROM (SELECT S.WINNER, S.SUCCESSFUL_CHASES, F.FAILED_CHASES, TRUNC(S.SUCCESSFUL_CHASES/(S.SUCCESSFUL_CHASES + F.FAILED_CHASES),4) * 100 AS WINNING_CHASES_AFTER_TOSS_WIN FROM (  SELECT WINNER, COUNT(*) AS SUCCESSFUL_CHASES FROM ( SELECT DISTINCT SEASON, MATCH_NO, WINNER FROM IPL_MASTER_DATA WHERE  TOSS_WINNER = WINNER AND TOSS_DECISION = 'field' ) GROUP BY WINNER ORDER BY SUCCESSFUL_CHASES DESC ) S, ( SELECT TOSS_WINNER AS LOSER, COUNT(*) AS FAILED_CHASES FROM ( SELECT DISTINCT SEASON, MATCH_NO, WINNER, TOSS_WINNER FROM IPL_MASTER_DATA WHERE  TOSS_WINNER != WINNER AND TOSS_DECISION = 'field' ) GROUP BY TOSS_WINNER ORDER BY FAILED_CHASES DESC ) F WHERE S.WINNER = F.LOSER ORDER BY WINNING_CHASES_AFTER_TOSS_WIN DESC) ALL_DATA WHERE WINNER ='"+teamName+"'");
            teamDetailsQueryMap.Add("totalNumberOfAllOuts", "SELECT * FROM (SELECT BATTING_TEAM, COUNT(INNING_WICKETS) AS NO_OF_ALL_OUTS FROM ( SELECT SEASON, MATCH_NO, INN_NO, BATTING_TEAM, COUNT(DISMISSAL) AS INNING_WICKETS FROM IPL_MASTER_DATA WHERE DISMISSAL != '*' GROUP BY SEASON, MATCH_NO, INN_NO, BATTING_TEAM )WHERE INNING_WICKETS = 10 GROUP BY BATTING_TEAM ORDER BY NO_OF_ALL_OUTS DESC) ALL_DATA WHERE BATTING_TEAM = '"+teamName+"'");
            teamDetailsQueryMap.Add("homeGroundQuery", "SELECT * FROM (SELECT TEAM, HOME_WINS, HOME_DEFEATS, TRUNC((HOME_WINS/( HOME_WINS + HOME_DEFEATS))*100,2) AS HOME_WIN_LOSS_PERCENTAGE FROM(  SELECT W.TEAM AS TEAM, W.NO_OF_HOME_WINS AS HOME_WINS, D.NO_OF_HOME_DEFEATS AS HOME_DEFEATS FROM ( SELECT TEAM_HOME AS TEAM, COUNT(*) AS NO_OF_HOME_WINS FROM ( SELECT DISTINCT SEASON, MATCH_NO, TEAM_HOME FROM IPL_MASTER_DATA WHERE TEAM_HOME = WINNER ) GROUP BY TEAM_HOME ) W, ( SELECT TEAM_HOME AS TEAM, COUNT(*) AS NO_OF_HOME_DEFEATS FROM ( SELECT DISTINCT SEASON, MATCH_NO, TEAM_HOME FROM IPL_MASTER_DATA WHERE TEAM_HOME != WINNER ) GROUP BY TEAM_HOME ) D WHERE W.TEAM = D.TEAM ) ORDER BY HOME_WIN_LOSS_PERCENTAGE DESC) ALL_DATA WHERE TEAM = '"+teamName+"'");
            teamDetailsQueryMap.Add("maxBoundariesByATeam", "SELECT * FROM (SELECT SEASON, MATCH_NO, INN_NO, BATTING_TEAM, COUNT(*) AS NO_OF_BOUNDARIES FROM IPL_MASTER_DATA WHERE RUNS_SCORED = 4 OR RUNS_SCORED = 6 GROUP BY SEASON, MATCH_NO, INN_NO, BATTING_TEAM ORDER BY NO_OF_BOUNDARIES DESC) WHERE ROWNUM =1 AND BATTING_TEAM = '"+teamName+"'");
            teamDetailsQueryMap.Add("highestRunsScored", "SELECT * FROM (SELECT SEASON, MATCH_NO, INN_NO, BATTING_TEAM, SUM(RUNS_SCORED) AS HIGHEST_TEAM_TOTALS FROM IPL_MASTER_DATA GROUP BY SEASON, MATCH_NO, INN_NO, BATTING_TEAM ORDER BY HIGHEST_TEAM_TOTALS DESC) ALL_DATA WHERE ROWNUM = 1 AND BATTING_TEAM = '" + teamName + "'");
            return teamDetailsQueryMap;

        }
        public static Dictionary<string, string> BatsmanDetailsQueryBuilder(string batsmanName)
        {

            Dictionary<string, string> batsmanDetailsQueryMap = new Dictionary<string, string>();
            batsmanDetailsQueryMap.Add("batsmanWithMostDucks", "select * from (SELECT STRIKE_BAT BATSMAN, COUNT(*) NO_OF_DUCKS FROM( SELECT BALL_BY_BALL.SEASON, BALL_BY_BALL.MATCH_ID, BALL_BY_BALL.STRIKE_BAT, SUM(BALL_BY_BALL.RUN_SCORED) AS DUCKS FROM BALL_BY_BALL INNER JOIN(SELECT DISTINCT STRIKE_BAT FROM BALL_BY_BALL WHERE OUT_DECISION <> '*') A ON BALL_BY_BALL.STRIKE_BAT = A.STRIKE_BAT GROUP BY BALL_BY_BALL.SEASON, BALL_BY_BALL.MATCH_ID, BALL_BY_BALL.STRIKE_BAT HAVING SUM(BALL_BY_BALL.RUN_SCORED) = 0) WHERE STRIKE_BAT ='"+batsmanName+"' GROUP BY STRIKE_BAT ORDER BY NO_OF_DUCKS DESC)");
            batsmanDetailsQueryMap.Add("batsmanCenturiesAndHalfCenturies", "select * from (SELECT X.BATSMAN, Y.NO_OF_100, X.NO_OF_50 FROM (SELECT STRIKE_BAT AS BATSMAN, COUNT(RUNS) AS NO_OF_50 FROM( SELECT SEASON, MATCH_ID, STRIKE_BAT, SUM(RUN_SCORED) AS RUNS FROM BALL_BY_BALL GROUP BY SEASON, MATCH_ID, STRIKE_BAT) WHERE RUNS >= 50 AND RUNS <= 99 GROUP BY STRIKE_BAT) X, (SELECT STRIKE_BAT AS BATSMAN, COUNT(RUNS) AS NO_OF_100 FROM(SELECT SEASON, MATCH_ID, STRIKE_BAT, SUM(RUN_SCORED) AS RUNS FROM BALL_BY_BALL GROUP BY SEASON, MATCH_ID, STRIKE_BAT)WHERE RUNS >= 100 GROUP BY STRIKE_BAT) Y WHERE X.BATSMAN = Y.BATSMAN AND X.BATSMAN='" + batsmanName + "' ORDER BY NO_OF_100 DESC, NO_OF_50 DESC)");
            batsmanDetailsQueryMap.Add("batsmanHighestScore", "select * from (SELECT SEASON, STRIKE_BAT, SUM(RUN_SCORED) AS RUNS FROM BALL_BY_BALL WHERE STRIKE_BAT='"+batsmanName+"' GROUP BY SEASON, STRIKE_BAT ORDER BY RUNS DESC) WHERE ROWNUM=1");
            batsmanDetailsQueryMap.Add("batsmanRunOuts", "select * from (SELECT STRIKE_BAT, COUNT(DISMISSAL) AS RUN_OUTS FROM IPL_MASTER_DATA WHERE STRIKE_BAT='" + batsmanName + "' AND DISMISSAL = 'run out' GROUP BY STRIKE_BAT ORDER BY RUN_OUTS DESC)");
            batsmanDetailsQueryMap.Add("batsmanDismissal", "select * from ( SELECT BOWLER, STRIKE_BAT, dismissal FROM IPL_MASTER_DATA WHERE DISMISSAL = 'retired hurt' AND STRIKE_BAT='" + batsmanName + "')");
            batsmanDetailsQueryMap.Add("MaximumBallsPlayedByBatsman", "select * from (SELECT SEASON, MATCH_NO, INN_NO, STRIKE_BAT, COUNT(*) AS BALLS_PLAYED FROM IPL_MASTER_DATA WHERE STRIKE_BAT='" + batsmanName + "' GROUP BY SEASON, MATCH_NO, INN_NO, STRIKE_BAT ORDER BY BALLS_PLAYED DESC) WHERE ROWNUM=1");
            batsmanDetailsQueryMap.Add("batsmanMaximumFours", "select * from (SELECT SEASON, MATCH_NO, INN_NO, STRIKE_BAT, COUNT(*) AS NO_OF_4 FROM IPL_MASTER_DATA WHERE RUNS_SCORED = 4 AND STRIKE_BAT='" + batsmanName + "' GROUP BY SEASON, MATCH_NO, INN_NO, STRIKE_BAT ORDER BY NO_OF_4 DESC)WHERE ROWNUM=1");
            batsmanDetailsQueryMap.Add("batsmanMaximumSixes", "select * from (SELECT SEASON, MATCH_NO, INN_NO, STRIKE_BAT, COUNT(*) AS NO_OF_6 FROM IPL_MASTER_DATA WHERE RUNS_SCORED = 6 AND STRIKE_BAT='" + batsmanName + "'GROUP BY SEASON, MATCH_NO, INN_NO, STRIKE_BAT ORDER BY NO_OF_6 DESC) WHERE ROWNUM=1");
            return batsmanDetailsQueryMap;
        }
    }
}