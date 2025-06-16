using UnityEngine;

[CreateAssetMenu(menuName = "Game_SO/FigureGeneratorSettings")]
public class FigureGeneratorSettingsSO : ScriptableObject
{ 
    [Tooltip("���������� �����. P.S ��� ����� ���������� �� 3")] 
    [Range(1, 30)]
    [SerializeField] private int _figuresNumber;
     
    public int FiguresNumber => _figuresNumber;
}