using API.Data;
using API.DTOs.ProductsDtos;
using API.Models.AppWebModels.ProductWeb.Categories;
using API.Models.ProductModels;
using API.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.CategoryControllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Route("api/products")]
    public class CategoryController : BaseApiController
    {
        private readonly AppWebDbContext _webDbContext;

        public CategoryController(AppWebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }

        [HttpGet("first")]
        public async Task<ActionResult> GetProductCategoryFirstList()
        {
            var firsts = await _webDbContext.ProductCategoryFirsts
                .AsNoTracking()
                .ToListAsync();

            if (firsts == null || firsts.Count() <= 0)
            {
                return NotFound("没有产品主类别");
            }

            return Ok(firsts);
        }

        [HttpPost("first")]
        public async Task<ActionResult> AddCategoryFirst([FromBody] ProductCategoryFirst categoryFirst)
        {
            if (nameChForFirstExists(categoryFirst.NameCh)) return BadRequest("产品主类别 中文名重复");
            if (nameEnForFirstExists(categoryFirst.NameEn)) return BadRequest("产品主类别 英文名重复");

            if (ModelState.IsValid)
            {
                _webDbContext.Add(categoryFirst);
                await _webDbContext.SaveChangesAsync();

                var firstId = categoryFirst.Id;

                return Ok(firstId);
            }
            return BadRequest("添加主类别失败");            
        }

        [HttpPost("second")]
        public async Task<ActionResult<ProductDto>> AddCategorySecond([FromBody] ProductCategorySecond categorySecond)
        {
            if (nameChForFirstExists(categorySecond.NameCh)) return BadRequest("产品次类别 中文名重复");
            if (nameEnForFirstExists(categorySecond.NameEn)) return BadRequest("产品次类别 英文名重复");

            if (ModelState.IsValid)
            {
                _webDbContext.Add(categorySecond);
                await _webDbContext.SaveChangesAsync();

                var firstId = categorySecond.Id;

                return Ok(firstId);
            }
            return BadRequest("添加公司失败");
        }

        [HttpGet("second/{firstId}")]
        public async Task<ActionResult> GetProductCategorySecondList(int firstId)
        {
            var seconds = await _webDbContext.ProductCategorySeconds
                .Where(s=>s.ProductCategoryFirstId==firstId)
                .AsNoTracking()
                .ToListAsync();

            if (seconds == null || seconds.Count() <= 0)
            {
                return NotFound("没有这个主类别的次类别");
            }

            return Ok(seconds);
        }

        private bool nameChForFirstExists(string nameCh)
        {
            return _webDbContext.ProductCategoryFirsts.Any(e => e.NameCh == nameCh);
        }
        private bool nameEnForFirstExists(string nameEn)
        {
            return _webDbContext.ProductCategoryFirsts.Any(e => e.NameEn == nameEn);
        }
    }
}
