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
    public class ParticipeControllerTests
    {
        private readonly VinodrillDBContext _context;
        private readonly ParticipeController _controller;
        private IDataRepository<Participe> _dataRepository;
        public ParticipeControllerTests()
        {
            var builder = new DbContextOptionsBuilder<VinodrillDBContext>().UseNpgsql("Server=postgresql-vinodrill.alwaysdata.net;port=5432;Database=vinodrill_main_db;uid=vinodrill;password=uaK99vfWnq6GLrg;SearchPath=vinodrill;"); // Chaine de connexion à mettre dans les ( )
            _context = new VinodrillDBContext(builder.Options);
            _dataRepository = new ParticipeManager(_context);
            _controller = new ParticipeController(_dataRepository);

        }

        [TestMethod()]
        public async Task GetParticipesTestAsync()
        {
            ActionResult<IEnumerable<Participe>> users = await _controller.GetParticipes();
            CollectionAssert.AreEqual(_context.Participes.ToList(), users.Value.ToList(), "La liste renvoyée n'est pas la bonne.");
        }
    }
}