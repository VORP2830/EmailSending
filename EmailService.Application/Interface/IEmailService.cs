using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailService.Application.DTOs;

namespace EmailService.Application.Interface
{
    public interface IEmailService
    {
        string SendEmail(EmailDTO model);
    }
}