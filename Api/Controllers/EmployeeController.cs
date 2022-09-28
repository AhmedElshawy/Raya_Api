using Api.DTOs;
using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class EmployeeController : BaseController
    {
        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
            var employees = await _unitOfWork.Employees.ListAllAsync(i=>i.Department);
            if (employees.Count == 0) return NotFound();

            var mappedData = _mapper.Map<List<EmployeeDTO>>(employees);

            return Ok(mappedData);
        }
        [HttpGet("department/{id}")]
        public async Task<ActionResult> GetEmployeesByDepartmentId(int id)
        {
            var employees = await _unitOfWork.Employees.ListAllAsync(d => d.DepartmentId == id, i => i.Department);
            if (employees.Count == 0) return NotFound();

            var mappedData = _mapper.Map<List<EmployeeDTO>>(employees);
            return Ok(mappedData);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            var employee = await _unitOfWork.Employees.FindAsync(i=>i.Id == id , d=>d.Department);
            if (employee == null) return NotFound();

            var mappedData = _mapper.Map<EmployeeDTO>(employee);
            return Ok(mappedData);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee(EmployeeToAddDTO employeeToAdd)
        {
            var employee = _mapper.Map<EmployeeToAddDTO, Employee>(employeeToAdd);

            await _unitOfWork.Employees.AddAsync(employee);
            var result = await _unitOfWork.CompleteAsync();

            if (result <= 0) return BadRequest();

            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, EmployeeToAddDTO employeeToUpdate)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if (employee == null) return NotFound();

            _mapper.Map(employeeToUpdate, employee);
            _unitOfWork.Employees.Update(employee);
            var result = await _unitOfWork.CompleteAsync();

            if (result <= 0) return BadRequest();

            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if (employee == null) return NotFound();

            _unitOfWork.Employees.Delete(employee);
            var result = await _unitOfWork.CompleteAsync();

            if (result <= 0) return BadRequest();

            return Ok(employee);
        }
    }
}
