using API.Data;
using API.Models.Setting;
using API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class DesignRecordRepository : IDesignRecordRepository 
    {
        private readonly DevDbContext _context;
        public DesignRecordRepository(DevDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<DesignRecord>> GetDesignRecordsAsync()
        {
            return await _context.DesignRecord
                .OrderBy(r => r.FolderName)
                //.ThenBy(r=>r.ComponentName)
                .ThenBy(r => r.Finished)
                .ThenByDescending(r => r.UpdateDay)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<DesignRecord> GetDesignRecordByIdAsync(int id)
        {
            return await _context.DesignRecord.FindAsync(id);
        }

        public void Create(DesignRecord designRecord)
        {
            _context.DesignRecord.Add(designRecord);
        }

        public void Delete(DesignRecord designRecord)
        {
            _context.DesignRecord.Remove(designRecord);
        }

        public void Update(DesignRecord designRecord)
        {
            _context.DesignRecord.Update(designRecord);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public bool AddDesignRecordExists(string folderName, string componentName, string crudState)
        {
            bool value = _context.DesignRecord.Any(e => e.FolderName == folderName && e.ComponentName == componentName && e.CrudState == crudState);

            return value;
        }



        public bool DesignRecordExists(string folderName, string componentName, string crudState, int id)
        {
            bool value = _context.DesignRecord.Any(e => e.FolderName == folderName && e.ComponentName == componentName && e.CrudState==crudState && e.Id != id);

            return value;

        }
    }
}
