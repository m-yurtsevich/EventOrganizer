using EventOrganizer.Core.DTO;
using EventOrganizer.Core.Queries;
using EventOrganizer.Core.Queries.EventQueries;
using EventOrganizer.WebClient.Views;
using Microsoft.AspNetCore.Mvc;

namespace EventOrganizer.WebClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IQuery<GetEventListQueryParameters, IList<EventDTO>> getEventListQuery;
        private readonly IQuery<GetEventByIdQueryParameters, EventDetailDTO> getEventByIdQuery;

        public EventController(
            IQuery<GetEventListQueryParameters, IList<EventDTO>> getEventListQuery,
            IQuery<GetEventByIdQueryParameters, EventDetailDTO> getEventByIdQuery)
        {
            this.getEventListQuery = getEventListQuery
                ?? throw new ArgumentNullException(nameof(getEventListQuery));
            this.getEventByIdQuery = getEventByIdQuery
                ?? throw new ArgumentNullException(nameof(getEventByIdQuery));
        }

        // GET: api/<EventController>
        [HttpGet]
        public ActionResult<IList<EventDTO>> Get(EventListSearchSettings searchSettings)
        {
            throw new NotImplementedException();
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public ActionResult<EventDetailDTO> Get(int id)
        {
            var result = getEventByIdQuery.Execute(new GetEventByIdQueryParameters { Id = id });

            return result;
        }

        // POST api/<EventController>
        [HttpPost]
        public ActionResult<EventDetailDTO> Post([FromBody] EventDetailDTO eventView)
        {
            throw new NotImplementedException();
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public ActionResult<EventDetailDTO> Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
