using System.Collections.Generic;
using UnityEngine;

public class FigureSlotsStore : IFigureSlotsStore
{
    private List<(FigureIdentity identity, GameObject figureGO)> _figures = new();
    public List<(FigureIdentity identity, GameObject figureGO)> Figures => _figures;
}