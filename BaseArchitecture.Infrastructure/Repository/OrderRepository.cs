using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Infrastructure.Context;
using BaseArchitecture.Infrastructure.Shared.BaseRepository;
using EcommerceProject.Infrastructure.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProject.Infrastructure.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        #region Feilds
        private readonly DbSet<Order> _set;
        #endregion

        #region Constructor(s)
        public OrderRepository(AppDbContext context) : base(context)
        {
            _set = context.Set<Order>();
        }
        #endregion


        #region Methods
        #endregion
    }
}
