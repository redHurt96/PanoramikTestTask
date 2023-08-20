using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Logic.Controllers.NetClientService;

namespace TestTask.Logic.Controllers.Queries
{
    internal class RankingsQuery : IRankingsQuery
    {
        private readonly INetClient _netClient;

        public RankingsQuery(INetClient netClient) => 
            _netClient = netClient;

        public async Task<List<RankingUserData>> Get() => 
            await _netClient.GetRankingsDataAsync();
    }
}