using System;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace WebsiteCrawler.Database
{
    /// <summary>
    /// The class that manage in work with Database
    /// </summary>
    public class Database
    {
        private static Database _templates;
        private MySqlConnectionStringBuilder _builder;
        private MySqlConnection _connection;

        private int _serviceClass;

        /// <summary>
        /// Constructor that initialize object variables
        /// </summary>
        /// <param name="server">server name or IP of remote server</param>
        /// <param name="user">Name of user that could manage with Database</param>
        /// <param name="password">Password to Database</param>
        /// <param name="name">Name of the database</param>
        /// <param name="port">tcp/ip port. As default: 3306</param>
        public Database(string server, string user, string password, string name, uint port=3306)
        {
            Init(server, user, password, name, port);
            _templates = this; //initialize the static variable to manage methods of database class
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

        /// <summary>
        /// return Id of row in database with given name of service
        /// </summary>
        /// <param name="service">name of service class</param>
        /// <returns>id number of row with service. 0, if not entry in table</returns>
        /// <exception cref="Exception">MySqlException</exception>
        public int GetServiceId(Service service)
        {
            _serviceClass=0;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT Id FROM service_class WHERE serviceClass_name=@name;";
                command.Parameters.AddWithValue("@name", service.ServiceClassName);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _serviceClass = reader.GetInt32("Id");
                    }
                }
                _connection.Close();
            }
            catch (MySqlException e)
            {
                _connection.Close();
                Debug.Assert(true,e.Message);
            }
            finally
            {
                _connection.Close();
            }
            return _serviceClass;
        }

        /// <summary>
        /// Insert in service_class table values of service class
        /// </summary>
        /// <param name="service">the name of service class</param>
        /// <returns>true - if operation done successfully,
        /// false - if we have exception</returns>
        public bool InsertServiceClassToDatabase(Service service)
        {
            try
            {
                _connection.Open();
                MySqlCommand insert = _connection.CreateCommand();
                insert.CommandText =
                    "INSERT INTO service_class(serviceClass_name) VALUES (@name)";
                insert.Parameters.AddWithValue("@name", service.ServiceClassName);
                insert.ExecuteNonQuery();
                _connection.Close();
                return true;
            }
            catch (MySqlException e)
            {
                _connection.Close();
                Debug.Assert(true,e.Message);
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }

        /// <summary>
        /// Insert stop overs to database in table stops
        /// </summary>
        /// <param name="stops">stop overs</param>
        /// <returns>true - if operation done successfully,
        /// false - if we have exception</returns>
        public bool InsertStopsToDatabase(Stops stops)
        {
            try
            {
                _connection.Open();
                MySqlCommand insert = _connection.CreateCommand();
                insert.CommandText =
                    "INSERT INTO service_class(search_id,arrival,arr_date,arr_time,operate_carrier,operateFlight_number,departure,dep_date,dep_time) VALUES (@searchId,@arrival,@arrDate,@arrTime,@operateCarrier,@operateFlightNumber,@departure,@depDate,@depTime);";
                insert.Parameters.AddWithValue("@searchId", stops.SearchId);
                insert.Parameters.AddWithValue("@arrival", stops.Arrival);
                insert.Parameters.AddWithValue("@arrDate", stops.ArrDate);
                insert.Parameters.AddWithValue("@arrTime", stops.ArrTime);
                insert.Parameters.AddWithValue("@operateCarrier", stops.OperateCarrier);
                insert.Parameters.AddWithValue("@operateFlightNumber", stops.OperateFlightNumber);
                insert.Parameters.AddWithValue("@departure", stops.Departure);
                insert.Parameters.AddWithValue("@depDate", stops.DepDate);
                insert.Parameters.AddWithValue("@depTime", stops.DepTime);
                insert.ExecuteNonQuery();
                _connection.Close();
                return true;
            }
            catch (MySqlException exception)
            {
                _connection.Close();
                Debug.Assert(true, exception.Message);
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }
        /// <summary>
        /// Insert roundtrip to database in table roundtrip
        /// </summary>
        /// <param name="roundtrip">roundtrips</param>
        /// <returns>true - if operation done successfully,
        /// false - if we have exception</returns>
        public int InsertRoundtripsToDatabase(Roundtrip roundtrip)
        {
            try
            {
                _connection.Open();
                MySqlCommand insert = _connection.CreateCommand();
                insert.CommandText =
                    "INSERT INTO roundtrip(departure,arrival,dep_date,dep_time,arr_date,arr_time,serviceClass,validate_carrier,validateFlight_number,operate_carrier,operateFlight_number,travelDuration) VALUES (@departure,@arrival,@depDate,@depTime,@arrDate,@arrTime,@serviceClass,@validateCarrier,@validateFlightNumber,@operateCarrier,@operateFlightNumber,@travelDuration);";
                insert.Parameters.AddWithValue("@departure", roundtrip.Departure);
                insert.Parameters.AddWithValue("@arrival", roundtrip.Arrival);
                insert.Parameters.AddWithValue("@depDate", roundtrip.DepDate);
                insert.Parameters.AddWithValue("@depTime", roundtrip.DepTime);
                insert.Parameters.AddWithValue("@arrDate", roundtrip.ArrDate);
                insert.Parameters.AddWithValue("@arrTime", roundtrip.ArrTime);
                insert.Parameters.AddWithValue("@serviceClass", roundtrip.ServiceClass);
                insert.Parameters.AddWithValue("@validateCarrier", roundtrip.ValidateCarrier);
                insert.Parameters.AddWithValue("@validateFlightNumber", roundtrip.ValidateCarrierNumber);
                insert.Parameters.AddWithValue("@operateCarrier", roundtrip.OperateCarrier);
                insert.Parameters.AddWithValue("@operateFlightNumber", roundtrip.OperateCarrierNumber);
                insert.Parameters.AddWithValue("@travelDuration", roundtrip.TravelDuration);
                insert.ExecuteNonQuery();
                _connection.Close();
                return GetRoundtripsId();
            }
            catch (MySqlException exception)
            {
                _connection.Close();
                Debug.Assert(true,exception.Message);
                return 0;
            }
            finally
            {
                _connection.Close();
            }
        }
        /// <summary>
        /// return the Id of entry of roundtrip that was added last
        /// </summary>
        /// <returns>returns Id of last entry in roundtrip table in database</returns>
        /// <exception cref="Exception">MySqlException</exception>
        private int GetRoundtripsId()
        {
            int round = 0;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT Id FROM roundtrip ORDER BY Id DESC LIMIT 1;";
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        round = reader.GetInt32("Id");
                    }
                }
                _connection.Close();
            }
            catch (MySqlException e)
            {
                round=0;
                _connection.Close();
                Debug.Assert(true,e.Message);
            }
            finally
            {
                _connection.Close();
            }
            return round;
        }
        /// <summary>
        /// Insert search result to database in table search_result
        /// </summary>
        /// <param name="search">search results</param>
        /// <returns>Id of entry, 0 if unsuccessful</returns>
        public int InsertSearchResultsToDatabase(SearchResult search)
        {
            try
            {
                _connection.Open();
                MySqlCommand insert = _connection.CreateCommand();
                insert.CommandText =
                    "INSERT INTO search_result(search_time, url, type, departure, arrival, dep_date, dep_time, arr_date, arr_time, roundtrip, roundtrip_id,  serviceClass, validate_carrier, validateFlight_number, operate_carrier, operateFlight_number, travelDuration, tariff, taxes, fee, charges, price) VALUES (@search_time, @url, @type, @departure, @arrival, @depDate, @depTime, @arrDate, @arrTime, @roundtrip, @roundtrip_id, @serviceClass, @validateCarrier, @validateFlightNumber, @operateCarrier, @operateFlightNumber, @travelDuration, @tariff, @taxes, @fee, @charges, @price);";
                insert.Parameters.AddWithValue("@search_time", search.SearchTime);
                insert.Parameters.AddWithValue("@url", search.Url);
                insert.Parameters.AddWithValue("@type", search.Type1);
                insert.Parameters.AddWithValue("@departure", search.Departure);
                insert.Parameters.AddWithValue("@arrival", search.Arrival);
                insert.Parameters.AddWithValue("@depDate", search.DepDate);
                insert.Parameters.AddWithValue("@depTime", search.DepTime);
                insert.Parameters.AddWithValue("@arrDate", search.ArrDate);
                insert.Parameters.AddWithValue("@arrTime", search.ArrTime);
                insert.Parameters.AddWithValue("@roundtrip", search.Rtrip);
                insert.Parameters.AddWithValue("@roundtrip_id", search.RoundtripId);
                insert.Parameters.AddWithValue("@serviceClass", search.ServiceClass);
                insert.Parameters.AddWithValue("@validateCarrier", search.ValidateCarrier);
                insert.Parameters.AddWithValue("@validateFlightNumber", search.ValidateCarrierNumber);
                insert.Parameters.AddWithValue("@operateCarrier", search.OperateCarrier);
                insert.Parameters.AddWithValue("@operateFlightNumber", search.OperateCarrierNumber);
                insert.Parameters.AddWithValue("@travelDuration", search.TravelDuration);
                insert.Parameters.AddWithValue("@tariff", search.Tariff);
                insert.Parameters.AddWithValue("@taxes", search.Taxes);
                insert.Parameters.AddWithValue("@fee", search.Fee);
                insert.Parameters.AddWithValue("@charges", search.Charges);
                insert.Parameters.AddWithValue("@price", search.Price);
                insert.ExecuteNonQuery();
                _connection.Close();
                return GetSearchResultId();
            }
            catch (MySqlException exception)
            {
                _connection.Close();
                Debug.Assert(true, exception.Message);
                return 0;
            }
            finally
            {
                _connection.Close();
            }
        }
        /// <summary>
        /// return result Id as last entry in search_result table
        /// </summary>
        /// <returns>Id entry</returns>
        /// <exception cref="Exception">MySqlException</exception>
        private int GetSearchResultId()
        {
            int round = 0;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT id FROM search_result ORDER BY Id DESC LIMIT 1;";
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        round = reader.GetInt32("Id");
                    }
                }
                _connection.Close();
            }
            catch (MySqlException e)
            {
                _connection.Close();
                Debug.Assert(true, e.Message);
            }
            finally
            {
                _connection.Close();
            }
            return round;
        }
        /// <summary>
        /// Check if search result with given parameters exist in search_result table in database
        /// </summary>
        /// <param name="search">search result</param>
        /// <returns>Id entry if exist in table, 0 - if there are now entry</returns>
        /// <exception cref="Exception">MySqlException</exception>
        public int SearchResultsIsExistsInDatabase(SearchResult search)
        {
            int id = 0;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText =
                    "SELECT id FROM search_result WHERE url=@url AND type=@type AND departure=@departure AND arrival=@arrival AND roundtrip=@roundtrip AND roundtrip_id=@roundtrip_id AND serviceClass=@serviceClass AND validate_carrier=@validateCarrier AND validateFlight_number=@validateFlightNumber AND operate_carrier=@operateCarrier AND operateFlight_number=@operateFlightNumber AND travelDuration=@travelDuration AND tariff=@tariff AND taxes=@taxes AND fee=@fee AND charges=@charges AND price=@price AND dep_date=@depDate AND dep_time=@depTime AND arr_date=@arrDate AND arr_time=@arrTime;";
                command.Parameters.AddWithValue("@url", search.Url);
                command.Parameters.AddWithValue("@type", search.Type1);
                command.Parameters.AddWithValue("@departure", search.Departure);
                command.Parameters.AddWithValue("@arrival", search.Arrival);
                command.Parameters.AddWithValue("@depDate", $"{search.DepDate:yyyy-MM-dd}");
                command.Parameters.AddWithValue("@depTime", $"{search.DepTime:HH:mm:ss}");
                command.Parameters.AddWithValue("@arrDate", $"{search.ArrDate:yyyy-MM-dd}");
                command.Parameters.AddWithValue("@arrTime", $"{search.ArrTime:HH:mm:ss}");
                command.Parameters.AddWithValue("@roundtrip", search.Rtrip);
                command.Parameters.AddWithValue("@roundtrip_id", search.RoundtripId);
                command.Parameters.AddWithValue("@serviceClass", search.ServiceClass);
                command.Parameters.AddWithValue("@validateCarrier", search.ValidateCarrier);
                command.Parameters.AddWithValue("@validateFlightNumber", search.ValidateCarrierNumber);
                command.Parameters.AddWithValue("@operateCarrier", search.OperateCarrier);
                command.Parameters.AddWithValue("@operateFlightNumber", search.OperateCarrierNumber);
                command.Parameters.AddWithValue("@travelDuration", search.TravelDuration);
                command.Parameters.AddWithValue("@tariff", search.Tariff);
                command.Parameters.AddWithValue("@taxes", search.Taxes);
                command.Parameters.AddWithValue("@fee", search.Fee);
                command.Parameters.AddWithValue("@charges", search.Charges);
                command.Parameters.AddWithValue("@price", search.Price);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32("Id");
                    }
                }
                _connection.Close();
                return id;
            }
            catch (MySqlException exception)
            {
                _connection.Close();
                Debug.Assert(true, exception.Message);
            }
            finally
            {
                _connection.Close();
            }
            return id;
        }
        /// <summary>
        /// Check if roundtrip with given parameters exist in roundtrip table in database
        /// </summary>
        /// <param name="roundtrip">roundtrip</param>
        /// <returns>Id entry if exist, and 0 if no entry with roundtrip with given parameters</returns>
        /// <exception cref="Exception">MySqlException</exception>
        public int RoundtripIsExistsInDatabase(Roundtrip roundtrip)
        {
            int id = 0;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText =
                    "SELECT Id FROM roundtrip WHERE departure=@departure AND arrival=@arrival AND  serviceClass=@serviceClass AND validate_carrier=@validateCarrier AND validateFlight_number=@validateFlightNumber AND operate_carrier=@operateCarrier AND operateFlight_number=@operateFlightNumber AND travelDuration=@travelDuration AND dep_date=@dep_date AND dep_time=@dep_time AND arr_date=@arr_date AND arr_time=@arr_time;";
                command.Parameters.AddWithValue("@departure", roundtrip.Departure);
                command.Parameters.AddWithValue("@arrival", roundtrip.Arrival);
                command.Parameters.AddWithValue("@serviceClass", roundtrip.ServiceClass);
                command.Parameters.AddWithValue("@validateCarrier", roundtrip.ValidateCarrier);
                command.Parameters.AddWithValue("@validateFlightNumber", roundtrip.ValidateCarrierNumber);
                command.Parameters.AddWithValue("@operateCarrier", roundtrip.OperateCarrier);
                command.Parameters.AddWithValue("@operateFlightNumber", roundtrip.OperateCarrierNumber);
                command.Parameters.AddWithValue("@travelDuration", roundtrip.TravelDuration);
                command.Parameters.AddWithValue("@dep_date", $"{roundtrip.DepDate:yyyy-MM-dd}");
                command.Parameters.AddWithValue("@dep_time", $"{roundtrip.DepTime:HH:mm:ss}");
                command.Parameters.AddWithValue("@arr_date", $"{roundtrip.ArrDate:yyyy-MM-dd}");
                command.Parameters.AddWithValue("@arr_time", $"{roundtrip.ArrTime:HH:mm:ss}");
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32("Id");
                    }
                }
                _connection.Close();
                return id;
            }
            catch (MySqlException exception)
            {
                _connection.Close();
                Debug.Assert(true,exception.Message);
                return 0;
            }
            finally
            {
                _connection.Close();
            }
        }

        /// <summary>
        /// Get IATA code of airline by given airline name
        /// </summary>
        /// <param name="name">airline name</param>
        /// <returns>iata code</returns>
        /// <exception cref="Exception">MySqlException</exception>
        public string GetAirlineCode(string name)
        {
            string id = null;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT iata FROM airline WHERE ru=@name OR name=@name;";
                command.Parameters.AddWithValue("@name", name);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = reader.GetString("iata");
                    }
                }
                _connection.Close();
                return id;
            }
            catch (MySqlException e)
            {
                _connection.Close();
                Debug.Assert(true, e.Message);
            }
            finally
            {
                _connection.Close();
            }
            return id;
        }       
    }
}
