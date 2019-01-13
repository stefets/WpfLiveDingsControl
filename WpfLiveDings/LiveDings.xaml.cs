using System.Windows;

namespace WpfLiveDings
{
    /// <summary>
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class WpfLiveDings //: UserControl
    {
        public WpfLiveDings()
        {
            InitializeComponent();

            this.DataContext = this;
        }



        public int Port
        {
            get { return (int)GetValue(PortProperty); }
            set { SetValue(PortProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Port.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PortProperty =
            DependencyProperty.Register("Port", typeof(int), typeof(WpfLiveDings), new PropertyMetadata(0));

            
    }
}
