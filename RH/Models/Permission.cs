using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;

namespace RH.Models
{
    public class Permission
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public Permission()
        {
        }

        public Permission (int id, string name)
        {
            Id = id;
            Name = name;
        }


    }

}
