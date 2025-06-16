using UnityEngine;

public class FigureIdentity
{
    public EnumFigureType Figure;
    public Sprite FrameColor;
    public Sprite Glasses; 

    public static FigureIdentity FromGO(FigureItem figureItem)
    {  
        var figure = figureItem.EnumFigureType;
        var frame = figureItem.FrameSprite.sprite;
        var glasses = figureItem.GlassesSprite.sprite;

        return new FigureIdentity
        {
            Figure = figure,
            FrameColor = frame,
            Glasses = glasses
        };
    }
} 