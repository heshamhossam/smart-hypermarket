﻿#pragma checksum "..\..\..\..\DataEntryManager\Views\AddOffer.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E6EED5A6A9D8DD4AD80E2EB8B34C8C2C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
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


namespace SmartHyperMarket.DataEntryManager.Views {
    
    
    /// <summary>
    /// AddOffer
    /// </summary>
    public partial class AddOffer : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\DataEntryManager\Views\AddOffer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxName;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\DataEntryManager\Views\AddOffer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxTeaser;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\DataEntryManager\Views\AddOffer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxCategories;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\DataEntryManager\Views\AddOffer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxProducts;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\DataEntryManager\Views\AddOffer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxQuantity;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\DataEntryManager\Views\AddOffer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonAddToOffer;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\DataEntryManager\Views\AddOffer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonSubmitOffer;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\DataEntryManager\Views\AddOffer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxOfferPrice;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\DataEntryManager\Views\AddOffer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listBoxProductOffer;
        
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
            System.Uri resourceLocater = new System.Uri("/SmartHyperMarket;component/dataentrymanager/views/addoffer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\DataEntryManager\Views\AddOffer.xaml"
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
            this.textBoxName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.textBoxTeaser = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.comboBoxCategories = ((System.Windows.Controls.ComboBox)(target));
            
            #line 21 "..\..\..\..\DataEntryManager\Views\AddOffer.xaml"
            this.comboBoxCategories.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.categorylist_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.comboBoxProducts = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.textBoxQuantity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.buttonAddToOffer = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\DataEntryManager\Views\AddOffer.xaml"
            this.buttonAddToOffer.Click += new System.Windows.RoutedEventHandler(this.buttonAddToOffer_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.buttonSubmitOffer = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\..\DataEntryManager\Views\AddOffer.xaml"
            this.buttonSubmitOffer.Click += new System.Windows.RoutedEventHandler(this.buttonSubmitOffer_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.textBoxOfferPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.listBoxProductOffer = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

