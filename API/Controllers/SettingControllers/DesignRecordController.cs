using API.Data;
using API.DTOs.SettingDtos;
using API.Models.AppDevModels.Settings;
using API.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
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
        private readonly AppDevDbContext _context;
        private readonly IDesignRecordRepository _repo;
        private readonly IMapper _mapper;

        public DesignRecordController(AppDevDbContext context, IDesignRecordRepository repo, IMapper mapper)
        {
            _context = context;
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDesignRecordsAsync()
        {
            var designRecords =await _repo.GetDesignRecordsAsync();
            if (designRecords == null || designRecords.Count() <= 0) 
            {
                return NotFound("No Design Records Now");
            }

            //var designRecordDto = _mapper.Map<ICollection<DesignRecordDto>>(designRecords);

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
        public async Task<IActionResult>AddDesignRecord([FromBody] DesignRecord designRecord)
        {
            if (_repo.AddDesignRecordExists(designRecord.FolderName, designRecord.ComponentName, designRecord.CrudState)) return BadRequest("新增了重复条目，请检查！");

            _repo.Create(designRecord);

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

            _repo.Delete(designRecord);

            await _repo.SaveAllAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateDesignRecord(int id,[FromBody] DesignRecord designRecord)
        {
            if (_repo.DesignRecordExists(designRecord.FolderName, designRecord.ComponentName, designRecord.CrudState, designRecord.Id)) return BadRequest("修改成重复的项目了，请检查！");

            _repo.Update(designRecord);

            await _repo.SaveAllAsync();

            return NoContent();
        }

        [HttpPatch("finish/{id}")]
        public async Task<IActionResult> UpdateDesignRecordFinishWithPatch(int id)
        {
            var designRecord =await _repo.GetDesignRecordByIdAsync(id);

            designRecord.UpdateDay = DateTime.Now;
            designRecord.Finished = !designRecord.Finished;

            _repo.Update(designRecord);

            await _repo.SaveAllAsync();

            return NoContent();
        }

        [HttpPatch("attention/{id}")]
        public async Task<IActionResult> UpdateDesignRecordAttentionWithPatch(int id)
        {
            var designRecord = await _repo.GetDesignRecordByIdAsync(id);

            designRecord.UpdateDay = DateTime.Now;
            designRecord.PayAttention = !designRecord.PayAttention;

            _repo.Update(designRecord);

            await _repo.SaveAllAsync();

            return NoContent();
        }

    }
}
