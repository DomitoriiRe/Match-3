using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx; 

public class FigureGeneratorViewModel : IFigureGeneratorViewModel
{
    private const int _copiesNumber = 3;

    private readonly IFigureGeneratorModel _model;
    private readonly FigureGeneratorSettingsSO _figureGeneratorSettingsSO;

    private readonly ReactiveProperty<List<GeneratedFigureVisualData>> _currentFigures = new();
    public IReadOnlyReactiveProperty<List<GeneratedFigureVisualData>> CurrentFigures => _currentFigures;

    private readonly Subject<GeneratedFigureVisualData> _spawnedFigureStream = new();
    public IObservable<GeneratedFigureVisualData> SpawnedFigureStream => _spawnedFigureStream;

    public FigureGeneratorViewModel(IFigureGeneratorModel model, FigureGeneratorSettingsSO figureGeneratorSettingsSO)
    {
        _model = model;
        _figureGeneratorSettingsSO = figureGeneratorSettingsSO;
    }

    public void GenerateFigures()
    {
        var figuresList = new List<GeneratedFigureVisualData>();

        for (int i = 0; i < _figureGeneratorSettingsSO.FiguresNumber; i++)
        {
            var figure = _model.GenerateRandomFigure();
            var frame = _model.GetRandomFrame(figure.FigureType);
            var glasses = _model.GetRandomGlasses();

            for (int j = 0; j < _copiesNumber; j++)
            {
                figuresList.Add(new GeneratedFigureVisualData(figure, frame, glasses));
            }
        }

        Shuffle(figuresList);
        _currentFigures.Value = figuresList;
    }

    public async UniTask GenerateNewFiguresAsync()
    {
        GenerateFigures();
        await EmitFiguresWithDelay(_currentFigures.Value);
    }

    private async UniTask EmitFiguresWithDelay(List<GeneratedFigureVisualData> dataList)
    {
        foreach (var data in dataList)
        {
            _spawnedFigureStream.OnNext(data);
            await UniTask.Delay(TimeSpan.FromSeconds(0.1f));
        }
    }

    private static void Shuffle<T>(IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }
}