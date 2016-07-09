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
        private static Database _templates;
        private MySqlConnectionStringBuilder _builder;
        private MySqlConnection _connection;

        private ObservableCollection<TemplateTable> _templateTables=new ObservableCollection<TemplateTable>();
        public ObservableCollection<TemplateTable> TemplateTables => _templates._templateTables;

        private ObservableCollection<Airline> _airlines = new ObservableCollection<Airline>();
        public ObservableCollection<Airline> Airlines => _templates._airlines;

        private ObservableCollection<City> _cities = new ObservableCollection<City>();
        public ObservableCollection<City> Cities => _templates._cities;

        private ObservableCollection<Country> _countries = new ObservableCollection<Country>();
        public ObservableCollection<Country> Countries => _templates._countries;

        private ObservableCollection<Airport> _airports = new ObservableCollection<Airport>();
        public ObservableCollection<Airport> Airports => _templates._airports;

        private ObservableCollection<FlightPoint> _travelPoints = new ObservableCollection<FlightPoint>();
        public ObservableCollection<FlightPoint> TravelPoints => _templates._travelPoints;
        private ObservableCollection<ResultView> _resultView = new ObservableCollection<ResultView>();
        public ObservableCollection<ResultView> ResultViews => _templates._resultView;

        public Database(string server, string user, string password, string name, uint port=3306)
        {
            Init(server, user, password, name, port);
            _templates = this;
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
                ConvertZeroDateTime = true,
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
                        if (_templates._templateTables.Contains(tt))
                        {
                            continue;
                        }
                        _templates._templateTables.Add(tt);
                    }
                }
            }
            catch (MySqlException e)
            {
                
                throw new Exception("Template Tables wrong access: "+e);
            }
            _connection.Close();
            return _templates._templateTables;
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
                _templates._templateTables.Add(newRow);
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
                        if (_templates._airlines.Contains(tt))
                        {
                            continue;
                        }
                        _templates._airlines.Add(tt);
                    }
                }
            }
            catch (MySqlException e)
            {

                throw new Exception("Template Tables wrong access: " + e);
            }
            _connection.Close();
            return _templates.Airlines;
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
                        if (_templates._countries.Contains(tt))
                        {
                            continue;
                        }
                        _templates._countries.Add(tt);
                    }
                }
            }
            catch (MySqlException e)
            {

                throw new Exception("Template Tables wrong access: " + e);
            }
            _connection.Close();
            return _templates.Countries;
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
                        if (_templates._cities.Contains(tt))
                        {
                            continue;
                        }
                        _templates._cities.Add(tt);
                    }
                }
            }
            catch (MySqlException e)
            {

                throw new Exception("Template Tables wrong access: " + e);
            }
            _connection.Close();
            return _templates.Cities;
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
                        if (_templates._airports.Contains(tt))
                        {
                            continue;
                        }
                        _templates._airports.Add(tt);
                    }
                }
            }
            catch (MySqlException e)
            {

                throw new Exception("Template Tables wrong access: " + e);
            }
            _connection.Close();
            return _templates.Airports;
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
                        if (_templates._travelPoints.Contains(tt))
                        {
                            continue;
                        }
                        _templates._travelPoints.Add(tt);
                    }
                }
            }
            catch (MySqlException e)
            {

                throw new Exception("Template Tables wrong access: " + e);
            }
            _connection.Close();
            return _templates.TravelPoints;
        }

        public int SetResultView(DateTime start, DateTime end)
        {
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText =
                    "create or replace view result_table as ( select  search.dep_date as DepartureDate, search.det_time as DepartureTime, search.departure as Departure, search.arrival as Arrival, search.roundtrip as RT, rt.dep_date as ReturnDate, rt.dep_time as ReturnTime, search.validate_carrier as ValidateCarrier, search.validateFlight_number as VC_Number, search.operate_carrier as OperateCarrier, search.operateFlight_number as OC_Number, search.travelDuration as Duration, search.price as Price from search_result as search, roundtrip as rt where search.roundtrip_id = rt.Id and(search.dep_date between @start and @end) ); ";
                string str = String.Format("{0:yyyy-MM-dd}", start);
                command.Parameters.AddWithValue("@start", String.Format("{0:yyyy-MM-dd}", start));
                command.Parameters.AddWithValue("@end",String.Format("{0:yyyy-MM-dd}", end));
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception)
            {
                _connection.Close();
                return 404;
            }
            return 200;
        }

        public int DropResultView()
        {
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = @"DROP VIEW result_table";
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception)
            {
                _connection.Close();
                return 404;
            }
            return 200;
        }
        public IEnumerable<ResultView> GetResultView()
        {
            _resultView = new ObservableCollection<ResultView>();
            ResultViews.Clear();
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM result_table;";
                System.Text.EncodingProvider ppp = System.Text.CodePagesEncodingProvider.Instance;
                Encoding.RegisterProvider(ppp);
               
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ResultView tt = new ResultView {DepartureDate = reader.GetDateTime("DepartureDate").Date, DepartureTime = reader.GetDateTime("DepartureTime"), DeparturePoint = reader.GetString("Departure"), ArrivalPoint = reader.GetString("Arrival"),Roundtrip = reader.GetByte("RT"),RoundtripDate = reader.GetDateTime("ReturnDate"), RoundtripTime = reader.GetDateTime("ReturnTime"), ValidateCarrierName = reader.GetString("ValidateCarrier"), ValidateCarrierNumber = reader.GetInt16("VC_Number"),OperateCarrierName = reader.GetString("OperateCarrier"),OperateCarrierNumber = reader.GetInt16("OC_Number"), Duration = reader.GetInt16("Duration"),Price = reader.GetDecimal("Price")};
                        if (_templates._resultView.Contains(tt))
                        {
                            continue;
                        }
                        _templates._resultView.Add(tt);
                    }
                }
            }
            catch (MySqlException e)
            {

                throw new Exception("Template Tables wrong access: " + e);
            }
            _connection.Close();
            return _templates.ResultViews;
        }
    }
}
