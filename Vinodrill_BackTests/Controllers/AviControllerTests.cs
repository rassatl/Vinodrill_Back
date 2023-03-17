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
using System.Runtime.Intrinsics.X86;

namespace Vinodrill_Back.Controllers.Tests
{
    [TestClass()]
    public class AviControllerTests
    {
        private readonly VinodrillDBContext _context;
        private readonly AviController _controller;
        private IAvisRepository _dataRepository;

        public AviControllerTests()
        {
            var builder = new DbContextOptionsBuilder<VinodrillDBContext>().UseNpgsql("Server=postgresql-vinodrill.alwaysdata.net;port=5432;Database=vinodrill_main_db;uid=vinodrill;password=uaK99vfWnq6GLrg;SearchPath=vinodrill;"); // Chaine de connexion à mettre dans les ( )
            _context = new VinodrillDBContext(builder.Options);
            _dataRepository = new AviManager(_context);
            _controller = new AviController(_dataRepository);
        }

        [TestMethod()]
        public async Task GetAvisTest()
        {
            ActionResult<IEnumerable<Avis>> avi = await _controller.GetAvis();
            CollectionAssert.AreEqual(_context.Avis.ToList(), avi.Value.ToList(), "La liste renvoyée n'est pas la bonne.");
        }

        [TestMethod()]
        public async Task GetAvisByIdTest_OK()
        {
            ActionResult<Avis> avi = await _controller.GetAvisById(1);
            Assert.AreEqual(_context.Avis.Where(c => c.IdAvis == 1).FirstOrDefault(), avi.Value, "Adresses différent");
        }

        [TestMethod()]
        public void GetAvisByIdTest_HttpResponse404()
        {
            var mockRepository = new Mock<IAvisRepository>();
            var userController = new AviController(mockRepository.Object);
            // Act
            ActionResult<Avis> avi = userController.GetAvisById(-1).Result;

            // Assert
            Assert.IsInstanceOfType(avi, typeof(ActionResult<Avis>));
            Assert.IsInstanceOfType(avi.Result, typeof(NotFoundResult));
        }

        [TestMethod()]
        public async Task PutAvisTest_AvecMoq()
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
        public void PutAvisTest_HttpResponse204()
        {
            // Arrange
            Avis avi = new Avis()
            {
                IdAvis = 1,
                IdClient = 1,
                IdSejour = 1,
                Note = 1,
                Commentaire = "j'aime les maths (c'est faut)",
                TitreAvis = "Trop bien ce projet",
                DateAvis = new DateTime(),
                AvisSignale = false,
                TypeSignalement = "typesignalement"
            };


            var mockRepository = new Mock<IAvisRepository>();
            mockRepository.Setup(x => x.GetById(1).Result).Returns(avi);
            var userController = new AviController(mockRepository.Object);
            var actionResult = userController.PutAvi(1, avi).Result;
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult");
        }

        [TestMethod()]
        public void PutAvisTest_HttpResponse400()
        {
            var mockRepository = new Mock<IAvisRepository>();
            var userController = new AviController(mockRepository.Object);
            // Arrange
            Avis avi = _context.Avis.FirstOrDefault(u => u.IdAvis == 1);

            var result = userController.PutAvi(2, avi).Result;

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod()]
        public void PutAvisTest_HttpResponse404()
        {
            var mockRepository = new Mock<IAvisRepository>();
            var userController = new AviController(mockRepository.Object);

            // Arrange
            Avis avi = new Avis()
            {
                IdAvis = 1,
                IdClient = 1,
                IdSejour = 1,
                Note = 1,
                Commentaire = "j'aime les maths (c'est faut)",
                TitreAvis = "Trop bien ce projet",
                DateAvis = new DateTime(),
                AvisSignale = false,
                TypeSignalement = "typesignalement"
            };

            // Act
            var result = userController.PutAvi(1, avi).Result;

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }


        [TestMethod()]
        public async Task PostAvisTest_AvecMoq()
        {
            var mockRepository = new Mock<IAvisRepository>();
            var userController = new AviController(mockRepository.Object);

            Avis avi = new Avis()
            {
                IdAvis = 1,
                IdClient = 1,
                IdSejour = 1,
                Note = 1,
                Commentaire = "j'aime les maths (c'est faut)",
                TitreAvis = "Trop bien ce projet",
                DateAvis = new DateTime(),
                AvisSignale = false,
                TypeSignalement = "typesignalement"
            };

            var actionResult = userController.PostAvi(avi).Result;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Avis>), "Pas un ActionResult<Avis>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Avis), "Pas une Avis");
            avi.IdAvis = ((Avis)result.Value).IdAvis;
            Assert.AreEqual(avi, (Avis)result.Value, "Avis pas identiques");
        }

        //je sais pas comment faire
        [TestMethod()]
        public void PostAvisTest_HttpResponse400()
        {
            var mockRepository = new Mock<IAvisRepository>();
            var userController = new AviController(mockRepository.Object);

            Avis avi = new Avis()
            {
                IdAvis = 1,
                IdClient = 1,
                IdSejour = 1,
                Note = 1,
                Commentaire = "j'aime les maths (c'est faut)",
                TitreAvis = "Trop bien ce projet",
                DateAvis = new DateTime(),
                AvisSignale = false,
                TypeSignalement = "typesignalement"
            };

            var actionResult = userController.PostAvi(avi).Result;
            Assert.IsInstanceOfType(actionResult.Result, typeof(BadRequestResult), "Pas un BadRequestResult");
        }

        [TestMethod()]
        public async Task DeleteAvisTest_HttpResponse204()
        {
            Avis avi = new Avis()
            {
                IdAvis = 1,
                IdClient = 1,
                IdSejour = 1,
                Note = 1,
                Commentaire = "j'aime les maths (c'est faut)",
                TitreAvis = "Trop bien ce projet",
                DateAvis = new DateTime(),
                AvisSignale = false,
                TypeSignalement = "typesignalement"
            };


            var mockRepository = new Mock<IAvisRepository>();
            mockRepository.Setup(x => x.GetById(1).Result).Returns(avi);
            var userController = new AviController(mockRepository.Object);
            var actionResult = userController.DeleteAvis(1).Result;
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult");
        }

        [TestMethod()]
        public void DeleteAvisTest_HttpResponse404()
        {
            var mockRepository = new Mock<IAvisRepository>();
            var userController = new AviController(mockRepository.Object);
            // Act
            var result = userController.DeleteAvis(-1).Result;

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}