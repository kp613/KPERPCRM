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

namespace API.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    //[Route("api/products")]
    [Route("api/v{version:apiVersion}/products")]
    [ApiVersion("2.0")]
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

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _repo.GetProductsAsync();
            if(products==null || products.Count() <= 0)
            {
                return NotFound("没有产品信息");
            }

            var productsDto = _mapper.Map<ICollection<ProductDto>>(products);

            return Ok(productsDto);
        }

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

        [HttpPost("add")]
        public async Task<ActionResult<Product>> AddProduct([FromBody]Product product)
        {
            if (await CasNoExists(product.CasNo)) return BadRequest("该Cas No已经存在");
            
            product.UpdateDay = DateTime.Now;
            _repo.AddProduct(product);
            await _repo.SaveAllAsync();
            return Ok();
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
    }
}