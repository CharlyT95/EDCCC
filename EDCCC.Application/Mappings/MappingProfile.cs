using EDCCC.Application.Features.Customer.Queries.GetCustomersList;
using EDCCC.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDCCC.Application.Features.CCards.Command.CreateCCard;
using EDCCC.Application.Features.CCards.Command.UpdateCCard;
using EDCCC.Application.Features.Accounts.Commands.CreateAccounts;
using EDCCC.Application.Features.Bills.Commands.CreateBills;
using EDCCC.Application.Features.Bills.Queries.GetBillsList;
using EDCCC.Application.Features.Customer.Commands.CreateCustomer;
using EDCCC.Application.Features.Accounts.Queries.GetAccountsList;
using EDCCC.Application.Features.CCards.Queries.GetCCardsList;

namespace EDCCC.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customers, CustomersVm>();
            CreateMap<CreateCustomerCommand,Customers>();

            CreateMap<CreateAccountsCommand, Account>();
            CreateMap<Account,AccountsVm>();

            CreateMap<Bill,BillVm>();
            CreateMap<CreateBillsCommand,Bill>();

            CreateMap<CCard,CCardsVm>();
            CreateMap<CreateCCardCommand, CCard>();
            CreateMap<UpdateCCardCommand, CCard>();

            

        } 

    }
}
