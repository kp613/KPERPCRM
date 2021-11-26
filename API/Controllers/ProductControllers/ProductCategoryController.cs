using API.Data;
using API.DTOs.ProductsDtos;
using API.Models.ProductModels;
using API.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.ProductControllers
{
    public class ProductCategoryController : BaseApiController
    {
        private readonly IProductRepository _repository;

        public ProductCategoryController(IProductRepository repository)
        {
            _repository = repository;
        }

   
    }
}
