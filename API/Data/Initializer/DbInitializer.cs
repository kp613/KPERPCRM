using API.Models.ProductModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace API.Data.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly ILoggerFactory _loggerFactory;

        public DbInitializer(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _loggerFactory = loggerFactory;
        }

        public async void Initialize()
        {
            try
            {
               
                if (!_context.Products.Any())
                {
                    var productsData = File.ReadAllText("Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        _context.Products.Add(item);
                    }

                    await _context.SaveChangesAsync();
                }

                if (!_context.ProductsGroupFirst.Any())
                {
                    //var productTypeMainData = File.ReadAllText("Data/SeedData/productsgroupfirst.json");
                    //var productTypeMain = JsonSerializer.Deserialize<List<ProductsGroupFirst>>(productTypeMainData);

                    var productTypeMain = new ProductsGroupFirst[]
                   {
                        new ProductsGroupFirst{Id=1,NameCh="原料药",NameEn="Active Pharmaceutical Ingredients(API)"},
                        new ProductsGroupFirst{Id=2,NameCh="生化化学品",NameEn="BioChemicals"},
                        new ProductsGroupFirst{Id=3,NameCh="天然产物",NameEn="Natural Products"},
                        new ProductsGroupFirst{Id=4,NameCh="催化剂",NameEn="Catalysts"},
                        new ProductsGroupFirst{Id=5,NameCh="合成砌块",NameEn="Organic Building Blocks"},
                        new ProductsGroupFirst{Id=6,NameCh="对照品",NameEn="Reference Substance"},
                        new ProductsGroupFirst{Id=7,NameCh="功能化学品",NameEn="Functional Chemical"},
                        new ProductsGroupFirst{Id=8,NameCh="材料化学品",NameEn="Material Chemicals"},
                        new ProductsGroupFirst{Id=30,NameCh="杂类",NameEn="Miscellaneous"},
                   };


                    foreach (var itemtypemain in productTypeMain)
                    {
                        _context.ProductsGroupFirst.Add(itemtypemain);
                    }

                    await _context.SaveChangesAsync();
                }

                if (!_context.ProductsGroupSecond.Any())
                {
                    //var productTypeData = File.ReadAllText("Data/SeedData/productsgroupsecond.json");
                    //var productType = JsonSerializer.Deserialize<List<ProductsGroupSecond>>(productTypeData);
                    var productType = new ProductsGroupSecond[]
{
                        new ProductsGroupSecond{Id=1,ProductsGroupFirstId=1,NameCh="头孢类",NameEn="Cephalosporin"},
                        new ProductsGroupSecond{Id=2,ProductsGroupFirstId=1,NameCh="抗肿瘤",NameEn="Anti-Neoplastic"},
                        new ProductsGroupSecond{Id=3,ProductsGroupFirstId=7,NameCh="香料化学品",NameEn="Fragrance Perfume Chemicals"},
                        new ProductsGroupSecond{Id=4,ProductsGroupFirstId=2,NameCh="生化原料",NameEn="BioChemical Material"},
                        new ProductsGroupSecond{Id=5,ProductsGroupFirstId=8,NameCh="光电化学品",NameEn="Opto-electronics Chemicals"},
                        new ProductsGroupSecond{Id=6,ProductsGroupFirstId=7,NameCh="个护化学品",NameEn="Personal Care Chemicals"},
                        new ProductsGroupSecond{Id=7,ProductsGroupFirstId=7,NameCh="阻燃剂",NameEn="Fire Retardant"},
                        new ProductsGroupSecond{Id=8,ProductsGroupFirstId=8,NameCh="有机杂质",NameEn="Organic Impurity"},
                        new ProductsGroupSecond{Id=9,ProductsGroupFirstId=8,NameCh="新化合物",NameEn="New Chemicals"},
};

                    foreach (var itemtype in productType)
                    {
                        _context.ProductsGroupSecond.Add(itemtype);
                    }

                    await _context.SaveChangesAsync();
                }

                if (!_context.ProductsGroupThird.Any())
                {
                    var productThirdData = File.ReadAllText("Data/SeedData/productsgroupthird.json");
                    var productThirdType = JsonSerializer.Deserialize<List<ProductsGroupThird>>(productThirdData);

                    foreach (var third in productThirdType)
                    {
                        _context.ProductsGroupThird.Add(third);
                    }

                    await _context.SaveChangesAsync();
                }

                if (!_context.ProductsGroupThirdProducts.Any())
                {
                    var productInTypes = new ProductsGroupThirdProducts[]
                    {
                        new ProductsGroupThirdProducts{ProductId=1,ProductsGroupThirdId=2},
                        new ProductsGroupThirdProducts{ProductId=1,ProductsGroupThirdId=6},
                        new ProductsGroupThirdProducts{ProductId=3,ProductsGroupThirdId=6},
                        new ProductsGroupThirdProducts{ProductId=3,ProductsGroupThirdId=2},
                        new ProductsGroupThirdProducts{ProductId=6,ProductsGroupThirdId=2},
                        new ProductsGroupThirdProducts{ProductId=7,ProductsGroupThirdId=3},
                        new ProductsGroupThirdProducts{ProductId=3,ProductsGroupThirdId=2},
                    };

                    foreach (var itemintype in productInTypes)
                    {
                        _context.ProductsGroupThirdProducts.Add(itemintype);
                    }

                    await _context.SaveChangesAsync();
                }

            }

            catch (Exception ex)
            {
                var logger = _loggerFactory.CreateLogger<DbInitializer>();
                logger.LogError(ex.Message);
            }

            return;
        }
    }
}
