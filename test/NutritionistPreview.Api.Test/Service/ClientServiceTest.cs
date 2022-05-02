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

namespace NutritionistPreview.Api.Test.Service
{
    class ClientServiceTest
    {
        private ClientService _clientService;
        private Mock<IAddressRepository> _addressRepository;
        private Mock<IClientRepository> _clientRepository;

        [SetUp]
        public void Setup()
        {
            var logger = new Mock<ILogger<Client>>();
            _addressRepository = new Mock<IAddressRepository>();
            _clientRepository = new Mock<IClientRepository>();
            _clientService = new ClientService(_clientRepository.Object, _addressRepository.Object, logger.Object);
        }

        [Test]
        public void GetbyIdSucess()
        {
            //Arrange
            _clientRepository.Setup(x => x.GetQueryable(It.IsAny<Expression<Func<Client, bool>>>())).Returns(ClientTestSeed.GetListClient().AsQueryable);

            //Act
            var result = _clientService.GetById(It.IsAny<long>()).Result;

            //Assert
            Assert.IsNotNull(result);
            _clientRepository.Verify(x => x.GetQueryable(It.IsAny<Expression<Func<Client, bool>>>()), Times.Once);
        }

        [Test]
        public void GetbyIdNotFound()
        {
            //Arrange & Act
            var msg = Assert.ThrowsAsync<BusinessException>(async () => await _clientService.GetById(It.IsAny<long>())).Message;

            //Assert
            Assert.AreEqual("Client não encontrado!", msg);
        }

        [Test]
        public void GetbyDocumentNumber()
        {
            //Arrange
            _clientRepository.Setup(x => x.GetQueryable(It.IsAny<Expression<Func<Client, bool>>>())).Returns(ClientTestSeed.GetListClient().AsQueryable);

            //Act
            var result = _clientService.GetById(It.IsAny<long>()).Result;

            //Assert
            Assert.IsNotNull(result);
            _clientRepository.Verify(x => x.GetQueryable(It.IsAny<Expression<Func<Client, bool>>>()), Times.Once);
        }

        [Test]
        public void GetbyDocumentNotFound()
        {
            //Arrange & Act
            var msg = Assert.ThrowsAsync<BusinessException>(async () => await _clientService.GetByDocumentNumber(It.IsAny<long>())).Message;

            //Assert
            Assert.AreEqual("Document Number não encontrado!", msg);
        }

        [Test]
        public void AddClient()
        {
            //Arrange
            var client = ClientTestSeed.GetNewClient();
            
            //Act
            var result = _clientService.SaveClient(client).Result;

            //Assert
            Assert.IsNotNull(result);
            _clientRepository.Verify(x => x.Add(It.IsAny<Client>()), Times.Once);

        }

        [Test]
        public void UpdateClient()
        {
            //Arrange
            var client = ClientTestSeed.GetClientDb();
            _clientRepository.Setup(x => x.GetQueryable(It.IsAny<Expression<Func<Client, bool>>>())).Returns(ClientTestSeed.GetListClient().AsQueryable);
            //Act
            var result = _clientService.SaveClient(client).Result;

            //Assert
            Assert.IsNotNull(result);
            _clientRepository.Verify(x => x.Attach(It.IsAny<Client>()), Times.Once);

        }

        [Test]
        public void UpdateClientNull()
        {
            //Arrange & Act
            var msg = Assert.ThrowsAsync<BusinessException>(async () => await _clientService.SaveClient(It.IsAny<Client>())).Message;

            //Assert
            Assert.AreEqual("Cliente deve ter os dados preenchidos", msg);

        }

        [Test]
        public void Delete()
        {
            //Arrange
            _clientRepository.Setup(x => x.Delete(It.IsAny<long>())).Returns(true);
            //Act
            var result = _clientService.Delete(It.IsAny<long>()).Result;

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void DeleteNotFound()
        {
            //Arrange & Act
            var msg = Assert.ThrowsAsync<BusinessException>(async () => await _clientService.Delete(It.IsAny<long>())).Message;

            //Assert
            Assert.AreEqual("Cliente não encontrado!", msg);

        }
    }
}
