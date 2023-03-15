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
    public class DestinationControllerTests
    {
        private readonly VinodrillDBContext _context;
        private readonly DestinationController _controller;
        private IDataRepository<Destination> _dataRepository;
        public DestinationControllerTests()
        {
            var builder = new DbContextOptionsBuilder<VinodrillDBContext>().UseNpgsql("Server=postgresql-vinodrill.alwaysdata.net;port=5432;Database=vinodrill_main_db;uid=vinodrill;password=uaK99vfWnq6GLrg;SearchPath=vinodrill;"); // Chaine de connexion à mettre dans les ( )
            _context = new VinodrillDBContext(builder.Options);
            _dataRepository = new DestinationManager(_context);
            _controller = new DestinationController(_dataRepository);

        }

        [TestMethod()]
        public async Task GetDestinationsTestAsync()
        {
            ActionResult<IEnumerable<Destination>> users = await _controller.GetDestination();
            CollectionAssert.AreEqual(_context.Destination.ToList(), users.Value.ToList(), "La liste renvoyée n'est pas la bonne.");
        }
    }
}