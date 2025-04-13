// All rights reserved 2024 ©
// Copyright (c) Ekrem Bugra Berdan thirtwo@protonmail.com

using Thirtwo.Data;
using Newtonsoft.Json;
using Thirtwo.Config;
using UnityEngine;
using Thirtwo.Factories;
namespace Thirtwo.Parse
{
    public class LeaderboardParser
    {
        private readonly LeaderboardDataFactory _dataFactory;
        public DataConfig Config { get; protected set; }
        public LeaderboardParser(DataConfig parsableAsset, LeaderboardDataFactory leaderboardDataFactory)
        {
            Config = parsableAsset;
            _dataFactory = leaderboardDataFactory;
        }


        public LeaderboardData Parse()
        {
            var data = JsonConvert.DeserializeObject<LeaderboardData>(Config.GetAsset().text);
            return data;
        }
    }
}
