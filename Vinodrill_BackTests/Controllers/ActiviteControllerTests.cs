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

            RequestBodyActivite requestActivite = new RequestBodyActivite()
            {
                IdActivite = 1,
                LibelleActivite = "Activite de follie",
                DescriptionActivite = "Activite cool où on s'amuse",
                RueRdv = "9 Rue de l'arc-en-ciel",
                CpRdv = "74000",
                VilleRdv = "Annecy",
                HoraireActivite = new TimeOnly().AddHours(1).ToString(),
            };

            Activite activite = requestActivite.ToActivite();

            var actionResult = userController.PostActivite(requestActivite).Result;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Activite>), "Pas un ActionResult<Activite>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Activite), "Pas une Activite");
            activite.IdActivite = ((Activite)result.Value).IdActivite;
            //Assert.AreEqual(activite, (Activite)result.Value, "Activitees pas identiques");
            Assert.AreEqual(activite.IdActivite, ((Activite)result.Value).IdActivite, "Id pas identiques");
            Assert.AreEqual(activite.LibelleActivite, ((Activite)result.Value).LibelleActivite, "Libelle pas identiques");
            Assert.AreEqual(activite.DescriptionActivite, ((Activite)result.Value).DescriptionActivite, "Description pas identiques");
            Assert.AreEqual(activite.RueRdv, ((Activite)result.Value).RueRdv, "Rue pas identiques");
            Assert.AreEqual(activite.CpRdv, ((Activite)result.Value).CpRdv, "Cp pas identiques");
            Assert.AreEqual(activite.VilleRdv, ((Activite)result.Value).VilleRdv, "Ville pas identiques");
            Assert.AreEqual(activite.HoraireActivite, ((Activite)result.Value).HoraireActivite, "Horaire pas identiques");
        }
    }
}