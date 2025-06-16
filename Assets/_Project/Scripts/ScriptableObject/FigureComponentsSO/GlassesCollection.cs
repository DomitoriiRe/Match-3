using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game_SO/GlassesCollection")]
public class GlassesCollection : ScriptableObject
{
    [SerializeField] private List<GlassesData> _glassesCollection;
    public IReadOnlyList<GlassesData> CollectionGlasses => _glassesCollection;
}