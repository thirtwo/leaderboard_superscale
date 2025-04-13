// All rights reserved 2024 ©
// Copyright (c) Ekrem Bugra Berdan thirtwo@protonmail.com

using UnityEngine;
namespace Thirtwo.Config
{
    [CreateAssetMenu(fileName = "UIConfig", menuName = "Thirtwo/Data/UIConfig")]
    public class UIConfig : Config
    {
        [field: Header("Loader")]
        [field: SerializeField] public float LoaderMinTimeOnScreen { get; private set; }
        [field: Header("Animations")]
        [field: SerializeField] public AnimationCurve EntryPointSlideCurve { get; private set; }
        [field: SerializeField] public AnimationCurve LeaderboardOpeningCurve { get; private set; }
        [field: SerializeField] public AnimationCurve LeaderboardClosingCurve { get; private set; }
    }
}
