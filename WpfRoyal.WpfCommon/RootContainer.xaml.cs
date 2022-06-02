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
            WxTween _wx = new WxTween(_rct.Width, 36);

            _wx.Event += delegate (string type)
            {
                Debug.WriteLine(string.Format("_wx: {0}/{1}", type, _wx.Current));

                double tw = _wx.Current;
                if (tw < 0) tw = 0;
                _rct.Width = tw;
            };

            MouseDown += delegate
            {
                Point tmpt = Mouse.GetPosition(this);
                _wx.Stop();
                _wx.To(tmpt.X);
            };
        }


    }


}
