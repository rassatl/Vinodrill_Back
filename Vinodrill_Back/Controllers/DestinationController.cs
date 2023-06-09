﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Controllers //PROBLEM 
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IDataRepository<Destination> dataRepository;

        public DestinationController(IDataRepository<Destination> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Destination
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Destination>))]
        public async Task<ActionResult<IEnumerable<Destination>>> GetDestination()
        {
            return await dataRepository.GetAll();
        }
    }
}
