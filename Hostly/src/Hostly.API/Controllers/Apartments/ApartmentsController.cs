using Hostly.Application.Apartments.SearchApartments;
using Hostly.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hostly.API.Controllers.Apartments
{
    [Route("api/apartments")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly ISender _sender;
        
        public ApartmentsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
       public async Task<IActionResult> SearchApartments(
       DateOnly startDate,
       DateOnly endDate,
       CancellationToken cancellationToken)
        {
            var query = new SearchApartmentsQuery(startDate, endDate);

            Result<IReadOnlyList<ApartmentResponse>> result = await _sender.Send(query, cancellationToken);

            return Ok(result.Value);
        }
    }
}
