using Dapper;
using uzakbaglantiAPI.Context;
using uzakbaglantiAPI.Entities;
using uzakbaglantiAPI.Repositories.Interfaces;

namespace uzakbaglantiAPI.Repositories.Abstract
{
    public class LoginRepository : ILoginRepository
    {
        private readonly uzakContext _context;

        public LoginRepository(uzakContext context)
        {
            _context = context;
        }



        public Kullanici kullaniciVarMi(string ad, string sifre)
        {
            var query = "select * from kullanici where ad=@ad and sifre=@sifre";
            using var connection = _context.CreateSqlConnection();
            var kul = connection.QueryFirst<Kullanici>(query, new { ad = ad, sifre = sifre });

            return kul;
        }
    }
}
