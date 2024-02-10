using uzakbaglantiAPI.Entities;
using uzakbaglantiAPI.Model;

namespace uzakbaglantiAPI.Repositories.Interfaces
{
    public interface IBaglantiRepository
    {
        public IEnumerable<Baglanti> AllBaglantiList();

        public void baglantiCreate(UzakBaglantiModel model);

        public void baglantiDelete(int id);

        public Baglanti GetBaglantiById(int id);
        
    }
}
