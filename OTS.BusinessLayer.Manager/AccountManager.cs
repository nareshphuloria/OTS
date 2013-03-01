using System.Collections.Generic;
using OTS.CommonLayer.DataTransferObjects;
using OTS.Models;
using OTS.PersistenceLayer;

namespace OTS.BusinessLayer.Manager
{
    public class AccountManager
    {
        public IList<AccountModel> GetAccountDetails()
        {
            AccountRepository accountRepository = new AccountRepository();
            IList<AccountModel> accountModelList = new List<AccountModel>();
            
            AutoMapper.Mapper.Map(accountRepository.GetAccountDetails(), accountModelList);
            return accountModelList;
        }

        public void SaveAccountDetails(AccountModel accountModelDetails)
        {
            AccountRepository accountRepository = new AccountRepository();
            AccountDTO accountEntity = new AccountDTO();
            
            AutoMapper.Mapper.Map(accountModelDetails, accountEntity);
            accountRepository.SaveAccountDetails(accountEntity);
        }
    }
}