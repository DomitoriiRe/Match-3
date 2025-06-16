using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private DataFullFledgedFigure _dataSource; 
    [SerializeField] private FigureGeneratorSettingsSO _figureGeneratorSettingsSO;
    [SerializeField] private FigureItem _figureItem;
    [SerializeField] private FigureGeneratorView _figureGeneratorView;
    [SerializeField] private FigureSlotPanelView _figureSlotPanelView;
    public override void InstallBindings()
    {
        BindFigureSlotPanel();
        BindFigureSlotPanelView(); 
        BindFigureGeneratorView();
        BindFigureItem();
        BindIFigureFactoryr();
        BindFigureGeneratorSettingsSO();
        BindDataSource(); 
        BindFigureGeneratorModel();
        BindFigureGeneratorViewModel(); 
    }

    private void BindFigureSlotPanel() => Container.Bind<IFigureSlotPanelModel>().To<FigureSlotPanelModel>().AsSingle().NonLazy();
    private void BindFigureSlotPanelView() => Container.Bind<FigureSlotPanelView>().FromInstance(_figureSlotPanelView).AsSingle().NonLazy(); 
    private void BindFigureGeneratorView() => Container.Bind<IFigureGeneratorView>().FromInstance(_figureGeneratorView).AsSingle().NonLazy();
    private void BindFigureItem() => Container.Bind<FigureItem>().FromInstance(_figureItem).AsSingle().NonLazy();
    private void BindIFigureFactoryr() => Container.Bind<IFigureFactory>().To<FigureFactory>().AsSingle();
    private void BindFigureGeneratorSettingsSO() => Container.Bind<FigureGeneratorSettingsSO>().FromInstance(_figureGeneratorSettingsSO).AsSingle().NonLazy();
    private void BindDataSource() => Container.Bind<DataFullFledgedFigure>().FromInstance(_dataSource).AsSingle().NonLazy(); 
    private void BindFigureGeneratorModel() => Container.Bind<IFigureGeneratorModel>().To<FigureGeneratorModel>().AsSingle().NonLazy();
    private void BindFigureGeneratorViewModel() => Container.Bind<IFigureGeneratorViewModel>().To<FigureGeneratorViewModel>().AsSingle().NonLazy();
}