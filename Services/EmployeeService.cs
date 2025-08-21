using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly PersonService personService;
        private readonly IMapper mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, PersonService personService)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
            this.personService = personService;
        }

        public async Task CreateEmployee(PersonRequestDto personRequestDto)
        {
            var employee = await personService.CreatePerson(personRequestDto);
            Employee empleado = new Employee();
            empleado.PersonId = employee.PersonId;
            empleado.Status = true;
            await employeeRepository.Insert(empleado);
        }

        public async Task UpdateEmployee(int id, PersonRequestDto personRequestDto)
        {
            var existingEmployee = await employeeRepository.GetById(id);
            if (existingEmployee == null)
            {
                throw new Exception("El empleado no existe");
            }
            else
            {
                var idPersona = existingEmployee.PersonId;
                await personService.UpdatePerson(idPersona, personRequestDto);
                await employeeRepository.Update(existingEmployee);
            }
        }


        public async Task<ActionResult<EmployeeResponseDto>> GetEmployeeById(int id)
        {
            var employee = await employeeRepository.GetById(id);
            return mapper.Map<EmployeeResponseDto>(employee);
        }

        public async Task<ActionResult<List<EmployeeResponseDto>>> GetAllEmployees()
        {
            var employees = await employeeRepository.GetAll();
            if(employees == null)
            {
                throw new Exception("Empleados no encontrados");
            }
            else
            {
                return mapper.Map<List<EmployeeResponseDto>>(employees);
            }           
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await employeeRepository.GetById(id);
            if (employee == null)
            {
                throw new KeyNotFoundException("El empleado no existe");
            }
            else
            {
                employee.Status = false;
                await employeeRepository.Update(employee);
            }
        }

    }
}
