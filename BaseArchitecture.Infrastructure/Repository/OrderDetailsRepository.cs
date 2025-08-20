using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Infrastructure.Context;
using BaseArchitecture.Infrastructure.Shared.BaseRepository;
using EcommerceProject.Infrastructure.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProject.Infrastructure.Repository
{
    public class OrderDetailsRepository : BaseRepository<OrderDetails>, IOrderDetailsRepository
    {
        #region Feilds
        private readonly DbSet<OrderDetails> _set;
        #endregion

        #region Constructor(s)
        public OrderDetailsRepository(AppDbContext context) : base(context)
        {
            _set = context.Set<OrderDetails>();
        }
        #endregion


        #region Methods
        #endregion
    }
}
