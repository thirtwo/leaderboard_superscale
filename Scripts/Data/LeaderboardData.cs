// All rights reserved 2024 ©
// Copyright (c) Ekrem Bugra Berdan thirtwo@protonmail.com

using System.Collections.Generic;
namespace Thirtwo.Data
{
    [System.Serializable]
    public class LeaderboardData
    {
        public List<LeaderboardEntryData> Ranking;
        public string PlayerUID;

    }
}
