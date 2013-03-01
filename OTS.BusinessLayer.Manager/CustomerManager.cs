using System.Collections.Generic;
using OTS.CommonLayer.DataTransferObjects;
using OTS.Models;
using OTS.PersistenceLayer;

namespace OTS.BusinessLayer.Manager
{
    public class CustomerManager
    {
        public IList<CustomerModel> GetCustomerDetails()
        {
            CustomerRepository customerRepository = new CustomerRepository();
            IList<CustomerModel> customerModelList = new List<CustomerModel>();

            AutoMapper.Mapper.Map(customerRepository.GetCustomerDetails(), customerModelList);
            return customerModelList;
        }

        public void SaveCustomerDetails(CustomerModel customerModelDetails)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            CustomerDTO customerEntity = new CustomerDTO();

            AutoMapper.Mapper.Map(customerModelDetails, customerEntity);
            customerRepository.SaveCustomerDetails(customerEntity);
        }

        public CustomerModel GetCustomerById(int customerId)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            CustomerModel customerModelDetails = new CustomerModel();

            AutoMapper.Mapper.Map(customerRepository.GetCustomerById(customerId), customerModelDetails);
            return customerModelDetails;
        }

        public void DeleteCustomer(int customerId)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            customerRepository.DeleteCustomer(customerId);
        }
    }
}