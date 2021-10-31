using API.Models.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.IRepository
{
    public interface IKPErpCrmDesignRecordRepository
    {
        Task<ICollection<KPErpCrmDesignRecord>> GetDesignRecordsAsync();

        Task<KPErpCrmDesignRecord> GetDesignRecordByIdAsync(int id);

        void Create(KPErpCrmDesignRecord kpErpCrmDesignRecord);
        void Delete(KPErpCrmDesignRecord kpErpCrmDesignRecord);
        void Update(KPErpCrmDesignRecord kpErpCrmDesignRecord);

        Task<bool> SaveAllAsync();

        bool DesignRecordExists(string folderName, string componentName, int id);

    }
}
