﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusReservationApi.Controllers
{
    public class Admin {
        public int AdminId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        static List<Admin> admins = new List<Admin> {
            new Admin{ AdminId = 1, Email = "admin1@gmail.com", Password = "admin", FirstName = "Anshul", LastName = "Bansal"},
            new Admin{ AdminId = 2, Email = "admin2@gmail.com", Password = "admin", FirstName = "Jitin", LastName = "Sharma"},
            new Admin{ AdminId = 3, Email = "admin3@gmail.com", Password = "admin", FirstName = "Divya", LastName = "Kumar"},
            new Admin{ AdminId = 4, Email = "admin4@gmail.com", Password = "admin", FirstName = "Omkar", LastName = "Bhagwat"}

        };

        // GET: api/<AdminSigninController>
        // to get the details of all admins
        [HttpGet]
        [Route("list")]
        public IActionResult GetAdmin()
        {
            return Ok(admins);
        }

        // GET api/<AdminSigninController>/5
        // to get the details of the specific admin
        [HttpGet("{id}")]
        [Route("list/{id}")]
        public IActionResult GetAdmin(int id)
        {
            var data = admins.Where(admin => admin.AdminId == id).FirstOrDefault();
            return Ok(data);
        }

        [HttpPost]
        [Route("validate")]
        public IActionResult PostAdmin(string Email, string Password) {
            if (ModelState.IsValid) {
                var data = admins.Where(admin => admin.Email == Email && admin.Password == Password).FirstOrDefault();
                if (data != null) return Ok(data);
                else return NotFound("Admin is not registered");
            }
            return BadRequest("Something went wrong");
        }
    }
}