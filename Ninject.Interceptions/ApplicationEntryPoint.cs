using System;
using Ninject.Interceptions.Repository;

namespace Ninject.Interceptions
{
    public class ApplicationEntryPoint
    {
        private readonly IRepository _repository;

        public ApplicationEntryPoint(IRepository repository)
        {
            _repository = repository;
        }

        public void GetByIdFromRepo()
        {
            _repository.GetById(3);
        }

        public void DoStuff()
        {
            _repository.GetById(3);
        }

        public void GetAllBetweenDatesFromRepo()
        {
            _repository.GetAllBetween(DateTime.Now.AddDays(-1), DateTime.Now);
        }
    }
}
