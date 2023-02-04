using System.ComponentModel.DataAnnotations.Schema;

namespace RH.Models
{
    public class Employee
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
        
        [Column ("email")]
        public string Email { get; set; }
        
        [Column ("password")]
        public string Password { get; set; }

        [Column ("salary")]
        public decimal Salary { get; set; }

        public Permission Permission { get; set; }

        [Column ("permission")]
        public int PermissionId { get; set; }


    }
}
