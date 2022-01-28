using Dell.Lead.WeApi.Data.Converter.Converter;
using Dell.Lead.WeApi.Data.VO;
using Dell.Lead.WeApi.Repositories;
using System;
using System.Collections.Generic;

namespace Dell.Lead.WeApi.Business.Implementation
{
    public class ContributorsBusinessImplementation : IContributorsBusiness
    {
        private readonly IContributorsRepository _Repository;
        private readonly ContributorsConverter _converter;

        public ContributorsBusinessImplementation(IContributorsRepository Repository)
        {
            _Repository = Repository;
            _converter = new ContributorsConverter();
        }
        public ContributorsVO Create(ContributorsVO contributors)
        {
            var contributorsEntity = _converter.Parse(contributors);
            contributorsEntity = _Repository.Create(contributorsEntity);
            return _converter.Parse(contributorsEntity);
            if (contributorsEntity == null)
            {
                Console.WriteLine("This item is null");
            }
            else
            {
                Console.WriteLine("The item has already been registered");
            }
        }

        public void Delete(long cpf)
        {
            _Repository.Delete(cpf);
        }

        public List<ContributorsVO> FindAll()
        {
            return _converter.Parse(_Repository.FindAll());
        }

        public ContributorsVO FindByCpf(long cpf)
        {
            var contributorscpf = _Repository.FindByCpf(cpf);
            if (contributorscpf == null); 
            return _converter.Parse(contributorscpf);
        }

        public ContributorsVO Update(ContributorsVO contributors)
        {
            var contributorsConverter = _converter.Parse(contributors);
            contributorsConverter.AddressId = contributors.Address.Id;
            if(FindByCpf(contributorsConverter.Cpf) != null)
            {
                contributorsConverter = _Repository.Update(contributorsConverter);
                return _converter.Parse(contributorsConverter);
            }
            return null;
        }
        public bool IsCpf(long cpf)
        {
            return _Repository.IsCpf(cpf);
        }
    }
}
