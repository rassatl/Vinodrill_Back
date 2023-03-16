using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class EffectueControllerTests
    {
        private readonly VinodrillDBContext _context;
        private readonly EffectueController _controller;
        private IDataRepository<Effectue> _dataRepository;

        public EffectueControllerTests()
        {
            var builder = new DbContextOptionsBuilder<VinodrillDBContext>().UseNpgsql("Server=postgresql-vinodrill.alwaysdata.net;port=5432;Database=vinodrill_main_db;uid=vinodrill;password=uaK99vfWnq6GLrg;SearchPath=vinodrill;"); // Chaine de connexion à mettre dans les ( )
            _context = new VinodrillDBContext(builder.Options);
            _dataRepository = new EffectueManager(_context);
            _controller = new EffectueController(_dataRepository);
        }

        [TestMethod()]
        public async Task GetEffectueTest()
        {
            ActionResult<IEnumerable<Effectue>> effectue = await _controller.GetEffectue();
            CollectionAssert.AreEqual(_context.Effectues.ToList(), effectue.Value.ToList(), "La liste renvoyée n'est pas la bonne.");
        }

        [TestMethod()]
        public async Task GetAvisByIdTest_OK()
        {
            ActionResult<Effectue> effectue = await _controller.GetEffectueById(1);
            Assert.AreEqual(_context.Effectues.Where(c => c.IdEtape == 1).FirstOrDefault(), effectue.Value, "effectue différent");
        }

        [TestMethod()]
        public async Task GetAvisByIdTest_HttpResponse404()
        {
            var mockRepository = new Mock<IDataRepository<Effectue>>();
            var userController = new EffectueController(mockRepository.Object);

            // Act
            var effectue = await userController.GetEffectueById(-1);

            // Assert
            Assert.IsInstanceOfType(effectue.Result, typeof(NotFoundResult));
        }

        [TestMethod()]
        public async Task PutEffectueTest_AvecMoq()
        {
            Effectue effectue = new Effectue()
            {
                IdEtape = 1,
                IdActivite = 1
            };


            // Act
            var mockRepository = new Mock<IDataRepository<Effectue>>();
            mockRepository.Setup(x => x.GetById(1).Result).Returns(effectue);
            var userController = new EffectueController(mockRepository.Object);


            effectue.IdActivite = 3;
            userController.PutEffectue(effectue.IdEtape, effectue);

            var actionResult = userController.GetEffectueById(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Effectue>), "Pas un ActionResult<Effectue>");
            var result = actionResult.Value;
            Console.WriteLine(result.GetType());
            Assert.IsInstanceOfType(result, typeof(Effectue), "Pas un Effectue");
            effectue.IdEtape = ((Effectue)result).IdEtape;
            Assert.AreEqual(effectue, (Effectue)result, "Effectues pas identiques");
        }

        [TestMethod()]
        public void PutEffectueTest_HttpResponse204()
        {
            var mockRepository = new Mock<IDataRepository<Effectue>>();
            var userController = new EffectueController(mockRepository.Object);

            // Arrange
            var effectue = userController.GetEffectueById(1).Result;

            var result = userController.PutEffectue(1, effectue.Value).Result;

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod()]
        public void PutEffectueTest_HttpResponse400()
        {
            var mockRepository = new Mock<IDataRepository<Effectue>>();
            var userController = new EffectueController(mockRepository.Object);

            // Arrange
            Effectue effectue = new Effectue()
            {
                IdEtape = 1,
                IdActivite = 1
            };

            // Act
            var result = userController.PutEffectue(-1, effectue).Result;

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod()]
        public void PutEffectueTest_HttpResponse404()
        {
            var mockRepository = new Mock<IDataRepository<Effectue>>();
            var userController = new EffectueController(mockRepository.Object);

            // Arrange
            Effectue effectue = new Effectue()
            {
                IdEtape = 1,
                IdActivite= 1
            };

            // Act
            var result = userController.PutEffectue(1, effectue).Result;

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }


        [TestMethod()]
        public async Task PostEffectueTest_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Effectue>>();
            var userController = new EffectueController(mockRepository.Object);

            Effectue effectue = new Effectue()
            {
                IdEtape = 1,
                IdActivite = 1
            };

            var actionResult = userController.PostEffectue(effectue).Result;
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Effectue), "Pas une Effectue");
            effectue.IdEtape = ((Effectue)result.Value).IdEtape;
            Assert.AreEqual(effectue, (Effectue)result.Value, "Effectue pas identiques");
        }

        //j'arrive pas à faire ce test
        [TestMethod()]
        public void PostEffectueTest_HttpResponse400()
        {
            var mockRepository = new Mock<IDataRepository<Effectue>>();
            var userController = new EffectueController(mockRepository.Object);

            // Arrange
            Effectue effectue = new Effectue()
            {
                IdEtape = 100,
                IdActivite = 100
            };

           var actionResult = userController.PostEffectue(effectue).Result;
            Assert.IsInstanceOfType(actionResult.Result, typeof(BadRequestObjectResult), "Pas un BadRequestObjectResult");
        }

        [TestMethod()]
        public void DeleteEffectueTest_HttpResponse204()
        {
            Effectue effectue = new Effectue()
            {
                IdEtape = 1,
                IdActivite = 1
            };


            var mockRepository = new Mock<IDataRepository<Effectue>>();
            mockRepository.Setup(x => x.GetById(1).Result).Returns(effectue);
            var userController = new EffectueController(mockRepository.Object);
            var actionResult = userController.DeleteEffectue(1).Result;
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult");
        }

        [TestMethod()]
        public void DeleteEffectueTest_HttpResponse404()
        {
            var mockRepository = new Mock<IDataRepository<Effectue>>();
            var userController = new EffectueController(mockRepository.Object);

            // Act
            var result = userController.DeleteEffectue(1).Result;

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}