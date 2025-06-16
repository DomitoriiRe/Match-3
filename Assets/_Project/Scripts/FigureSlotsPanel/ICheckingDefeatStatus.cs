using System.Collections.Generic;
using UnityEngine;

public interface ICheckingDefeatStatus 
{
    void CheckDefeatStatus(Transform[] slots, List<(FigureIdentity identity, GameObject figureGO)> figures);
} 