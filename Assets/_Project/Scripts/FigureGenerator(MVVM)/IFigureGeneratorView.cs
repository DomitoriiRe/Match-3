using System.Collections.Generic;
using UnityEngine;

public interface IFigureGeneratorView
{
    void Bind(IFigureGeneratorViewModel figureGeneratorViewModel);
    IReadOnlyList<GameObject> CurrentInstances { get; }
    void RemoveDestroyedInstances();
}