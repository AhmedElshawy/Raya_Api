using Api.DTOs;
using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class DepartmentController : BaseController
    {
        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        public async Task<ActionResult> GetAllDepartments()
        {
            var departments = await _unitOfWork.Departments.ListAllAsync();
            if (departments == null) return NotFound();

            var mappedData = _mapper.Map<List<DepartmentDTO>>(departments);
            return Ok(mappedData);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDepartmentById(int id)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id);
            if (department == null) return NotFound();

            var mappedData = _mapper.Map<DepartmentDTO>(department);
            return Ok(mappedData);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDepartment(DepartmentToCreateDTO departmentToCreate)
        {
            var department = _mapper.Map<DepartmentToCreateDTO, Department>(departmentToCreate);

            await _unitOfWork.Departments.AddAsync(department);
            var result = await _unitOfWork.CompleteAsync();

            if (result <= 0) return BadRequest();

            return Ok(department);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDepartment(int id , DepartmentToCreateDTO departmentToUpdate)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id);
            if (department == null) return NotFound();

            _mapper.Map(departmentToUpdate, department);
            _unitOfWork.Departments.Update(department);
            var result = await _unitOfWork.CompleteAsync();

            if (result <= 0) return BadRequest();

            return Ok(department);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepetment(int id)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id);
            if(department == null) return NotFound();

            _unitOfWork.Departments.Delete(department);
            var result = await _unitOfWork.CompleteAsync();

            if (result <= 0) return BadRequest();

            return Ok(department);
        }
    }
}
