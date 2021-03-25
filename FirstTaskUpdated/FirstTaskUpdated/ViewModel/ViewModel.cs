using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FirstTaskUpdated
{

  
        class ViewModel : INotifyPropertyChanged
        {

        string json = System.IO.File.ReadAllText(@"C:\Users\99002679\Downloads\data.json");
        public RelayCommand cmd { get; set; }
        private ObservableCollection<Employee> employees;

        public ObservableCollection<Employee> Employees
        {
            get
            {
                return employees;
            }
            set
            {
                employees = value;
                 OnPropertyChanged("Employees");
            }
        }

        public ViewModel()
            {
            cmd = new RelayCommand(Canexecute, CanUse);

            Employees = JsonConvert.DeserializeObject<ObservableCollection<Employee>>(json);

        }

        private string username;
            private string password;



            public string Name
            {
                get
                {
                    return username;
                }
                set
                {
                    username = value;
                    OnPropertyChanged("Name");
                }
            }

            public string Password
            {
                get
                {
                    return password;
                }
                set
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
            private System.Windows.Visibility showvisibility;
            public System.Windows.Visibility Showvisibility
            {
                get
                {
                    return showvisibility;
                }
                set
                {
                    showvisibility = value;
                    OnPropertyChanged("Showvisibility");
                }
            }
            private System.Windows.Visibility hidevisibility;
            public System.Windows.Visibility Hidevisibility
            {
                get
                {
                    return hidevisibility;
                }
                set
                {
                    hidevisibility = value;
                    OnPropertyChanged("Hidevisibility");
                }
            }
            private System.Windows.Visibility pwd;
            public System.Windows.Visibility Pwd
            {
                get
                {
                    return pwd;
                }
                set
                {
                    pwd = value;
                    OnPropertyChanged("Pwd");
                }
            }
            private System.Windows.Visibility txtbox;
            public System.Windows.Visibility Txtbox
            {
                get
                {
                    return txtbox;
                }
                set
                {
                    txtbox = value;
                    OnPropertyChanged("Txtbox");
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;





        public void Canexecute(object param)
        {


            if (param.ToString() == "ShowPassword")
            {
                Showvisibility = Visibility.Collapsed;
                Hidevisibility = Visibility.Visible;
                Pwd = Visibility.Collapsed;
                Txtbox = Visibility.Visible;


            }

            else if (param.ToString() == "HidePassword")
            {
                Hidevisibility = Visibility.Collapsed;
                Showvisibility = Visibility.Visible;
                Txtbox = Visibility.Collapsed;
                Pwd = Visibility.Visible;

            }
           else if(param.ToString()== "ADDBUTTON")

            { 
                Employee emp = new Employee()
                {
                    Firstname = "Maneesh",
                    Lastname = "Dani",
                    Dateofbirth = "23-02-1998",
                    Experience = "4"
                };
                
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(emp, Newtonsoft.Json.Formatting.Indented);
                using (var writer = new StreamWriter(@"C:\Users\99002679\Downloads\data.json",true))
                {
                    writer.Write(output);
                }
            }
            else 
            {
               if(param.ToString()==null || Name == null)
                {
            
                    MessageBox.Show("Password/ username Cannot be empty");
                }
               else if (Name == "grace" && param.ToString() == "1234")
                {
                  
                    MessageBox.Show("Login Successful");
                    Home home = new Home();
                  //  Employees = null;
                    home.Show(); 
                    FirstTaskUpdated.MainWindow.AppWindow.Hide();
                }
                else
                   
                MessageBox.Show("Invalid Credentials");

            }


        }

            public bool CanUse(object message)
            {
                return true;
            }

            public void OnPropertyChanged(string property)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
            }

            private bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
            {
                if (!Equals(field, newValue))
                {
                    field = newValue;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                    return true;
                }

                return false;
            }


        }
    }

