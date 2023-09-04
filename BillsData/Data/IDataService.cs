using System;
namespace BillssData.Data
{
	public interface IDataService
	{
            Task<IEnumerable<T>> GetData<T, P>(string query, P parameters,
           string connectionId = "DefaultConnection");

			Task SaveData<P>
                (string query, P parameters, string connectionId = "DefaultConnection");   
	}
}

