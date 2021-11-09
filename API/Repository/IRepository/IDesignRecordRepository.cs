using API.Models.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.IRepository
{
    public interface IDesignRecordRepository
    {
        Task<ICollection<DesignRecord>> GetDesignRecordsAsync();

        Task<DesignRecord> GetDesignRecordByIdAsync(int id);

        void Create(DesignRecord designRecord);
        void Delete(DesignRecord designRecord);
        void Update(DesignRecord designRecord);

        Task<bool> SaveAllAsync();

        bool AddDesignRecordExists(string folderName, string componentName, string crudState);
        bool DesignRecordExists(string folderName, string componentName, string crudState, int id);
    }
}
