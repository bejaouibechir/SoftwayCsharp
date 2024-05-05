using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObserverProject
{
    //Le client qui observe le button
    public partial class Form1 : Form ,IObserver
    {
        private ObservableButton button;
        public Form1()
        {
            InitializeComponent();
            button = new ObservableButton();
            button.Top = 20;
            button.Left = 20;
            button.Text = "Click Me";
            //Abonner l'observer dans le bouton 
            button.AttachObserver(this);
            Controls.Add(button);   
        }

        public void Observe()
        {
            MessageBox.Show("Button clicked!");
        }
    }

    public interface IObserver
    {
       void Observe();
    }


    public class ObservableButton : Button
    {
        //Attacher l'evenement à l'action
        public void AttachObserver(IObserver observer)
        {
            Click += (sender, e) => observer.Observe();
        }
    }

}
