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
        private static Database Templates;
        private MySqlConnectionStringBuilder _builder;
        private MySqlConnection _connection;

        private ObservableCollection<TemplateTable> _templateTables=new ObservableCollection<TemplateTable>();
        public ObservableCollection<TemplateTable> TemplateTables => Templates._templateTables;

        public Database(string server, string user, string password, string name, uint port=3306)
        {
            Init(server, user, password, name, port);
            Templates = this;
        }
        
        private void Init(string server, string user, string password, string name, uint port)
        {
            _builder = new MySqlConnectionStringBuilder
            {
                Server = server,
                UserID = user,
                Password = password,
                Database = name,
                CharacterSet = "utf8",
                SslMode = MySqlSslMode.None,
                Port = port,
            };
            _connection=new MySqlConnection(_builder.ToString());
        }

        public IEnumerable<TemplateTable> GetTemplates()
        {
            _templateTables=new ObservableCollection<TemplateTable>();
            TemplateTables.Clear();
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT name FROM templates_storage;";
                using (MySqlDataReader reader=command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TemplateTable tt=new TemplateTable(reader.GetString("name"));
                        if (Templates._templateTables.Contains(tt))
                        {
                            continue;
                        }
                        Templates._templateTables.Add(tt);
                    }
                }
            }
            catch (MySqlException e)
            {
                
                throw new Exception("Template Tables wrong access: "+e);
            }
            _connection.Close();
            return Templates._templateTables;
        }

        public bool InsertTemplatesToDatabase(string name, string path, string file)
        {
            TemplateTable newRow=new TemplateTable(name,path,file);
            try
            {
                _connection.Open();
                MySqlCommand insert = _connection.CreateCommand();
                insert.CommandText =
                    "INSERT INTO templates_storage(name, folder_path, file_name) VALUES (@name, @path, @file)";
                insert.Parameters.AddWithValue("@name", name);
                insert.Parameters.AddWithValue("@path", path);
                insert.Parameters.AddWithValue("@file", file);
                insert.ExecuteNonQuery();
                Templates._templateTables.Add(newRow);
                _connection.Close();
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
                _connection.Open();
                MySqlCommand insert = _connection.CreateCommand();
                insert.CommandText =
                    "UPDATE templates_storage SET name=@upd WHERE name=@old;";
                insert.Parameters.AddWithValue("@upd", upd);
                insert.Parameters.AddWithValue("@old", old);
                insert.ExecuteNonQuery();
                _connection.Close();
                return true;
            }
            catch (MySqlException)
            {

                return false;
            }
        }
    }
}
