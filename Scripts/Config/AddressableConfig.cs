// All rights reserved 2024 ©
// Copyright (c) Ekrem Bugra Berdan thirtwo@protonmail.com
using UnityEngine;
namespace Thirtwo.Config
{
    [CreateAssetMenu(fileName = "AddressableConfig", menuName = "Thirtwo/Data/Addressable Config")]
    public class AddressableConfig : Config
    {
        [field: SerializeField] public string FirstThreePrefix { get; private set; }
        [field: SerializeField] public string CharacterPrefix { get; private set; }
        [field: SerializeField] public string FlagPrefix { get; private set; }
        [field: SerializeField] public string DataPrefix { get; private set; }
    }
}
