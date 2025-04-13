// All rights reserved 2024 ©
// Copyright (c) Ekrem Bugra Berdan thirtwo@protonmail.com

using System;
using Thirtwo.Config;
using Thirtwo.Data;
using Thirtwo.Factories;
using Thirtwo.MVVM;
using UnityEngine;
namespace Thirtwo.UI
{
    public class LeaderboardEntryVM : ViewModel<LeaderboardEntryView, LeaderboardEntryModel>, IDisposable
    {
        private readonly VisualConfig _visualConfig;
        public readonly UIConfig UIConfig;
        public LeaderboardEntryVM(LeaderboardEntryViewFactory viewFactory, LeaderboardEntryModelFactory modelFactory,VisualConfig visualConfig, UIConfig uIConfig) 
          :base()
        {
            Model = modelFactory.Create();
            View = viewFactory.Create();
            View.Construct(this);
            _visualConfig = visualConfig;
            UIConfig = uIConfig;
        }

        public void Init(LeaderboardEntryData data)
        {
            Model.LeaderboardEntryData = data;
            Model.HighlightBackground = _visualConfig.UserBackground;
            SetView();
        }
        private void SetView()
        {
            var data = new LeaderboardEntryViewData();
            var entryData = Model.LeaderboardEntryData;
            data.Points = entryData.Points;
            data.Rank = entryData.Ranking;
            data.RankImage = _visualConfig.GetRankSprite(entryData.Ranking);
            data.VipStatus = _visualConfig.GetVipStatus(entryData.Player.IsVip);
            data.Avatar = _visualConfig.GetCharacterSprite(entryData.Player.CharacterIndex);
            data.Flag = _visualConfig.GatFlagSprite(entryData.Player.CountryCode);
            data.NickName = entryData.Player.UserName;
            data.UserColor = ColorUtility.TryParseHtmlString(entryData.Player.CharacterColor, out var color) ? color : Color.blue;

            View.SetEntryView(data);
            View.transform.localScale = Vector3.one;
        }
        public void SetParent(RectTransform parent)
        {
            View.transform.SetParent(parent);
        }
        public float GetEntrySizeY()
        {
            return View.GetEntrySizeY();
        }

        public void Dispose()
        {
            View.Dispose();
        }

        public void HighlightBackground()
        {
            View.HighlightBackground();
        }
    }
}
