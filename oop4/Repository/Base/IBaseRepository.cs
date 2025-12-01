using System.Collections.Generic;


namespace DuelingClubAppStarWars.Repository.Base
{
    public interface IBaseRepository<T>
    {
        void Add(T entity);
        T GetById(int id);
        List<T> GetAll();
        void Update(T entity);
        void Delete(int id);
    }
}