using StarWarsDestiny.Crawler.Card.Controller;
using StarWarsDestiny.Crawler.Card.Interfaces;
using StarWarsDestiny.Crawler.Model.Enum;
using System;
using System.Threading.Tasks;

namespace StarWarsDestiny.Crawler.Card
{
    public class Program
    {
        private readonly IDownloadCardSWDestinyDBController _downloadCardController;

        public Program(IDownloadCardSWDestinyDBController downloadCardController)
        {
            _downloadCardController = downloadCardController;
        }
        public async Task Main(string[] args)
        {
            EnumStatus? status = null;
            if (args.Length > 1 && args[1] != null)
                status = (EnumStatus)Enum.Parse(typeof(EnumStatus), args[1]);

            if (status == null)
                status = EnumStatus.AwaitingProcessing;

            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Executing");

            if (args.Length > 0 && string.Equals(args[0], "/downloadCards", StringComparison.CurrentCultureIgnoreCase))
            {
                await _downloadCardController.ExecuteAsync(status.Value);
            }
        }
    }
}
