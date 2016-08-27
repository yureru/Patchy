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

namespace ExceptionsAsynchronousTask
{
    /// <summary>
    /// This project shows how to handle exceptions thrown by an asynchronously method that needs to be awaited.
    /// Basically it handles the exception locally in the thread that raised, but it's saved in the class
    /// AsyncException that is passed as an argument. Then AsyncException is checked in the method caller
    /// and handled accordingly.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void synchronouslyException_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Raise();
            }
            catch (Exception err)
            {
                HandleException(err);
            }
        }

        async void asynchronouslyException_Click(object sender, RoutedEventArgs e)
        {
            AsyncException<Exception> errorFound = new AsyncException<Exception>();
            await RaiseAsync(errorFound);
            if (errorFound.WasRaised)
            {
                HandleAsyncException(errorFound);
            }

        }

        void HandleAsyncException(AsyncException<Exception> err)
        {
            MessageBox.Show(err.Error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        void HandleException(Exception err)
        {
            MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        void Raise()
        {
            throw new ArgumentOutOfRangeException("Some error happened");
        }

        Task RaiseAsync(AsyncException<Exception> excp)
        {
            Task t = Task.Run(() =>
            {
                try
                {
                    throw new ArgumentOutOfRangeException("Some error happened");
                }
                catch (Exception err)
                {
                    excp.WasRaised = true;
                    excp.Error = err;
                }
            });
            return t;
        }
    }
}
