using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Messages.Web.ViewModels
{

    public class MessageCreateVM
    {
        [Required]
        public string Body { get; set; }
    }
}