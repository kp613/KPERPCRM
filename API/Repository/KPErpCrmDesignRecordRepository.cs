﻿using API.Data;
using API.Models.Setting;
using API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class KPErpCrmDesignRecordRepository : IKPErpCrmDesignRecordRepository 
    {
        private readonly ApplicationDbContext _context;
        public KPErpCrmDesignRecordRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<KPErpCrmDesignRecord>> GetDesignRecordsAsync()
        {
            return await _context.KPErpCrmDesignRecord
                .OrderBy(r => r.CrudState)
                //.OrderBy(r=>r.ComponentName)
                //.OrderByDescending(r=>r.UpdateDay)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<KPErpCrmDesignRecord> GetDesignRecordByIdAsync(int id)
        {
            return await _context.KPErpCrmDesignRecord.FindAsync(id);
        }

        public void Create(KPErpCrmDesignRecord kpErpCrmDesignRecord)
        {
            _context.KPErpCrmDesignRecord.Add(kpErpCrmDesignRecord);
        }

        public void Delete(KPErpCrmDesignRecord kpErpCrmDesignRecord)
        {
            _context.KPErpCrmDesignRecord.Remove(kpErpCrmDesignRecord);
        }

        public void Update(KPErpCrmDesignRecord kpErpCrmDesignRecord)
        {
            _context.KPErpCrmDesignRecord.Update(kpErpCrmDesignRecord);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public bool DesignRecordExists(string folderName, string componentName, int id)
        {
            if (id == null)
            {
            bool value = _context.KPErpCrmDesignRecord.Any(e => e.FolderName == folderName && e.ComponentName == componentName);
                return value;
            }
            else
            {
           bool value = !_context.KPErpCrmDesignRecord.Any(e => e.FolderName == folderName && e.ComponentName == componentName && e.Id==id);
                return value;
            }
     
        }
    }
}