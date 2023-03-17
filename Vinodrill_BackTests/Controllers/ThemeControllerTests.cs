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
    public class ThemeControllerTests
    {
        private readonly VinodrillDBContext _context;
        private readonly ThemeController _controller;
        private IDataRepository<Theme> _dataRepository;
        public ThemeControllerTests()
        {
            var builder = new DbContextOptionsBuilder<VinodrillDBContext>().UseNpgsql("Server=postgresql-vinodrill.alwaysdata.net;port=5432;Database=vinodrill_main_db;uid=vinodrill;password=uaK99vfWnq6GLrg;SearchPath=vinodrill;"); // Chaine de connexion à mettre dans les ( )
            _context = new VinodrillDBContext(builder.Options);
            _dataRepository = new ThemeManager(_context);
            _controller = new ThemeController(_dataRepository);

        }

        [TestMethod()]
        public async Task GetThemesTest_OK()
        {
            ActionResult<IEnumerable<Theme>> users = await _controller.GetThemes();
            CollectionAssert.AreEqual(_context.Themes.ToList(), users.Value.ToList(), "La liste renvoyée n'est pas la bonne.");
        }
    }
}