﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bkc_backend.Controller.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using bkc_backend.Services;
using bkc_backend.Data.Entities;
using bkc_backend.Services.EmployeeServices;
using bkc_backend.Controller.ViewModel.Request;
using bkc_backend.Api.ViewModel.Response;

namespace bkc_backend.Controller.Controllers
{
    public class AuthController : ControllerBase
    {
        private IEmployeeServices _employeeServices;
        private ICreateToken _token;
        private IUserRoleServices _userRoleServices;
        private IRoleServices _roleServices;
        public AuthController(IEmployeeServices employeeServices, ICreateToken token,
            IUserRoleServices userRoleServices, IRoleServices roleServices)
        {
            _token = token;
            _employeeServices = employeeServices;
            _userRoleServices = userRoleServices;
            _roleServices = roleServices;
        }
        [AllowAnonymous]
        [Route("api/authenticate")]
        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthRequest authRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Email");
            }
            Employee emp = _employeeServices.GetEmployeeByEmail(authRequest.Email);
            if (emp == null)
            {
                return BadRequest();
            }
            var userRole = _userRoleServices.GetUserRoleByUserId(emp.Id);
            if (userRole == null)
            {
                return BadRequest();
            }
            var role = _roleServices.GetById(userRole.RoleId);
            if (role == null)
            {
                return BadRequest();
            }
            emp.Role = role.Name;
            string token = _token.Create(emp.Name, role.Name);
            AuthResponse response = new AuthResponse() { Token = token, Employee = emp };
            return Ok(response);
        }

        [AllowAnonymous]
        [Route("api/bkc/authenticate1")]
        [HttpGet]
        public IActionResult Authenticate1()
        {
            return Ok("helllo");
        }
    }
}
