using Dapper;
using System.Data;
using uzakbaglantiAPI.Context;
using uzakbaglantiAPI.Entities;
using uzakbaglantiAPI.Model;
using uzakbaglantiAPI.Repositories.Interfaces;

namespace uzakbaglantiAPI.Repositories.Abstract
{
    public class BaglantiRepository : IBaglantiRepository
    {

        private readonly uzakContext _context;

        public BaglantiRepository(uzakContext context)
        {
            _context = context;
        }

        public IEnumerable<Baglanti> AllBaglantiList()
        {
            var query = "Select * from baglanti";
            using var connection = _context.CreateSqlConnection();
            var baglantilar = connection.Query<Baglanti>(query);
            return baglantilar.ToList();
        }

        public void baglantiCreate(UzakBaglantiModel model)
        {
            var query = "insert into baglanti(sirketAd,baglantiAd,baglantiId,baglantiSifre,yetkiliAd,yetkiliTel)" + "Values(@sirketAd,@baglantiAd,@baglantiId,@baglantiSifre,@yetkiliAd,@yetkiliTel)";
            var parameters = new DynamicParameters();
            parameters.Add("sirketAd", model.sirketAd, DbType.String);
            parameters.Add("baglantiAd", model.baglantiAd, DbType.String);
            parameters.Add("baglantiId", model.baglantiId, DbType.String);
            parameters.Add("baglantiSifre", model.baglantiSifre, DbType.String);
            parameters.Add("yetkiliAd", model.yetkiliAd, DbType.String);
            parameters.Add("yetkiliTel", model.yetkiliTel, DbType.String);

            using var connection = _context.CreateSqlConnection();
            connection.Execute(query,parameters);


        }

        public void baglantiDelete(int id)
        {
            var query = "delete from baglanti where id=@id";
            var connection = _context.CreateSqlConnection();
            var deleted = connection.QueryFirst<Baglanti>(query, new {id=id});
            
            
        }

        public Baglanti GetBaglantiById(int id)
        {
            var query = "select * from baglanti where id=@id";
            var connection = _context.CreateSqlConnection();
            var baglanti = connection.QueryFirst<Baglanti>(query, new { id = id });

            return baglanti;
        }
    }
}
