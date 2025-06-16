using System.Collections.Generic;
using UnityEngine;

public interface IFigureSlotsStore
{
    List<(FigureIdentity identity, GameObject figureGO)> Figures { get; }
}
