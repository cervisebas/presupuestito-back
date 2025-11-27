using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Requests;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.DTOs.Responses;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class SettingService
    {
        private readonly ISettingRepository settingRepository;
        private readonly IMapper mapper;

        public SettingService(ISettingRepository settingRepository, IMapper mapper)
        {
            this.settingRepository = settingRepository;
            this.mapper = mapper;
        }

        public async Task<ActionResult<SettingResponseDto>> GetSettingByLabel(string label)
        {
            var setting = await settingRepository.GetByLabelAsync(label);

            if (setting == null)
                throw new KeyNotFoundException("Setting no encontrado");

            return mapper.Map<SettingResponseDto>(setting);
        }

        public async Task<SettingResponseDto> UpdateOrCreateSetting(string label, SettingRequestDto request)
        {
            var setting = await settingRepository.UpdateOrCreateAsync(label, request.Value);
            return mapper.Map<SettingResponseDto>(setting);
        }


        public async Task<ActionResult<List<SettingResponseDto>>> GetAllSettings()
        {
            var setting = await settingRepository.GetAll();
            return mapper.Map<List<SettingResponseDto>>(setting);
        }
    }
}
