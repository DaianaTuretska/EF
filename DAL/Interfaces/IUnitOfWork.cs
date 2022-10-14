using DAL.Entities;
using DAL.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;


namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        UserManager<User> UserManager { get; }
        SignInManager<User> SignInManager { get; }
        ISeanceRepository SeanceRepository { get; }
        IMovieRepository MovieRepository { get; }
        ICinemaRepository CinemaRepository { get; }

        Task Commit();
        Task Dispose();
    }
}
