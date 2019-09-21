using System;
using System.Collections.Generic;

namespace Livescores.Models
{
	public class Fixture
	{
		public int FixtureId { get; set; }
		public DateTime Date { get; set; }
		public string Competition { get; set; }
		public string HomeTeam { get; set; }
		public string AwayTeam { get; set; }
		public int HomeScore { get; set; }
		public int AwayScore { get; set; }
		public virtual IList<Goal> Goals { get; set; }
		public int CompetitionRank
		{
			get
			{
				switch(Competition)
				{
					case "PREMIER LEAGUE":
					return 1;
					case "CHAMPIONSHIP":
					return 2;
					case "LEAGUE ONE":
					return 3;
					case "LEAGUE TWO":
					return 4;
					case "THE FA CUP":
					return 5;
					case "EFL CUP":
					return 6;
					default:
					return 7;
				}
			}
		}
	}
}
