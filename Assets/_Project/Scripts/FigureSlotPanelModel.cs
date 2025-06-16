using System.Collections.Generic;
using UnityEngine; 
using System.Linq;
using Cysharp.Threading.Tasks;

public class FigureSlotPanelModel : IFigureSlotPanelModel
{
    private  List<(FigureIdentity identity, GameObject go)> _figures = new(); 
    private IFigureGeneratorView _figureGeneratorView;
    private Vector3 _defaultSize = new Vector3(70, 70, 1);

    public FigureSlotPanelModel(IFigureGeneratorView figureGeneratorView) => _figureGeneratorView = figureGeneratorView;

    public void AddFigure(GameObject figureGO, Transform[] slots)
    {  
        var identity = FigureIdentity.FromGO(figureGO);
        _figures.Add((identity, figureGO));

        int slotIndex = _figures.Count - 1;
        figureGO.transform.SetParent(slots[slotIndex]);
        figureGO.transform.localPosition = Vector3.zero;
        figureGO.transform.localRotation = Quaternion.identity;
        figureGO.transform.localScale = _defaultSize;

        var rb = figureGO.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;

        var col = figureGO.GetComponent<PolygonCollider2D>();
        col.isTrigger = true;

        RefillSlots(slots);
        CheckForTripleMatch(slots);
    }

    public async UniTask CheckDefeatStatus(Transform[] slots)
    {
        await UniTask.Yield(PlayerLoopTiming.PostLateUpdate);
         
        if (_figures.Count >= slots.Length)
        {
            Debug.Log("❌ Проигрыш! Слоты переполнены.");
            return;
        }
    }

    public async UniTask CheckVictoryStatus()
    {
        await UniTask.Yield(PlayerLoopTiming.PostLateUpdate);

        _figureGeneratorView.RemoveDestroyedInstances();

        if (_figureGeneratorView.CurrentInstances.Count == 0 && _figures.Count == 0)
        {
            Debug.Log("🏆 Победа! Все фигуры уничтожены.");
        }
    }

    public void RefillSlots(Transform[] slots)
    {
        for (int i = 0; i < _figures.Count; i++)
        {
            var figure = _figures[i];
            figure.go.transform.SetParent(slots[i]);
            figure.go.transform.localPosition = Vector3.zero;
        }
    }

    private void CheckForTripleMatch(Transform[] slots)
    {
        var groups = _figures
            .GroupBy(f => (f.identity.Figure, f.identity.FrameColor, f.identity.Glasses))
            .Where(g => g.Count() >= 3)
            .ToList();

        foreach (var group in groups)
        {
            var toRemove = group.Take(3).ToList();

            foreach (var item in toRemove)
            {
                if (_figures != null)
                {
                    Object.Destroy(item.go);
                    _figures.Remove(item); 
                } 
            }
        }
         
        CheckDefeatStatus(slots).Forget();
        CheckVictoryStatus().Forget();
    }
}