﻿#pragma checksum "..\..\..\..\Menu\TreiningPage\StartTreining.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8310C1EDC469776BA5A63091C20958DA424E5C58952448A39F9F9C48ED6E4EFC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using Trainer.Menu.TreiningPage;


namespace Trainer.Menu.TreiningPage {
    
    
    /// <summary>
    /// StartTreining
    /// </summary>
    public partial class StartTreining : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\Menu\TreiningPage\StartTreining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StackImage;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Menu\TreiningPage\StartTreining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button back;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Menu\TreiningPage\StartTreining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel MainStackPanel;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Menu\TreiningPage\StartTreining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button like;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Menu\TreiningPage\StartTreining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Finish;
        
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
            System.Uri resourceLocater = new System.Uri("/Trainer;component/menu/treiningpage/starttreining.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Menu\TreiningPage\StartTreining.xaml"
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
            this.StackImage = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.back = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\Menu\TreiningPage\StartTreining.xaml"
            this.back.Click += new System.Windows.RoutedEventHandler(this.back_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MainStackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.like = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\Menu\TreiningPage\StartTreining.xaml"
            this.like.Click += new System.Windows.RoutedEventHandler(this.like_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Finish = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\Menu\TreiningPage\StartTreining.xaml"
            this.Finish.Click += new System.Windows.RoutedEventHandler(this.Finish_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
