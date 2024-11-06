using Restapi_Authentication.Hypermedia.Utils;
using RestWithASPNETUdemy.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(int id);
        List<PersonVO> FindByName(string firstName, string lastName);
        PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
        PersonVO Update(PersonVO person);
        PersonVO Disable(int id);
        void Delete(int id);
    }
}
