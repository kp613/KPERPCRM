using API.DTOs.SettingDtos;
using API.Models.AppDevModels.Settings;
using System.Collections.Generic;
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
