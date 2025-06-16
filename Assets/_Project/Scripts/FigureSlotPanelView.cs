using UnityEngine; 
using Zenject;


public class FigureSlotPanelView : MonoBehaviour
{
    [SerializeField] private Transform[] _slots; 
    private IFigureSlotPanelModel _figureSlotPanelModel;

    [Inject] public void Construct(IFigureSlotPanelModel figureSlotPanelModel) => _figureSlotPanelModel = figureSlotPanelModel;

    public void AddFigure(GameObject figureGO) => _figureSlotPanelModel.AddFigure(figureGO, _slots);
}
