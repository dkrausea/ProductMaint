using AutoMapper;
using Core.Model;

namespace WithAutomapper.Models
{
    public class ExampleProfile : Profile
    {
        protected override void Configure()
        {
            ForSourceType<Name>().AddFormatter<NameFormatter>();
            ForSourceType<decimal>().AddFormatExpression(context => 
                ((decimal) context.SourceValue).ToString("c"));

            CreateMap<Customer, CustomerInfo>()
                .ForMember(x => x.ShippingAddress, opt =>
                {
                    opt.AddFormatter<AddressFormatter>();
                });
        }
    }
}