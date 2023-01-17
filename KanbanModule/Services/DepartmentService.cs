using AutoMapper;
using Infrastucture.DataAccess.Interfaces;
using KanbanModule.DTOs;
using KanbanModule.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanModule.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DepartmentDto>> GetAll()
        {
            try
            {
                var result = await _departmentRepository.GetAll();
                var departmentMapper = _mapper.Map<IEnumerable<DepartmentDto>>(result);
                return departmentMapper;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
