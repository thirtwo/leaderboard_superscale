// All rights reserved 2024 ©
// Copyright (c) Ekrem Bugra Berdan thirtwo@protonmail.com

using Thirtwo.UI;
using Zenject;
namespace Thirtwo.Factories
{
    public class LeaderboardEntryVMFactory : PlaceholderFactory<LeaderboardEntryVM>
    {

    }
    public class CustomLeaderboardEntryVMFactory : IFactory<LeaderboardEntryVM>
    {
        private readonly DiContainer container;

        public CustomLeaderboardEntryVMFactory(DiContainer container)
        {
            this.container = container;
        }
        public LeaderboardEntryVM Create()
        {
            var leaderboardEntryVM = container.Instantiate<LeaderboardEntryVM>();
            container.BindInterfacesTo<LeaderboardEntryVM>().FromInstance(leaderboardEntryVM);
            return leaderboardEntryVM;
        }
    }
}
