using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultController : ControllerBase
    {
        private IAdultData adultService;

        public AdultController(IAdultData adultService)
        {
            this.adultService = adultService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults([FromQuery] int? id)
        {
            try
            {
                IList<Adult> adults;
                if (id == null)
                {
                    adults = await adultService.GetAdultsAsync();
                }
                else
                {
                    adults = new List<Adult>();
                    adults.Add(await adultService.GetByIdAsync(id.Value));
                }

                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdult([FromBody] Adult adult)
        {
            try
            {
                Adult added = await adultService.AddAdultAsync(adult);
                return Created($"{added.Id}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteAdult([FromRoute] int id)
        {
            try
            {
                Adult deleted = await adultService.RemoveAdultAsync(id);
                return Ok($"Deleted adult {deleted}"); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}