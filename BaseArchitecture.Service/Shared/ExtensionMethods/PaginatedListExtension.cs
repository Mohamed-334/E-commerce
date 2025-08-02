﻿using BaseArchitecture.Service.Shared.PaginatedList;
using Microsoft.EntityFrameworkCore;

namespace BaseArchitecture.Service.Shared.ExtensionMethods
{
    public static class PaginatedListExtension
    {
        public static async Task<PaginatedList<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize)
            where T : class
        {
            if (source == null)
            {
                throw new Exception("Empty");
            }

            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;
            int count = await source.AsNoTracking().CountAsync();

            if (count == 0)
                return PaginatedList<T>.Success(new List<T>(), count, pageNumber, pageSize);

            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return PaginatedList<T>.Success(items, count, pageNumber, pageSize);
        }
    }
}
