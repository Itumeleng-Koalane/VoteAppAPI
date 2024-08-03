﻿using Microsoft.AspNetCore.Http.HttpResults;
using VoteAppAPI.DBContext;
using VoteAppAPI.Domain_Model;
using VoteAppAPI.Repositories.Interfaces;

namespace VoteAppAPI.Repositories.Implementations
{
    public class NationalRepository : INationalRepository
    {
        private readonly VoteAppDBContext dBContext;
        public NationalRepository(VoteAppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<National> CreateNationalAsync(National national)
        {
            await dBContext.Nationals.AddAsync(national);
            await dBContext.SaveChangesAsync();

            return national;
        }

        //public async Task<National> GetAllNationalAsync()
        //{
        //    var nationalVotes = dBContext.Nationals.ToList();

        //    await dBContext.Nationals.FindAsync();
        //}
    }
}
