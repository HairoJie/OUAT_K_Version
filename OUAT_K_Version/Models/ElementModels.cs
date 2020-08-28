using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OUAT_K_Version.Models
{
    public class ElementModels
    {
        [Display (Name = "Card Type")]
        public string ElementType { get; set; }

        [Display(Name ="Card Name")]
        [Required(ErrorMessage = "Name is Needed")]
        public string ElementName { get; set; }

        [Display(Name = "Add san")]
        public int InSan { get; set; }

        [Display(Name = "Minus san")]
        public int DeSan { get; set; }
        
        [Display(Name ="CEC?")]
        public string IsForce { get; set; }

        [Display(Name ="Interrupt?")]
        public string IsInter { get; set; }

        [Display(Name = "Card Description")]
        public string ElementDes { get; set; }

        public byte[] ImagePath { get; set; }

        public string convPath { get; set; }
    }
}