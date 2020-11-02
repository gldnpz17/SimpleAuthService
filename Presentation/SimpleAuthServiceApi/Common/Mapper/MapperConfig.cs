using Application.Accounts.Claims.Queries.DTOs;
using Application.Accounts.Emails.Queries.DTOs;
using Application.Authentication.Queries.DTOs;
using AutoMapper;
using Domain.Entities;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using SimpleAuthServiceApi.Common.DTOs.Request;
using Application.Accounts.Commands.CreateAccount;
using Application.Authentication.Queries.PasswordLogin;
using Application.Authentication.Queries.AuthenticateToken;
using SimpleAuthServiceApi.Common.DTOs.Response;
using Application.Authentication.Commands.Logout;

namespace SimpleAuthServiceApi.Common.Mapper
{
    internal class MapperConfig
    {
        public MapperConfiguration GetConfiguration()
        {
            return new MapperConfiguration(
                config =>
                {
                    config.CreateMap<Application.Accounts.Queries.DTOs.AccountDto, ApiGetAccountDto>();

                    config.CreateMap<Application.Authentication.Queries.DTOs.AccountDto, ApiGetAccountDto>();

                    config.CreateMap<AuthTokenDto, ApiAuthTokenDto>();

                    config.CreateMap<Application.Authentication.Queries.DTOs.AccountDto, ApiVerifyTokenGetAccountDto>();

                    config.CreateMap<EmailAddressDto, ApiGetEmailDto>();

                    config.CreateMap<ClaimDto, ApiGetClaimDto>();
                });
        }
    }
}
