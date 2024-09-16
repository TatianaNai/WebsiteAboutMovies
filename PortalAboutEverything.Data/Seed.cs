using Microsoft.Extensions.DependencyInjection;
using PortalAboutEverything.Data.Enums;
using PortalAboutEverything.Data.Model;
using PortalAboutEverything.Data.Repositories;

namespace PortalAboutEverything.Data
{
    public class Seed
    {
        public void Fill(IServiceProvider serviceProvider)
        {
            using var service = serviceProvider.CreateScope();

            FillUsers(service);
            FillMovies(service);
        }

        private void FillUsers(IServiceScope service)
        {
            var userRepository = service.ServiceProvider.GetService<UserRepository>()!;

            if (!userRepository.Any())
            {
                var admin = new User
                {
                    UserName = "admin",
                    Password = "admin",
                    Role = UserRole.Admin,
                    Language = Language.En
                };
                userRepository.Create(admin);

                var user = new User
                {
                    UserName = "user",
                    Password = "user",
                    Role = UserRole.User,
                    Language = Language.Ru
                };
                userRepository.Create(user);
            }
        }

        public void FillMovies(IServiceScope service)
        {
            var movieRepositories = service.ServiceProvider.GetService<MovieRepositories>()!;
            
            if (!movieRepositories.Any())
            {
                var inception = new Movie
                {
                    Name = "Inception",
                    Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.",
                    ReleaseYear = 2010,
                    Director = "Christopher Nolan",
                    Budget = 160_000_000,
                    CountryOfOrigin = "USA",
                };
                movieRepositories.Create(inception);
                
                var insideOut = new Movie
                {
                    Name = "InsideOut",
                    Description = "After young Riley is uprooted from her Midwest life and moved to San Francisco, her emotions - Joy, Fear, Anger, Disgust and Sadness - conflict on how best to navigate a new city, house, and school.",
                    ReleaseYear = 2015,
                    Director = "Pete Docter",
                    Budget = 175_000_000,
                    CountryOfOrigin = "USA",
                };
                movieRepositories.Create(insideOut);
            }
        }
    }
}
