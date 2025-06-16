using System.Linq;
using UnityEngine;

public class MatchChecking : IMatchChecking
{
    private readonly int _matchSize = 3;
    private readonly ICheckingVictoryStatus _victoryStatus;
    private readonly ICheckingDefeatStatus _defeatStatus;
    private readonly IFigureSlotsStore _figureSlotsStore;

    public MatchChecking(ICheckingVictoryStatus victory, ICheckingDefeatStatus defeat, IFigureSlotsStore figureSlotsStore)
    {
        _victoryStatus = victory;
        _defeatStatus = defeat;
        _figureSlotsStore = figureSlotsStore;
    }

    public void CheckForMatches(Transform[] slots)
    {
        var matches = _figureSlotsStore.Figures
            .GroupBy(f => (f.identity.Figure, f.identity.FrameColor, f.identity.Glasses))
            .Where(g => g.Count() >= _matchSize)
            .SelectMany(g => g.Take(_matchSize))
            .ToList();

        foreach (var match in matches)
        {
            _figureSlotsStore.Figures.Remove(match);
            Object.Destroy(match.figureGO);
        }

        _defeatStatus.CheckDefeatStatus(slots, _figureSlotsStore.Figures);
        _victoryStatus.CheckVictoryStatus(_figureSlotsStore.Figures);
    } 
} 