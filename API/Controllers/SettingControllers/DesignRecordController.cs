using API.Data;
using API.Models.Setting;
using API.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.SettingControllers
{
    [ApiController]
    [Route("api/[controller]")]

    //[Route("api/v{version:apiVersion}/[controller]")]
    //[ApiVersion("3.0")]
    public class DesignRecordController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IKPErpCrmDesignRecordRepository _repo;

        public DesignRecordController(ApplicationDbContext context, IKPErpCrmDesignRecordRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetDesignRecordsAsync()
        {
            var designRecords =await _repo.GetDesignRecordsAsync();
            if (designRecords == null || designRecords.Count() <= 0) 
            {
                return NotFound("No Design Records Now");
            }
            return Ok(designRecords);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDesignRecordByIdAsync(int id)
        {
            var designRecord = await _repo.GetDesignRecordByIdAsync(id);
            if (designRecord == null)
            {
                return NotFound("Have No This Design Record");
            }
            return Ok(designRecord);
        }

        [HttpPost]
        public async Task<IActionResult>AddDesignRecord([FromBody] KPErpCrmDesignRecord kpErpCrmDesignRecord)
        {
            if (_repo.DesignRecordExists(kpErpCrmDesignRecord.FolderName, kpErpCrmDesignRecord.ComponentName, kpErpCrmDesignRecord.Id)) return BadRequest("重复输入了，请检查！");

            _repo.Create(kpErpCrmDesignRecord);

            await _repo.SaveAllAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteDesignRecord(int id)
        {
            var designRecord = await _repo.GetDesignRecordByIdAsync(id);

            if (designRecord == null)
            {
                return BadRequest("没有该产品");
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateDesignRecord(int id,[FromBody] KPErpCrmDesignRecord kpErpCrmDesignRecord)
        {
            if (_repo.DesignRecordExists(kpErpCrmDesignRecord.FolderName, kpErpCrmDesignRecord.ComponentName, kpErpCrmDesignRecord.Id)) return BadRequest("重复输入了，请检查！");

            _repo.Update(kpErpCrmDesignRecord);

            await _repo.SaveAllAsync();

            return NoContent();
        }

    }
}
