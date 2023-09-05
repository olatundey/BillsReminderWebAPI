using System;
using BillssData.Data;
using BillssData.Models;

namespace BillssData.Repository
{
public class BillsRepository : IBillsRepository
{
    private readonly IDataService _db;

    public BillsRepository(IDataService db)
    {
        _db = db;
    }

    public async Task<bool> AddBills(Bills bills)
    {
        try
        {
            string query = "insert into bills(BillName, Description, Amount, DueDate) values(@BillName, @Description, @Amount, @DueDate)";
    await _db.SaveData(query, new { BillName = bills.BillName, Description = bills.Description, Amount = bills.Amount, DueDate = bills.DueDate});
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> DeleteBills(int BillId)
    {
        try
        {
            string query = "delete from bills where BillID=@BillID";
            await _db.SaveData(query, new { BillID = BillId });
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }


public async Task<IEnumerable<Bills>> GetBills()
{
string query = "select * from bills";
var allBills = await _db.GetData<Bills, dynamic>(query, new { });
return allBills;
}


public async Task<Bills> GetBillsByName(string billname)
{
string query = "select * from bills where BillName=@BillName";
IEnumerable<Bills> bill = await _db.GetData<Bills, dynamic>(query, new { BillName = billname });
return bill.FirstOrDefault();
}

        public async Task<Bills> GetBillsById(int BillId)
{
        string query = "select * from bills where BillID=@BillID";
        IEnumerable<Bills> bill = await _db.GetData<Bills, dynamic>(query, new { BillID = BillId });
        return bill.FirstOrDefault();
    }

        public async Task<bool> UpdateBills(Bills bills)
        {
            try
            {
                string query = "UPDATE bills SET BillName = @BillName, Description = @Description, Amount = @Amount, DueDate = @DueDate WHERE BillID = @BillID";

                await _db.SaveData(query, new
                {
                    bills.BillName,
                    bills.Description,
                    bills.Amount,
                    bills.DueDate,
                    bills.BillID
                });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}

