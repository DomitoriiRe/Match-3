using UnityEngine;

[CreateAssetMenu(menuName = "Game_SO/FigureViewSettings")]
public class FigureViewSettingsSO : ScriptableObject
{  
    [Range(1f, 100f)]
    [SerializeField] private float _defaultSizeX = 70f;

    [Range(1f, 100f)]
    [SerializeField] private float _defaultSizeY = 70f;

    [Range(1f, 1f)]
    [SerializeField] private float _defaultSizeZ = 1f;

    public Vector3 DefaultFigureSize => new Vector3(_defaultSizeX, _defaultSizeY, _defaultSizeZ); 
}