﻿using DataModel;
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
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<Company>> Get()
        {
            try
            {
                var result = await _companyRepository.GetAll();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Company> GetById(int id)
        {
            try
            {
                var result = await _companyRepository.Get(id);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Company> GetByName(string name)
        {
            try
            {
                var result = await _companyRepository.FindByCondition(x => x.Name == name);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> AddCompany(AddCompanyRequest request)
        {
            try
            {
                var company = new Company()
                {
                    Name = request.Name,
                    Description = request.Description,
                    PhoneNumber = request.PhoneNumber,
                    Active = true,
                    CreatedOn = DateTime.Now,
                };
                await _companyRepository.Insert(company);
                return company.CompanyId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateCompany(UpdateCompanyRequest request)
        {
            try
            {
                var companyToUpdate = await _companyRepository.Get(request.CompanyId);
                companyToUpdate.Name = request.Name;
                companyToUpdate.Description = request.Description;
                companyToUpdate.PhoneNumber = request.PhoneNumber;
                await _companyRepository.Update(companyToUpdate);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteCompany(int Id)
        {
            try
            {
                var companyToDelete = await _companyRepository.Get(Id);
                companyToDelete.Active = false;
                companyToDelete.DeletedOn = DateTime.Now;

                await _companyRepository.Update(companyToDelete);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
