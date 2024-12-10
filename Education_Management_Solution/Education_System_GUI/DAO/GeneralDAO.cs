using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_System_GUI.DAO
{
    public abstract class GeneralDAO
    {
        protected readonly string _connectionString;

        public GeneralDAO()
        {
            _connectionString = "Server=.;Database=EducationSystemDB;Trusted_Connection=True;TrustServerCertificate=True;";
        }
    }
}
