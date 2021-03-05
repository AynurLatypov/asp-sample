using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trade.Models;
using Trade.Services;

namespace Trade.Controllers
{
    [Authorize]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _portfolioService.GetAll();
            return Ok(result);
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _portfolioService.GetById(id);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(PortfolioModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var result = await _portfolioService.Create(model);
            return Ok(result);
        }
        
        [HttpPut("/{id}")]
        public async Task<IActionResult> Put(int id, PortfolioModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            model.Id = id;
            var result = await _portfolioService.Update(model);
            return Ok(result);

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _portfolioService.Delete(id);
            return NoContent();
        }
    }
}