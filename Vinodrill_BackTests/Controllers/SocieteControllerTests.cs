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
    public class SocieteControllerTests
    {
        private readonly VinodrillDBContext _context;
        private readonly SocieteController _controller;
        private IDataRepository<Societe> _dataRepository;
        public SocieteControllerTests()
        {
            var builder = new DbContextOptionsBuilder<VinodrillDBContext>().UseNpgsql("Server=postgresql-vinodrill.alwaysdata.net;port=5432;Database=vinodrill_main_db;uid=vinodrill;password=uaK99vfWnq6GLrg;SearchPath=vinodrill;"); // Chaine de connexion à mettre dans les ( )
            _context = new VinodrillDBContext(builder.Options);
            _dataRepository = new SocieteManager(_context);
            _controller = new SocieteController(_dataRepository);

        }

        [TestMethod()]
        public async Task GetSocietesTestAsync()
        {
            ActionResult<IEnumerable<Societe>> users = await _controller.GetSocietes();
            CollectionAssert.AreEqual(_context.Societes.ToList(), users.Value.ToList(), "La liste renvoyée n'est pas la bonne.");
        }
    }
}