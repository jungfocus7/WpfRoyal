namespace WpfRoyal.WpfCommon
{
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using WpfRoyal.WpfCommon.Effect;






    /// <summary>
    /// RootContainer.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class RootContainer : UserControl
    {
        public RootContainer()
        {
            InitializeComponent();
            Loaded += pf_Loaded;
        }



        private void pf_Loaded(object tsd, RoutedEventArgs tea)
        {
            bool _xb = true;


            WxTween _wx = new WxTween(_rct.Opacity, 36);
            _wx.Event += delegate (string type)
            {
                Debug.WriteLine(string.Format("_wx: {0}/{1}", type, _wx.Current));

                if (type == WxTween.EtUpdate)
                {
                    double tw = _wx.Current;
                    if (tw < 0) tw = 0;
                    _rct.Opacity = tw;
                }
                else if (type == WxTween.EtEnd)
                {
                    if (!_xb)
                        _rct.Visibility = Visibility.Hidden;
                }
            };


            

            MouseLeftButtonDown += delegate
            {
                //Point tmpt = Mouse.GetPosition(this);
                if (_xb)
                {
                    _wx.To(0);
                    _xb = false;
                }
                else
                {
                    _rct.Visibility = Visibility.Visible;
                    _wx.To(1);
                    _xb = true;
                }
            };
        }


    }


}
