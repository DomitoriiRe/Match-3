using UnityEngine;

[CreateAssetMenu(menuName = "Game_SO/FigureGeneratorSettings")]
public class FigureGeneratorSettingsSO : ScriptableObject
{ 
    [Tooltip(" оличество фигур. P.S Ёто число умножаетс€ на 3")] 
    [Range(1, 30)]
    [SerializeField] private int _figuresNumber;
     
    public int FiguresNumber => _figuresNumber;
}