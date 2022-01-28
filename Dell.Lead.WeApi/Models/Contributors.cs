using Dell.Lead.WeApi.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dell.Lead.WeApi.Models
{
    [Table("Contributors")]
    public class Contributors : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }
        [Column("cpf")]
        public long Cpf { get; set; }
        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }
        [Column("cellfone")]
        public long Cellfone { get; set; }
        [Column("gender")]
        public string Gender { get; set; }
        [Column("address_id")]
        public long AddressId { get; set; }
        [Column("address")]
        public Address Address { get; set; }


    }
}
