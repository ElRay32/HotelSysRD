using HotelSysRD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace HotelSysRD.AutomationTests.Utils
{
    public static class DbHelper
    {
        public static HotelContext CrearContexto()
        {
            var options = new DbContextOptionsBuilder<HotelContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HotelSysRDDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True")
                .Options;

            return new HotelContext(options);
        }
    }
}