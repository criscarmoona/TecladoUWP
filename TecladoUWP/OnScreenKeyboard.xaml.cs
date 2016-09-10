using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace TecladoUWP
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public partial class OnScreenKeyBoard : UserControl
    {
        #region Properties
        public object Host { get; set; }

        public KeyboardLayouts InitialLayout
        {
            get { return (this.DataContext as KeyboardViewModel).Layout; }
            set { (this.DataContext as KeyboardViewModel).Layout = value; }
        }
        public static readonly DependencyProperty InitialLayoutProperty = DependencyProperty.Register("InitialLayout", typeof(KeyboardLayouts), typeof(OnScreenKeyBoard), new PropertyMetadata(KeyboardLayouts.English));
        #endregion

        public OnScreenKeyBoard()
        {
            DataContext = new KeyboardViewModel(this);
            InitializeComponent();
        }

        public void RegisterTarget(TextBox control)
        {
            RegisterBox(control);
        }
        public void RegisterTarget(PasswordBox control)
        {
            RegisterBox(control);
        }
        private void RegisterBox(Control control)
        {
            control.GotFocus += delegate { (DataContext as KeyboardViewModel).TargetBox = control; System.Diagnostics.Debug.WriteLine("focused"); };
            control.LostFocus += delegate { (DataContext as KeyboardViewModel).TargetBox = null; };
        }
    }
}
