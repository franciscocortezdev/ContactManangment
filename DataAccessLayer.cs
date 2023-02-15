using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ContactManangment
{
    public class DataAccessLayer
    {
        private SqlConnection connectionDB = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        public void InsertContact(Contact contact)
        {
            try
            {
                connectionDB.Open();

                string query = "INSERT INTO Contacts (FirstName, LastName, Phone, Address) VALUES (@firstName, @lastName, @Phone, @Address)";

                SqlParameter firstName = new SqlParameter("@firstName", contact.FirstName);
                SqlParameter lastName = new SqlParameter("@lastName", contact.LastName);
                SqlParameter Phone = new SqlParameter("@Phone", contact.Phone);
                SqlParameter Address = new SqlParameter("@Address", contact.Address);

                SqlCommand command = new SqlCommand(query, connectionDB);
                command.Parameters.Add(firstName);
                command.Parameters.Add(lastName);
                command.Parameters.Add(Phone);
                command.Parameters.Add(Address);
                command.ExecuteNonQuery();



            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connectionDB.Close();
            }
        }


        public List<Contact> GetContacts()
        {
            List<Contact> listContacts = new List<Contact>();
            try
            {
                connectionDB.Open();

                string query = "SELECT * FROM Contacts";

                using (SqlCommand command = new SqlCommand(query, connectionDB))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            listContacts.Add(new Contact()
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Phone = reader.GetInt32(3),
                                Address = reader.GetString(4),

                            });

                        }
                    }

                }


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connectionDB.Close();
            }

            return listContacts;
        }


        public void UpdateContact(Contact contact)
        {
            try
            {
                connectionDB.Open();

                string query = "UPDATE Contacts SET FirstName = @firstName, LastName = @lastName, Phone = @Phone, Address = @Address WHERE Id = @Id";


                SqlParameter Id = new SqlParameter("@Id", contact.Id);
                SqlParameter firstName = new SqlParameter("@firstName", contact.FirstName);
                SqlParameter lastName = new SqlParameter("@lastName", contact.LastName);
                SqlParameter Phone = new SqlParameter("@Phone", contact.Phone);
                SqlParameter Address = new SqlParameter("@Address", contact.Address);

                SqlCommand command = new SqlCommand(query, connectionDB);
                command.Parameters.Add(Id);
                command.Parameters.Add(firstName);
                command.Parameters.Add(lastName);
                command.Parameters.Add(Phone);
                command.Parameters.Add(Address);
                command.ExecuteNonQuery();



            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connectionDB.Close();
            }
        }

        public void DeleteContact(int IdContact)
        {
            try
            {
                connectionDB.Open();

                string query = "DELETE FROM Contacts WHERE Id = @Id";


                SqlParameter Id = new SqlParameter("@Id", IdContact);

                SqlCommand command = new SqlCommand(query, connectionDB);
                command.Parameters.Add(Id);

                command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connectionDB.Close();
            }
        }
    }
}
