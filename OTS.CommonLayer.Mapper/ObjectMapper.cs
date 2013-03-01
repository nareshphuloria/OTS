using OTS.CommonLayer.DataTransferObjects;
using OTS.Models;

namespace OTS.CommonLayer.Mapper
{
    public class ObjectMapper : IObjectMapper
    {
        public void CreateMap()
        {
            AutoMapper.Mapper.CreateMap<AccountDTO, AccountModel>();
            AutoMapper.Mapper.CreateMap<AccountModel, AccountDTO>();

            AutoMapper.Mapper.CreateMap<CustomerDTO, CustomerModel>();
            AutoMapper.Mapper.CreateMap<CustomerModel, CustomerDTO>();
        }
    }
}