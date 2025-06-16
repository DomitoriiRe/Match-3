using System.Collections.Generic;
using UnityEngine;

public class CheckingDefeatStatus : ICheckingDefeatStatus
{
    public void CheckDefeatStatus(Transform[] slots, List<(FigureIdentity identity, GameObject figureGO)> figures)
    {
        if (figures.Count >= slots.Length)
        {
            Debug.Log("❌ Проигрыш! Слоты переполнены.");
            return;
        }
    } 
}