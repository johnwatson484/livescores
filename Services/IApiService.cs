using System;
using System.Collections.Generic;
using Livescores.Models;

namespace Livescores.Services
{
	public interface IApiService
	{
		IEnumerable<Fixture> GetFixtures();
	}
}
