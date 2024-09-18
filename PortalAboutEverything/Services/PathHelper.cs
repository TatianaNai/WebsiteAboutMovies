using PortalAboutEverything.Services.Interfaces;

namespace PortalAboutEverything.Services
{
    public class PathHelper : IPathHelper
    {
        private IWebHostEnvironment _webHostEnvironment;

        public PathHelper(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string GetPathToMovieImage(int movieId)
        {
            var fileName = $"cover-{movieId}.jpg";
            return GetPathByFolder("images\\Movie", fileName);
        }

        public bool IsMovieImageExist(int id)
        {
            var path = GetPathToMovieImage(id);
            return File.Exists(path);
        }

        private string GetPathByFolder(string pathToFolder, string fileName)
        {
            var path = Path.Combine(_webHostEnvironment.WebRootPath, pathToFolder, fileName);
            return path;
        }
    }
}
