using Roulette.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.API.Interfaces
{
    public interface IRouletteRepository
    {
        Task<IEnumerable<PlaceBetResponse>> PlaceBetAsync(int selection, decimal stake);
        int Spin();
        decimal Payout(decimal stake);
        Task<IEnumerable<int>> PreviousSpinsAsync();
    }
}

