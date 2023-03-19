using Pokemon.Domain.Masters;
using Pokemon.Interfaces;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pokemon.Repository.Masters
{
    public class MasterRepository : IMasterRepository
    {
        private readonly IContext _context;

        public MasterRepository(IContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Save or if exist, update the Master Pokemon on db
        /// </summary>
        /// <param name="master"></param>
        /// <returns></returns>
        public async Task<Domain.Masters.Master> AddOrUpdate(Domain.Masters.Master master)
        {
            _context.Masters.AddOrUpdate(master);
            await _context.SaveChangesAsync();


            return master;
        }

        /// <summary>
        /// Get a master from Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Domain.Masters.Master> GetById(int id)
        {
            return await _context.Masters.FindAsync(id);
        }

        /// <summary>
        /// Get Master from Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<Domain.Masters.Master> GetByEmail(string email)
        {
            return await _context.Masters.FirstOrDefaultAsync(m => m.Email == email);
        }

        /// <summary>
        /// Get Master from UserName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<Domain.Masters.Master> GetByUserName(string userName)
        {
            return await _context.Masters.FirstOrDefaultAsync(m => m.UserName == userName);
        }

        /// <summary>
        /// Remove Master from id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task RemoveById(int id)
        {
            _context.Masters.Remove(await GetById(id));
        }

        /// <summary>
        /// Remove Master
        /// </summary>
        /// <param name="master"></param>
        /// <returns></returns>
        public Task Remove(Domain.Masters.Master master)
        {
            _context.Masters.Remove(master);

            return Task.CompletedTask;
        }

    }
}
