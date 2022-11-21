using ShopAngular.Model.Entities;
using ShopAngular.Model.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopAngular.Model.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);
        Task<IReadOnlyList<T>> GetAll();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> List(ISpecification<T> spec);
        Task<int> Count(ISpecification<T> spec);
    }
}
