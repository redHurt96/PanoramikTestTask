using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Logic.Controllers.Queries;

namespace TestTask.Logic.Controllers.NetClientService
{
    public interface INetClient
    {
        Task<List<RankingUserData>> GetRankingsDataAsync();
        Task<UserData> GetUserDataAsync();
    }
}