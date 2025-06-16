using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game_SO/ColorFrameCollection")]
public class ColorFrameCollection : ScriptableObject
{
    [SerializeField] private List<ColorFrameData> _colorFrameSquareCollection;
    public IReadOnlyList<ColorFrameData> SquareFrameCollection => _colorFrameSquareCollection;


    [SerializeField] private List<ColorFrameData> _colorFrameCircleCollection;
    public IReadOnlyList<ColorFrameData> CircleFrameCollection => _colorFrameCircleCollection;


    [SerializeField] private List<ColorFrameData> _colorFrameCapsuleCollection;
    public IReadOnlyList<ColorFrameData> CapsuleFrameCollection => _colorFrameCapsuleCollection;
}