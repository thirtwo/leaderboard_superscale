
using Thirtwo.UI;
using UnityEngine;
using Zenject;

namespace Thirtwo.Factories
{
    public class LeaderboardEntryViewFactory : PlaceholderFactory<LeaderboardEntryView>
    {
    }

    public class CustomLeaderboardEntryViewFactory : IFactory<LeaderboardEntryView>
    {
        private readonly DiContainer container;
        private readonly GameObject leaderboardEntryPrefab;

        public CustomLeaderboardEntryViewFactory(DiContainer container, GameObject leaderboardEntryPrefab)
        {
            this.container = container;
            this.leaderboardEntryPrefab = leaderboardEntryPrefab;
        }
        public LeaderboardEntryView Create()
        {
            return container.InjectGameObjectForComponent<LeaderboardEntryView>(leaderboardEntryPrefab);
        }
    }
}
