using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class FigureGeneratorBinding : MonoBehaviour
{
    private IFigureGeneratorView _view;

    private IFigureGeneratorViewModel _viewModel;

    [Inject] public void Construct(IFigureGeneratorViewModel viewModel, IFigureGeneratorView view)
    {
        _viewModel = viewModel;
        _view = view;
        _view.Bind(_viewModel);
    }

    private void Start() => _viewModel.GenerateNewFiguresAsync().Forget(); 
}