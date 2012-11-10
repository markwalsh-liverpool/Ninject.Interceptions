using System;

namespace Ninject.Interceptions.Repository
{
    public interface IRepository
    {
        string GetById(int id);
        string GetAllBetween(DateTime StartDate, DateTime EndDate);
    }
}
