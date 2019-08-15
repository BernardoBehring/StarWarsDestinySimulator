using StarWarsDestiny.Crawler.Base.Interfaces;

namespace StarWarsDestiny.Crawler.Deck.Interfaces
{
    public interface IDownloadDeckSWDestinyDBExtractor : ICrawlerBaseExtractor
    {
        int GetMaxPageNumber(string page);
    }
}
