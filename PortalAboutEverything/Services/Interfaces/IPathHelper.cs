namespace PortalAboutEverything.Services.Interfaces
{
    public interface IPathHelper
    {
        string GetPathToMovieImage(int movieId);
        bool IsMovieImageExist(int id);
    }
}