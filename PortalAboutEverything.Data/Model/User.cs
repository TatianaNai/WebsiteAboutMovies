using PortalAboutEverything.Data.Enums;
using PortalAboutEverything.Data.Model.Alerts;

namespace PortalAboutEverything.Data.Model
{
    public class User : BaseModel
    {
        // TODO [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserName { get; set; }
        public string Password { get; set; } // TODO Store only hash

        public Language Language { get; set; } = Language.Ru;

        public Permission Permission { get; set; }
        public UserRole Role {  get; set; }

        public virtual List<Movie> FavoriteMovies { get; set; }

        public virtual List<AlertUser> AlertsWhichISaw { get; set; }
    }
}
