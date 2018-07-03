using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IIAC.DataRepository.Interfaces
{
    public interface IDapperHelper
    {
        Task<IEnumerable<T>> GetAllAsync<T>(string procedureName, object parameters = null);
        T GetAsync<T>(string procedureName, object parameters = null);
        int Upsert(string procedureName, object parameters = null);
        T AddOrUpdateAsync<T>(string procedureName, object parameters = null);
        bool Delete(string procedureName, object parameters = null);
    }
}
