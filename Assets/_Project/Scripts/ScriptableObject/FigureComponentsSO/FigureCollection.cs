using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game_SO/FigureCollection")]
public class FigureCollection : ScriptableObject
{
    [SerializeField] private List<FigureData> _figureCollection;
    public IReadOnlyList<FigureData> CollectionFigure => _figureCollection;
}