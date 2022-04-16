using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Threading.Tasks.Dataflow;
using CourierWebApp.Data;
using Microsoft.CodeAnalysis.CSharp;

namespace CourierWebApp.Models
{
    public class Users : IdentityUser
    {
        [Key]
        public override string Id { get; set; }
        public override string UserName { get; set; }
    }
}
