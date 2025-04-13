// All rights reserved 2024 ©
// Copyright (c) Ekrem Bugra Berdan thirtwo@protonmail.com

using UnityEngine;
namespace Thirtwo.Config
{
    [CreateAssetMenu(fileName = "PrefabConfig", menuName = "Thirtwo/Data/Prefab Config")]
    public class PrefabConfig : Config
    {
        [field: Header("Prefabs")]
        [field: SerializeField] public GameObject LeaderboardEntryPrefab { get; private set; }
    }
}
