using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;

public class FigureGeneratorView : MonoBehaviour, IFigureGeneratorView
{
    [SerializeField] private Transform _parentSpawn;
    private readonly List<GameObject> _currentInstances = new();
    public IReadOnlyList<GameObject> CurrentInstances => _currentInstances;

    private IDisposable _spawnSubscription;
    private IFigureFactory _figureFactory;

    [Inject] public void Construct(IFigureFactory figureFactory) => _figureFactory = figureFactory; 

    public void Bind(IFigureGeneratorViewModel viewModel)
    {
        _spawnSubscription?.Dispose();
        _currentInstances.Clear();

        _spawnSubscription = viewModel.SpawnedFigureStream
            .Subscribe(data =>
            {
                if (data != null)
                {
                    var go = _figureFactory.Create(data, _parentSpawn);
                    _currentInstances.Add(go);
                }
            })
            .AddTo(this);
    }

    public void RemoveDestroyedInstances() => _currentInstances.RemoveAll(go => go == null);
    private void OnDestroy() => _spawnSubscription?.Dispose(); 
}