using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using WebsiteCrawler.de.berlogic.devlt;
using WebsiteCrawler.Database;

namespace WebsiteCrawler.Web
{
    /// <summary>
    /// In this class we define method to get data from web service from GDS
    /// </summary>
    class DataFromGds
    {
        /// <summary>
        /// Method of receiving and store data from GDS using web service
        /// </summary>
        /// <param name="controller">object variable with predefined application configuration and parameters of investigation</param>
        /// <param name="leg">object variable where stored information about flight routes that need to investigate (Departure point and Arrival point)</param>
        public void Start(Controller controller, Route leg)
        {
            var wdslUrl = new Uri("https://devlt.berlogic.de:444/Partner/Avia?wsdl ");
            var serviceUrl = new Uri("https://devlt.berlogic.de:444/Partner/Avia");

            var agencyCode = controller.Config.AgencyNumber;
            var salesPoint = controller.Config.AgencySalespoint;
            var agentCode = controller.Config.AgencyName;
            var agentPassword = controller.Config.AgencyPassword;

            var client = new Avia {Url = serviceUrl.AbsoluteUri};

            routeSegment[] routes;
            routeSegment routeTo = new routeSegment
            {
                beginLocation = leg.Departure,
                endLocation = leg.Arrival,
                date = DateTime.Parse(controller.DepartureDate, null, System.Globalization.DateTimeStyles.RoundtripKind),
                dateSpecified = true,
                departureTimeFrom = null,
                departureTimeTo = null
            };
            
            if (controller.ArrivalDate!=null)
            {
                routeSegment routeFrom  = new routeSegment
                {
                    beginLocation = leg.Arrival,
                    endLocation = leg.Departure,
                    date = DateTime.Parse(controller.ArrivalDate, null, System.Globalization.DateTimeStyles.RoundtripKind),
                    dateSpecified = true,
                    departureTimeFrom = null,
                    departureTimeTo = null
                };
                routes = new routeSegment[2];
                routes[0] = routeTo;
                routes[1] = routeFrom;
            }
            else
            {
                routes = new routeSegment[1];
                routes[0] = routeTo;
            }
            flightSearchSettingsEntry adult = new flightSearchSettingsEntry
            {
                key = passengerCategory.ADULT,
                value = 1,
                keySpecified = true,
                valueSpecified = true
            };
            flightSearchSettingsEntry child = new flightSearchSettingsEntry
            {
                key = passengerCategory.CHILD,
                value = 0,
                keySpecified = true,
                valueSpecified = true
            };
            flightSearchSettingsEntry infant = new flightSearchSettingsEntry
            {
                key = passengerCategory.INFANT,
                value = 0,
                keySpecified = true,
                valueSpecified = true
            };
            flightSearchSettings settings = new flightSearchSettings
            {
                agencyCode = agencyCode,
                salesPoint = salesPoint,
                agentCode = agentCode,
                agentPassword = agentPassword,
                dateTolerance = 0,
                eticketsOnly = false,

                lang = "ru",
                mixedVendors = true,
                preferredCurrency = "RUB",
                serviceClass = serviceClass.ECONOM,
                skipConnected = false,
                route = routes,
                seats = new[] { adult, child, infant },
                serviceClassSpecified = true
            };

            try
            {
                client.authenticate(agentCode, agentPassword);
                var response = client.searchFlights(settings);
                Thread.Sleep(5000);
                Database.Database database=new Database.Database(controller.Config.DatabaseRemote,controller.Config.DatabaseUser,controller.Config.DatabasePassword,controller.Config.DatabaseName,(uint)controller.Config.DatabasePort);
                foreach (flight flight in response)
                {
                    Roundtrip roundtrip=new Roundtrip();
                    Service service=new Service();
                    SearchResult result=new SearchResult();
                    List<Stops> stopsList=new List<Stops>();
                    Service rtService = new Service();

                    decimal fee = 0;
                    decimal tariff = 0;
                    decimal taxes = 0;
                    fee += flight.cost.fee;
                    foreach (costElement t in flight.cost.elements)
                    {
                        fee += t.fee;
                        tariff += t.tariff;
                        taxes += t.taxes;
                    }
                    var price = fee + tariff + taxes;
                    result.Fee = fee;
                    result.Tariff = tariff;
                    result.Taxes = taxes;
                    result.Price = price;
                    result.Charges = 0;
                    result.SearchTime=DateTime.Now;
                    int durationOneLeg = 0;
                    int durationSecondLeg = 0;
                    result.Type1 = 2;
                    result.Url = salesPoint;

                    bool isOneWay = true;

                    int segments = flight.segments.Length;
                    for (int i = 0; i < segments; i++)
                    {
                        Stops stops = new Stops();
                        var isStop = flight.segments[i].connected;
                        if (isOneWay&&!isStop) //в одну сторону без пересадки
                        {
                            result.Departure = flight.segments[i].beginLocation.id;
                            result.DepDate = flight.segments[i].beginDate.Date;
                            result.DepTime = flight.segments[i].beginDate;
                            result.ArrDate = flight.segments[i].endDate.Date;
                            result.ArrTime = flight.segments[i].endDate;
                            result.Arrival = flight.segments[i].endLocation.id;
                            result.OperateCarrier = flight.segments[i].operatingVendor.id;
                            result.OperateCarrierNumber = Int32.Parse(flight.segments[i].flightNumber);
                            result.ValidateCarrier = flight.segments[i].marketingVendor.id;
                            result.ValidateCarrierNumber= Int32.Parse(flight.segments[i].flightNumber);
                            result.Rtrip = 0;
                            service.ServiceClassName = flight.segments[i].serviceClass.ToString();
                            if (database.GetServiceId(service)==0)
                            {
                                database.InsertServiceClassToDatabase(service);
                                service.Id = database.GetServiceId(service);
                            }
                            else
                            {
                                service.Id = database.GetServiceId(service);
                            }
                            durationOneLeg += flight.segments[i].travelDuration;
                            if (!flight.segments[i+1].connected)
                            {
                                isOneWay = false;
                            }
                            result.TravelDuration = durationOneLeg;
                            result.ServiceClass = service.Id;
                            continue;
                        }
                        if (isOneWay&&isStop) //в одну сторону но есть пересадка
                        {
                            stops.ArrDate = flight.segments[i].endDate.Date;
                            stops.ArrTime = flight.segments[i].endDate;
                            stops.Arrival = flight.segments[i].endLocation.id;
                            stops.DepDate = flight.segments[i].beginDate.Date;
                            stops.DepTime = flight.segments[i].beginDate;
                            stops.Departure= flight.segments[i].beginLocation.id;
                            stops.OperateCarrier = flight.segments[i].operatingVendor.id;
                            stops.OperateFlightNumber = Int32.Parse(flight.segments[i].flightNumber);
                            durationOneLeg += flight.segments[i].travelDuration;
                            stopsList.Add(stops);
                            if (!flight.segments[i + 1].connected)
                            {
                                isOneWay = false;
                                result.ArrDate = flight.segments[i].endDate.Date;
                                result.ArrTime = flight.segments[i].endDate;
                                result.Arrival = flight.segments[i].endLocation.id;
                                result.TravelDuration = durationOneLeg;
                            }
                            continue;
                        }
                        if (!isOneWay && !isStop) //обратно, но без пересадки
                        {
                            roundtrip.Departure = flight.segments[i].beginLocation.id;
                            roundtrip.DepDate = flight.segments[i].beginDate.Date;
                            roundtrip.DepTime = flight.segments[i].beginDate;
                            roundtrip.ArrDate = flight.segments[i].endDate.Date;
                            roundtrip.ArrTime = flight.segments[i].endDate;
                            roundtrip.Arrival = flight.segments[i].endLocation.id;
                            roundtrip.OperateCarrier = flight.segments[i].operatingVendor.id;
                            roundtrip.OperateCarrierNumber = Int32.Parse(flight.segments[i].flightNumber);


                            rtService.ServiceClassName = flight.segments[i].serviceClass.ToString();
                            
                            if (database.GetServiceId(rtService) == 0)
                            {
                                database.InsertServiceClassToDatabase(rtService);
                                rtService.Id = database.GetServiceId(rtService);
                            }
                            else
                            {
                                rtService.Id = database.GetServiceId(rtService);
                            }
                            roundtrip.ServiceClass = rtService.Id;
                            roundtrip.ValidateCarrier = flight.segments[i].marketingVendor.id;
                            roundtrip.ValidateCarrierNumber = Int32.Parse(flight.segments[i].flightNumber);
                            durationSecondLeg += flight.segments[i].travelDuration;
                            roundtrip.TravelDuration = durationSecondLeg;
                            continue;
                        }
                        if (!isOneWay && isStop) //обратно, с пересадками
                        {
                            stops.ArrDate = flight.segments[i].endDate.Date;
                            stops.ArrTime = flight.segments[i].endDate;
                            stops.Arrival = flight.segments[i].endLocation.id;
                            stops.DepDate = flight.segments[i].beginDate.Date;
                            stops.DepTime = flight.segments[i].beginDate;
                            stops.Departure = flight.segments[i].beginLocation.id;
                            stops.OperateCarrier = flight.segments[i].operatingVendor.id;
                            stops.OperateFlightNumber = Int32.Parse(flight.segments[i].flightNumber);
                            durationSecondLeg += flight.segments[i].travelDuration;
                            stopsList.Add(stops);
                            if (i==flight.segments.Length-1)
                            {
                                roundtrip.ArrDate = flight.segments[i].endDate.Date;
                                roundtrip.ArrTime = flight.segments[i].endDate;
                                roundtrip.Arrival = flight.segments[i].endLocation.id;
                                roundtrip.ServiceClass = rtService.Id;
                                roundtrip.TravelDuration = durationSecondLeg;
                            }
                        }
                    }
                    var rtid = database.RoundtripIsExistsInDatabase(roundtrip) == 0 ? database.InsertRoundtripsToDatabase(roundtrip) : database.RoundtripIsExistsInDatabase(roundtrip);

                    int sid = 0;

                    if (rtid!=0)
                    {
                        result.Rtrip = 1;
                        result.RoundtripId = rtid;
                        if (database.SearchResultsIsExistsInDatabase(result)==0)
                        {
                            sid = database.InsertSearchResultsToDatabase(result);
                        }
                    }
                    else
                    {
                        result.Rtrip = 0;
                        sid = database.InsertSearchResultsToDatabase(result);
                    }
                    if (stopsList.Count>0)
                    {
                        foreach (Stops stopse in stopsList)
                        {
                            stopse.SearchId = sid;
                            database.InsertStopsToDatabase(stopse);
                        }
                    }                   
                }
            }
            catch (Exception exception)
            {
                Debug.Assert(true,exception.Message);
                //ignore
            }
        }
    }
}
