using UnityEngine;

public interface IFigureFactory
{
    GameObject Create(GeneratedFigureVisualData data, Transform parent);
}
