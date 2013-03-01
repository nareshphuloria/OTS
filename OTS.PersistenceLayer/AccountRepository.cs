using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using OTS.CommonLayer.DataTransferObjects;
using OTS.CommonLayer.Utilities;

namespace OTS.PersistenceLayer
{
    public class AccountRepository
    {
        public IList<AccountDTO> GetAccountDetails()
        {
            IList<AccountDTO> lstAccounts = new List<AccountDTO>();

            ////Sql Object to Access DataBase and Fetch Database Values using stored procedure            
            using (IDataReader reader = SqlHelper.ExecuteReader(
                ConnectionClass.OpenConnection(), CommandType.StoredProcedure,
                AppConstants.GETACCOUNTDETAILS))
            {
                while (reader.Read())
                {
                    lstAccounts.Add(PopulateAccountDetails(reader));
                }
            }
            return lstAccounts;
        }

        private AccountDTO PopulateAccountDetails(IDataRecord dataRecord)
        {
            AccountDTO accountDetails = new AccountDTO();
            accountDetails.Id = Convert.ToInt32(dataRecord["Id"]);
            accountDetails.CustomerId = Convert.ToInt32(dataRecord["CustomerId"]);
            accountDetails.CustomerName = Convert.ToString(dataRecord["CustomerName"]);
            accountDetails.BrokAmount = Convert.ToInt32(dataRecord["BrokAmount"]);
            accountDetails.TransAmount = Convert.ToInt32(dataRecord["TransAmount"]);
            accountDetails.Interest = Convert.ToInt32(dataRecord["Interest"]);
            accountDetails.GainLost = Convert.ToInt32(dataRecord["GainLost"]);
            accountDetails.Balance = Convert.ToInt32(dataRecord["Balance"]);
            return accountDetails;
        }

        public void SaveAccountDetails(AccountDTO accountEntity)
        {
            SqlParameter[] _sqlParams = new SqlParameter[]
            {
                new SqlParameter("@AccountId", accountEntity.Id),
                new SqlParameter("@CustomerId", accountEntity.CustomerId),
                new SqlParameter("@BrokAmount", accountEntity.BrokAmount),
                new SqlParameter("@TransAmount", accountEntity.TransAmount),
                new SqlParameter("@Interest", accountEntity.Interest),
                new SqlParameter("@GainLost", accountEntity.GainLost),
                new SqlParameter("@Balance", accountEntity.Balance)
            };

            SqlHelper.ExecuteNonQuery(ConnectionClass.OpenConnection(), CommandType.StoredProcedure,
                 AppConstants.SAVEORUPDATEACCOUNTS, _sqlParams);
        }
    }
}