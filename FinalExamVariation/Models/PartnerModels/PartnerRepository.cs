using FinalExamVariation.Utilities;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamVariation.Models.PartnerModels
{
    public class PartnerRepository : RepositoryBase, IParentRepository
    {
        public List<Partners> Repository { get; set; }
        private List<PartnerTypes> PartnerTypes { get; set; }
        private List<Addresses> Addresses { get; set; }

        public PartnerRepository() 
        {
            PartnerTypes = GetPartnerTypes();
            Addresses = GetAddresses();
            Repository = GetAll();
        }

        private List<PartnerTypes> GetPartnerTypes()
        {
            List<PartnerTypes> listofPTypes = [];

            string cmdText = "select * from PartnerTypes";

            using (var conn = GetConnection())
            using (var cmd = new SqlCommand(cmdText, conn))
            {
                if (conn == null)
                    throw new Exception("Связь с базой данных накрылась медным тазом...");

                SqlDataAdapter dataAdapter = new(cmd);
                DataTable dataTable = new();
                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    PartnerTypes ptype = new();

                    ptype.ID = (int)row["ID"];
                    ptype.Title = (string)row["Title"];

                    listofPTypes.Add(ptype);
                }
            }
            return listofPTypes;
        }

        private List<Addresses> GetAddresses()
        {
            List<Addresses> listOfAddresses = [];

            string cmdText = "select * from Addresses";

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
                    Addresses address = new();

                    address.ID = (int)row["ID"];
                    address.PortalCode = (int)row["PortalCode"];
                    address.Region = (string)row["Region"];
                    address.Town = (string)row["Town"];
                    address.Street = (string)row["Street"];
                    address.Number = (int)row["Number"];
                    address.FullAddress = (string)row["FullAddress"];

                    listOfAddresses.Add(address);
                }
            }
            return listOfAddresses;
        }

        public List<Partners> GetAll()
        {
            List<Partners> listOfPartners = [];

            string cmdText = "select * from Partners";
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
                    Partners partner = new();

                    partner.ID = (int)row["ID"];
                    partner.PartnerTypeID = (int)row["PartnerType"];
                    partner.PartnerType = PartnerTypes.FirstOrDefault(x => x.ID == partner.PartnerTypeID);
                    partner.Title = (string)row["Title"];
                    partner.Director = (string)row["Director"];
                    partner.Email = (string)row["Email"];
                    partner.Number = "+7 " + (string)row["Number"];
                    partner.AddressID = (int)row["Address"];
                    partner.Address = Addresses.FirstOrDefault(x => x.ID == partner.AddressID);
                    partner.INN = (string)row["INN"];
                    partner.Rating = (int)row["Rating"];

                    listOfPartners.Add(partner);
                }
            }
            return listOfPartners;
        }
    }
}
