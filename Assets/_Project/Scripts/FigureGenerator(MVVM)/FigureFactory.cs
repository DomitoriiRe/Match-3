using UnityEngine;
using Zenject;

public class FigureFactory : IFigureFactory
{
    private readonly DiContainer _container;
    private readonly FigureItem _prefab;

    public FigureFactory(DiContainer container, FigureItem prefab)
    {
        _container = container;
        _prefab = prefab;
    }

    public GameObject Create(GeneratedFigureVisualData data, Transform parent)
    {
        var instance = _container.InstantiatePrefab(_prefab, parent.position, Quaternion.identity, parent); 
        var figure = instance.GetComponent<FigureItem>();
        figure.SetSprites(data.Figure.FigureType, data.Figure.Sprite, data.Frame.Sprite, data.Glasses.Sprite);
        return instance;
    }
}