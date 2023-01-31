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
    public partial class SearchForm : Form
    {
        ScheduleMainForm parent = null;
        public SearchForm(Form sf)
        {
            parent = sf as ScheduleMainForm;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var criteria = this.comboBox1.Text;
            var value = this.textBox1.Text;
            var list = this.parent.searchPerson(criteria, value);
            fill(list);
        }

        private void fill(List<Person> persons)
        {
            personBindingSource.Clear();
            foreach (var item in persons.OrderBy(x => x.Id))
            {
                personBindingSource.Add(item);

            }
        }
    }
}
