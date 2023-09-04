using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillssData.Models;
using BillssData.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BillsReminder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsReminderController : ControllerBase
    {
        private readonly IBillsRepository _billsRepository;
        public BillsReminderController(IBillsRepository billsRepository)
        {
            _billsRepository = billsRepository;
        }

        // GET: api/BillsReminder
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bills = await _billsRepository.GetBills();
            return Ok(bills);
        }

        // GET: api/BillsReminder/by-name/{billName}
        [HttpGet("by-name/{billName}")]
        public async Task<IActionResult> Get(string billName)
        {
            var bills = await _billsRepository.GetBillsByName(billName);
            if (bills is null)
                return NotFound();
            return Ok(bills);
        }

        // GET: api/BillsReminder/by-id/{BillId}
        [HttpGet("by-id/{BillId}")]
        public async Task<IActionResult> Get(int BillId)
        {
            var bills = await _billsRepository.GetBillsById(BillId);
            if (bills is null)
                return NotFound();
            return Ok(bills);
        }

        // POST: api/BillsReminder
        [HttpPost]
        public async Task<IActionResult> Post(Bills bills)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var result = await _billsRepository.AddBills(bills);
            if (!result)
                return BadRequest("Could not save data");
            return Ok();
        }

        // PUT: api/BillsReminder/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Bills newbill)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var bill = _billsRepository.GetBillsById(id);
            if (bill is null)
                return NotFound();
            newbill.BillID = id;
            var result = await _billsRepository.UpdateBills(newbill);
            if (!result)
                return BadRequest("Could not save data");
            return Ok();
        }

        // DELETE: api/BillsReminder/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var bill = _billsRepository.GetBillsById(id);
            if (bill is null)
                return NotFound();
            var result = await _billsRepository.DeleteBills(id);
            if (!result)
                return BadRequest("Could not save data");
            return Ok();
        }
    }
}


