using API.Data;
using API.DTOs.ProductsDtos;
using API.Interfaces;
using API.Models.ProductModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ProductsGroupsController : BaseApiController
    {
        private readonly IProductRepository _repository;

        public ProductsGroupsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("/api/groupfirst")]
        public async Task<ActionResult<IEnumerable<ProductsGroupFirstDto>>> GetGroupFirst()
        {
            var productsGroupFirst = await _repository.GetGroupFirstsAsync();

            if (productsGroupFirst == null || productsGroupFirst.Count()<=0)
            {
                return NotFound("没有该类别");
            }
            return Ok(productsGroupFirst);
        }
    }
}
