using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MyDatabase
{
    public class Database
    {
        private static readonly Database Templates=new Database();
        private MySqlConnectionStringBuilder _builder;
        private MySqlConnection _connection;

        private readonly ObservableCollection<TemplateTable> _templateTables=new ObservableCollection<TemplateTable>();
        public ObservableCollection<TemplateTable> TemplateTables => Templates._templateTables;

        public Database()
        {
            this.GetTemplates();
        }
        private void Init()
        {
            _builder = new MySqlConnectionStringBuilder
            {
                Server = "185.106.120.107",
                UserID = "admin",
                Password = "0O2z6T7e",
                Database = "b2b_support",
                CharacterSet = "utf8",
                SslMode = MySqlSslMode.None
            };
            _connection=new MySqlConnection(_builder.ToString());
        }

        public IEnumerable<TemplateTable> GetTemplates()
        {
            try
            {
                Init();
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT name FROM templates_storage;";
                using (MySqlDataReader reader=command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Templates._templateTables.Add(new TemplateTable(reader.GetString("name")));
                    }
                }
            }
            catch (MySqlException e)
            {
                
                throw new Exception("Template Tables wrong access: "+e);
            }
            return Templates.TemplateTables;
        }

        public bool InsertTemplatesToDatabase(string name, string path, string file)
        {
            TemplateTable newRow=new TemplateTable(name,path,file);
            try
            {
                Init();
                _connection.Open();
                MySqlCommand insert = _connection.CreateCommand();
                insert.CommandText =
                    "INSERT INTO templates_storage(name, folder_path, file_name) VALUES (@name, @path, @file)";
                insert.Parameters.AddWithValue("@name", name);
                insert.Parameters.AddWithValue("@path", path);
                insert.Parameters.AddWithValue("@file", file);
                insert.ExecuteNonQuery();
                Templates._templateTables.Add(newRow);
                return true;
            }
            catch (MySqlException)
            {

                return false;
            }           
        }

        public bool UpgradeTemplatesInDatabase(string old, string upd)
        {
            try
            {
                Init();
                _connection.Open();
                MySqlCommand insert = _connection.CreateCommand();
                insert.CommandText =
                    "UPDATE templates_storage SET name=@upd WHERE name=@old;";
                insert.Parameters.AddWithValue("@upd", upd);
                insert.Parameters.AddWithValue("@old", old);
                insert.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException)
            {

                return false;
            }
        }
    }
}
