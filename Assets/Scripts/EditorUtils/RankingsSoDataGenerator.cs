using System;
using System.Collections.Generic;
using TestTask.Logic.Controllers.NetClientService;
using UnityEngine;
using Random = System.Random;

namespace EditorUtils
{
    public sealed class RankingsSoDataGenerator : MonoBehaviour
    {
        [SerializeField] private RankingsData _rankingsData;
        [SerializeField] private int _playersCount = 84;
        [SerializeField] private int _maxRank = 100000;
        
        private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string _constIconNamePart = "icons_1_";
        private const int _iconsCount = 20;
        private const int _maxNameLength = 15;
        private const int _minNameLength = 5;
        
        private readonly Random _random = new Random();
        
        [ContextMenu("Generate")]
        private void GeneratePlayersData()
        {
            _rankingsData.RankingUserData ??= new List<RankingUserData>();
            _rankingsData.RankingUserData.Clear();
            
            var rankStep = _maxRank / _playersCount;
            var currentRank = _maxRank;
            for (var i = 0; i < _playersCount; i++)
            {
                // currentRank -= rankStep;
                // _rankingsData.RankingUserData.Add(new RankingUserData(
                //     RandomString(_random.Next(_minNameLength, _maxNameLength)),
                //     i + 1,
                //     Math.Clamp(currentRank - _random.Next(0, rankStep / 2), 0, _maxRank),
                //     $"{_constIconNamePart}{_random.Next(0, _iconsCount)}"));
            }
        }

        private string RandomString(int length)
        {
            var result = string.Empty;

            for (var i = 0; i < length; i++)
                result += _chars[_random.Next(0, _chars.Length)];

            return result;
        }
    }
}