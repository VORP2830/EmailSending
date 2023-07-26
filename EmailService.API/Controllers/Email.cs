using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmailService.Application.Interface;
using EmailService.Application.DTOs;
using Microsoft.AspNetCore.Http;
using EmailService.Application.Service;

namespace EmailService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok("Acessado em " + DateTime.Now.ToLongDateString());
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> Post(EmailDTO model)
        {
            try
            {
                var email = _emailService.SendEmail(model);
                return Ok(email);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
