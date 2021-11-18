using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Repositories;
using Raze.Api.Domain.Services;
using Raze.Api.Domain.Services.Communication;
using Raze.Api.Shared.Domain.Repositories;

namespace Raze.Api.Services
{
    public class ProfessionService : IProfessionService
    {
        private readonly IProfessionRepository _professionRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public ProfessionService(IProfessionRepository professionRepository, IUnitOfWork unitOfWork)
        {
            _professionRepository = professionRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<Profession>> ListAsync()
        {
            return await _professionRepository.ListAsync();   
        }

        public async Task<ProfessionResponse> SaveAsync(Profession profession)
        {
            try
            {
                await _professionRepository.AddAsync(profession);
                await _unitOfWork.CompleteAsync();

                return new ProfessionResponse(profession);
            }
            catch (Exception e)
            {
                return new ProfessionResponse($"Error while saving profession: {e.Message}");
            }
        }

        public async Task<ProfessionResponse> UpdateAsync(int id, Profession profession)
        {
            var existingProfession = await _professionRepository.FindByIdAsync(id);

            if (existingProfession == null)
                return new ProfessionResponse("Profession not found.");
            existingProfession.Name = profession.Name;

            try
            {
                _professionRepository.Update(existingProfession);
                await _unitOfWork.CompleteAsync();

                return new ProfessionResponse(existingProfession);
            }
            catch (Exception e)
            {
                return new ProfessionResponse($"Error while updating profession: {e.Message}");
            }
        }

        public async Task<ProfessionResponse> DeleteAsync(int id)
        {
            var existingProfession = await _professionRepository.FindByIdAsync(id);

            if (existingProfession == null)
                return new ProfessionResponse("Profession not found.");

            try
            {
                _professionRepository.Remove(existingProfession);
                await _unitOfWork.CompleteAsync();

                return new ProfessionResponse(existingProfession);
            }
            catch (Exception e)
            {
                return new ProfessionResponse($"Error while deleting profession: {e.Message}");

            }
        }

        public async Task<ProfessionResponse> GetByIdAsync(int id)
        {
            var existingProfession = await _professionRepository.FindByIdAsync(id);
            
            if (existingProfession == null)
                return new ProfessionResponse("Profession not found.");
            
            return new ProfessionResponse(existingProfession);
        }
    }
}