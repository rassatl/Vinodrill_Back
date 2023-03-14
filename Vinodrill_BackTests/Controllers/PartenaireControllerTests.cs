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

namespace Vinodrill_Back.Controllers.Tests
{
    [TestClass()]
    public class PartenaireControllerTests
    {
        private readonly VinodrillDBContext _context;
        private readonly PartenaireController _controller;
        private IDataRepository<Partenaire> _dataRepository;
        public PartenaireControllerTests()
        {
            var builder = new DbContextOptionsBuilder<VinodrillDBContext>().UseNpgsql("Server=postgresql-vinodrill.alwaysdata.net;port=5432;Database=vinodrill_main_db;uid=vinodrill;password=uaK99vfWnq6GLrg;SearchPath=vinodrill;"); // Chaine de connexion à mettre dans les ( )
            _context = new VinodrillDBContext(builder.Options);
            _dataRepository = new PartenaireManager(_context);
            _controller = new PartenaireController(_dataRepository);

        }

        [TestMethod()]
        public async Task GetPartenairesTestAsync()
        {
            ActionResult<IEnumerable<Partenaire>> users = await _controller.GetPartenaires();
            CollectionAssert.AreEqual(_context.Partenaires.ToList(), users.Value.ToList(), "La liste renvoyée n'est pas la bonne.");
        }

        [TestMethod()]
        public async Task GetPartenaireByIdTest()
        {
            ActionResult<Partenaire> user = await _controller.GetPartenaireById(1);
            Assert.AreEqual(_context.Partenaires.Where(c => c.IdPartenaire == 1).FirstOrDefault(), user.Value, "Partenaire différent");
        }

        [TestMethod()]
        public async Task GetTypeVisiteByIdTestFalse()
        {
            ActionResult<Partenaire> user = await _controller.GetPartenaireById(1);
            Assert.AreNotEqual(_context.Partenaires.Where(c => c.IdPartenaire == 2).FirstOrDefault(), user.Value, "Partenaire différent");
        }
    }
}