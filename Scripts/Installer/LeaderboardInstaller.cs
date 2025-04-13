using Thirtwo.Config;
using Thirtwo.Data;
using Thirtwo.Factories;
using Thirtwo.Parse;
using Thirtwo.UI;
using UnityEngine;
using Zenject;

public class LeaderboardInstaller : MonoInstaller
{
    [SerializeField] private PrefabConfig prefabConfig;
    [SerializeField] private DataConfig dataConfig;
    [SerializeField] private LeaderboardConfig leaderboardConfig;
    [SerializeField] private VisualConfig visualConfig;
    [SerializeField] private UIConfig uiConfig;


    public override void InstallBindings()
    {
        BindScriptableObjects();
        BindFactories();

        
        BindLeaderboard();
    }

    private void BindScriptableObjects()
    {
        Container.Bind<PrefabConfig>().FromScriptableObject(prefabConfig).AsSingle().NonLazy();
        Container.Bind<DataConfig>().FromScriptableObject(dataConfig).AsSingle().NonLazy();
        Container.Bind<LeaderboardConfig>().FromScriptableObject(leaderboardConfig).AsSingle().NonLazy();
        Container.Bind<VisualConfig>().FromScriptableObject(visualConfig).AsSingle().NonLazy();
        Container.Bind<UIConfig>().FromScriptableObject(uiConfig).AsSingle().NonLazy();
    }
    private void BindFactories()
    {
        BindLeaderboardEntryFactories();
        Container.BindFactory<LeaderboardData, LeaderboardDataFactory>();
    }

    private void BindLeaderboard()
    {
        Container.Bind<LeaderboardParser>().AsSingle();
        Container.Bind<LeaderboardVM>().AsSingle().NonLazy();
        Container.Bind<LeaderboardView>().FromComponentInHierarchy(false).AsSingle().NonLazy();
        Container.Bind<LeaderboardModel>().AsSingle().NonLazy();
    }
    private void BindLeaderboardEntryFactories()
    {
        Container.BindInstance(prefabConfig.LeaderboardEntryPrefab);
        Container.BindFactory<LeaderboardEntryView, LeaderboardEntryViewFactory>().FromComponentInNewPrefab(prefabConfig.LeaderboardEntryPrefab);
        Container.BindFactory<LeaderboardEntryModel, LeaderboardEntryModelFactory>();
        Container.BindFactory<LeaderboardEntryVM, LeaderboardEntryVMFactory>().FromFactory<CustomLeaderboardEntryVMFactory>();
    }

}