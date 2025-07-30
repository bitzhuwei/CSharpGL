using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestBresenham {
    public partial class BresenhamDisplay : UserControl {
        internal bool mouseDown = false;
        internal Point mouseDownPosition = new();
        internal Point mouseCurrentPosition = new();
        private int pixelLength = 10;
        internal PointF lastStart = new();
        internal PointF lastEnd = new();
        internal List<Point> bresenhamPoints = new();
        internal bool showOriginalLine = true;
        internal FormInfo? frmInfo;
        internal Form? mainForm;

        public void SetPixelLength(int pixelLength) {
            this.pixelLength = pixelLength;
            this.bresenhamPoints.Clear();
            this.mouseDownPosition = new();
            this.mouseCurrentPosition = new();
            this.Invalidate();
        }

        public BresenhamDisplay() {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer |  // 启用优化双缓冲
                     ControlStyles.AllPaintingInWmPaint |   // 忽略 WM_ERASEBKGND 消息
                     ControlStyles.UserPaint, true);        // 自行处理绘制
            //DoubleBuffered = true;                        // 快速启用双缓冲（等效于上述设置）

            this.MouseDown += BresenhamDisplay_MouseDown;
            this.MouseMove += BresenhamDisplay_MouseMove;
            this.MouseUp += BresenhamDisplay_MouseUp;
        }

        private void BresenhamDisplay_MouseUp(object? sender, MouseEventArgs e) {
            this.mouseDown = false;
            this.Invalidate();
            this.frmInfo?.UpdateInfo();
        }

        private void BresenhamDisplay_MouseMove(object? sender, MouseEventArgs e) {
            if (this.mouseDown) {
                this.mouseCurrentPosition = e.Location;
                var start = new PointF((float)this.mouseDownPosition.X / (float)pixelLength, (float)this.mouseDownPosition.Y / (float)pixelLength);
                var end = new PointF((float)this.mouseCurrentPosition.X / (float)pixelLength, (float)this.mouseCurrentPosition.Y / (float)pixelLength);
                this.lastStart = start; this.lastEnd = end;
                this.bresenhamPoints.Clear();
                Bresenham.FindPixelsAtLine(start, end, this.bresenhamPoints);
                this.Invalidate();
                if (this.mainForm != null) {
                    this.mainForm.Text = $"{this.mouseDownPosition} -> {e.Location}";
                }
            }
            else {
                if (this.mainForm != null) {
                    this.mainForm.Text = $"{e.Location}";
                }
            }
        }

        private void BresenhamDisplay_MouseDown(object? sender, MouseEventArgs e) {
            this.mouseDownPosition = e.Location;
            this.mouseCurrentPosition = e.Location;
            this.mouseDown = true;
            this.bresenhamPoints.Clear();
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

            foreach (var item in this.bresenhamPoints) {
                {
                    var x = item.X * pixelLength;// x = x - x % pixelLength;
                    var y = item.Y * pixelLength;// y = y - y % pixelLength;
                    g.FillRectangle(Brushes.Red, x, y, pixelLength, pixelLength);
                }
                //{
                //    var x = (item.X * pixelLength);
                //    var y = (item.Y * pixelLength);
                //    g.DrawRectangle(Pens.Red, x + pixelLength / 2 - 2, y + pixelLength / 2 - 2, 4, 4);
                //}
            }
            if (this.showOriginalLine) {
                g.DrawLine(Pens.Black, this.mouseDownPosition, this.mouseCurrentPosition);
            }
        }
    }
}
