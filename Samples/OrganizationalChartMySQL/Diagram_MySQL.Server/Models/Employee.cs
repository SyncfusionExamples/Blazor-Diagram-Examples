using LinqToDB.Mapping;

namespace Diagram_MySQL.Server.Models
{
    [Table("employees")]
    public class Employee
    {
        [PrimaryKey, Identity]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        [NotNull]
        public string Name { get; set; }

        [Column("ParentId")]
        public int? ParentId { get; set; }
    }
}