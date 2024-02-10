using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using uzakbaglantiAPI.Context;
using uzakbaglantiAPI.Entities;
using uzakbaglantiAPI.Model;

namespace uzakbaglantiAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BaglantiController : ControllerBase
    {
        private readonly uzakContext _context;

        public BaglantiController(uzakContext context)
        {
            _context = context;
        }



        [HttpPost("List")]

        public async Task<IActionResult> List()
        {


            try
            {
                var list = await _context.Baglanti.AsNoTracking().ToListAsync();

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
                if (ModelState.IsValid)
                {
                    if (model != null)
                    {

                        Baglanti b = new Baglanti();

                        b.sirketAd = model.sirketAd;
                        b.baglantiAd = model.baglantiAd;
                        b.baglantiId = model.baglantiId;
                        b.baglantiSifre = model.baglantiSifre;
                        b.yetkiliAd = model.yetkiliAd;
                        b.yetkiliTel = model.yetkiliTel;

                        _context.Baglanti.Add(b);
                        await _context.SaveChangesAsync();
                    }

                    return Ok(model);

                }
                else
                {

                }
            }
            catch (Exception ex)
            {


            }

            return Ok();

        }







        [HttpDelete("Delete") ]
        public async Task<IActionResult> Delete(int id )
        {
            try
            {

                var uzak = await _context.Baglanti.FindAsync(id);
                if (uzak!=null)
                {
                    _context.Baglanti.Remove(uzak);
                   await _context.SaveChangesAsync();
                    return Ok("Başarıyla Silindi...");
                }
                else
                {
                    return Ok("Uzak Bağlantı Bulunamadı....!");
                }

               
            }
            catch (Exception ex)
            {


            }

            return Ok();

        }


    }
}
