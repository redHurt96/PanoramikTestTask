using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Logic.Controllers.NetClientService
{
    [CreateAssetMenu(fileName = "RankingsData", menuName = "RankingsData")]
    public class RankingsData : ScriptableObject
    {
        public List<RankingUserData> RankingUserData;
    }
}