using Pokemon.Domain.Masters;
using Pokemon.Models.Masters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Interfaces.Services
{
    public interface IMasterService
    {
        Task<Master> AddMaster(MasterModel model);
        Task RemoveMaster(int id);
        Task<Master> Update(MasterModel model, int masterId);
    }
}
