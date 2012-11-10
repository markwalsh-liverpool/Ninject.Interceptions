using System;

namespace Ninject.Interceptions.Repository
{
    public class Repository : IRepository
    {
        //Don't have to be virtual!
        public string GetById(int id)
        {
            return "test string1";
        }

        //Don't have to be virtual
        public string GetAllBetween(DateTime StartDate, DateTime EndDate)
        {
            return "test string2";
        }
    }
}
