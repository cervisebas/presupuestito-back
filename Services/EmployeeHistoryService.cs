using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class EmployeeHistoryService
    {
        private readonly IEmployeeHistoryRepository employeeHistoryRepository;
        private readonly IMapper mapper;

        public EmployeeHistoryService(IEmployeeHistoryRepository employeeHistoryRepository, IMapper mapper)
        {
            this.employeeHistoryRepository = employeeHistoryRepository;
            this.mapper = mapper;
        }

        public async Task CreateEmployeeHistory(EmployeeHistoryRequestDto employeeHistoryRequestDto)
        {
            var employeeHistory = mapper.Map<EmployeeHistory>(employeeHistoryRequestDto);
            employeeHistory.Status = true;
            await employeeHistoryRepository.Insert(employeeHistory);
        }

        public async Task UpdateEmployeeHistory(int id, EmployeeHistoryRequestDto employeeHistoryRequestDto)
        {
            var existingEmployeeHistory = await employeeHistoryRepository.GetById(id);
            if (existingEmployeeHistory == null)
            {
                throw new Exception("El historial del empleado no existe");
            }
            else
            {
                mapper.Map(employeeHistoryRequestDto, existingEmployeeHistory);
                await employeeHistoryRepository.Update(existingEmployeeHistory);
            }
        }

        public async Task<ActionResult<EmployeeHistoryResponseDto>> GetEmployeeHistoryById(int id)
        {
            var employeeHistory = await employeeHistoryRepository.GetById(id);
            if (employeeHistory == null)
            {
                throw new KeyNotFoundException("El historial del empleado no fue encontrado.");
            }
            else
            {
                return mapper.Map<EmployeeHistoryResponseDto>(employeeHistory);
            }
        }

        public async Task<ActionResult<List<EmployeeHistoryResponseDto>>> GetAllEmployeeHistories()
        {
            var employeeHistories = await employeeHistoryRepository.GetAll();
            if (employeeHistories == null)
            {
                throw new Exception("Historiales de empleados no encontrados.");
            }
            else
            {
                return mapper.Map<List<EmployeeHistoryResponseDto>>(employeeHistories);
            }
        }

        public async Task DeleteEmployeeHistory(int id)
        {
            var employeeHistory = await employeeHistoryRepository.GetById(id);
            if (employeeHistory == null)
            {
                throw new KeyNotFoundException("El historial del empleado no fue encontrado.");
            }
            else
            {
                employeeHistory.Status = false;
                await employeeHistoryRepository.Update(employeeHistory);
            }
        }

    }
}
