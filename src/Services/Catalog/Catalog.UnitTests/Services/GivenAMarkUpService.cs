namespace Catalog.UnitTests.Services;

public class GivenAMarkUpService {

    public MarkUpService _sut;

    public GivenAMarkUpService()
    {
        _sut = new MarkUpService();
    }

    [Fact]
    [Trait("Type", "UnitTest")]
    public void WhenAMarkUpIsRequested_ThenTheCorrectMarkUpIsReturned() {

        var result = _sut.GetCurrentMarkUp();

        Assert.True(result == (decimal)1.2);
    }
}