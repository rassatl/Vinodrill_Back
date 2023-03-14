using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vinodrill_Back.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.DataManager;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;
using Moq;

namespace Vinodrill_Back.Controllers.Tests
{
    [TestClass()]
    public class HebergementControllerTests
    {
        private readonly VinodrillDBContext _context;
        private readonly HebergementController _controller;
        private IHebergementRepository _dataRepository;
        public HebergementControllerTests()
        {
            var builder = new DbContextOptionsBuilder<VinodrillDBContext>().UseNpgsql("Server=postgresql-vinodrill.alwaysdata.net;port=5432;Database=vinodrill_main_db;uid=vinodrill;password=uaK99vfWnq6GLrg;SearchPath=vinodrill;"); // Chaine de connexion à mettre dans les ( )
            _context = new VinodrillDBContext(builder.Options);
            _dataRepository = new HebergementManager(_context);
            _controller = new HebergementController(_dataRepository);

        }

        [TestMethod()]
        public async Task GetHebergementsTestAsync()
        {
            ActionResult<IEnumerable<Hebergement>> users = await _controller.GetHebergement();
            CollectionAssert.AreEqual(_context.Hebergement.ToList(), users.Value.ToList(), "La liste renvoyée n'est pas la bonne.");
        }

        [TestMethod()]
        public async Task GetHebergementByIdTest()
        {
            ActionResult<Hebergement> user = await _controller.GetHebergementById(1);
            Assert.AreEqual(_context.Hebergement.Where(c => c.IdHebergement == 1).FirstOrDefault(), user.Value, "Hebergement différent");
        }

        [TestMethod()]
        public async Task GetHebergementByIdTestFalse()
        {
            ActionResult<Hebergement> user = await _controller.GetHebergementById(1);
            Assert.AreNotEqual(_context.Hebergement.Where(c => c.IdHebergement == 2).FirstOrDefault(), user.Value, "Hebergement différent");
        }

        [TestMethod()]
        public async Task PostHebergementTest()
        {
            // Arrange
            var mockRepository = new Mock<IHebergementRepository>();
            var userController = new HebergementController(mockRepository.Object);
            // Le mail doit être unique donc 2 possibilités :
            // 1. on s'arrange pour que le mail soit unique en concaténant un random ou un timestamp
            // 2. On supprime le user après l'avoir créé. Dans ce cas, nous avons besoin d'appeler la méthode DELETE de l’API ou remove du DbSet.
            Hebergement user = new Hebergement()
            {
                IdPartenaire = 1,
                IdHebergement = 1,
                LibelleHebergement = "MegaLibelle",
                DescriptionHebergement = "Hebergement de dingo les poto",
                NbChambre = 12,
                HoraireHebergement = new TimeOnly(12, 20)
            };
            Hotel userr = new Hotel()
            {
                NbEtoileHotel = 1,
            };
            // Act
            var actionResult = userController.PostAdresse(user, userr).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Hebergement>), "Pas un ActionResult<Hebergement>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Hebergement), "Pas un Hebergement");
            user.IdHebergement = ((Hebergement)result.Value).IdHebergement;
            Assert.AreEqual(user, (Hebergement)result.Value, "Hebergements pas identiques");
        }
    }
}