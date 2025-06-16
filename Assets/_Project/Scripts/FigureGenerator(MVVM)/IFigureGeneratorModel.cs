public interface IFigureGeneratorModel 
{
    FigureData GenerateRandomFigure();
    ColorFrameData GetRandomFrame(EnumFigureType type);
    GlassesData GetRandomGlasses();
}