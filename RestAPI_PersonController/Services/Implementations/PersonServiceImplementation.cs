using Microsoft.EntityFrameworkCore;
using Restapi_PersonController.Model;
using Restapi_PersonController.Model.Context;
using System;

namespace Restapi_PersonController.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private SqlServerContext _context;

        public PersonServiceImplementation(SqlServerContext context)
        {
            _context = context;
        }
        public List<Person> FindAll()
        {            
            return _context.Persons.ToList();
        }

        public Person FindById(int id)
        {
            return _context.Persons.SingleOrDefault(p=>p.Id.Equals(id));
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return person;
        }
        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            if(result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }

            }
            return person;
        }

        public void Delete(int id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }
        private bool Exists(int id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
