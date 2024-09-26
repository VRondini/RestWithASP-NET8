using Restapi_PersonController.Data.VO;

namespace Restapi_PersonController.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(int id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(int Id);
    }
}
