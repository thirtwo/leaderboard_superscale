// All rights reserved 2024 ©
// Copyright (c) Ekrem Bugra Berdan thirtwo@protonmail.com

using UnityEngine;
namespace Thirtwo.Config
{
    [CreateAssetMenu(fileName = "LeaderboardConfig", menuName = "Thirtwo/Data/Leaderboard Config")]
    public class LeaderboardConfig : Config
    {
        [Tooltip("Set the most rank that get special badge")]
        [field: SerializeField] public int RankWithBadges { get; private set; }

        [field: SerializeField] public int[] DatapointCounts { get; private set; }


    }
}
