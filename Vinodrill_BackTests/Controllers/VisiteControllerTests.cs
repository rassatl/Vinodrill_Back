using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vinodrill_Back.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.Repository;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.DataManager;
using Microsoft.AspNetCore.Mvc;

namespace Vinodrill_Back.Controllers.Tests
{
    [TestClass()]
    public class VisiteControllerTests
    {
        private readonly VinodrillDBContext _context;
        private readonly VisiteController _controller;
        private IDataRepository<Visite> _dataRepository;
        public VisiteControllerTests()
        {
            var builder = new DbContextOptionsBuilder<VinodrillDBContext>().UseNpgsql("Server=postgresql-vinodrill.alwaysdata.net;port=5432;Database=vinodrill_main_db;uid=vinodrill;password=uaK99vfWnq6GLrg;SearchPath=vinodrill;"); // Chaine de connexion à mettre dans les ( )
            _context = new VinodrillDBContext(builder.Options);
            _dataRepository = new VisiteManager(_context);
            _controller = new VisiteController(_dataRepository);

        }

        [TestMethod()]
        public async Task GetVisitesTestAsync()
        {
            ActionResult<IEnumerable<Visite>> users = await _controller.GetVisites();
            CollectionAssert.AreEqual(_context.Visites.ToList(), users.Value.ToList(), "La liste renvoyée n'est pas la bonne.");
        }

        [TestMethod()]
        public async Task GetVisiteByIdTest()
        {
            ActionResult<Visite> user = await _controller.GetVisiteById(1);
            Assert.AreEqual(_context.Visites.Where(c => c.IdVisite == 1).FirstOrDefault(), user.Value, "Visite différent");
        }

        [TestMethod()]
        public async Task GetVisiteByIdTestFalse()
        {
            ActionResult<Visite> user = await _controller.GetVisiteById(1);
            Assert.AreNotEqual(_context.Visites.Where(c => c.IdVisite == 2).FirstOrDefault(), user.Value, "Visite différent");
        }
    }
}