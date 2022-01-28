using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Dell.Lead.WeApi.Data.VO
{
    public class AddressVO
    {
        /// <summary>
        /// ID address
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Name of street
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// Name of home
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Name of district
        /// </summary>
        public string District { get; set; }
        /// <summary>
        /// Name of city
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Stade name
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Cep if address
        /// </summary>
        public long Cep { get; set; }
    }
}
