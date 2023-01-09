using Microsoft.AspNetCore.Mvc;
using Roulette.API.Interfaces;

namespace Roulette.API.Controllers
{

    public class RouletteController : ControllerBase
    {
        private readonly IRouletteRepository _rouletteRepo;

        // now we have used DI to inject the instance once only 
        public RouletteController(IRouletteRepository rouletteRepo)
        {
            _rouletteRepo = rouletteRepo;
        }

        // now we can write out 4 endpoints PlaceBet, Spin, Payout and ShowPreviousSpins
        // all implementations of Roullte Interface will be accesibble via _rouletteRepo
        [HttpGet]
        [Route("api/[controller]/spin")]
        public IActionResult Spin()
        {
            return Ok(_rouletteRepo.Spin());
        }

        [HttpGet]
        [Route("api/[controller]/payout")]
        public IActionResult Payout(decimal stake)
        {
            return Ok(_rouletteRepo.Payout(stake));
        }

        [HttpGet]
        [Route("api/[controller]/previousspins")]
        public IActionResult ShowPreviousSpins(decimal stake)
        {
            return Ok(_rouletteRepo.PreviousSpinsAsync());
        }

        [HttpPost]
        [Route("api/[controller]/placebet")]
        public IActionResult PlaceBet(int selection, decimal stake)
        {
            return Ok(_rouletteRepo.PlaceBetAsync(selection, stake));
        }
    }
}
