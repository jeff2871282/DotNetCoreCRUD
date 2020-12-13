using System.ComponentModel.DataAnnotations;

namespace DotNetCoreCRUD.Models
{
    public class login
    {
        public class loginModels{
            
            [Required]
            public string username{get;set;}
            [Required]
            public string password{get;set;}
        }

        public class loginResult{
            public string token{get;set;}
        }
    }
}