﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vinodrill_Back.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Vinodrill_Back.Models.DataManager;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Controllers.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        private readonly VinodrillDBContext _context;
        private readonly UserController _controller;
        private IUserRepository _dataRepository;
        public UserControllerTests()
        {
            var builder = new DbContextOptionsBuilder<VinodrillDBContext>().UseNpgsql("Server=postgresql-vinodrill.alwaysdata.net;port=5432;Database=vinodrill_main_db;uid=vinodrill;password=uaK99vfWnq6GLrg;SearchPath=vinodrill;"); // Chaine de connexion à mettre dans les ( )
            _context = new VinodrillDBContext(builder.Options);
            _dataRepository = new UserManager(_context);
            _controller = new UserController(_dataRepository);

        }

        [TestMethod()]
        public async Task GetUserByIdTest_OK()
        {
            ActionResult<User> user = await _controller.GetUserById(1);
            Assert.AreEqual(_context.Users.Where(c => c.IdClient == 1).FirstOrDefault(), user.Value, "Client différent");
        }

        [TestMethod()]
        public async Task GetUserByIdTestFalse()
        {
            ActionResult<User> user = await _controller.GetUserById(1);
            Assert.AreNotEqual(_context.Users.Where(c => c.IdClient == 2).FirstOrDefault(), user.Value, "Client différent");
        }

        [TestMethod()]
        public void GetUserByIdTest_HttpResponse404()
        {
            var mockRepository = new Mock<IUserRepository>();
            var userController = new UserController(mockRepository.Object);
            // Act
            ActionResult<User> avi = userController.GetUserById(-1).Result;

            // Assert
            Assert.IsInstanceOfType(avi, typeof(ActionResult<User>));
            Assert.IsInstanceOfType(avi.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PutUserTest_AvecMoq()
        {
            User user = new User
            {
                IdClient = 1,
                IdCbClient = 1,
                NomClient = "MEGANOM",
                PrenomClient = "Megaprenom",
                DateNaissanceClient = new DateTime(2000,10,12),
                SexeClient = "M",
                EmailClient = "mega@email.mega",
                MotDePasse = "MegaMDP",
                UserRole = "Admin"
            };


            // Act
            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(x => x.GetById(1, false).Result).Returns(user);
            var userController = new UserController(mockRepository.Object);


            user.NomClient = "MEGANOMmodifié";
            userController.PutUser(user.IdClient, user);

            var actionResult = userController.GetUserById(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<User>), "Pas un ActionResult<User>");
            var result = actionResult.Value;
            Console.WriteLine(result.GetType());
            Assert.IsInstanceOfType(result, typeof(User), "Pas un Client");
            user.IdClient = ((User)result).IdClient;
            Assert.AreEqual(user, (User)result, "Clients pas identiques");
        }

        [TestMethod()]
        public void PutUserTest_HttpResponse204()
        {
            // Arrange
            User user = new User
            {
                IdClient = 1,
                IdCbClient = 1,
                NomClient = "MEGANOM",
                PrenomClient = "Megaprenom",
                DateNaissanceClient = new DateTime(2000, 10, 12),
                SexeClient = "M",
                EmailClient = "mega@email.mega",
                MotDePasse = "MegaMDP",
                UserRole = "Admin"
            };


            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(x => x.GetById(1, false).Result).Returns(user);
            var userController = new UserController(mockRepository.Object);
            var actionResult = userController.PutUser(1, user).Result;
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult");
        }

        [TestMethod()]
        public void PutUserTest_HttpResponse400()
        {
            var mockRepository = new Mock<IUserRepository>();
            var userController = new UserController(mockRepository.Object);

            // Arrange
            User user = new User
            {
                IdClient = 1,
                IdCbClient = 1,
                NomClient = "MEGANOM",
                PrenomClient = "Megaprenom",
                DateNaissanceClient = new DateTime(2000, 10, 12),
                SexeClient = "M",
                EmailClient = "mega@email.mega",
                MotDePasse = "MegaMDP",
                UserRole = "Admin"
            };

            // Act
            var result = userController.PutUser(-1, user).Result;

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod()]
        public void PutUserTest_HttpResponse404()
        {
            var mockRepository = new Mock<IUserRepository>();
            var userController = new UserController(mockRepository.Object);

            // Arrange
            User user = new User
            {
                IdClient = 1,
                IdCbClient = 1,
                NomClient = "MEGANOM",
                PrenomClient = "Megaprenom",
                DateNaissanceClient = new DateTime(2000, 10, 12),
                SexeClient = "M",
                EmailClient = "mega@email.mega",
                MotDePasse = "MegaMDP",
                UserRole = "Admin"
            };

            // Act
            var result = userController.PutUser(1, user).Result;

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

    }
}