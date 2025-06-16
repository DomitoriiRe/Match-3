using UnityEngine; 
using Zenject;
 
public class FigureSlotPanelView : MonoBehaviour
{
    [SerializeField] private Transform[] _slots; 
    private IFigureSlotPanelModel _figureSlotPanelModel;

    [Inject] public void Construct(IFigureSlotPanelModel figureSlotPanelModel) => _figureSlotPanelModel = figureSlotPanelModel;

    public void AddFigure(FigureItem figureItem) => _figureSlotPanelModel.AddFigure(figureItem, _slots);
}