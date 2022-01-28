using Dell.Lead.WeApi.Models;
using System.Collections.Generic;

namespace Dell.Lead.WeApi.Repositories
{
    public interface IContributorsRepository
    {
        Contributors FindByCpf(long cpf);
        List<Contributors> FindAll();
        Contributors Create(Contributors contributors);
        Contributors Update(Contributors contributors);
        bool IsCpf(long cpf);
        void Delete(long cpf);
    }
}
