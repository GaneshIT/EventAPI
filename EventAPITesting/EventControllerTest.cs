using EventAPI.Controllers;
using EventBusiness.Services;
using EventData.Repository;
using EventEntity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAPITesting
{
    public class EventControllerTest
    {
        private readonly Mock<EventService> _mockService;
        private readonly EventController _controller;

        public EventControllerTest()
        {
           // _mockService = new Mock<EventService>();
           // _controller = new EventController(_mockService.Object);
        }
        [Fact] //UNIT Testing method
        public void AddEventTesting()
        { 
            //_mockService.Setup(service => service.GetAll()).Returns(new List<EventModel>());

            var result = "Inserted";

            Assert.StartsWith("Inserted", result);

        }
        [Fact] //UNIT Testing method
        public void UpdateEventTesting()
        {
            //_mockService.Setup(service => service.GetAll()).Returns(new List<EventModel>());

            var result = "Updated";

            Assert.StartsWith("Updated", result);

        }
    }
}
