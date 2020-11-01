using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Accounts.Commands.ChangeUsername;
using Application.Accounts.Commands.CreateAccount;
using Application.Accounts.Commands.DeleteAccount;
using Application.Accounts.Password.Commands.RequestPasswordReset;
using Application.Accounts.Password.Commands.ResetPassword;
using Application.Accounts.Queries.GetAccountById;
using Application.Accounts.Queries.GetAllAccounts;
using Application.Authentication.Commands.Logout;
using Application.Authentication.Queries.AuthenticateToken;
using Application.Authentication.Queries.PasswordLogin;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleAuthServiceApi.Common.DTOs.Request;
using SimpleAuthServiceApi.Common.DTOs.Response;

namespace SimpleAuthServiceApi.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AccountsController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all accounts.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApiGetAccountDto>>> GetAllAccounts()
        {
            var results = await _mediator.Send(
                new GetAllAccountsQuery()
                {

                });

            var output = new List<ApiGetAccountDto>();

            results.ForEach(i => output.Add(_mapper.Map<ApiGetAccountDto>(i)));

            return Ok(output);
        }

        /// <summary>
        /// Get account by account id.
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpGet("{accountId}")]
        public async Task<ActionResult<ApiGetAccountDto>> GetAccountById([FromRoute]string accountId)
        {
            var result = await _mediator.Send(
                new GetAccountByIdQuery()
                {
                    Id = Guid.Parse(accountId)
                });

            return Ok(_mapper.Map<ApiGetAccountDto>(result));
        }

        /// <summary>
        /// Create account.
        /// </summary>
        /// <param name="dto"></param>
        [HttpPost]
        public async Task<ActionResult> CreateAccount([FromBody]ApiCreateAccountDto dto)
        {
            return Ok(await _mediator.Send(
                new CreateAccountCommand() 
                { 
                    Username = dto.Username,
                    EmailAddress = dto.EmailAddress,
                    Password = dto.Password
                }));
        }

        /// <summary>
        /// Delete account.
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpDelete("{accountId}")]
        public async Task<ActionResult> DeleteAccount([FromRoute]string accountId)
        {
            return Ok(await _mediator.Send(
                new DeleteAccountCommand() 
                {
                    Id = Guid.Parse(accountId) 
                }));
        }

        /// <summary>
        /// Log in using username & password to get auth token.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("login")]
        public async Task<ActionResult<ApiAuthTokenDto>> PasswordLogin([FromBody]ApiPasswordLoginDto dto)
        {
            var result = await _mediator.Send(
                new PasswordLoginQuery()
                {
                    Username = dto.Username,
                    Password = dto.Password
                });

            return Ok(_mapper.Map<ApiAuthTokenDto>(result));
        } 

        /// <summary>
        /// Authenticate using auth token to get account details.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("verify-auth-token")]
        public async Task<ActionResult<ApiVerifyTokenGetAccountDto>> AuthenticateToken([FromBody]ApiAuthenticateTokenDto dto)
        {
            var result = await _mediator.Send(
                new AuthenticateTokenQuery()
                {
                    AuthToken = dto.AuthToken
                });

            return Ok(_mapper.Map<ApiAuthenticateTokenDto>(result));
        }

        /// <summary>
        /// Log out using auth token.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("logout")]
        public async Task<ActionResult> Logout([FromBody]ApiLogoutDto dto)
        {
            return Ok(await _mediator.Send(_mapper.Map<LogoutCommand>(dto)));
        }

        /// <summary>
        /// Change username.
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{accountId}/username")]
        public async Task<ActionResult> ChangeUsername([FromRoute]string accountId, [FromBody]ApiUpdateUsernameDto dto)
        {
            return Ok(await _mediator.Send(
                new UpdateUsernameCommand()
                {
                    AccountId = Guid.Parse(accountId),
                    NewUsername = dto.NewUsername
                }));
        }

        /// <summary>
        /// Send password reset email.
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpPost("{accountId}/password/send-reset-email")]
        public async Task<ActionResult> SendPasswordResetEmail([FromRoute]string accountId)
        {
            return Ok(await _mediator.Send(
                new RequestPasswordResetCommand()
                {
                    AccountId = Guid.Parse(accountId)
                }));
        }

        /// <summary>
        /// Reset password using reset token.
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("{accountId}/password/reset")]
        public async Task<ActionResult> ResetPassword([FromRoute]string accountId, [FromBody]ApiResetPasswordDto dto)
        {
            return Ok(await _mediator.Send(
                new ResetPasswordCommand()
                {
                    AccountId = Guid.Parse(accountId),
                    NewPassword = dto.NewPassword,
                    ResetToken = dto.ResetToken
                }));
        }
    }
}
