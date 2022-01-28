using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Dell.Lead.WeApi.Data.VO
{
    public class ContributorsVO
    {
        /// <summary>
        /// ID cadastro
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Complit name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Cpf number
        /// </summary>
        public long Cpf { get; set; }
        /// <summary>
        /// Date of birth
        /// </summary>

        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// cellfone number
        /// </summary>
        public long Cellfone { get; set; }
        /// <summary>
        /// gener
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// address information
        /// </summary>
        public AddressVO Address { get; set; }
    }
}
