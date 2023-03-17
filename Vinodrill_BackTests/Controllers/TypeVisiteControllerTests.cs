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
    public class TypeVisiteControllerTests
    {
        private readonly VinodrillDBContext _context;
        private readonly TypeVisiteController _controller;
        private IDataRepository<TypeVisite> _dataRepository;
        public TypeVisiteControllerTests()
        {
            var builder = new DbContextOptionsBuilder<VinodrillDBContext>().UseNpgsql("Server=postgresql-vinodrill.alwaysdata.net;port=5432;Database=vinodrill_main_db;uid=vinodrill;password=uaK99vfWnq6GLrg;SearchPath=vinodrill;"); // Chaine de connexion à mettre dans les ( )
            _context = new VinodrillDBContext(builder.Options);
            _dataRepository = new TypeVisiteManager(_context);
            _controller = new TypeVisiteController(_dataRepository);

        }

        [TestMethod()]
        public async Task GetTypeVisitesTest_OK()
        {
            ActionResult<IEnumerable<TypeVisite>> users = await _controller.GetTypeVisites();
            CollectionAssert.AreEqual(_context.TypeVisites.ToList(), users.Value.ToList(), "La liste renvoyée n'est pas la bonne.");
        }

        [TestMethod()]
        public async Task GetTypeVisiteByIdTest_OK()
        {
            ActionResult<TypeVisite> user = await _controller.GetTypeVisiteById(1);
            Assert.AreEqual(_context.TypeVisites.Where(c => c.IdTypeVisite == 1).FirstOrDefault(), user.Value, "TypeVisite différent");
        }

        [TestMethod()]
        public async Task GetTypeVisiteByIdTestFalse()
        {
            ActionResult<TypeVisite> user = await _controller.GetTypeVisiteById(1);
            Assert.AreNotEqual(_context.TypeVisites.Where(c => c.IdTypeVisite == 2).FirstOrDefault(), user.Value, "TypeVisite différent");
        }

        [TestMethod()]
        public void GetTypeVisiteByIdTest_HttpResponse404()
        {
            var mockRepository = new Mock<IDataRepository<TypeVisite>>();
            var userController = new TypeVisiteController(mockRepository.Object);
            // Act
            ActionResult<TypeVisite> avi = userController.GetTypeVisiteById(-1).Result;

            // Assert
            Assert.IsInstanceOfType(avi, typeof(ActionResult<TypeVisite>));
            Assert.IsInstanceOfType(avi.Result, typeof(NotFoundResult));
        }
    }
}