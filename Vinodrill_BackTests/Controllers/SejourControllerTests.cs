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
            var builder = new DbContextOptionsBuilder<VinodrillDBContext>().UseNpgsql("Server=localhost;port=5432;Database=vino; uid=postgres; password=postgres;"); // Chaine de connexion à mettre dans les ( )
            _context = new VinodrillDBContext(builder.Options);
            _dataRepository = new SejourManager(_context);
            _controller = new SejourController(_dataRepository);

        }

        [TestMethod]
        public void PutSejourTest_AvecMoq()
        {

            Sejour user = new Sejour
            {
                IdSejour = 500,
                IdDestination = 500,
                IdTheme = 500,
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
            mockRepository.Setup(x => x.GetById(500, false, false, false, false, false, false, false).Result).Returns(user);
            var userController = new SejourController(mockRepository.Object);


            user.TitreSejour = "MegaBgSejourModifié";
            userController.PutSejour(user.IdSejour, user);

            var actionResult = userController.GetSejourById(500).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Sejour>), "Pas un ActionResult<Sejour>");
            var result = actionResult.Value;
            Console.WriteLine(result.GetType());
            Assert.IsInstanceOfType(result, typeof(Sejour), "Pas un Sejour");
            user.IdSejour = ((Sejour)result).IdSejour;
            Assert.AreEqual(user, (Sejour)result, "Sejours pas identiques");
        }

        [TestMethod()]
        public async Task PostSejourTest()
        {
            // Arrange
            var mockRepository = new Mock<ISejourRepository>();
            var userController = new SejourController(mockRepository.Object);
            // Le mail doit être unique donc 2 possibilités :
            // 1. on s'arrange pour que le mail soit unique en concaténant un random ou un timestamp
            // 2. On supprime le user après l'avoir créé. Dans ce cas, nous avons besoin d'appeler la méthode DELETE de l’API ou remove du DbSet.
            Sejour user = new Sejour
            {
                IdSejour = 500,
                IdDestination = 500,
                IdTheme = 500,
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

        [TestMethod]
        public void Postsejour_ModelValidated_CreationOK()
        {
            // Arrange
            Random rnd = new Random();
            int chiffre = rnd.Next(1, 1000000000);

            Sejour user = new Sejour
            {
                IdSejour = 500,
                IdDestination = 500,
                IdTheme = 500,
                TitreSejour = "MegaSejour",
                PhotoSejour = "https://MegaPhoto.png",
                PrixSejour = 100,
                DescriptionSejour = "Un Mega sejour de dingo les poto",
                NbJour = chiffre,
                NbNuit = 4,
                LibelleTemps = null,
                NoteMoyenne = null
            };
            // Act
            var result = _controller.PostSejour(user).Result;
            // Assert
            Sejour? userRecupere = _context.Sejours.Where(u => u.NbJour == user.NbJour).FirstOrDefault();

            user.IdSejour = userRecupere.IdSejour;
            Assert.AreEqual(user, userRecupere, "Sejours pas identiques");
        }

        [TestMethod]
        public void Postsejour_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<ISejourRepository>();
            var userController = new SejourController(mockRepository.Object);
            Sejour user = new Sejour
            {
                IdSejour = 500,
                IdDestination = 500,
                IdTheme = 500,
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

        [TestMethod]
        public void GetSejourById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Sejour user = new Sejour
            {
                IdSejour = 500,
                IdDestination = 500,
                IdTheme = 500,
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
            mockRepository.Setup(x => x.GetById(500, false, false, false, false, false, false, false).Result).Returns(user);
            var userController = new SejourController(mockRepository.Object);
            // Act
            var actionResult = userController.GetSejourById(500).Result;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(user, actionResult.Value as Sejour);
        }

        [TestMethod()]
        public async Task DeleteSejourTest()
        {
            Random rnd = new Random();
            int chiffre = rnd.Next(1, 1000000000);
            Sejour user = new Sejour
            {
                IdSejour = 500,
                IdDestination = 500,
                IdTheme = 500,
                TitreSejour = "MegaSejour",
                PhotoSejour = "https://MegaPhoto.png",
                PrixSejour = 100,
                DescriptionSejour = "Un Mega sejour de dingo les poto",
                NbJour = 5,
                NbNuit = 4,
                LibelleTemps = null,
                NoteMoyenne = null
            };
            EntityEntry<Sejour> res = _context.Sejours.Add(user);
            _context.SaveChanges();
            IActionResult result = await _controller.DeleteSejour(res.Entity.IdSejour);

            Sejour usere = _context.Sejours.Where(u => u.IdSejour == res.Entity.IdSejour).FirstOrDefault();

            Assert.IsNull(usere, "Non");


        }

        [TestMethod]
        public void DeleteSejourTest_AvecMoq()
        {

            // Arrange
            Sejour user = new Sejour
            {
                IdSejour = 500,
                IdDestination = 500,
                IdTheme = 500,
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
            mockRepository.Setup(x => x.GetById(500, false, false, false, false, false, false, false).Result).Returns(user);
            var userController = new SejourController(mockRepository.Object);

            // Act
            var actionResult = userController.DeleteSejour(500).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

    }
}