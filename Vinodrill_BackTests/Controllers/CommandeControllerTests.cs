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
    public class CommandeControllerTests
    {
        private readonly VinodrillDBContext _context;
        private readonly CommandeController _controller;
        private IDataRepository<Commande> _dataRepository;
        public CommandeControllerTests()
        {
            var builder = new DbContextOptionsBuilder<VinodrillDBContext>().UseNpgsql("Server=postgresql-vinodrill.alwaysdata.net;port=5432;Database=vinodrill_main_db;uid=vinodrill;password=uaK99vfWnq6GLrg;SearchPath=vinodrill;"); // Chaine de connexion à mettre dans les ( )
            _context = new VinodrillDBContext(builder.Options);
            _dataRepository = new CommandeManager(_context);
            _controller = new CommandeController(_dataRepository);

        }

        [TestMethod()]
        public async Task GetCommandesTestAsync()
        {
            ActionResult<IEnumerable<Commande>> users = await _controller.GetCommandes();
            CollectionAssert.AreEqual(_context.Commandes.ToList(), users.Value.ToList(), "La liste renvoyée n'est pas la bonne.");
        }

        [TestMethod()]
        public async Task GetCommandeByIdTest()
        {
            ActionResult<Commande> user = await _controller.GetCommandeById(1);
            Assert.AreEqual(_context.Commandes.Where(c => c.IdPaiement == 1).FirstOrDefault(), user.Value, "Commande différent");
        }

        [TestMethod()]
        public async Task GetCommandeByIdTestFalse()
        {
            ActionResult<Commande> user = await _controller.GetCommandeById(1);
            Assert.AreNotEqual(_context.Commandes.Where(c => c.IdPaiement == 2).FirstOrDefault(), user.Value, "Commande différent");
        }
    }
}