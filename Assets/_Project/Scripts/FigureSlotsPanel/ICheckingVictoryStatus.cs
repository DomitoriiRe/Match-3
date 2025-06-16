using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public interface ICheckingVictoryStatus
{
    UniTask CheckVictoryStatus(List<(FigureIdentity identity, GameObject figureGO)> figures);  
}