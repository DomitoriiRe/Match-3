using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private DataFullFledgedFigure _dataSourceSO; 
    [SerializeField] private FigureGeneratorSettingsSO _figureGeneratorSettingsSO;
    [SerializeField] private FigureViewSettingsSO _figureViewSettingsSO;

    [SerializeField] private FigureItem _figureItem;
    [SerializeField] private FigureGeneratorView _figureGeneratorView;
    [SerializeField] private FigureSlotPanelView _figureSlotPanelView;
    public override void InstallBindings()
    {
        BindFigureSlotPanelView();
        BindFigureItem();
        BindFigureGeneratorSettingsSO();
        BindDataSource();
        BindFigureViewSettingsSO();

        BindFigureConfigurator();
        BindFigureSlotsStore();
        BindFigureSlotPanel();
        BindIFigureFactoryr();
        BindFigureGeneratorView();
        BindCheckingVictoryStatus();
        BindCheckingDefeatStatus();
        BindMatchChecking();
        BindFigureGeneratorModel();
        BindFigureGeneratorViewModel(); 
    }
    private void BindFigureSlotPanelView() => Container.Bind<FigureSlotPanelView>().FromInstance(_figureSlotPanelView).AsSingle();
    private void BindFigureItem() => Container.Bind<FigureItem>().FromInstance(_figureItem).AsSingle();
    private void BindFigureGeneratorSettingsSO() => Container.Bind<FigureGeneratorSettingsSO>().FromInstance(_figureGeneratorSettingsSO).AsSingle();
    private void BindDataSource() => Container.Bind<DataFullFledgedFigure>().FromInstance(_dataSourceSO).AsSingle();
    private void BindFigureViewSettingsSO() => Container.Bind<FigureViewSettingsSO>().FromInstance(_figureViewSettingsSO).AsSingle();
    private void BindFigureConfigurator() => Container.Bind<IFigureConfigurator>().To<FigureConfigurator>().AsSingle();
    private void BindFigureSlotsStore() => Container.Bind<IFigureSlotsStore>().To<FigureSlotsStore>().AsSingle();
    private void BindFigureSlotPanel() => Container.Bind<IFigureSlotPanelModel>().To<FigureSlotPanelModel>().AsSingle();
    private void BindIFigureFactoryr() => Container.Bind<IFigureFactory>().To<FigureFactory>().AsSingle();
    private void BindFigureGeneratorView() => Container.Bind<IFigureGeneratorView>().FromInstance(_figureGeneratorView).AsSingle();
    private void BindCheckingVictoryStatus() => Container.Bind<ICheckingVictoryStatus>().To<CheckingVictoryStatus>().AsSingle();
    private void BindCheckingDefeatStatus() => Container.Bind<ICheckingDefeatStatus>().To<CheckingDefeatStatus>().AsSingle();
    private void BindMatchChecking() => Container.Bind<IMatchChecking>().To<MatchChecking>().AsSingle();
    private void BindFigureGeneratorModel() => Container.Bind<IFigureGeneratorModel>().To<FigureGeneratorModel>().AsSingle();
    private void BindFigureGeneratorViewModel() => Container.Bind<IFigureGeneratorViewModel>().To<FigureGeneratorViewModel>().AsSingle();
}