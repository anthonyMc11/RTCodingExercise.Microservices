namespace Catalog.UnitTests.Handlers
{
    public class GivenAGetPlatesHandler
    {
        public GetPlatesHandler _sut;

        public Mock<IPromotionService> _mockPromotionService = new();
        public Mock<IMarkUpService> _mockMarkUpService = new();
        public Mock<IPlatesRepository> _mockPlatesRepository = new();

        public IList<Plate> _plateDb = new List<Plate>();
        public GivenAGetPlatesHandler()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var context = new Mock<ApplicationDbContext>(optionsBuilder.Options);
            context.SetupGet(x => x.Plates).ReturnsDbSet(_plateDb);

            _mockPlatesRepository.Setup(s => s.AsQueryable()).Returns(() => context.Object.Plates);
            _sut = new GetPlatesHandler(_mockPlatesRepository.Object, _mockPromotionService.Object, _mockMarkUpService.Object);
        }

        [Fact]
        public async Task WhenItemsExistInTheDatabase_ThenTheyAreReturned()
        {
            _plateDb.Add(new() { Id = Guid.NewGuid(), Availability = Availability.Available, Registration = "ABC123", Letters = "ABC", Numbers = 123, PurchasePrice = 10, SalePrice = 100 });

            var result = await _sut.Handle(new(null, null, null, 1, 10, null, false));

            Assert.True(result.TotalCount == 1);
            Assert.True(result.Items.Count == 1);
        }

        [Theory]
        [InlineData(Availability.Available, 1)]
        [InlineData(Availability.Sold, 0)]
        [InlineData(Availability.Reserved, 0)]
        [InlineData(Availability.Revoked, 0)]
        public async Task WhenHideUnavailableIsSet_ThenTheyAreReturnedCorrectly(Availability availability, int resultCount)
        {
            _plateDb.Add(new() { Id = Guid.NewGuid(), Availability = availability, Registration = "ABC123", Letters = "ABC", Numbers = 123, PurchasePrice = 10, SalePrice = 100 });

            var result = await _sut.Handle(new(null, null, null, 1, 10, null, true));

            Assert.True(result.TotalCount == resultCount);
            Assert.True(result.Items.Count == resultCount);
        }

        [Theory]
        [InlineData("ABC", 1)]
        [InlineData("123", 1)]
        [InlineData("XYZ", 0)]
        [InlineData("567", 0)]
        public async Task WhenSearchingWithaSearchTerm_ThenCorrectResultReturned(string searchTerm, int resultCount)
        {
            _plateDb.Add(new() { Id = Guid.NewGuid(), Availability = Availability.Available, Registration = "ABC123", Letters = "ABC", Numbers = 123, PurchasePrice = 10, SalePrice = 100 });

            var result = await _sut.Handle(new(searchTerm, null, null, 1, 10, null, false));

            Assert.True(result.TotalCount == resultCount);
            Assert.True(result.Items.Count == resultCount);
        }

        //I would extend this testing to cover all the searchCriteria and edge cases as they are identified, 
        //This is needs to check the select statement and is not nessessarily testing Entity framework
    }
}