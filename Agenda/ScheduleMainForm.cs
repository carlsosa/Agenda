using System.Data;

namespace Agenda
{
    public partial class ScheduleMainForm : Form
    {
         public List<Person> persons  = new List<Person>();
        public ScheduleMainForm()
        {
            
            InitializeComponent();
            dataList.Visible = true;
            persons = new List<Person>();
            var person = new Person();
            person.Id = 1;
            person.FirstName = "Marcus";
            person.LastName = "Valdan";
            person.Created = DateTime.Now;
            person.Instagram = "@insta";
            person.PhoneNumber = "8092224455";
            person.Email = "example@example.com";
            persons.Add(person);
             person = new Person();
            person.Id = 1;
            person.FirstName = "Martin";
            person.LastName = "Viena";
            person.Created = DateTime.Now;
            person.Instagram = "@insta2021u1u8u34y3y4y1u3iu1";
            person.PhoneNumber = "80922244556";
            person.Email = "example2@example.com";
            persons.Add(person);
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var item in persons)
            {
                personBindingSource.Add(item);

            }
        }
        public void Form1_Reload(Person person)
        {

            personBindingSource.Add(person);
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(this);
            addForm.Show();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void quienMeHizoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBoxForm about = new AboutBoxForm();
            about.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}