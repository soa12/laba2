using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using DataAccess;
using PostgreSQLRepository;
using DomainModel;
using System.Reflection;
using DataAccess.Interfaces;
using System.IO;

namespace WFApp
{
    public partial class Form1 : Form
    {

        private RecordRepository db = new RecordRepository();

        public Form1()
        {
            InitializeComponent();

            dataGridView1.DataSource = db.ToBindingList();
            //dataGridView1.DataSource = db.GetRecords().ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                //Record record = db.Read(id);
                db.Delete(id);

                //Player player = db.Players.Find(id);
                //db.Players.Remove(player);
                //db.SaveChanges();
                dataGridView1.Refresh();
                MessageBox.Show("Контакт удален");
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            ContactForm contactForm = new ContactForm();
            DialogResult result = contactForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Record record = new Record();
            record.Name = contactForm.textBoxName.Text;
            record.LastName = contactForm.textBoxLastName.Text;
            record.PhoneNumber = contactForm.textBoxPhone.Text;
            record.Birthday = contactForm.dateTimeBirthdate.Value.Date;
            db.Create(record);
            dataGridView1.Refresh();
            MessageBox.Show("Новый контакт добавлен");
        }

        private void Close_Click(object sender, EventArgs e)
        {
            //DialogResult result = ShowDialog(this);
            //if (result == DialogResult.OK)
            Close();

        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                //Player player = db.Players.Find(id);
                Record record = db.Read(id);
                ContactForm contactForm = new ContactForm();
                //PlayerForm plForm = new PlayerForm();
                contactForm.textBoxName.Text = record.Name;
                contactForm.textBoxLastName.Text = record.LastName;
                contactForm.textBoxPhone.Text = record.PhoneNumber;
                contactForm.dateTimeBirthdate.Value = record.Birthday;
                //plForm.numericUpDown1.Value = player.Age;
                //plForm.comboBox1.SelectedItem = player.Position;
                //plForm.textBox1.Text = player.Name;

                DialogResult result = contactForm.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                record.Name = contactForm.textBoxName.Text;
                record.LastName = contactForm.textBoxLastName.Text;
                record.PhoneNumber = contactForm.textBoxPhone.Text;
                record.Birthday = contactForm.dateTimeBirthdate.Value.Date;
                db.Update(record);

                //player.Age = (int)plForm.numericUpDown1.Value;
                //player.Name = plForm.textBox1.Text;
                //player.Position = plForm.comboBox1.SelectedItem.ToString();

                //db.SaveChanges();
                dataGridView1.Refresh(); // обновляем грид
                MessageBox.Show("Контакт обновлен");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            int day = 5;

            Report reportForm = new Report();

            reportForm.dataGridView1.DataSource = db.GetRecords(day).ToList();
            DialogResult result = reportForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;
            List<Record> list = new List<Record>();
            list = db.GetRecords(day).ToList();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            //openFileDialog1 = new OpenFileDialog(); //создание диалогового окна для выбора файла
            //openFileDialog1.Filter = "Text files (*.dll)|*.txt|All files(*.*)|*.*"; //формат загружаемого файла
            //if (openFileDialog1.ShowDialog() == DialogResult.OK) //если в окне была нжата кнопка "ОК"
            //{
            //    Encoding enc = Encoding.GetEncoding(1251);
            //    string path = openFileDialog1.FileName;
            //    string temp;
            //    StreamReader sr = new StreamReader(path, enc);

            //    var asm = Assembly.LoadFile(path);
            //    //Пример поиска типа данных, реализующего интерфейс репозитория:
            //    var results = from type in asm.GetTypes() where typeof(IPhoneBookRepository).IsAssignableFrom(type) select type;
            //    //Пример создания объекта найденного типа данных:
            //    IPhoneBookRepository instance = (IPhoneBookRepository)Activator.CreateInstance(results.FirstOrDefault());

            //}
            
        }
    }
}
