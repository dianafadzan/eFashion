﻿#pragma checksum "..\..\KupacInfoWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "283854FDAE2656F0547DC3159FDD31D5376766CB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using eF;


namespace eF {
    
    
    /// <summary>
    /// KupacInfoWindow
    /// </summary>
    public partial class KupacInfoWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 76 "..\..\KupacInfoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbIme;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\KupacInfoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPrezime;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\KupacInfoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbAdresa;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\KupacInfoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPb;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\KupacInfoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbGrad;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\KupacInfoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbTelefon;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\KupacInfoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbUkupno;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/eF;component/kupacinfowindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\KupacInfoWindow.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\KupacInfoWindow.xaml"
            ((eF.KupacInfoWindow)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 25 "..\..\KupacInfoWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbIme = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbPrezime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tbAdresa = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.cbPb = ((System.Windows.Controls.ComboBox)(target));
            
            #line 85 "..\..\KupacInfoWindow.xaml"
            this.cbPb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CbPb_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tbGrad = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.tbTelefon = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.tbUkupno = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
