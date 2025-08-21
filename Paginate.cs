﻿using PresupuestitoBack.DTOs;

namespace PresupuestitoBack
{
    public class PaginateHelper
    {
        public static PaginateDto<T> Paginate<T>(List<T> itemsToPaginate, int currentPage, string url, int pageSize = 10)
        {
            var totalItems = itemsToPaginate.Count;
            var totalPage = (int)Math.Ceiling((double)totalItems / pageSize);

            var paginateItems = itemsToPaginate.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            var prevUrl = currentPage > 1 ? $"{url}?page={currentPage - 1}" : null;
            var nextUrl = currentPage < totalPage ? $"{url}?page={currentPage + 1}" : null;

            return new PaginateDto<T>()
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPage,
                PrevUrl = prevUrl,
                NextUrl = nextUrl,
                Items = paginateItems
            };
        }
    }
}
