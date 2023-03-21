using AutoMapper;

using Pokemon.Domain.Masters;
using Pokemon.Interfaces;
using Pokemon.Interfaces.Services;
using Pokemon.Models.Masters;

using System.Threading.Tasks;

namespace Pokemon.Service
{
    public class MasterService : IMasterService
    {
        private readonly IMasterRepository _masterRepository;
        private readonly IMapper _mapper;

        public MasterService(IMasterRepository masterRepository,IMapper mapper)
        {
            _masterRepository = masterRepository;
            _mapper = mapper;
        }

        public async Task<Master> AddMaster(MasterModel model)
        {    

            var master = _mapper.Map<Master>(model);

            return await _masterRepository.AddOrUpdate(master);
        }

        public async Task<Master> Update(MasterModel model, int masterId)
        {
            var master = _mapper.Map<Master>(model);
            master.Id = masterId;

            return await _masterRepository.AddOrUpdate(master);
        }

        public async Task RemoveMaster(int id)
        {
            await _masterRepository.RemoveById(id);
        }
    }
}
