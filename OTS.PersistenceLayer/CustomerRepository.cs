using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using OTS.CommonLayer.DataTransferObjects;
using OTS.CommonLayer.Utilities;

namespace OTS.PersistenceLayer
{
    public class CustomerRepository
    {
        public IList<CustomerDTO> GetCustomerDetails()
        {
            IList<CustomerDTO> lstCustomers = new List<CustomerDTO>();

            ////Sql Object to Access DataBase and Fetch Database Values using stored procedure            
            using (IDataReader reader = SqlHelper.ExecuteReader(
                ConnectionClass.OpenConnection(), CommandType.StoredProcedure,
                AppConstants.GETCUSTOMERDETAILS))
            {
                while (reader.Read())
                {
                    lstCustomers.Add(PopulateCustomerDetails(reader));
                }
            }
            return lstCustomers;
        }

        private CustomerDTO PopulateCustomerDetails(IDataRecord dataRecord)
        {
            CustomerDTO customerDetails = new CustomerDTO();
            customerDetails.Id = Convert.ToInt32(dataRecord["Id"]);
            customerDetails.FirstName = Convert.ToString(dataRecord["FirstName"]);
            customerDetails.LastName = Convert.ToString(dataRecord["LastName"]);
            customerDetails.Address = Convert.ToString(dataRecord["Address"]);
            customerDetails.Phone = Convert.ToString(dataRecord["Phone"]);
            customerDetails.Email = Convert.ToString(dataRecord["Email"]);
            return customerDetails;
        }

        public void SaveCustomerDetails(CustomerDTO customerEntity)
        {
            SqlParameter[] _sqlParams = new SqlParameter[]
            {
                new SqlParameter("@Id", customerEntity.Id),
                new SqlParameter("@FirstName", customerEntity.FirstName),
                new SqlParameter("@LastName", customerEntity.LastName),
                new SqlParameter("@Address", customerEntity.Address),
                new SqlParameter("@Phone", customerEntity.Phone),
                new SqlParameter("@Email", customerEntity.Email)
            };

            SqlHelper.ExecuteNonQuery(ConnectionClass.OpenConnection(), CommandType.StoredProcedure,
                 AppConstants.SAVEORUPDATECUSTOMER, _sqlParams);
        }

        public void DeleteCustomer(int customerId)
        {
            SqlParameter _sqlParam = new SqlParameter("@CustomerId", customerId);

            SqlHelper.ExecuteNonQuery(ConnectionClass.OpenConnection(), CommandType.StoredProcedure,
                 AppConstants.DELETECUSTOMER, _sqlParam);
        }

        public CustomerDTO GetCustomerById(int customerId)
        {
            SqlParameter _sqlParam = new SqlParameter("@CustomerId", customerId);
            CustomerDTO customerEntity = new CustomerDTO();

            ////Sql Object to Access DataBase and Fetch Database Values using stored procedure            
            using (IDataReader reader = SqlHelper.ExecuteReader(
                ConnectionClass.OpenConnection(), CommandType.StoredProcedure,
                AppConstants.GETCUSTOMERBYID, _sqlParam))
            {
                if (reader.Read())
                {
                    customerEntity = PopulateCustomerDetails(reader);
                }
            }
            return customerEntity;
        }
    }
}