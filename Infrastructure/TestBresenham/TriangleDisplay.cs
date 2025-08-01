using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace TestBresenham {
    public partial class TriangleDisplay : UserControl {
        enum TriangleState { ZeroPoint, OnePoint, TwoPoint, ThreePoint };
        private TriangleState pointState = TriangleState.ZeroPoint;
        private Point[] trianglePoints = new Point[3];
        private ConcurrentBag<Point> filledPoints = new();
        private int pixelLength = 10;
        //internal FormInfo? frmInfo;
        //internal Form? mainForm;

        public void SetPixelLength(int pixelLength) {
            this.pixelLength = pixelLength;
            this.pointState = TriangleState.ZeroPoint;
            this.filledPoints.Clear();
            this.Invalidate();
        }

        public TriangleDisplay() {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer |  // 启用优化双缓冲
                     ControlStyles.AllPaintingInWmPaint |   // 忽略 WM_ERASEBKGND 消息
                     ControlStyles.UserPaint, true);        // 自行处理绘制
            //DoubleBuffered = true;                        // 快速启用双缓冲（等效于上述设置）

            this.MouseDown += BresenhamDisplay_MouseDown;
            this.MouseUp += BresenhamDisplay_MouseUp;
        }

        private void BresenhamDisplay_MouseUp(object? sender, MouseEventArgs e) {
            this.Invalidate();
            //this.frmInfo?.UpdateInfo();
        }

        private void BresenhamDisplay_MouseMove(object? sender, MouseEventArgs e) {
            this.Invalidate();
        }

        private void BresenhamDisplay_MouseDown(object? sender, MouseEventArgs e) {
            switch (this.pointState) {
            case TriangleState.ZeroPoint: {
                this.trianglePoints[0] = e.Location;
                this.pointState = TriangleState.OnePoint;
            }
            break;
            case TriangleState.OnePoint: {
                this.trianglePoints[1] = e.Location;
                this.pointState = TriangleState.TwoPoint;
            }
            break;
            case TriangleState.TwoPoint: {
                this.trianglePoints[2] = e.Location;
                this.pointState = TriangleState.ThreePoint;
                var fragCoord0 = new PointF((float)this.trianglePoints[0].X / (float)pixelLength, (float)this.trianglePoints[0].Y / (float)pixelLength);
                var fragCoord1 = new PointF((float)this.trianglePoints[1].X / (float)pixelLength, (float)this.trianglePoints[1].Y / (float)pixelLength);
                var fragCoord2 = new PointF((float)this.trianglePoints[2].X / (float)pixelLength, (float)this.trianglePoints[2].Y / (float)pixelLength);
                this.filledPoints.Clear();
                Bresenham.FindFragmentsInTriangle(fragCoord0, fragCoord1, fragCoord2, this.filledPoints);
            }
            break;
            case TriangleState.ThreePoint: {
                this.trianglePoints[0] = e.Location;
                this.pointState = TriangleState.OnePoint;
                this.filledPoints.Clear();
            }
            break;
            default: throw new NotImplementedException();
            }

            this.Invalidate();
        }

        protected override void OnPaintBackground(PaintEventArgs e) {
            base.OnPaintBackground(e);
            var g = e.Graphics;
            var width = this.ClientSize.Width; var height = this.ClientSize.Height;
            for (var x = 0; x < width; x += pixelLength) {
                for (var y = 0; y < height; y += pixelLength) {
                    if ((x / pixelLength + y / pixelLength) % 2 == 0) {
                        g.FillRectangle(Brushes.SkyBlue, x, y, pixelLength, pixelLength);
                    }
                }
            }
            //for (int x = 0; x < width; x += pixelLength) {
            //    g.DrawLine(Pens.Blue, x, 0, x, height - 1);
            //}
            //for (int y = 0; y < height; y += pixelLength) {
            //    g.DrawLine(Pens.Blue, 0, y, width - 1, y);
            //}

            foreach (var item in this.filledPoints) {
                {
                    var x = item.X * pixelLength;// x = x - x % pixelLength;
                    var y = item.Y * pixelLength;// y = y - y % pixelLength;
                    g.FillRectangle(Brushes.Orange, x, y, pixelLength, pixelLength);
                }
                //{
                //    var x = (item.X * pixelLength);
                //    var y = (item.Y * pixelLength);
                //    g.DrawRectangle(Pens.Red, x + pixelLength / 2 - 2, y + pixelLength / 2 - 2, 4, 4);
                //}
            }
            {
                var count = (int)this.pointState;
                for (int i = 0; i < count; i++) {
                    var point = this.trianglePoints[i];
                    var x = (int)((float)point.X / pixelLength) * pixelLength;
                    var y = (int)((float)point.Y / pixelLength) * pixelLength;
                    g.FillRectangle(Brushes.Red, x, y, pixelLength, pixelLength);
                }
            }
        }
    }
}
