using AutoMapper;
using EventOrganizer.Core.DTO;
using EventOrganizer.Core.Queries.EventQueries;
using EventOrganizer.Core.Repositories;
using EventOrganizer.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EventOrganizer.Core.Tests.Queries.EventQueries
{
    public class GetEventByIdQueryTest
    {
        private readonly Mock<IEventRepository> eventRepositoryMoq;
        private readonly Mock<IMapper> mapperMoq;
        private readonly GetEventByIdQuery underTest;

        public GetEventByIdQueryTest()
        {
            eventRepositoryMoq = new Mock<IEventRepository>();
            mapperMoq = new Mock<IMapper>();

            underTest = new GetEventByIdQuery(eventRepositoryMoq.Object, mapperMoq.Object);
        }

        [Fact]
        public void ExecuteShouldReturnExpectedValue()
        {
            var parameters = new GetEventByIdQueryParameters { Id = 1 };
            var eventEntity = new EventModel();
            var eventDto = new EventDetailDTO();

            eventRepositoryMoq.Setup(er => er.Get(parameters.Id))
                .Returns(eventEntity);

            mapperMoq.Setup(m => m.Map<EventDetailDTO>(eventEntity))
                .Returns(eventDto);

            var result = underTest.Execute(parameters);

            Assert.Equal(result, eventDto);
        }

        [Fact]
        public void ExecuteShouldThrowException()
        {
            var parameters = new GetEventByIdQueryParameters { Id = 1 };

            eventRepositoryMoq.Setup(er => er.Get(parameters.Id))
                .Returns((EventModel)null);

            Assert.Throws<ArgumentOutOfRangeException>(() => underTest.Execute(parameters));
        }
    }
}
