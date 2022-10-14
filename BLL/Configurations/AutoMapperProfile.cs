using AutoMapper;
using BLL.DTO.Requests;
using BLL.DTO.Responses;
using DAL.Entities;

namespace BLL.Configurations
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateSeanceMaps();
            CreateUsersMaps();
            CreateMovieMaps();
            CreateCinemaMaps();
        }

        private void CreateUsersMaps()
        {
            CreateMap<UserSignUpRequest, User>();
            CreateMap<UserRequest, User>();
            CreateMap<User, UserResponse>()
                .ForMember(response => response.FullName,
                options => options.MapFrom(user => $"{user.FirstName} {user.LastName}"));
        }

        private void CreateSeanceMaps()
        {
            CreateMap<SeanceRequest, Seance>();
            CreateMap<Seance, SeanceResponse>();
        }

        private void CreateMovieMaps()
        {
            CreateMap<MovieRequest, Movie>();
            CreateMap<Movie, MovieResponse>();
        }

        private void CreateCinemaMaps()
        {
            CreateMap<CinemaRequest, Cinema>();
            CreateMap<Cinema, CinemaResponse>()
                .ForMember(response => response.During, 
                options => options.MapFrom(address => address.Seance.During))
                .ForMember(response => response.City,
                options => options.MapFrom(address => address.Seance.City))
                 .ForMember(response => response.DataTime,
                options => options.MapFrom(address => address.Seance.DataTime))
                  .ForMember(response => response.PlaceCount,
                options => options.MapFrom(address => address.Seance.PlaceCount));
        }
    }
}
