using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Logic.Controllers.NetClientService;

namespace TestTask.Logic.Controllers.Queries
{
    public interface IRankingsQuery
    {
        Task<List<RankingUserData>> Get();
    }
}