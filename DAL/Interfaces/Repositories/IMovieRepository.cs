﻿using DAL.Entities;
using DAL.Pagination;
using DAL.Parameters;

namespace DAL.Interfaces.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<PagedList<Movie>> GetAsync(MovieParameters parameters);
    }
}

