using UnityEngine;  

public class FigureSlotPanelModel : IFigureSlotPanelModel
{
    private readonly FigureViewSettingsSO _figureViewSettingsSO;
    private readonly IMatchChecking _matchChecking;
    private readonly IFigureSlotsStore _figureSlotsStore;
    private readonly IFigureConfigurator _figureConfigurator;

    public FigureSlotPanelModel(FigureViewSettingsSO figureViewSettingsSO, IFigureSlotsStore figureSlotsStore, IMatchChecking matchChecking, IFigureConfigurator figureConfigurator)
    {
        _figureViewSettingsSO = figureViewSettingsSO;
        _figureSlotsStore = figureSlotsStore;
        _matchChecking = matchChecking;
        _figureConfigurator = figureConfigurator;
    } 
     
    public void AddFigure(FigureItem figureItem, Transform[] slots)
    { 
        var identity = FigureIdentity.FromGO(figureItem);
        _figureSlotsStore.Figures.Add((identity, figureItem.gameObject));

        SetFigureTransform(figureItem, slots);
        _figureConfigurator.ConfigureFigureComponents(figureItem);

        UpdateSlotPositions(slots);
        _matchChecking.CheckForMatches(slots);
    }

    private void SetFigureTransform(FigureItem figureItem, Transform[] slots)
    {
        int slotIndex = _figureSlotsStore.Figures.Count - 1;

        if (slotIndex >= slots.Length) return;  

        figureItem.transform.SetParent(slots[slotIndex]);
        figureItem.transform.localPosition = Vector3.zero;
        figureItem.transform.localRotation = Quaternion.identity;
        figureItem.transform.localScale = _figureViewSettingsSO.DefaultFigureSize;
    }

    public void UpdateSlotPositions(Transform[] slots)
    {
        int count = Mathf.Min(_figureSlotsStore.Figures.Count, slots.Length);
        for (int i = 0; i < count; i++)
        {
            var figure = _figureSlotsStore.Figures[i];
            figure.figureGO.transform.SetParent(slots[i]);
            figure.figureGO.transform.localPosition = Vector3.zero;
        }
    } 
}