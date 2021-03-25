using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FirstTaskUpdated.Components
{
    /// <summary>
    /// Interaction logic for BindablePassword.xaml
    /// </summary>
    
public partial class BindablePassword : UserControl
{
    private Boolean isPasswordChanging;
    public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register("Password", typeof(string), typeof(BindablePassword),
        new PropertyMetadata(string.Empty, PasswordPropertyChanged));

    private static void PasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is BindablePassword passwordBox)
        {
            passwordBox.UpdatePassword();
        }
    }

    private void UpdatePassword()
    {
        if (!isPasswordChanging)
            passwordBox.Password = Password;
    }

    public string Password
    {
        get { return (string)GetValue(PasswordProperty); }
        set { SetValue(PasswordProperty, value); }
    }


    public BindablePassword()
    {
        InitializeComponent();
    }


    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        isPasswordChanging = true;
        Password = passwordBox.Password;
        isPasswordChanging = false;
    }
}
}

