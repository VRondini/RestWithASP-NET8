﻿using Restapi_WorkingWithFiles.Data.Converter.Implementations;
using Restapi_WorkingWithFiles.Data.VO;
using Restapi_WorkingWithFiles.Model;
using Restapi_WorkingWithFiles.Repository;

namespace Restapi_WorkingWithFiles.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }
        public List<PersonVO> FindAll()
        {            
            return _converter.Parse(_repository.FindAll());
        }

        public PersonVO FindById(int id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }
        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}