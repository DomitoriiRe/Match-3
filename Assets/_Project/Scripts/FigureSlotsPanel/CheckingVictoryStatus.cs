using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class CheckingVictoryStatus : ICheckingVictoryStatus
{
    private IFigureGeneratorView _figureGeneratorView;

    public CheckingVictoryStatus(IFigureGeneratorView figureGeneratorView) => _figureGeneratorView = figureGeneratorView;
      
    public async UniTask CheckVictoryStatus(List<(FigureIdentity identity, GameObject figureGO)> figures)
    {
        await UniTask.Yield(PlayerLoopTiming.PostLateUpdate); //Ожидание конца фрейма 

        _figureGeneratorView.RemoveDestroyedInstances();

        if (_figureGeneratorView.CurrentInstances.Count == 0 && figures.Count == 0)
        {
            Debug.Log("🏆 Победа! Все фигуры уничтожены.");
        }
    }
}