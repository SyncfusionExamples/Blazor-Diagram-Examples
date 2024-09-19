using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
namespace DiagramWithRemoteData.Models
{
    public class Employee
    {
        [Key]
        [DisplayName("EmployeeID")]
        public required int EmployeeID { get; set; }

        [DisplayName("Name")]
        public required string Name { get; set; }

        [DisplayName("ReportsTo")]
        public required string ReportsTo { get; set; }

        public required string Designation { get; set; }

        public required string Colour { get; set; }


    }
}
