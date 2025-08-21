using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class SalaryService
    {
        private readonly ISalaryRepository salaryRepository;
        private readonly IMapper mapper;

        public SalaryService(ISalaryRepository salaryRepository, IMapper mapper)
        {
            this.salaryRepository = salaryRepository;
            this.mapper = mapper;
        }

        public async Task CreateSalary(SalaryRequestDto salaryRequestDto)
        {
            var salary = mapper.Map<Salary>(salaryRequestDto);
            await salaryRepository.Insert(salary);
        }

        public async Task UpdateSalary(int id, SalaryRequestDto salaryRequestDto)
        {
            var existingSalary = await salaryRepository.GetById(id);
            if (existingSalary == null)
            {
                throw new Exception("El salario no existe");
            }
            else
            {
                mapper.Map(salaryRequestDto, existingSalary);
                await salaryRepository.Update(existingSalary);
            }
        }

        public async Task<ActionResult<SalaryResponseDto>> GetSalaryById(int id)
        {
            var salary = await salaryRepository.GetById(id);
            if (salary == null)
            {
                throw new KeyNotFoundException("El salario no fue encontrado.");
            }
            else
            {
                return mapper.Map<SalaryResponseDto>(salary);
            }
        }

        public async Task<ActionResult<List<SalaryResponseDto>>> GetAllSalaries()
        {
            var salaries = await salaryRepository.GetAll();
            if (salaries == null)
            {
                throw new Exception("Salarios no encontrados.");
            }
            else
            {
                return mapper.Map<List<SalaryResponseDto>>(salaries);
            }
        }

        public async Task DeleteSalary(int id)
        {
            var salary = await salaryRepository.GetById(id);
            if (salary == null)
            {
                throw new KeyNotFoundException("El salario no fue encontrado.");
            }
            else
            {
                salary.Status = false;
                await salaryRepository.Update(salary);
            }
        }

    }
}
