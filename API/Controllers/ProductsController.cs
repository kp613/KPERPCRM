using API.Models.ProductModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs.ProductsDtos;
using System;
using API.Repository.IRepository;
using AutoMapper;
using API.Helpers;
using API.Extensions;

namespace API.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/products")]

    //[Route("api/v{version:apiVersion}/products")]
    //[ApiVersion("3.0")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public ProductsController(IProductRepository repo, IMapper mapper, ApplicationDbContext context)
        {
            _repo = repo;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("lists")]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _repo.GetProductsAsync();
            if (products == null || products.Count() <= 0)
            {
                return NotFound("没有产品信息");
            }

            var productsDto = _mapper.Map<ICollection<ProductDto>>(products);

            return Ok(productsDto);
        }

        //products/12345-12-1
        [HttpGet("{casno}")]
        public async Task<ActionResult<ProductDto>> GetProductByCasNoAsync(string casno)
        {
            var product= await _repo.GetProductByCasNoAsync(casno);
            if (product==null)             
            { 
                return NotFound($"没有该产品{casno}") ;
            }
            return Ok(product);
        }

        [HttpGet("edit/{id}")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _repo.GetProductByIdAsync(id);
            if (product == null )
            {
                return NotFound("没有该产品");
            }

            return Ok(product);
        }

        [HttpPost("add")]
        public async Task<ActionResult<ProductDto>> AddProduct([FromBody]Product product)
        {
            if (await CasNoExists(product.CasNo)) return BadRequest("该Cas No已经存在");
            if (await ProductCodeExists(product.ProductCode)) return BadRequest("该产品的代号已经存在");

            product.UpdateDay = DateTime.Now;

            _repo.AddProduct(product);

            await _repo.SaveAllAsync();

            if (product.ProductCode == null || product.ProductCode == "" )
            {
                product.ProductCode = product.Id.ToString();
                await _repo.SaveAllAsync();
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id,[FromBody] Product product)
        {
            if ((!await NoChangedCasNo(product.CasNo, product.Id)) && await CasNoExists(product.CasNo)) return BadRequest("该Cas No已经存在");
            if (product.ProductCode == "") return BadRequest("产品代号不能为空");
            if ((!await NoChangedCode(product.ProductCode, product.Id)) && await ProductCodeExists(product.ProductCode)) return BadRequest("该产品的代号已经存在");
           

            product.UpdateDay = DateTime.Now;

            _repo.UpdateProduct(product);

            await _repo.SaveAllAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _repo.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _repo.DeleteProduct(product);

            await _repo.SaveAllAsync();

            return NoContent();
        }
        //[HttpGet("producttypemain")]
        //public async Task<ActionResult<List<ProductsGroupFirst>>> GetTypeMains()
        //{
        //    var productTypeMain = await _repo.GetProductTypeMainsAsync();
        //    return Ok(productTypeMain);
        //}

        //[HttpGet("producttype")]
        //public async Task<ActionResult<List<ProductsGroupSecond>>> GetTypes()
        //{
        //    var productType = await _repo.GetProductTypesAsync();
        //    return Ok(productType);
        //}

        //[HttpGet("productintype")]
        //public async Task<ActionResult<List<ProductsListInGroupThird>>> GetProductListInTypes()
        //{
        //    var productInType = await _repo.GetProductListInTypesAsync();
        //    return Ok(productInType);
        //}

        private async Task<bool> CasNoExists(string casNo)
        {
            return await _context.Products.AnyAsync(x => x.CasNo == casNo);
        }

        private async Task<bool> NoChangedCasNo(string casNo, int id)
        {
            return await _context.Products.AnyAsync(x => x.CasNo == casNo && x.Id == id);
        }

        private async Task<bool> ProductCodeExists(string productCode)
        {
            return await _context.Products.AnyAsync(x => x.ProductCode == productCode);
        }

        private async Task<bool> NoChangedCode(string productCode,int id)
        {
            return await _context.Products.AnyAsync(x => x.ProductCode == productCode && x.Id == id);
        }
    }
}