using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;

public interface IFigureGeneratorViewModel
{
    IReadOnlyReactiveProperty<List<GeneratedFigureVisualData>> CurrentFigures { get; }
    IObservable<GeneratedFigureVisualData> SpawnedFigureStream { get; }
    void GenerateFigures();
    UniTask GenerateNewFiguresAsync();
}
