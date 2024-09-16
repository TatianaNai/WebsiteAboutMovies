using Microsoft.AspNetCore.Hosting;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using PortalAboutEverything.Data.Model;
using PortalAboutEverything.Services;

namespace PortalAboutEverything.Tests.Services
{
    public class PathHelperTest
    {
        public const string FAKE_PROJECT_PATH = "C:\\project";

        private Mock<IWebHostEnvironment> _webHostEnvironmentMock;
        private PathHelper _pathHelper;

        [SetUp]
        public void SetUp()
        {
            _webHostEnvironmentMock = new Mock<IWebHostEnvironment>();
            _pathHelper = new PathHelper(_webHostEnvironmentMock.Object);
        }

        [Test]
        [TestCase(12, "C:\\project\\images\\Movie\\cover-12.jpg")]
        [TestCase(35, "C:\\project\\images\\Movie\\cover-35.jpg")]
        public void GetPathToMovieImage(int movieId, string path)
        {
            // Prepare
            _webHostEnvironmentMock
                .Setup(x => x.WebRootPath)
                .Returns(FAKE_PROJECT_PATH);

            // Act
            var result = _pathHelper.GetPathToMovieImage(movieId);

            // Assert
            Assert.That(result, Is.EqualTo(path));
        }
    }
}
