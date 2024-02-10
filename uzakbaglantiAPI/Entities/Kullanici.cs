using Microsoft.AspNetCore.Mvc.RazorPages;

namespace uzakbaglantiAPI.Entities
{
    public class Kullanici
    {
        public int id { get; set; }

        public string ad { get; set; }

        public string sifre { get; set; }

    }
}
