using System;

namespace TestTask.Logic.Controllers.NetClientService
{
    [Serializable]
    public struct RankingUserData
    {
        public string Nickname;
        public int Position;
        public int Rank;
        public string IconName;
        public bool IsLocal;

        public RankingUserData(string nickname, int position, int rank, string iconName, bool isLocal)
        {
            Nickname = nickname;
            Position = position;
            Rank = rank;
            IconName = iconName;
            IsLocal = isLocal;
        }
    }
}