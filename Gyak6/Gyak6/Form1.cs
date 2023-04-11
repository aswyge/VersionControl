using Gyak6.Entities;
using Gyak6.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gyak6
{
    public partial class Form1 : Form
    {
        List<Toy> Toys = new List<Toy>();

        private Toy _nextToy;
        private IToyFactory _factory;
        public IToyFactory Factory
        {
            get { return _factory; }
            set {
                _factory = value;
                DisplayNext();
                }
        }
        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var Toy = Factory.CreateNew();
            Toys.Add(Toy);
            mainPanel.Controls.Add(Toy);
            Toy.Left = -Toy.Width;
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var Toy in Toys)
            {
                Toy.MoveToy();
                if (maxPosition < Toy.Left)
                {
                    maxPosition = Toy.Left;
                }
                if (maxPosition > 1000)
                {
                    var oldestToy = Toys[0];
                    mainPanel.Controls.Remove(oldestToy);
                    Toys.Remove(oldestToy);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void DisplayNext()
        {
            if (_nextToy != null)
                Controls.Remove(_nextToy);
            _nextToy = Factory.CreateNew();
            _nextToy.Top = lblNext.Top + lblNext.Height + 20;
            _nextToy.Left = lblNext.Left;
            Controls.Add(_nextToy);
        }
    }
}
