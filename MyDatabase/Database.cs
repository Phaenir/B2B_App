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

        private ObservableCollection<Airline> _airlines = new ObservableCollection<Airline>();
        public ObservableCollection<Airline> Airlines => Templates._airlines;

        private ObservableCollection<City> _cities = new ObservableCollection<City>();
        public ObservableCollection<City> Cities => Templates._cities;

        private ObservableCollection<Country> _countries = new ObservableCollection<Country>();
        public ObservableCollection<Country> Countries => Templates._countries;

        private ObservableCollection<Airport> _airports = new ObservableCollection<Airport>();
        public ObservableCollection<Airport> Airports => Templates._airports;

        private ObservableCollection<FlightPoint> _travelPoints = new ObservableCollection<FlightPoint>();
        public ObservableCollection<FlightPoint> TravelPoints => Templates._travelPoints;

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
        public IEnumerable<Airline> GetAirlines()
        {
            _airlines = new ObservableCollection<Airline>();
            Airlines.Clear();
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM airline;";
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Airline tt = new Airline(reader.GetString("iata"),reader.GetString("name"));
                        if (Templates._airlines.Contains(tt))
                        {
                            continue;
                        }
                        Templates._airlines.Add(tt);
                    }
                }
            }
            catch (MySqlException e)
            {

                throw new Exception("Template Tables wrong access: " + e);
            }
            _connection.Close();
            return Templates.Airlines;
        }
        public IEnumerable<Country> GetCountries()
        {
            _countries = new ObservableCollection<Country>();
            Countries.Clear();
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM countries;";
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Country tt = new Country(reader.GetString("iata"),reader.GetString("name"));
                        if (Templates._countries.Contains(tt))
                        {
                            continue;
                        }
                        Templates._countries.Add(tt);
                    }
                }
            }
            catch (MySqlException e)
            {

                throw new Exception("Template Tables wrong access: " + e);
            }
            _connection.Close();
            return Templates.Countries;
        }
        public IEnumerable<City> GetCities()
        {
            _cities = new ObservableCollection<City>();
            Cities.Clear();
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM cities;";
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        City tt = new City(reader.GetString("iata"),reader.GetString("name"), reader.GetString("coordinates"),reader.GetString("timezone"),reader.GetString("parent_name"));
                        if (Templates._cities.Contains(tt))
                        {
                            continue;
                        }
                        Templates._cities.Add(tt);
                    }
                }
            }
            catch (MySqlException e)
            {

                throw new Exception("Template Tables wrong access: " + e);
            }
            _connection.Close();
            return Templates.Cities;
        }
        public IEnumerable<Airport> GetAirports()
        {
            _airports = new ObservableCollection<Airport>();
            Airports.Clear();
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM airports;";
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Airport tt = new Airport(reader.GetString("iata"),reader.GetString("name"),reader.GetString("coordinates"),reader.GetString("timezone"),reader.GetString("parent_name"));
                        if (Templates._airports.Contains(tt))
                        {
                            continue;
                        }
                        Templates._airports.Add(tt);
                    }
                }
            }
            catch (MySqlException e)
            {

                throw new Exception("Template Tables wrong access: " + e);
            }
            _connection.Close();
            return Templates.Airports;
        }
        public IEnumerable<FlightPoint> GetFlightPoints()
        {
            _travelPoints = new ObservableCollection<FlightPoint>();
            TravelPoints.Clear();
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM airportlist;";
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FlightPoint tt = new FlightPoint(reader.GetString("iata"),reader.GetString("name"),reader.GetString("coordinates"),reader.GetString("timezone"),reader.GetString("cityname"),reader.GetString("citycode"),reader.GetString("countryname"),reader.GetString("countrycode"));
                        if (Templates._travelPoints.Contains(tt))
                        {
                            continue;
                        }
                        Templates._travelPoints.Add(tt);
                    }
                }
            }
            catch (MySqlException e)
            {

                throw new Exception("Template Tables wrong access: " + e);
            }
            _connection.Close();
            return Templates.TravelPoints;
        }
    }
}
