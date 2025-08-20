using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Infrastructure.Context;
using BaseArchitecture.Infrastructure.Shared.BaseRepository;
using EcommerceProject.Infrastructure.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProject.Infrastructure.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        #region Feilds
        private readonly DbSet<Product> _set;
        #endregion

        #region Constructor(s)
        public ProductRepository(AppDbContext context) : base(context)
        {
            _set = context.Set<Product>();
        }
        #endregion


        #region Methods
        #endregion
    }
}
