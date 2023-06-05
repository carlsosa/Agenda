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
          
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            fill();
        }
        public int saveContact(Person person)
        {
            var list = persons.Where(x => x.PhoneNumber == person.PhoneNumber).ToList();
            if (list.Count() == 0)
            {
                var context = new ScheduleContext();
                context.Add(person);
                context.SaveChanges();
                fill();
                return 1;
            }
            return 0;
            
        }
        public int editPerson(Person person)
        {
            var context = new ScheduleContext();
            var p_sel = context.person.Where(x => x.Id == person.Id).FirstOrDefault();
            var result = p_sel == null? 0 : 1;
            if (result == 1)
            {
                p_sel = person;
                context.SaveChanges();
                fill();
            }
            
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
                    default: MessageBox.Show("Campo o entrada no valida");
                    break;
            }
            
            return p_sels;
        }

        public int  deletePerson(Person? getSelectedPerson1)
        {
            var context = new ScheduleContext();
            context.Remove(getSelectedPerson1);
            context.SaveChanges();
            var find = context.person.FirstOrDefault(x => x.Id == getSelectedPerson1.Id);
            if(find == null)
            {
                fill();
                return 1;
            }
            return 0;
        }

        public void fill()
        {
            var context = new ScheduleContext();
            persons = context.person.ToList();
            
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

        private void personBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}