using UnityEngine;

public class FigureGeneratorModel : IFigureGeneratorModel
{
    private DataFullFledgedFigure _dataSource;

    public FigureGeneratorModel(DataFullFledgedFigure dataSource) => _dataSource = dataSource; 
     
    public FigureData GenerateRandomFigure()
    {
        var figures = _dataSource.FigureCollection.CollectionFigure;
        return figures[Random.Range(0, figures.Count)];
    }
     
    public ColorFrameData GetRandomFrame(EnumFigureType type)
    {
        switch (type)
        {
            case EnumFigureType.Square:
                var squareFrame = _dataSource.ColorSpriteCollection.SquareFrameCollection;
                return squareFrame[Random.Range(0, squareFrame.Count)];

            case EnumFigureType.Circle:
                var circleFrame = _dataSource.ColorSpriteCollection.CircleFrameCollection;
                return circleFrame[Random.Range(0, circleFrame.Count)];

            case EnumFigureType.Capsule:
                var capsuleFrame = _dataSource.ColorSpriteCollection.CapsuleFrameCollection;
                return capsuleFrame[Random.Range(0, capsuleFrame.Count)];

            default:
                throw new System.ArgumentOutOfRangeException(nameof(type));
        }
    }
     
    public GlassesData GetRandomGlasses()
    {
        var glasses = _dataSource.GlassesCollection.CollectionGlasses;
        return glasses[Random.Range(0, glasses.Count)];
    }
}