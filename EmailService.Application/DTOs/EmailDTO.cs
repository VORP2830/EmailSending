using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailService.Application.DTOs
{
    public class EmailDTO
    {
        public string Addressee { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}