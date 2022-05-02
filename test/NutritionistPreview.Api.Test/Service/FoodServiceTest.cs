using NUnit.Framework;
using Moq;
using NutritionistPreview.Api.Business.Services;
using NutritionistPreview.Api.Core.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace NutritionistPreview.Api.Test.Service
{
     class FoodServiceTest
    {
        
        private FoodService _foodService;
        [SetUp]
        public void Setup()
        {
            var logger = new Mock<ILogger<Food>>();
            _foodService = new FoodService(logger.Object);
        }

        [Test]
        public void GetOptions()
        {
            //Act
            var result = _foodService.GetOptions(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()).Result;

            //Assert
            Assert.IsNotNull(result);

        }
    }
}
