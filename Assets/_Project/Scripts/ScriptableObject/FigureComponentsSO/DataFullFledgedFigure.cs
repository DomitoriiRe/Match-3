using UnityEngine;

[CreateAssetMenu(menuName = "Game_SO/FigureAsset")]
public class DataFullFledgedFigure : ScriptableObject
{
    [Tooltip("Список доступных цветов.")]
    [SerializeField] private ColorFrameCollection _colorSpriteCollection;

    [Tooltip("Список доступных фигур.")]
    [SerializeField] private FigureCollection _figureCollection;

    [Tooltip("Список доступных очков.")]
    [SerializeField] private GlassesCollection _glassesCollection;

    public ColorFrameCollection ColorSpriteCollection => _colorSpriteCollection;
    public FigureCollection FigureCollection => _figureCollection;
    public GlassesCollection GlassesCollection => _glassesCollection;
}