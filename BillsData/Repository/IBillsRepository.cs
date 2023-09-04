using System;
using BillssData.Models;

namespace BillssData.Repository
{
	public interface IBillsRepository
	{
        Task<bool> AddBills(Bills bills);

        Task<bool> UpdateBills(Bills bills);

        Task<Bills> GetBillsByName(string billname);

        Task<Bills> GetBillsById(int BillId);

        Task<bool> DeleteBills(int BillId);

        Task<IEnumerable<Bills>> GetBills();

    }
}

