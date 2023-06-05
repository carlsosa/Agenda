using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda
{
    public partial class EditForm : Form
    {
        ScheduleMainForm? parent = null;
        Person? GetSelectedPerson1 = null;
        public EditForm(Form parent_super)
        {
            parent =  parent_super as ScheduleMainForm;
            InitializeComponent();
            if (parent != null)
            {
                this.GetSelectedPerson1 = this.parent.GetPersonSelected;
                this.textBox1.Text = this.parent.GetPersonSelected.FirstName;
                this.textBox2.Text = this.parent.GetPersonSelected.LastName;
                this.textBox3.Text = this.parent.GetPersonSelected.PhoneNumber;
                this.textBox4.Text = this.parent.GetPersonSelected.Email;
                this.textBox5.Text = this.parent.GetPersonSelected.Instagram;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetSelectedPerson1.FirstName = this.textBox1.Text;
            GetSelectedPerson1.LastName = this.textBox2.Text;
            GetSelectedPerson1.PhoneNumber = this.textBox3.Text;
            GetSelectedPerson1.Email = this.textBox4.Text;
            GetSelectedPerson1.Instagram = this.textBox5.Text;
            var result = this.parent.editPerson(GetSelectedPerson1);
            if(result == 1)
            {
                MessageBox.Show("Modificado Exitosamente");
            }
            else
            {
                MessageBox.Show("No se pudo modificar");
            }
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = this.parent.deletePerson(GetSelectedPerson1);
            if (result == 1)
            {
                MessageBox.Show("Modificado Exitosamente");
            }
            else
            {
                MessageBox.Show("No se pudo modificar");
            }
            this.Close();
        }
    }
}
