using UnityEngine;
using Zenject;

public class FigureClickHandler : MonoBehaviour
{
    [SerializeField] private FigureItem _figureItem;
    private FigureSlotPanelView _figureSlotPanelView;

    [Inject] public void Construct(FigureSlotPanelView figureSlotPanelView) => _figureSlotPanelView = figureSlotPanelView;
     
    private void OnMouseDown() => _figureSlotPanelView.AddFigure(_figureItem); 
} 
