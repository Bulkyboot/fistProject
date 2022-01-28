using Dell.Lead.WeApi.Data.VO;
using System.Collections.Generic;

namespace Dell.Lead.WeApi.Business
{
    public interface IContributorsBusiness
    {
        ContributorsVO FindByCpf(long cpf);
        List<ContributorsVO> FindAll();
        ContributorsVO Create(ContributorsVO contributors);
        ContributorsVO Update(ContributorsVO contributors);
        void Delete(long cpf);
        bool IsCpf(long cpf);

    }
}
