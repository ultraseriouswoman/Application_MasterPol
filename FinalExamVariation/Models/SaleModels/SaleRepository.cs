using FinalExamVariation.Utilities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamVariation.Models.SaleModels
{
    public class SaleRepository: RepositoryBase
    {
        public List<Sales> Repository { get; set; }

        public SaleRepository()
        {
            Repository = GetAllSales();
        }

        public List<Sales> GetAllSales()
        {
            List<Sales> listOfSales = [];

            string cmdText = "select Sales.PartnerID, SUM(Count) AS Count from Sales\r\ninner join Partners as Part on Sales.PartnerID = Part.ID\r\ngroup by Sales.PartnerID ";

            using (var conn = GetConnection())
            using (var cmd = new SqlCommand(cmdText, conn))
            {
                if (conn == null)
                    throw new Exception("Связь с базой данных накрылась медным тазом...");

                conn.Open();

                SqlDataAdapter dataAdapter = new(cmd);
                DataTable dataTable = new();
                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    Sales sale = new();

                    sale.PartnerID = (int)row["PartnerID"];
                    sale.Count = (int)row["Count"];

                    listOfSales.Add(sale);
                }
            }
            return listOfSales;
        }
    }
}
