using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.Services;
using PresupuestitoBack.DTOs.Response;

namespace PresupuestitoBack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StatsController : ControllerBase
  {
    private readonly StatService statService;

    public StatsController(StatService statService)
    {
      this.statService = statService;
    }

    [HttpGet]
    public async Task<ActionResult<StatResponseDto>> GetBudgets()
    {
      return await statService.GetStats();
    }
  }
}