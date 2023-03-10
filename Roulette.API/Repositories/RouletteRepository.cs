using Dapper;
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

        public async Task<PlaceBetResponse> PlaceBetAsync(int selection, decimal stake)
        {
            var result = await QueryAsync<PlaceBetResponse>($"INSERT INTO BetHistory VALUES({selection}, {stake})", commandType: CommandType.Text);

            if (result.Any() != null)
            {
                return new PlaceBetResponse
                {
                    ResponseMessage = "Success"
                };
            }
            else
            {
                return new PlaceBetResponse
                {
                    ResponseMessage = "Error - Unable to Place Bet"
                };
            }
        }

        public async Task<List<int>> PreviousSpinsAsync()
        {
            var results = await QueryAsync<int>("SELECT TOP 10 SpinValue FROM SpinHistory", commandType: CommandType.Text);
            List<int> finalList = results.ToList();
            return finalList;
        }

        public async Task<int> SpinAsync()
        {
            var rnd = new Random().Next(1, 36);
            await ExecuteAsync($"INSERT INTO SpinHistory VALUES({rnd})", commandType: CommandType.Text);
            return rnd;
        }
    }
}
