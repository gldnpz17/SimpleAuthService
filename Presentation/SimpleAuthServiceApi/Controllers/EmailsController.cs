using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Accounts.Emails.Commands.AddEmailAddress;
using Application.Accounts.Emails.Commands.RemoveEmailAddress;
using Application.Accounts.Emails.Commands.SetPrimaryEmail;
using Application.Accounts.Emails.Commands.TryToVerifyEmailAddress;
using Application.Accounts.Emails.Commands.VerifyEmailAddress;
using Application.Accounts.Emails.Queries.GetAllEmailAddresses;
using Application.Accounts.Emails.Queries.GetPrimaryEmailAddress;
using Application.Accounts.Queries.GetAccountById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleAuthServiceApi.Common.DTOs.Request;
using SimpleAuthServiceApi.Common.DTOs.Response;

namespace SimpleAuthServiceApi.Controllers
{
    [Route("api/{accountId}/emails")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EmailsController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Set primary email.
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="setPrimaryEmailDto"></param>
        /// <returns></returns>
        [HttpPut("primary-email")]
        public async Task<ActionResult> SetPrimaryEmail([FromRoute]string accountId, [FromBody]ApiSetPrimaryEmailDto setPrimaryEmailDto)
        {
            return Ok(await _mediator.Send(
                new SetPrimaryEmailCommand()
                {
                    AccountId = Guid.Parse(accountId),
                    Email = setPrimaryEmailDto.Email
                }));
        }

        /// <summary>
        /// Get primary email.
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpGet("primary-email")]
        public async Task<ActionResult<ApiGetEmailDto>> GetPrimaryEmail([FromRoute]string accountId)
        {
            return Ok(await _mediator.Send(
                new GetPrimaryEmailAddressQuery()
                {
                    AccountId = Guid.Parse(accountId)
                }));
        }

        /// <summary>
        /// Add email to account.
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddEmail([FromRoute]string accountId, [FromBody]ApiAddEmailDto dto)
        { 
            return Ok(await _mediator.Send(
                new AddEmailAddressCommand()
                {
                    AccountId = Guid.Parse(accountId),
                    EmailAddress = dto.EmailAddress
                }));
        }

        /// <summary>
        /// Get all emails of an account.
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApiGetEmailDto>>> GetAllEmails([FromRoute]string accountId)
        {
            var result = await _mediator.Send(
                new GetAllEmailAddressesQuery()
                {
                    AccountId = Guid.Parse(accountId)
                });

            var output = new List<ApiGetEmailDto>();

            result.ForEach(i => output.Add(_mapper.Map<ApiGetEmailDto>(i)));
            
            return Ok(output);
        }

        /// <summary>
        /// Send email verification message
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("send-verification-email")]
        public async Task<ActionResult> SendEmailVerificationMessage([FromRoute]string accountId, [FromBody]ApiSendEmailVerificationMessageDto dto)
        {
            return Ok(await _mediator.Send(
                new SendEmailVerificationMessageCommand()
                {
                    AccountId = Guid.Parse(accountId),
                    EmailAddress = dto.EmailAddress
                }));
        } 

        /// <summary>
        /// Verify email.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("/api/verify-email")]
        public async Task<ActionResult> VerifyEmail([FromBody]ApiVerifyEmailDto dto)
        {
            return Ok(await _mediator.Send(
                new VerifyEmailAddressCommand()
                {
                    VerificationCode = dto.VerificationCode
                }));
        }

        /// <summary>
        /// Remove email.
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> RemoveEmail([FromRoute]string accountId, [FromBody]ApiRemoveEmailDto dto)
        {
            return Ok(await _mediator.Send(
                new RemoveEmailAddressCommand()
                {
                    AccountId = Guid.Parse(accountId),
                    EmailAddress = dto.EmailAddress
                }));
        }
    }
}
