using UnityEngine;

[System.Serializable]
public class FigureData : BaseSpriteData
{
    [SerializeField] private EnumFigureType _figureType; 

    public EnumFigureType FigureType => _figureType; 
}