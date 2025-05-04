using LightNap.Core.Data;
using LightNap.Core.Data.Entities;
using LightNap.Core.Extensions;
using LightNap.Core.Competitions.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace LightNap.Core.Tests.Services
{
    [TestClass]
    public class CompetitionServiceTests
    {
        // These will be initialized during TestInitialize.
#pragma warning disable CS8618
        private ApplicationDbContext _dbContext;
        private CompetitionService _competitionService;
#pragma warning restore CS8618

        [TestInitialize]
        public void TestInitialize()
        {
            var services = new ServiceCollection();
            services.AddLogging()
                .AddLightNapInMemoryDatabase()
                .AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            var serviceProvider = services.BuildServiceProvider();
            _dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

            _competitionService = new CompetitionService(this._dbContext);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetCompetitions_ShouldReturnEmptyList_WhenNoCompetitionsExist()
        {
            // Arrange
            // No competitions are added to the database.

            // Act
            var competitions = await _competitionService.GetCompetitionsAsync();

            // Assert
            Assert.IsNotNull(competitions);
            Assert.AreEqual(0, competitions.Count);
        }


    }
}
