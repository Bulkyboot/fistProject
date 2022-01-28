using Dell.Lead.WeApi.Data.Converter.Contract;
using Dell.Lead.WeApi.Data.VO;
using Dell.Lead.WeApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace Dell.Lead.WeApi.Data.Converter.Converter
{
    public class ContributorsConverter : IParse<Contributors, ContributorsVO>, IParse<ContributorsVO, Contributors>
    {
        public Contributors Parse(ContributorsVO origin)
        {
            if(origin == null) return null;
            return new Contributors
            {
                Id = origin.Id,
                Name = origin.Name,
                Cpf = origin.Cpf,
                Cellfone = origin.Cellfone,
                DateOfBirth = origin.DateOfBirth,
                Gender = origin.Gender,
                AddressId = origin.Address.Id,
                Address = new AddressConverter().Parse(origin.Address)
            };
        }
        public ContributorsVO Parse(Contributors origin)
        {
            if(origin == null) return null;
            return new ContributorsVO
            {
                Id = origin.Id,
                Name = origin.Name,
                Cpf = origin.Cpf,
                Cellfone = origin.Cellfone,
                DateOfBirth = origin.DateOfBirth,
                Gender = origin.Gender,
                Address = new AddressConverter().Parse(origin.Address)
            };
        }
        public List<Contributors> Parse(List<ContributorsVO> origins)
        {
            if (origins == null) return null;
            return origins.Select(item => Parse(item)).ToList();
        }

        public List<ContributorsVO> Parse(List<Contributors> origins)
        {
            if (origins == null) return null;
            return origins.Select(item => Parse(item)).ToList();
        }
    }
}
