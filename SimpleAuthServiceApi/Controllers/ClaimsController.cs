using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Accounts.Claims.Commands.AddClaim;
using Application.Accounts.Claims.Commands.RemoveClaim;
using Application.Accounts.Claims.Commands.UpdateClaimValue;
using Application.Accounts.Claims.Queries.GetAllClaims;
using Application.Accounts.Claims.Queries.GetClaimValue;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleAuthServiceApi.Common.DTOs.Request;
using SimpleAuthServiceApi.Common.DTOs.Response;

namespace SimpleAuthServiceApi.Controllers
{
    [Route("api/{accountId}/claims")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ClaimsController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Add claim.
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddClaim([FromRoute]string accountId, [FromBody]ApiAddClaimDto dto)
        {
            return Ok(await _mediator.Send(
                new AddClaimCommand()
                {
                    AccountId = Guid.Parse(accountId),
                    ClaimName = dto.ClaimName,
                    ClaimValue = dto.ClaimValue
                }));
        }

        /// <summary>
        /// Get all claims.
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApiGetClaimDto>>> GetAllClaims([FromRoute]string accountId)
        {
            var result = await _mediator.Send(
                new GetAllClaimsQuery()
                {
                    AccountId = Guid.Parse(accountId)
                });

            var output = new List<ApiGetClaimDto>();

            result.ForEach(i => output.Add(_mapper.Map<ApiGetClaimDto>(i)));

            return Ok(output);
        }

        /// <summary>
        /// Get claim value
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="claimName"></param>
        /// <returns></returns>
        [HttpGet("{claimName}")]
        public async Task<ActionResult<ApiGetClaimDto>> GetClaimValue([FromRoute]string accountId, [FromRoute]string claimName)
        {
            var result = await _mediator.Send(
                new GetClaimValueQuery()
                {
                    AccountId = Guid.Parse(accountId),
                    ClaimName = claimName
                });

            return _mapper.Map<ApiGetClaimDto>(result);
        }

        /// <summary>
        /// Update claim value.
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="claimName"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{claimName}")]
        public async Task<ActionResult> UpdateClaimValue([FromRoute]string accountId, [FromRoute]string claimName, [FromBody]ApiUpdateClaimValueDto dto)
        {
            return Ok(await _mediator.Send(
                new UpdateClaimValueCommand()
                {
                    AccountId = Guid.Parse(accountId),
                    ClaimName = claimName,
                    ClaimValue = dto.ClaimValue
                }));
        }

        /// <summary>
        /// Remove claim
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="claimName"></param>
        /// <returns></returns>
        [HttpDelete("{claimName}")]
        public async Task<ActionResult> RemoveClaim([FromRoute]string accountId, [FromRoute]string claimName)
        {
            return Ok(await _mediator.Send(
                new RemoveClaimCommand()
                {
                    AccountId = Guid.Parse(accountId),
                    ClaimName = claimName
                }));
        }
    }
}
