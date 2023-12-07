using BlackJack.Utilities;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BlackJack.UI.MonoControls
{
    [DefaultProperty(@"EnableHoverHighlight")]
    [DefaultEvent(@"Click")]
    public sealed class MonoControlBox : Control
    {
        #region Enums

        public enum ButtonHoverState
        {
            Minimize,
            Maximize,
            Close,
            None
        }

        #endregion
        #region Variables

        private ButtonHoverState _buttonHState = ButtonHoverState.None;
        private bool _autoRelocate = true;
        private bool _enableMaximize = true;
        private bool _enableHoverHighlight;
        private bool _enableMinimize = true;
        private Color _foreColor2;
        private Color _backColor2;

        #endregion
        #region Properties

        public bool AutoRelocate
        {
            get { return _autoRelocate; }
            set
            {
                _autoRelocate = value;
                Relocate();
            }
        }
        public bool EnableMaximizeButton
        {
            get { return _enableMaximize; }
            set
            {
                _enableMaximize = value;
                Invalidate();
            }
        }
        public bool EnableMinimizeButton
        {
            get { return _enableMinimize; }
            set
            {
                _enableMinimize = value;
                Invalidate();
            }
        }
        public bool EnableHoverHighlight
        {
            get { return _enableHoverHighlight; }
            set
            {
                _enableHoverHighlight = value;
                Invalidate();
            }
        }
        public Color ForeColor2
        {
            get { return _foreColor2; }
            set
            {
                _foreColor2 = value;
                Invalidate();
            }
        }
        public Color BackColor2
        {
            get { return _backColor2; }
            set
            {
                _backColor2 = value;
                Invalidate();
            }
        }

        #endregion
        #region Events

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Size = new Size(100, 25);
        }
        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            Relocate();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            var x = e.Location.X;
            var y = e.Location.Y;
            if (y > 0 && y < (Height - 2))
            {
                if (x > 0 && x < 34)
                {
                    _buttonHState = ButtonHoverState.Minimize;
                }
                else if (x > 33 && x < 65)
                {
                    _buttonHState = ButtonHoverState.Maximize;
                }
                else if (x > 64 && x < Width)
                {
                    _buttonHState = ButtonHoverState.Close;
                }
                else
                {
                    _buttonHState = ButtonHoverState.None;
                }
            }
            else
            {
                _buttonHState = ButtonHoverState.None;
            }
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            var findForm = Parent.FindForm();
            if (findForm == null) return;

            switch (_buttonHState)
            {
                case ButtonHoverState.Close:
                    findForm.Close();
                    break;
                case ButtonHoverState.Minimize:
                    if (_enableMinimize)
                        findForm.WindowState = FormWindowState.Minimized;
                    break;
                case ButtonHoverState.Maximize:
                    if (_enableMaximize)
                        findForm.WindowState = findForm.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
                    break;
            }
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _buttonHState = ButtonHoverState.None;
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var gfx = e.Graphics;

            gfx.Clear(BackColor);
            gfx.SmoothingMode = SmoothingMode.HighQuality;

            if (_enableHoverHighlight)
            {
                switch (_buttonHState)
                {
                    case ButtonHoverState.None:
                        gfx.Clear(BackColor);
                        break;
                    case ButtonHoverState.Minimize:
                        if (_enableMinimize)
                        {
                            gfx.FillRectangle(
                                new SolidBrush(BackColor2),
                                new Rectangle(3, 0, 30, Height)
                                );
                        }
                        break;
                    case ButtonHoverState.Maximize:
                        if (_enableMaximize)
                        {
                            gfx.FillRectangle(
                                new SolidBrush(BackColor2),
                                new Rectangle(35, 0, 30, Height)
                                );
                        }
                        break;
                    case ButtonHoverState.Close:
                        gfx.FillRectangle(
                            new SolidBrush(BackColor2),
                            new Rectangle(66, 0, 35, Height)
                            );
                        break;
                }
            }

            //close btn
            gfx.DrawString(
                @"r",
                new Font(@"Marlett", 12),
                new SolidBrush(ForeColor),
                new Point(Width - 16, 8),
                new StringFormat
                {
                    Alignment = StringAlignment.Center
                });

            //maximize btn
            var findForm = Parent.FindForm();
            if (findForm != null)
            {
                switch (findForm.WindowState)
                {
                    case FormWindowState.Maximized:
                        gfx.DrawString(
                            @"2",
                            new Font(@"Marlett", 12),
                            _enableMaximize ? new SolidBrush(ForeColor) : new SolidBrush(ForeColor2),
                            new Point(51, 7),
                            new StringFormat
                            {
                                Alignment = StringAlignment.Center
                            });
                        break;
                    case FormWindowState.Normal:
                        gfx.DrawString(
                            @"1",
                            new Font(@"Marlett", 12),
                            _enableMaximize ? new SolidBrush(ForeColor) : new SolidBrush(ForeColor2),
                            new Point(51, 7),
                            new StringFormat
                            {
                                Alignment = StringAlignment.Center
                            });
                        break;
                }
            }

            //Minimize
            gfx.DrawString(
                @"0",
                new Font(@"Marlett", 12),
                _enableMinimize ? new SolidBrush(ForeColor) : new SolidBrush(ForeColor2),
                new Point(20, 7),
                new StringFormat
                {
                    Alignment = StringAlignment.Center
                });
        }
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (Parent == null) return;

            Relocate();
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (Parent == null) return;

            Relocate();

            var monoFormTheme = Parent as MonoTheme;
            if (monoFormTheme != null)
                monoFormTheme.HeaderAttributeChanged += ParentHeaderChanged;
        }

        private void ParentHeaderChanged(object sender, EventArgs e)
        {
            Relocate();
        }

        #endregion
        #region Methods

        private void Relocate()
        {
            if (Parent == null | !_autoRelocate) return;
            try
            {
                Location = new Point(Parent.Width - 112, 15);

                var theme = Parent as MonoTheme;
                if (theme != null)
                    BackColor = theme.HeaderBackColor;
            }
            catch
            { }

            Invalidate();
        }

        #endregion
        #region Constructors

        public MonoControlBox()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Anchor = AnchorStyles.Top | AnchorStyles.Right;

            BackColor = Color.FromArgb(181, 41, 42);
            BackColor2 = Color.FromArgb(156, 35, 35);
            ForeColor = Color.FromArgb(255, 254, 255);
            ForeColor2 = Color.LightGray;
        }

        #endregion
    }
}
