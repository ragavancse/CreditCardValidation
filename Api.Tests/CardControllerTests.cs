using System;
using System.Collections.Generic;
using AutoFixture;
using AutoMapper;
using CreditCardValidation.Controllers;
using CreditCardValidation.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Serilog;

namespace CreditCardValidation.Tests
{
    [TestFixture]
    public class CardControllerTests : TestBase
    {
        private Mock<ILogger> _loggerMock;
        private Mock<IMapper> _mapperMock;

        private List<CardDto> _dtos;

        [SetUp]
        public void Setup()
        {
            _loggerMock = Fixture.Freeze<Mock<ILogger>>();
            _mapperMock = Fixture.Freeze<Mock<IMapper>>();

            //_dtos = new List<CardDto> { new CardDto { CardNumber = "5098-1231-4213-1242", Name = "test1" } };
            //_mapperMock.Setup(x => x.Map<List<CardModel>, List<CardDto>>(It.IsAny<List<CardModel>>())).Returns(_dtos);
        }

        [Test]
        public void ValidateValidCard()
        {
            var target = Fixture.Create<CardController>();

            IActionResult result = target.ValidateCard(new CardModel { CardNumber = "4035-6200-6020-2005" });

            var okObjectResult = result as OkObjectResult;
            Assert.AreEqual(okObjectResult.StatusCode, 200);
        }

        [Test]
        public void ValidateInValidCard()
        {
            var target = Fixture.Create<CardController>();

            IActionResult result = target.ValidateCard(new CardModel { CardNumber = "4125-1234-6020-2005" });

            var okObjectResult = result as BadRequestObjectResult;
            Assert.AreNotEqual(okObjectResult.StatusCode, 200);
        }

    }
}
