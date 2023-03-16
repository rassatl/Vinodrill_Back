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
    public class HotelControllerTests
    {
        private readonly VinodrillDBContext _context;
        private readonly HotelController _controller;
        private IDataRepository<Hotel> _dataRepository;
        public HotelControllerTests()
        {
            var builder = new DbContextOptionsBuilder<VinodrillDBContext>().UseNpgsql("Server=postgresql-vinodrill.alwaysdata.net;port=5432;Database=vinodrill_main_db;uid=vinodrill;password=uaK99vfWnq6GLrg;SearchPath=vinodrill;"); // Chaine de connexion à mettre dans les ( )
            _context = new VinodrillDBContext(builder.Options);
            _dataRepository = new HotelManager(_context);
            _controller = new HotelController(_dataRepository);

        }

        [TestMethod()]
        public async Task GetHotelsTestAsync()
        {
            ActionResult<IEnumerable<Hotel>> users = await _controller.GetHotels();
            CollectionAssert.AreEqual(_context.Hotels.ToList(), users.Value.ToList(), "La liste renvoyée n'est pas la bonne.");
        }

        [TestMethod()]
        public async Task GetHotelByIdTest()
        {
            ActionResult<Hotel> user = await _controller.GetHotelById(1);
            Assert.AreEqual(_context.Hotels.Where(c => c.IdPartenaire == 1).FirstOrDefault(), user.Value, "Hotel différent");
        }

        [TestMethod()]
        public async Task GetHotelByIdTestFalse()
        {
            ActionResult<Hotel> user = await _controller.GetHotelById(1);
            //Assert.AreNotEqual(_context.Hotels.Where(c => c.IdPartenaire == 2).FirstOrDefault(), user.Value, "Hotel différent");
            Assert.IsFalse(_context.Hotels.Where(c => c.IdPartenaire == 2).FirstOrDefault() != user.Value, "Hotel différent");
        }
    }
}