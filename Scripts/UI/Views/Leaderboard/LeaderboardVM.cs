// All rights reserved 2024 ©
// Copyright (c) Ekrem Bugra Berdan thirtwo@protonmail.com

using Thirtwo.Factories;
using Thirtwo.MVVM;
using Thirtwo.Parse;
using Thirtwo.UI;
using System.Collections.Generic;
using Thirtwo.Config;


public class LeaderboardVM : ViewModel<LeaderboardView, LeaderboardModel>
{
    private readonly LeaderboardEntryVMFactory _entryVMFactory;
    private readonly LeaderboardParser _leaderboardParser;
    private readonly List<LeaderboardEntryVM> _entries;
    public readonly UIConfig UIConfig;
    public LeaderboardVM(LeaderboardView view, LeaderboardModel model, LeaderboardEntryVMFactory entryVMFactory,
        LeaderboardParser parser, UIConfig uIConfig)
         : base()
    {
        Model = model;
        View = view;
        _entries = new List<LeaderboardEntryVM>();
        _entryVMFactory = entryVMFactory;
        _leaderboardParser = parser;
        UIConfig = uIConfig;
    }

    private void SetLeaderboardData()
    {
        Model.ActiveLeaderboardData = _leaderboardParser.Parse();
    }

    public void SetLeaderboard()
    {
        SetLeaderboardData();
        for (int i = 0; i < Model.ActiveLeaderboardData.Ranking.Count; i++)
        {
            SetEntry(i);
        }
        var entrySize = _entries[0].GetEntrySizeY();
        View.SetLayoutSize(entrySize, Model.ActiveLeaderboardData.Ranking.Count);
    }

    private void SetEntry(int index)
    {
        var entry = _entryVMFactory.Create();
        entry.SetParent(View.Layout);
        _entries.Add(entry);

        entry.Init(Model.ActiveLeaderboardData.Ranking[index]);
        if (Model.ActiveLeaderboardData.PlayerUID == entry.Model.LeaderboardEntryData.Player.UID)
            entry.HighlightBackground();
    }

    public void Clear()
    {
        for (int i = 0; i < _entries.Count; i++)
        {
            _entries[i].Dispose();
        }
        _entries.Clear();
    }
}
