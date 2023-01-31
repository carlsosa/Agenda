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
    public partial class AddForm : Form
    {

        ScheduleMainForm parent = null;
        public AddForm(Form parent)
        {
            this.parent = parent as ScheduleMainForm;      
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fn = textBox1.Text;
            var ln = textBox2.Text;
            var tel = textBox3.Text;
            var email = textBox4.Text;
            var insta = textBox5.Text;
            var person = new Person();
            person.Email = email;
            person.PhoneNumber = tel;
            person.FirstName = fn;
            person.LastName = ln;
            person.Instagram = insta;
            person.Created = DateTime.Now;
           var result = this.parent.saveContact(person);
            if(result == 0) { MessageBox.Show("Contacto ya existe"); } else
            {
                MessageBox.Show("Guardado exitosamente");
                this.Close();
            }
           
            
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
