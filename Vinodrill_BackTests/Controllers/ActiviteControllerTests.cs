using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vinodrill_Back.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinodrill_Back.Models.Repository;
using Vinodrill_Back.Models.DataManager;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Vinodrill_Back.Controllers.Tests
{
    [TestClass()]
    public class ActiviteControllerTests
    {
        private readonly VinodrillDBContext _context;
        private readonly ActiviteController _controller;
        private IDataRepository<Activite> _dataRepository;
        public ActiviteControllerTests()
        {
            var builder = new DbContextOptionsBuilder<VinodrillDBContext>().UseNpgsql("Server=postgresql-vinodrill.alwaysdata.net;port=5432;Database=vinodrill_main_db;uid=vinodrill;password=uaK99vfWnq6GLrg;SearchPath=vinodrill;"); // Chaine de connexion à mettre dans les ( )
            _context = new VinodrillDBContext(builder.Options);
            _dataRepository = new ActiviteManager(_context);
            _controller = new ActiviteController(_dataRepository);
        }

        [TestMethod()]
        public async Task GetActivitesTest()
        {
            ActionResult<IEnumerable<Activite>> users = await _controller.GetActivites();
            CollectionAssert.AreEqual(_context.Activites.ToList(), users.Value.ToList(), "La liste renvoyée n'est pas la bonne.");
        }

        [TestMethod()]
        public async Task PostActiviteTest_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Activite>>();
            var userController = new ActiviteController(mockRepository.Object);

            Activite activite = new Activite()
            {
                IdActivite = 1,
                LibelleActivite = "Activite de follie",
                DescriptionActivite = "Activite cool où on s'amuse",
                RueRdv = "9 Rue de l'arc-en-ciel",
                CpRdv = "74000",
                VilleRdv = "Annecy",
                HoraireActivite = new TimeOnly()
            };

            var actionResult = userController.PostActivite(activite).Result;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Activite>), "Pas un ActionResult<Activite>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Activite), "Pas une Activite");
            activite.IdActivite = ((Activite)result.Value).IdActivite;
            Assert.AreEqual(activite, (Activite)result.Value, "Activitees pas identiques");
        }

        [TestMethod()]
        public void PostActiviteTest_HttpResponse400()
        {
            var mockRepository = new Mock<IDataRepository<Activite>>();
            var userController = new ActiviteController(mockRepository.Object);

            // Arrange
            Activite activite = new Activite()
            {
                IdActivite = -100,
                LibelleActivite = "Activite de follie",
                DescriptionActivite = "Activite cool où on s'amuse",
                RueRdv = "9 Rue de l'arc-en-ciel",
                CpRdv = "74000",
                VilleRdv = "Annecy",
                HoraireActivite = new TimeOnly()
            };

            // Act
            var actionResult = userController.PostActivite(activite).Result;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Activite>), "Pas un ActionResult<Activite>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(BadRequestObjectResult), "Pas un BadRequestObjectResult");
            var result = actionResult.Result as BadRequestObjectResult;
            Assert.IsInstanceOfType(result.Value, typeof(Activite), "Pas une Activite");
            activite.IdActivite = ((Activite)result.Value).IdActivite;
            Assert.AreEqual(activite, (Activite)result.Value, "Activitees pas identiques ☺");
            Assert.IsNull(result.Value);
        }
    }
}