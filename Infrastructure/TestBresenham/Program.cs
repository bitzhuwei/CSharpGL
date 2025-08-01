namespace TestBresenham {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            //var mouseDownPosition = new Point(63, 60);
            //var mouseCurrentPosition = new Point(18, 82);
            //const int pixelLength = 40;
            //var start = new PointF((float)mouseDownPosition.X / (float)pixelLength, (float)mouseDownPosition.Y / (float)pixelLength);
            //var end = new PointF((float)mouseCurrentPosition.X / (float)pixelLength, (float)mouseCurrentPosition.Y / (float)pixelLength);
            //var list = new List<Point>();
            //Bresenham.FindPixelsAtLine(start, end, list);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            Application.Run(new FormTriangle());
        }
    }
}