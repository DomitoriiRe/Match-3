using UnityEngine;

public class FigureItem : MonoBehaviour
{
    private EnumFigureType _enumFigureType;
    [SerializeField] private SpriteRenderer _figureSprite;
    [SerializeField] private SpriteRenderer _frameSprite;
    [SerializeField] private SpriteRenderer _glassesSprite; 

    public EnumFigureType EnumFigureType => _enumFigureType;
    public SpriteRenderer FigureSprite => _figureSprite;
    public SpriteRenderer FrameSprite => _frameSprite;
    public SpriteRenderer GlassesSprite => _glassesSprite;

    public void SetSprites(EnumFigureType enumFigureType, Sprite figure, Sprite frame, Sprite glasses)
    {
        _enumFigureType = enumFigureType;
        _figureSprite.sprite = figure;
        _frameSprite.sprite = frame;
        _glassesSprite.sprite = glasses;
        var itemFigure = gameObject.AddComponent<PolygonCollider2D>(); 
    } 
}