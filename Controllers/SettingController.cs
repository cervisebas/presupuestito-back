using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Requests;
using PresupuestitoBack.DTOs.Responses;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly SettingService settingService; 


        public SettingController(SettingService settingService)
        {
            this.settingService = settingService;
        }

        [HttpGet("{label}")]
        public async Task<SettingResponseDto> GetSettingByLabel(string label)
        {
            var result = await settingService.GetSettingByLabel(label);
            return result;
        }

        [HttpPut("{label}")]
        public async Task<SettingResponseDto> UpdateSetting(string label, [FromBody] SettingRequestDto dto)
        {
            var setting = await settingService.UpdateOrCreateSetting(label, dto);
            return setting;
        }
    }
}
