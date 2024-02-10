using uzakbaglantiAPI.Entities;

namespace uzakbaglantiAPI.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        public Kullanici kullaniciVarMi(string ad, string sifre);
    }
}
