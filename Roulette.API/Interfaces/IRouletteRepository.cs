using Roulette.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.API.Interfaces
{
    public interface IRouletteRepository
    {
        Task<PlaceBetResponse> PlaceBetAsync(int selection, decimal stake);
        Task<int> SpinAsync();
        decimal Payout(decimal stake);
        Task<List<int>> PreviousSpinsAsync();
    }
}

