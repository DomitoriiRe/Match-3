using UnityEngine;

[System.Serializable]
public abstract class BaseSpriteData
{
    [SerializeField] protected Sprite _sprite; 
    public Sprite Sprite => _sprite;
} 