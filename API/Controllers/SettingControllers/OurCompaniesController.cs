using API.Data;
using API.Models.AdminModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class OurCompaniesController : ControllerBase
    {

        private readonly ApplicationDbContext _db;

        public OurCompaniesController(ApplicationDbContext _db)
        {
            this._db = _db;
        }

        // GET: Common/OurCompanies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OurCompany[]>>> Index()
        {
            var companies = await _db.OurCompany.ToListAsync();
            return Ok(companies);
        }

        // GET: Common/OurCompanies/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ourCompany = await _db.OurCompany.FindAsync(id);
            if (ourCompany == null)
            {
                return NotFound();
            }

            return Ok();
        }


        // POST: Common/OurCompanies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(OurCompany ourCompany)
        {
            if (OurCompanyExists(ourCompany.CompanyName)) return BadRequest("公司名重复");
            if (ModelState.IsValid)
            {
                _db.Add(ourCompany);
                await _db.SaveChangesAsync();
                return Ok();
            }
            return BadRequest("添加公司失败");
        }

        // GET: Common/OurCompanies/Edit/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ourCompany = await _db.OurCompany.FindAsync(id);
            if (ourCompany == null)
            {
                return NotFound();
            }
            return Ok(ourCompany);
        }

        // POST: Common/OurCompanies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, OurCompany ourCompany)
        //{
        //    if (id != ourCompany.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _db.Update(ourCompany);
        //            await _db.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!OurCompanyExists(ourCompany.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(ourCompany);
        //}

        // GET: Common/OurCompanies/Delete/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ourCompany = await _db.OurCompany
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (ourCompany == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(ourCompany);
        //}

        // POST: Common/OurCompanies/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ourCompany = await _db.OurCompany.FindAsync(id);
            _db.OurCompany.Remove(ourCompany);
            await _db.SaveChangesAsync();
            return Ok();
        }

        private bool OurCompanyExists(string companyName)
        {
            return _db.OurCompany.Any(e => e.CompanyName == companyName);
        }
    }
}
