using UnityEngine;

[CreateAssetMenu(menuName = "Game_SO/FigureAsset")]
public class DataFullFledgedFigure : ScriptableObject
{
    [Tooltip("������ ��������� ������.")]
    [SerializeField] private ColorFrameCollection _colorSpriteCollection;

    [Tooltip("������ ��������� �����.")]
    [SerializeField] private FigureCollection _figureCollection;

    [Tooltip("������ ��������� �����.")]
    [SerializeField] private GlassesCollection _glassesCollection;

    public ColorFrameCollection ColorSpriteCollection => _colorSpriteCollection;
    public FigureCollection FigureCollection => _figureCollection;
    public GlassesCollection GlassesCollection => _glassesCollection;
}