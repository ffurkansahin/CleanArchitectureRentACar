using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Reflection;

namespace CleanArchitecture.UnitTest
{
    public class CarControllerUnitTest
    {
        [Fact]
        public async void Create_ReturnsOkResult_WhenRequestIsValid()
        {
            //Arrange (Tanýmlama)
            var mediatrMock = new Mock<IMediator>();
            CreateCarCommand createCarCommand = new("Honda","Civic",5000);
            MessageResponse response = new("Araç Baþarýyla Kaydedildi");
            CancellationToken cancellationToken = new CancellationToken();

            mediatrMock.Setup(i=>i.Send(createCarCommand, cancellationToken)).ReturnsAsync(response);

            CarsController carsController = new(mediatrMock.Object);

            //Act (Eylem)
            var result = await carsController.Create(createCarCommand, cancellationToken);

            //Assert (Kontrol)
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<MessageResponse>(okResult.Value);
            Assert.Equal(response, returnValue);
            mediatrMock.Verify(i => i.Send(createCarCommand, cancellationToken), Times.Once);
        }
    }
}