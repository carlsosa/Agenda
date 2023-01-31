using Newtonsoft.Json;
using System.Data;
using System.Text.Json;

namespace Agenda
{
    public partial class ScheduleMainForm : Form
    {
         public List<Person> persons  = new List<Person>();
         public Person GetPersonSelected = new Person();
        public ScheduleMainForm()
        {
            
            InitializeComponent();
            dataList.Visible = true;
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
            person.Id = 2;
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
            fill();
        }
        public int saveContact(Person person)
        {
            var list = persons.Where(x => x.PhoneNumber == person.PhoneNumber).ToList();
            var p_id = persons.OrderByDescending(u => u.Id).FirstOrDefault();
            if (list.Count() == 0)
            {
                person.Id = p_id == null ? 0 : p_id.Id + 1;
                persons.Add(person);
                fill();
                return 1;
            }
            return 0;
            
        }
        public int editPerson(Person person)
        {
            var p_sel = persons.Where(x => x.Id == person.Id).FirstOrDefault();
            p_sel = person;
            var result = p_sel == null? 0 : 1;      
            fill();
            return result;
        }
        public List<Person> searchPerson(String criteria, string keyWord)
        {
            var p_sels = new List<Person>();
            switch (criteria)
            {
                case "Nombre":
                     p_sels = persons.Where(x => x.FirstName.Contains(keyWord)).ToList();
                    break;
                case "Apellido":
                     p_sels = persons.Where(x => x.LastName.Contains(keyWord)).ToList();
                    break;
                case "Telefono":
                     p_sels = persons.Where(x => x.PhoneNumber.Contains(keyWord)).ToList();
                    break;
                case "Correo": 
                    p_sels = persons.Where(x => x.Email.Contains(keyWord)).ToList();
                    break;
                case "Instagram":
                    p_sels = persons.Where(x => x.Instagram.Contains(keyWord)).ToList();
                    break;
                    default: throw new ArgumentException();
            }
            
            return p_sels;
        }
        public void fill()
        {
            personBindingSource.Clear();
            foreach (var item in persons.OrderBy(x=> x.Id))
            {
                personBindingSource.Add(item);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var sended = (DataGridView)sender;
            GetPersonSelected = (Person)sended.CurrentRow.DataBoundItem;
            EditForm editForm =  new EditForm(this);
            editForm.Show();

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

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm(this);
            searchForm.Show();
        }
    }
}