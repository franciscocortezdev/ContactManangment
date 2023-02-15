using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManangment
{
    public partial class Main : Form
    {
        private BusinessLogicLayer _businessLogicLayer;

        public Main()
        {
            InitializeComponent();
            _businessLogicLayer = new BusinessLogicLayer();

        }

        private void Main_Load(object sender, EventArgs e)
        {
            PopulateContacts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenContactDetails();
        }


        private void OpenContactDetails()
        {
            ContactDetails ConDetails = new ContactDetails();
            ConDetails.ShowDialog(this);
        }

        public void PopulateContacts()
        {
            List<Contact> listContacts = _businessLogicLayer.GetContacts();
            gridContacts.DataSource = listContacts;
        }

        private void gridContacts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewButtonCell cell = (DataGridViewButtonCell)gridContacts.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.Value.ToString() == "Edit")
            {
                ContactDetails ConDetails = new ContactDetails();
                ConDetails.LoadContact(new Contact()
                {
                    Id = (int)gridContacts.Rows[e.RowIndex].Cells[0].Value,
                    FirstName = gridContacts.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    LastName = gridContacts.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    Phone = (int)gridContacts.Rows[e.RowIndex].Cells[3].Value,
                    Address = gridContacts.Rows[e.RowIndex].Cells[4].Value.ToString(),

                });
                ConDetails.ShowDialog(this);
            }
            else if(cell.Value.ToString() == "Delete")
            {
                int Id = (int)gridContacts.Rows[e.RowIndex].Cells[0].Value;
                _businessLogicLayer.DeleteContact(Id);
                PopulateContacts();
            }
        }
    }
}
