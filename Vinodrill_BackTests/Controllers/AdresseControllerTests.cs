using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vinodrill_Back.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.DataManager;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Vinodrill_Back.Controllers.Tests
{
    [TestClass()]
    public class AdresseControllerTests
    {
        private readonly VinodrillDBContext _context;
        private readonly AdresseController _controller;
        private IDataRepository<Adresse> _dataRepository;

        public AdresseControllerTests()
        {
            var builder = new DbContextOptionsBuilder<VinodrillDBContext>().UseNpgsql("Server=postgresql-vinodrill.alwaysdata.net;port=5432;Database=vinodrill_main_db;uid=vinodrill;password=uaK99vfWnq6GLrg;SearchPath=vinodrill;"); // Chaine de connexion à mettre dans les ( )
            _context = new VinodrillDBContext(builder.Options);
            _dataRepository = new AdresseManager(_context);
            _controller = new AdresseController(_dataRepository);
        }

        [TestMethod()]
        public async Task GetAdressesTest()
        {
            ActionResult<IEnumerable<Adresse>> users = await _controller.GetAdresses();
            CollectionAssert.AreEqual(_context.Adresses.ToList(), users.Value.ToList(), "La liste renvoyée n'est pas la bonne.");
        }

        [TestMethod()]
        public async Task GetAdresseByIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public async Task PutAdresseTest_AvecMoq()
        {
            //à adapter à la class de test

            /*
            Activite activite = new Activite()
            {
                LibelleActivite = "Activite de follie",
                DescriptionActivite = "Activite cool où on s'amuse",
                RueRdv = "9 Rue de l'arc-en-ciel",
                CpRdv = "74000",
                VilleRdv = "Annecy",
                HoraireActivite = new TimeOnly()
            };

            // Act
            var mockRepository = new Mock<IDataRepository<Activite>>();
            mockRepository.Setup(x => x.GetById(1).Result).Returns(activite);
            var userController = new ActiviteController(mockRepository.Object);


            activite.LibelleActivite = "a";
            userController.PutActivite(activite.IdActivite, activite);

            var actionResult = userController.GetActiviteById(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Activite>), "Pas un ActionResult<Activite>");
            var result = actionResult.Value;
            Console.WriteLine(result.GetType());
            Assert.IsInstanceOfType(result, typeof(Activite), "Pas une Activite");
            activite.IdActivite = ((Activite)result).IdActivite;
            Assert.AreEqual(activite, (Activite)result, "Activitees pas identiques");
            */
        }

        [TestMethod()]
        public async Task PostAdresseTest_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Adresse>>();
            var userController = new AdresseController(mockRepository.Object);

            Adresse adresse = new Adresse()
            {
                IdAdresse = 1,
                LibelleAdresse = "adresse de l'entreprise",
                RueAdresse = "9 Rue de l'arc-en-ciel",
                VilleAdresse = "Annecy",
                CodePostalAdresse = "74000",
                PaysAdresse = "France"
            };

            var actionResult = userController.PostAdresse(adresse).Result;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Adresse>), "Pas un ActionResult<Adresse>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Adresse), "Pas une Adresse");
            adresse.IdAdresse = ((Adresse)result.Value).IdAdresse;
            Assert.AreEqual(adresse, (Adresse)result.Value, "Adresses pas identiques");
        }

        [TestMethod()]
        public void DeleteAdresseTest_AvecMoq()
        {
            Adresse adresse = new Adresse()
            {
                IdAdresse = 1,
                LibelleAdresse = "adresse de l'entreprise",
                RueAdresse = "9 Rue de l'arc-en-ciel",
                VilleAdresse = "Annecy",
                CodePostalAdresse = "74000",
                PaysAdresse = "France"
            };

            var mockRepository = new Mock<IDataRepository<Adresse>>();
            mockRepository.Setup(x => x.GetById(1).Result).Returns(adresse);
            var userController = new AdresseController(mockRepository.Object);
            var actionResult = userController.DeleteAdresse(1).Result;
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult");
        }
    }
}