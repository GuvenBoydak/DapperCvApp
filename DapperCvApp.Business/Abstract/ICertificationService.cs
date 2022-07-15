using DapperCvApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCvApp.Business
{
    public interface ICertificationService:IBaseService<Certification>
    {
        Task<IEnumerable<Certification>> GetActiveAsync();
    }
}
