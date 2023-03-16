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
    }
}