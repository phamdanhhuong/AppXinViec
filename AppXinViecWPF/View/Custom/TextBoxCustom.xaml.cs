using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppXinViecWPF.View.Custom
{
    /// <summary>
    /// Interaction logic for TextBoxCustom.xaml
    /// </summary>
    public partial class TextBoxCustom : UserControl
    {
        public TextBoxCustom()
        {
            InitializeComponent();
        }
        private string placeHolder;
        public string PlaceHolder
        {
            get { return placeHolder; }
            set 
            { 
                placeHolder = value; 
                tbPlaceHolder.Text = placeHolder;
            }
        }
        private string txtText;
        public string TxtText
        {
            get { return txtText; }
            set
            {
                txtText = value;
                txtInput.Text = txtText;
            }
        }
        private Brush backGroundCustom;
        public Brush BackGroundCustom
        {
            get { return backGroundCustom; }
            set
            {
                backGroundCustom = value;
                main.Background = backGroundCustom;
            }
        }
        private TextAlignment placeHolderAlignment;
        public TextAlignment PlaceHolderAlignment
        {
            get { return placeHolderAlignment; }
            set
            {
                placeHolderAlignment = value;
                tbPlaceHolder.TextAlignment = placeHolderAlignment;
            }
        }
        private int heightCustom;
        public int HeightCustom
        {
            get { return heightCustom; }
            set
            {
                heightCustom = value;
                tbPlaceHolder.Height = heightCustom;
                txtInput.Height = heightCustom;
            }
        }
        private int widthtCustom;
        public int WidthtCustom
        {
            get { return heightCustom; }
            set
            {
                widthtCustom = value;
                tbPlaceHolder.Width = widthtCustom;
                txtInput.Width = widthtCustom;
            }
        }
        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
            {
                tbPlaceHolder.Visibility = Visibility.Visible;
            }
            else
            {
                tbPlaceHolder.Visibility = Visibility.Hidden;
            }
        }
        private int inputFSize;
        public int InputFSize
        {
            get { return inputFSize; }
            set
            {
                inputFSize = value;
                txtInput.FontSize = inputFSize;
            }
        }
        private int placeHolderFSize;
        public int PlaceHolderFSize
        {
            get { return placeHolderFSize; }
            set
            {
                placeHolderFSize = value;
                tbPlaceHolder.FontSize = placeHolderFSize;
            }
        }
        private FontWeight inputFWeight;
        public FontWeight InputFWeight
        {
            get { return inputFWeight; }
            set
            {
                inputFWeight = value;
                txtInput.FontWeight = inputFWeight;
            }
        }
        private FontWeight placeHolderFWeight;
        public FontWeight PlaceHolderFWeight
        {
            get { return placeHolderFWeight; }
            set
            {
                placeHolderFWeight = value;
                tbPlaceHolder.FontWeight = placeHolderFWeight;
            }
        }
        private Brush inputFColor;
        public Brush InputFColor
        {
            get { return inputFColor; }
            set
            {
                inputFColor = value;
                txtInput.Foreground= inputFColor;
            }
        }
        private Brush placeHolderFColor;
        public Brush PlaceHolderFColor
        {
            get { return placeHolderFColor; }
            set
            {
                placeHolderFColor = value;
                tbPlaceHolder.Foreground = placeHolderFColor;
            }
        }
        private Style inputStyle;
        public Style InputStyle
        {
            get { return inputStyle; }
            set
            {
                inputStyle = value;
                txtInput.Style = inputStyle;
            }
        }
        private Style placeholderStyle;
        public Style PlaceholderStyle
        {
            get { return placeholderStyle; }
            set
            {
                placeholderStyle = value;
                tbPlaceHolder.Style = placeholderStyle;
            }
        }
    }
}
