using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traccia
{
    public partial class CompCopiaFoto: Component
    {

        public CompCopiaFoto()
        {
            InitializeComponent();
        }

        public CompCopiaFoto(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
