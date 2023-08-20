using System.Threading.Tasks;
using TestTask.Logic.Controllers.NetClientService;

namespace TestTask.Logic.Controllers.Queries
{
    internal class CharacterQuery : ICharacterQuery
    {
        private readonly INetClient _netClient;

        public CharacterQuery(INetClient netClient) => 
            _netClient = netClient;
        
        public async Task<UserData> Get() => 
            await _netClient.GetUserDataAsync();
    }
}