using Application.Accounts.Claims.Queries.DTOs;
using Application.Accounts.Emails.Queries.DTOs;
using Application.Accounts.Queries.DTOs.GetAccountById;
using Application.Authentication.Queries.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Mapper
{
    internal class MapperConfig
    {
        public MapperConfiguration GetConfiguration()
        {
            return new MapperConfiguration(
                config =>
                {
                    config.CreateMap<Account, Accounts.Queries.DTOs.GetAccountById.AccountDto>();
                    config.CreateMap<Account, Authentication.Queries.DTOs.AccountDto>();
                    config.CreateMap<AccountEmailAddress, EmailAddressDto>();
                    config.CreateMap<Claim, ClaimDto>();
                    config.CreateMap<AuthToken, AuthTokenDto>().ForMember(
                        (dest) => dest.AuthToken,
                        (opt) => opt.MapFrom(src => src.TokenString));
                });
        }
    }
}
