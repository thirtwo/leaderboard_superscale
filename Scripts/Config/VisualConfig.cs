// All rights reserved 2024 ©
// Copyright (c) Ekrem Bugra Berdan thirtwo@protonmail.com

using System.Collections.Generic;
using UnityEngine;
namespace Thirtwo.Config
{
    [CreateAssetMenu(fileName = "VisualConfig", menuName = "Thirtwo/Data/Visual Config")]
    public class VisualConfig : Config
    {
        [field: SerializeField] public Sprite[] Ranks { get; set; }
        [field: SerializeField] public List<Sprite> Characters { get; set; }
        [field: SerializeField] public List<Sprite> Flags { get; set; }
        [field: SerializeField] public Sprite UserBackground { get; set; }

        [SerializeField] private Sprite defaultCharacterSprite;
        [SerializeField] private Sprite defaultFlagSprite;

        [SerializeField] private Sprite vipStatus;

        

        public Sprite GetVipStatus(bool isVip)
        {
            if (isVip) return vipStatus;
            return null;
        }
        public Sprite GatFlagSprite(string key)
        {
            for (int i = 0; i < Flags.Count; i++)
            {
                if (Flags[i].name == key)
                    return Flags[i];
            }
            return default;
        }
        public Sprite GetCharacterSprite(int index)
        {
            if (index <= Characters.Count)
                return Characters[index-1];
            return default;
        }
        public Sprite GetRankSprite(int rank)
        {
            return Ranks.Length > rank - 1 ? Ranks[rank - 1] : null;
        }
    }
}
