using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using uzakbaglantiAPI.Context;
using uzakbaglantiAPI.Entities;
using uzakbaglantiAPI.Model;
using uzakbaglantiAPI.Repositories.Interfaces;

namespace uzakbaglantiAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BaglantiController : ControllerBase
    {
        private readonly IBaglantiRepository _baglantiRepo;

        public BaglantiController(IBaglantiRepository baglantiRepo)
        {
            _baglantiRepo = baglantiRepo;
        }



        [HttpPost("List")]

        public async Task<IActionResult> List()
        {


            try
            {
                var list = _baglantiRepo.AllBaglantiList();

                return Ok(list);
            }
            catch (Exception ex)
            {


            }
            return Ok();
        }



        [HttpPost("Create")]
        public async Task<IActionResult> Create(UzakBaglantiModel model)
        {
            try
            {
                _baglantiRepo.baglantiCreate(model);
                return Ok(model);
            }
            catch (Exception ex)
            {


            }

            return Ok();

        }







        [HttpGet("Getbaglanti")]
        public async Task<IActionResult> Getbaglanti(int id)
        {
            try
            {

                var baglanti = _baglantiRepo.GetBaglantiById(id);
                return Ok(baglanti);
            }
            catch (Exception)
            {


            }
            return Ok();
        }




        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                var baglanti = _baglantiRepo.GetBaglantiById(id);
                if (baglanti == null)
                {
                    return NotFound();

                }
                else
                {
                    _baglantiRepo.baglantiDelete(id);
                    return Ok("Başarıyla Silindi...");
                }


            }
            catch (Exception ex)
            {


            }

            return Ok();

        }





    }
}
