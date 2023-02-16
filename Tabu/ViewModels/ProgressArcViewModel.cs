namespace Tabu.ViewModels
{
    public class ProgressArcViewModel : IDrawable
    {
        public double Progress { get; set; }
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            int endAngle = 90 - (int)Math.Round(Progress * 360, MidpointRounding.AwayFromZero);
            canvas.StrokeColor = Color.FromRgba("6599ff");
            canvas.StrokeSize = 4;
            //Debug.WriteLine($"The rect width is {dirtyRect.Width} and height is {dirtyRect.Height}");
            canvas.DrawArc(5, 5, dirtyRect.Width - 10, dirtyRect.Height - 10, 90, endAngle, false, false);
        }
    }

}
