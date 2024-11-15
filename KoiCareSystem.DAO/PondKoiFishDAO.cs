using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.DAO
{
    public class PondKoiFishDAO
    {
        private CarekoisystemContext _context;
        private static PondKoiFishDAO instance;

        public PondKoiFishDAO()
        {
            _context = new CarekoisystemContext();
        }

        public static PondKoiFishDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PondKoiFishDAO();
                }

                return instance;
            }
        }


    }
}
