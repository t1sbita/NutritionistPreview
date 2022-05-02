using NUnit.Framework;
using Moq;
using NutritionistPreview.Api.Business.Services;
using NutritionistPreview.Api.Infrastructure.Interfaces;
using NutritionistPreview.Api.Core.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System;
using NutritionistPreview.Api.Test.Mocks;
using System.Linq;
using NutritionistPreview.Api.Core.Exceptions;
using System.Collections.Generic;

namespace NutritionistPreview.Api.Test.Service
{
    class AppointmentServiceTest
    {
        private AppointmentService _appointmentService;
        private Mock<IAppointmentRepository> _appointmentRepository;

        [SetUp]
        public void Setup()
        {
            var logger = new Mock<ILogger<Appointment>>();
            _appointmentRepository = new Mock<IAppointmentRepository>();
            _appointmentService = new AppointmentService(_appointmentRepository.Object,logger.Object);
        }

        [Test]
        public void AddAppointment()
        {
            //Arrange
            var appointment = AppointmentTestSeed.GetNewAppointment();

            //Act
            var result = _appointmentService.SaveAppointment(appointment).Result;

            //Assert
            Assert.IsNotNull(result);
            _appointmentRepository.Verify(x => x.Add(It.IsAny<Appointment>()), Times.Once);
        }

        [Test]
        public void UpdateAppointment()
        {
            //Arrange
            var appointment = AppointmentTestSeed.GetAppointment();

            //Act
            var result = _appointmentService.SaveAppointment(appointment).Result;

            //Assert
            Assert.IsNotNull(result);
            _appointmentRepository.Verify(x => x.Update(It.IsAny<Appointment>()), Times.Once);
        }

        [Test]
        public void GetbyIdSucess()
        {
            //Arrange
            _appointmentRepository.Setup(x => x.GetById(It.IsAny<long>())).Returns(AppointmentTestSeed.GetAppointment());

            //Act
            var result = _appointmentService.GetById(It.IsAny<long>()).Result;

            //Assert
            Assert.IsNotNull(result);
            _appointmentRepository.Verify(x => x.GetById(It.IsAny<long>()), Times.Once);
        }

        [Test]
        public void GetbyIdNotFound()
        {
            //Arrange & Act
            var msg = Assert.ThrowsAsync<BusinessException>(async () => await _appointmentService.GetById(It.IsAny<long>())).Message;

            //Assert
            Assert.AreEqual("Appointment não encontrado!", msg);
        }

        [Test]
        public void GetPaged()
        {
            //Arrange
            var expectedResult = AppointmentTestSeed.GetSearchPaged(1, 5);
            _appointmentRepository.Setup(a => a.GetAllPaged(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<ICollection<Expression<Func<Appointment, bool>>>>(),
                It.IsAny<Func<IQueryable<Appointment>, IOrderedQueryable<Appointment>>>())).Returns(AppointmentTestSeed.GetSearchPaged(1, 5));

            //Act
            var result = _appointmentService.GetAllPaged(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<long>()).Result;

            //Assert
            Assert.AreEqual(expectedResult.NumberPage, result.NumberPage);
            Assert.AreEqual(expectedResult.SizePage, result.SizePage);
        }

    }
}
