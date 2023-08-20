using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Logic.Controllers.Queries;
using UnityEngine;

namespace TestTask.Logic.Controllers.NetClientService
{
    public sealed class NetClient : INetClient
    {
        private const int _millisecondsDelayRime = 500;
        private const int _playerRank = 9;
        
        private string _jsonData;
        private List<RankingUserData> _rankingUserData;
        
        public int GetPlayerRank => _playerRank;
        
        public async Task<List<RankingUserData>> GetRankingsDataAsync()
        {
            await Task.Delay(_millisecondsDelayRime);
           
            if (_rankingUserData == null || !_rankingUserData.Any()) 
                LoadRankingsData();

            return _rankingUserData;
        }

        private void LoadRankingsData() =>
            _rankingUserData = Resources
                .Load<RankingsData>("RankingsData")
                .RankingUserData;

        public async Task<UserData> GetUserDataAsync()
        {
            await Task.Delay(_millisecondsDelayRime);
           
            if (_rankingUserData == null || !_rankingUserData.Any()) 
                LoadRankingsData();

            RankingUserData userData = _rankingUserData.Find(x => x.IsLocal);
            return new (userData.Nickname, userData.Rank);
        }
    }
}