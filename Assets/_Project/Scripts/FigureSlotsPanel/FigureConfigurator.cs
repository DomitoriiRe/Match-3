using UnityEngine;

public class FigureConfigurator : IFigureConfigurator
{
    public void ConfigureFigureComponents(FigureItem figureItem)
    {
        var rb = figureItem.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Static;
        }

        var col = figureItem.GetComponent<PolygonCollider2D>();
        if (col != null)
        {
            col.enabled = false;
        } 
    }
}