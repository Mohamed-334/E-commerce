﻿namespace BaseArchitecture.Service.Shared.PaginatedList
{
    public class PaginatedList<T>
    {
        public PaginatedList(List<T> data)
        {
            Data = data;
        }

        internal PaginatedList(bool succeeded, List<T> data = default, List<string> messages = null, int count = 0, int page = 1, int pageSize = 10)
        {
            Data = data;
            CurrentPage = page;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
        }

        public static PaginatedList<T> Success(List<T> data, int count, int page, int pageSize)
        {
            return new(true, data, null, count, page, pageSize);
        }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
        public List<T> Data { get; set; }
    }
}
