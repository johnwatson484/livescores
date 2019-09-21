using System;
using System.Collections.Generic;
using System.Linq;
using Livescores.Models;
using System.Net;
using Newtonsoft.Json;

namespace Livescores.Services
{
  public class ApiService : IApiService
  {
	private string url = "https://lynxmagnus.com/footballscores/api/fixtures?startDate=";

	public IEnumerable<Fixture> GetFixtures()
	{
		url = string.Format("{0}{1}&endDate={2}", url, DateTime.Now.Date.AddDays(-7).ToString("s"), DateTime.Now.ToString("s"));

		using (WebClient client = new WebClient())
		{
			try
			{
				var json = client.DownloadString(url);
				var fixtures = JsonConvert.DeserializeObject<List<Fixture>>(json);
				return fixtures.OrderByDescending(x => x.Date).OrderBy(x => x.CompetitionRank).ThenBy(x => x.HomeTeam);
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
  }
}
