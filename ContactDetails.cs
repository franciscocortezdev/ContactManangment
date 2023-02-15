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
    public partial class ContactDetails : Form
    {
        private BusinessLogicLayer _businessLogicLayer;
        private Contact _Contact;
        public ContactDetails()
        {
            InitializeComponent();
            _businessLogicLayer= new BusinessLogicLayer();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveContact();
            ((Main)this.Owner).PopulateContacts();
            this.Close();

        }



        private void SaveContact()
        {
            Contact contact = new Contact();
            contact.FirstName = txtFirstName.Text;
            contact.LastName = txtLastName.Text;
            contact.Phone = Convert.ToInt32(txtPhone.Text);
            contact.Address = txtAddress.Text;
            contact.Id = _Contact !=null ? _Contact.Id : 0;

            _businessLogicLayer.SaveContact(contact);
        }

        public void LoadContact(Contact contact)
        {
            _Contact = contact;

            ClearForm();
            txtFirstName.Text = contact.FirstName;
            txtLastName.Text = contact.LastName;
            txtPhone.Text = contact.Phone.ToString();
            txtAddress.Text = contact.Address;

        }

        public void ClearForm()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }
    }
}
