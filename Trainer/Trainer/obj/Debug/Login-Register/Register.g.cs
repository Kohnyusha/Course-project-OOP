﻿#pragma checksum "..\..\..\Login-Register\Register.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DEEB4D257F8178E1D3FE1C28D9B4D33FB13284703711995E3EC5CDD6583D2F28"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using Trainer.Login_Register;


namespace Trainer.Login_Register {
    
    
    /// <summary>
    /// Register
    /// </summary>
    public partial class Register : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Login-Register\Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LoginWindow;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Login-Register\Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image login;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Login-Register\Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MailBox;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Login-Register\Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LoginBox;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Login-Register\Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwordBox;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Login-Register\Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RegButton;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Login-Register\Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button log_form;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Login-Register\Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_reg;
        
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
            System.Uri resourceLocater = new System.Uri("/Trainer;component/login-register/register.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Login-Register\Register.xaml"
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
            this.LoginWindow = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.login = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.MailBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 38 "..\..\..\Login-Register\Register.xaml"
            this.MailBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.MailBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LoginBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 42 "..\..\..\Login-Register\Register.xaml"
            this.LoginBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.LoginBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.passwordBox = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 46 "..\..\..\Login-Register\Register.xaml"
            this.passwordBox.PasswordChanged += new System.Windows.RoutedEventHandler(this.passwordBox_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RegButton = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\Login-Register\Register.xaml"
            this.RegButton.Click += new System.Windows.RoutedEventHandler(this.RegButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.log_form = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\Login-Register\Register.xaml"
            this.log_form.Click += new System.Windows.RoutedEventHandler(this.log_form_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.label_reg = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

