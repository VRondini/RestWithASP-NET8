﻿using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Base;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(int id);
        List<T> FindAll();
        T Update(T item);
        void Delete(int Id);
        bool Exists(int id);
        List<T> FindWithPagedSearch(string query);
        int GetCount(string query);
    }
}
