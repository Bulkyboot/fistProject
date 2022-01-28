using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Dell.Lead.WeApi.Data.VO
{
    public class UserVO
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
