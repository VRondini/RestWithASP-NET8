﻿using Restapi_WorkingWithFiles.Data.VO;

namespace Restapi_WorkingWithFiles.Business
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