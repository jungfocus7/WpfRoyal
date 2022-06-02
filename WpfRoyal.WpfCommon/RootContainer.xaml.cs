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
                _rct.Width = _wx.Current;
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
