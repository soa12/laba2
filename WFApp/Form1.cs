﻿using System;
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
using System.IO;
using DataAccess;


namespace WFApp
{
    public partial class Form1 : Form
    {
        private IPhoneBookRepository db;
        //private RecordRepository db = new RecordRepository();

        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("Выберите репозиторий");
            openFileDialog1 = new OpenFileDialog(); //создание диалогового окна для выбора файла
            openFileDialog1.Filter = "Dynamic Link Library (*.dll)|*.txt|All files(*.*)|*.*"; //формат загружаемого файла
            if (openFileDialog1.ShowDialog() == DialogResult.OK) //если в окне была нжата кнопка "ОК"
            {
                string path = openFileDialog1.FileName;
                db = ModuleLoader.ReturnObject(path);
                dataGridView1.DataSource = db.ToBindingList();
            }
            
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
                Record record = db.Read(id);
                ContactForm contactForm = new ContactForm();
                contactForm.textBoxName.Text = record.Name;
                contactForm.textBoxLastName.Text = record.LastName;
                contactForm.textBoxPhone.Text = record.PhoneNumber;
                contactForm.dateTimeBirthdate.Value = record.Birthday;
                DialogResult result = contactForm.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                record.Name = contactForm.textBoxName.Text;
                record.LastName = contactForm.textBoxLastName.Text;
                record.PhoneNumber = contactForm.textBoxPhone.Text;
                record.Birthday = contactForm.dateTimeBirthdate.Value.Date;
                db.Update(record);
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

            //if (result == DialogResult.Cancel)
            //    return;
            //List<Record> list = new List<Record>();
            
            //list = db.GetRecords(day).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog(); //создание диалогового окна для выбора файла
            openFileDialog1.Filter = "Dynamic Link Library (*.dll)|*.txt|All files(*.*)|*.*"; //формат загружаемого файла
            if (openFileDialog1.ShowDialog() == DialogResult.OK) //если в окне была нжата кнопка "ОК"
            {
                string path = openFileDialog1.FileName;
                db = ModuleLoader.ReturnObject(path);
                dataGridView1.DataSource = db.ToBindingList();

            }

        }
    }
}
