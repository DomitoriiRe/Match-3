using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public interface IFigureSlotPanelModel
{
    void AddFigure(GameObject figureGO, Transform[] slots); 
}
