using Roulette.API.Interfaces;
using Roulette.API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.API.Repositories
{
    public class RouletteRepository : DapperRepository, IRouletteRepository
    {
        public RouletteRepository(string connectionString) : base(connectionString)
        {
        }

        public decimal Payout(decimal stake)
        {
            // use a default odd of 35 to 1 for a straight bet
            return 35.0m * stake;
        }

        public async Task<IEnumerable<PlaceBetResponse>> PlaceBetAsync(int selection, decimal stake)
        {
            //implement dapper save to db here 
            return await QueryAsync<PlaceBetResponse>("INSERT INTO");
        }

        public async Task<IEnumerable<int>> PreviousSpinsAsync()
        {
            // return a list of previous spins
            return await QueryAsync<int>("SELECT TOP 10 Selections FROM RouletteDb");
        }

        public int Spin()
        {
            return new Random().Next(1, 36);
        }
    }
}
