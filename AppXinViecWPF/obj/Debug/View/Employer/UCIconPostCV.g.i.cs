// Updated by XamlIntelliSenseFileGenerator 5/7/2024 2:57:02 PM
#pragma checksum "..\..\..\..\View\Employer\UCIconPostCV.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D2D017410066D853333A0BD926626CDA2429C81FF5E9BCA45464AD973CF264A9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AppXinViecWPF.View.Employer;
using FontAwesome.Sharp;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace AppXinViecWPF.View.Employer
{


    /// <summary>
    /// UCIconPostCV
    /// </summary>
    public partial class UCIconPostCV : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector
    {


#line 27 "..\..\..\..\View\Employer\UCIconPostCV.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgAvata;

#line default
#line hidden


#line 42 "..\..\..\..\View\Employer\UCIconPostCV.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnViewCV;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AppXinViecWPF;component/view/employer/uciconpostcv.xaml", System.UriKind.Relative);

#line 1 "..\..\..\..\View\Employer\UCIconPostCV.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.imgAvata = ((System.Windows.Controls.Image)(target));
                    return;
                case 2:
                    this.btnViewCV = ((System.Windows.Controls.Button)(target));

#line 42 "..\..\..\..\View\Employer\UCIconPostCV.xaml"
                    this.btnViewCV.Click += new System.Windows.RoutedEventHandler(this.btnViewCV_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.RichTextBox txtDes;
    }
}

