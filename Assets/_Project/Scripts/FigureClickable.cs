using UnityEngine;
using Zenject;

public class FigureClickHandler : MonoBehaviour
{
    public FigureSlotPanelView _figureSlotPanelView;

   [Inject] public void Construct(FigureSlotPanelView figureSlotPanelView) => _figureSlotPanelView = figureSlotPanelView;
     
    private void OnMouseDown() => _figureSlotPanelView.AddFigure(gameObject); 
} 
