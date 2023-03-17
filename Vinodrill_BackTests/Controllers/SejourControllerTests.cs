using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vinodrill_Back.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vinodrill_Back.Models.Repository;
using Vinodrill_Back.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.DataManager;
using Moq;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Vinodrill_Back.Controllers.Tests
{
    [TestClass()]
    public class SejourControllerTests
    {
        private readonly VinodrillDBContext _context;
        private readonly SejourController _controller;
        private ISejourRepository _dataRepository;
        public SejourControllerTests()
        {
            var builder = new DbContextOptionsBuilder<VinodrillDBContext>().UseNpgsql("Server=postgresql-vinodrill.alwaysdata.net;port=5432;Database=vinodrill_main_db;uid=vinodrill;password=uaK99vfWnq6GLrg;SearchPath=vinodrill;"); // Chaine de connexion à mettre dans les ( )
            _context = new VinodrillDBContext(builder.Options);
            _dataRepository = new SejourManager(_context);
            _controller = new SejourController(_dataRepository);

        }

        [TestMethod()]
        public async Task GetSejourTest_OK()
        {
            ActionResult<IEnumerable<Sejour>> users = await _controller.GetSejours();
            CollectionAssert.AreEqual(_context.Sejours.ToList(), users.Value.ToList(), "La liste renvoyée n'est pas la bonne.");
        }

        [TestMethod]
        public void PutSejourTest_AvecMoq()
        {

            Sejour user = new Sejour
            {
                IdSejour = 1,
                IdDestination = 1,
                IdTheme = 1,
                TitreSejour = "MegaSejour",
                PhotoSejour = "https://MegaPhoto.png",
                PrixSejour = 100,
                DescriptionSejour = "Un Mega sejour de dingo les poto",
                NbJour = 5,
                NbNuit = 4,
                LibelleTemps = null,
                NoteMoyenne = null
            };


            // Act
            var mockRepository = new Mock<ISejourRepository>();
            mockRepository.Setup(x => x.GetById(1, false, false, false, false, false, false, false).Result).Returns(user);
            var userController = new SejourController(mockRepository.Object);


            user.TitreSejour = "MegaBgSejourModifié";
            userController.PutSejour(user.IdSejour, user);

            var actionResult = userController.GetSejourById(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Sejour>), "Pas un ActionResult<Sejour>");
            var result = actionResult.Value;
            Console.WriteLine(result.GetType());
            Assert.IsInstanceOfType(result, typeof(Sejour), "Pas un Sejour");
            user.IdSejour = ((Sejour)result).IdSejour;
            Assert.AreEqual(user, (Sejour)result, "Sejours pas identiques");
        }

        [TestMethod()]
        public void PutSejourTest_HttpResponse204()
        {
            // Arrange
            Sejour sej = new Sejour
            {
                IdSejour = 1,
                IdDestination = 1,
                IdTheme = 1,
                TitreSejour = "MegaSejour",
                PhotoSejour = "https://MegaPhoto.png",
                PrixSejour = 100,
                DescriptionSejour = "Un Mega sejour de dingo les poto",
                NbJour = 5,
                NbNuit = 4,
                LibelleTemps = null,
                NoteMoyenne = null
            };


            var mockRepository = new Mock<ISejourRepository>();
            mockRepository.Setup(x => x.GetById(1, false, false, false, false, false, false, false).Result).Returns(sej);
            var userController = new SejourController(mockRepository.Object);
            var actionResult = userController.PutSejour(1, sej).Result;
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult");
        }

        [TestMethod()]
        public void PutEffectueTest_HttpResponse400()
        {
            var mockRepository = new Mock<ISejourRepository>();
            var userController = new SejourController(mockRepository.Object);

            // Arrange
            Sejour sej = new Sejour
            {
                IdSejour = 1,
                IdDestination = 1,
                IdTheme = 1,
                TitreSejour = "MegaSejour",
                PhotoSejour = "https://MegaPhoto.png",
                PrixSejour = 100,
                DescriptionSejour = "Un Mega sejour de dingo les poto",
                NbJour = 5,
                NbNuit = 4,
                LibelleTemps = null,
                NoteMoyenne = null
            };

            // Act
            var result = userController.PutSejour(-1, sej).Result;

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod()]
        public void PutEffectueTest_HttpResponse404()
        {
            var mockRepository = new Mock<ISejourRepository>();
            var userController = new SejourController(mockRepository.Object);

            // Arrange
            Sejour sej = new Sejour
            {
                IdSejour = 1,
                IdDestination = 1,
                IdTheme = 1,
                TitreSejour = "MegaSejour",
                PhotoSejour = "https://MegaPhoto.png",
                PrixSejour = 100,
                DescriptionSejour = "Un Mega sejour de dingo les poto",
                NbJour = 5,
                NbNuit = 4,
                LibelleTemps = null,
                NoteMoyenne = null
            };

            // Act
            var result = userController.PutSejour(1, sej).Result;

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Postsejour_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<ISejourRepository>();
            var userController = new SejourController(mockRepository.Object);
            Sejour user = new Sejour
            {
                IdSejour = 1,
                IdDestination = 1,
                IdTheme = 1,
                TitreSejour = "MegaSejour",
                PhotoSejour = "https://MegaPhoto.png",
                PrixSejour = 100,
                DescriptionSejour = "Un Mega sejour de dingo les poto",
                NbJour = 5,
                NbNuit = 4,
                LibelleTemps = null,
                NoteMoyenne = null
            };
            // Act
            var actionResult = userController.PostSejour(user).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Sejour>), "Pas un ActionResult<Sejour>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Sejour), "Pas un Sejour");
            user.IdSejour = ((Sejour)result.Value).IdSejour;
            Assert.AreEqual(user, (Sejour)result.Value, "Sejours pas identiques");
        }

        [TestMethod()]
        public async Task GetSejourByIdTest_OK()
        {
            ActionResult<Sejour> user = await _controller.GetSejourById(1);
            Assert.AreEqual(_context.Sejours.Where(c => c.IdSejour == 1).FirstOrDefault(), user.Value, "Sejour différent");
        }

        [TestMethod()]
        public async Task GetSejourByIdTestFalse()
        {
            ActionResult<Sejour> user = await _controller.GetSejourById(1);
            Assert.AreNotEqual(_context.Sejours.Where(c => c.IdSejour == 2).FirstOrDefault(), user.Value, "Sejour différent");
        }

        [TestMethod]
        public void GetSejourById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<ISejourRepository>();
            var userController = new SejourController(mockRepository.Object);
            // Act
            var actionResult = userController.GetSejourById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetSejourById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Sejour user = new Sejour
            {
                IdSejour = 1,
                IdDestination = 1,
                IdTheme = 1,
                TitreSejour = "MegaSejour",
                PhotoSejour = "https://MegaPhoto.png",
                PrixSejour = 100,
                DescriptionSejour = "Un Mega sejour de dingo les poto",
                NbJour = 5,
                NbNuit = 4,
                LibelleTemps = null,
                NoteMoyenne = null
            };
            var mockRepository = new Mock<ISejourRepository>();
            mockRepository.Setup(x => x.GetById(1, false, false, false, false, false, false, false).Result).Returns(user);
            var userController = new SejourController(mockRepository.Object);
            // Act
            var actionResult = userController.GetSejourById(1).Result;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(user, actionResult.Value as Sejour);
        }

        [TestMethod()]
        public void GetSejourByIdTest_HttpResponse404()
        {
            var mockRepository = new Mock<ISejourRepository>();
            var userController = new SejourController(mockRepository.Object);
            // Act
            ActionResult<Sejour> avi = userController.GetSejourById(-1).Result;

            // Assert
            Assert.IsInstanceOfType(avi, typeof(ActionResult<Sejour>));
            Assert.IsInstanceOfType(avi.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void DeleteSejourTest_AvecMoq()
        {

            // Arrange
            Sejour user = new Sejour
            {
                IdSejour = 1,
                IdDestination = 1,
                IdTheme = 1,
                TitreSejour = "MegaSejour",
                PhotoSejour = "https://MegaPhoto.png",
                PrixSejour = 100,
                DescriptionSejour = "Un Mega sejour de dingo les poto",
                NbJour = 5,
                NbNuit = 4,
                LibelleTemps = null,
                NoteMoyenne = null
            };

            var mockRepository = new Mock<ISejourRepository>();
            mockRepository.Setup(x => x.GetById(1, false, false, false, false, false, false, false).Result).Returns(user);
            var userController = new SejourController(mockRepository.Object);

            // Act
            var actionResult = userController.DeleteSejour(1).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

    }
}