using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.EntityModel;
using System.Web;

namespace TestWcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        String BingMapsKey = "";
        String RequestAddress = "";
        String DestinationAddress = "";
        String JSonValue = "";

        public string GetData(String value)
        {
            if (value == "test1")
            {
                return "TEST1";
            }
            else
            {
                return "SomeRandomValue";
            }
        }

        public int GetDataPostMethod(String val1, String val2)
        {
            if (val1 == "test1" && val2 == "test2")
            {
                return 222;
            }
            else
            {
                return 111;
            }
            //if (val.Name == "test1" && val.Age == 0)
            //{
            //    return 222;
            //}
            //else
            //{
            //    return 111;
            //}
        }

        public int InsertPatientDetails(String FName, String LName, String UserName, String Password, String House_Address, String City, String State, String Zip)
        {
            try
            {
                //Inserting details into db
                if (FName != null && UserName != null && Password != null && House_Address != null && City != null && State != null && Zip != null)
                {

                    using (var db = new Cmpe285ProjEntities())
                    {
                        int ForId = 0;
                        var Patient_DetailsList = db.Patient_Details.ToArray();//.ToList < Patient_Details>;

                        for (int j = 0; j < Patient_DetailsList.Count(); j++)
                        {
                            ForId = Patient_DetailsList[j].Id;
                        }

                        Patient_Details patient = new Patient_Details();
                        if (ForId != null)
                        {
                            patient.Id = (ForId) + 1;
                        }
                        else
                        {
                            patient.Id = 1;
                        }
                        patient.City = City;
                        patient.F_Name = FName;
                        patient.Home_Address = House_Address;
                        patient.L_Name = LName;
                        patient.State = State;
                        patient.UserName = UserName;
                        patient.Password = Password;
                        patient.ZipCode = Zip;
                        db.Patient_Details.Add(patient);
                        db.SaveChanges();
                    }
                }
                return 1;
            }
            //var db = new HealthServiceProvider_Day_Table();
            catch (Exception e)
            {
                return 0;
            }
        }

        public int InsertHealthServiceProviderDetails(String FName, String LName, String UserName, String Password, String HostpitalName, String Specialization, String Designation, String WorkPlace_Address, String City, String State, String Zip)
        {
            try
            {
                //Inserting details into db
                if (FName != null && UserName != null && Password != null && HostpitalName != null && Specialization != null && Designation != null && WorkPlace_Address != null && City != null && State != null && Zip != null)
                {

                    using (var db = new Cmpe285ProjEntities())
                    {
                        int ForId = 0;
                        var HealthServiceProvider_DetailsList = db.HealthServiceProvider_Details.ToArray();//.ToList < Patient_Details>;

                        for (int j = 0; j < HealthServiceProvider_DetailsList.Count(); j++)
                        {
                            ForId = HealthServiceProvider_DetailsList[j].Id;
                        }

                        HealthServiceProvider_Details HealthServiceProvider = new HealthServiceProvider_Details();
                        if (ForId != null)
                        {
                            HealthServiceProvider.Id = (ForId) + 1;
                        }
                        else
                        {
                            HealthServiceProvider.Id = 1;
                        }
                        HealthServiceProvider.City = City;
                        HealthServiceProvider.F_Name = FName;
                        HealthServiceProvider.Workplace_Location_Address = WorkPlace_Address;
                        HealthServiceProvider.L_Name = LName;
                        HealthServiceProvider.State = State;
                        HealthServiceProvider.UserName = UserName;
                        HealthServiceProvider.Password = Password;
                        HealthServiceProvider.ZipCode = Zip;
                        HealthServiceProvider.Specialization = Specialization;
                        HealthServiceProvider.HospitalName = HostpitalName;
                        HealthServiceProvider.Designation = Designation;
                        db.HealthServiceProvider_Details.Add(HealthServiceProvider);
                        db.SaveChanges();
                    }
                }
                return 1;
            }
            //var db = new HealthServiceProvider_Day_Table();
            catch (Exception e)
            {
                return 0;
            }
        }

        public void RequestHealthService(String PatientName, String Required_Specilization)
        {
            //Get Doc details form db.
            try
            {
                using (var db = new Cmpe285ProjEntities())
                {
                    //var HealthServiceProvider_DetailsList = db.HealthServiceProvider_Details.ToArray();//.ToList < Patient_Details>;
                    var tempHealthServiceProvider_Day_Details = db.HealthServiceProvider_Day_Details.Where(p => p.Specialization == Required_Specilization).ToArray();

                    ResponseToSpecializationRequest Req;
                    List<ResponseToSpecializationRequest> listResponseToSpecializationRequest = new List<ResponseToSpecializationRequest>();
                    for (int j = 0; j < tempHealthServiceProvider_Day_Details.Count(); j++)
                    {
                        Req = new ResponseToSpecializationRequest();
                        Req.DoctorName = tempHealthServiceProvider_Day_Details[j].HealthServiceProvider_Name.ToString();
                        Req.Address = tempHealthServiceProvider_Day_Details[j].HealthServiceProvider_Address;
                        listResponseToSpecializationRequest.Add(Req);
                        //ForId = HealthServiceProvider_DetailsList[j].Id;
                    }

                    JsonSerializer jsonSerializer = new JsonSerializer();
                    //jsonSerializer.Serialize()
                    String returnValue = "callback(";
                    returnValue = returnValue + JsonConvert.SerializeObject(listResponseToSpecializationRequest);
                    returnValue = returnValue + ");";

                    //return JsonConvert.SerializeObject(listResponseToSpecializationRequest);
                    //return returnValue;

                    HttpContext.Current.Response.ContentType = "application/json; charset=utf-8";
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(listResponseToSpecializationRequest));

                    
                }
            }
            catch (Exception e)
            {
                //return null;
            }

        }

        public void CheckAndRequestDoctorDetails(String UserName, String Password)
        {
            try
            {
                using (Cmpe285ProjEntities db = new Cmpe285ProjEntities())
                {
                    db.Database.Connection.Open();
                    //using (DatabaseEntities context = new DatabaseEntities())
                    //{
                    //    context.Connection.Open();
                    //    // the rest
                    //}
                    //var HealthServiceProvider_DetailsList = db.HealthServiceProvider_Details.ToArray();//.ToList < Patient_Details>;
                    var HealthServiceProvider_DetailsList = db.HealthServiceProvider_Details.Where(p => p.UserName == UserName && p.Password == Password).ToArray();
                    if (HealthServiceProvider_DetailsList != null)
                    {
                        //JsonSerializer jsonSerializer = new JsonSerializer();
                        //jsonSerializer.Serialize()
                        String returnValue = "callback(";
                        returnValue = returnValue + JsonConvert.SerializeObject(HealthServiceProvider_DetailsList);
                        returnValue = returnValue + ");";
                        //String temp_Addrs = HealthServiceProvider_DetailsList[0].HospitalName + "\n" + HealthServiceProvider_DetailsList[0].Workplace_Location_Address + "\n" + HealthServiceProvider_DetailsList[0].City + "\n" + HealthServiceProvider_DetailsList[0].State + "\n" + HealthServiceProvider_DetailsList[0].ZipCode;
                        //InsertintoDayTable(HealthServiceProvider_DetailsList[0].Id, HealthServiceProvider_DetailsList[0].F_Name, temp_Addrs, HealthServiceProvider_DetailsList[0].Specialization);

                        //return JsonConvert.SerializeObject(HealthServiceProvider_DetailsList);

                        HttpContext.Current.Response.ContentType = "application/json; charset=utf-8";
                        HttpContext.Current.Response.Write(JsonConvert.SerializeObject(HealthServiceProvider_DetailsList));
                    }
                    else
                    {
                        //return null;
                    }

                }
            }
            catch (Exception ex)
            {
                //return null;
            }
        }

        public void CheckAndRequestPatientDetails(String UserName, String Password)
        {
            try
            {
                using (var db = new Cmpe285ProjEntities())
                {
                    //var HealthServiceProvider_DetailsList = db.HealthServiceProvider_Details.ToArray();//.ToList < Patient_Details>;
                    var Patient_DetailsList = db.Patient_Details.Where(p => p.UserName == UserName && p.Password == Password).ToArray();
                    if (Patient_DetailsList != null)
                    {
                        JsonSerializer jsonSerializer = new JsonSerializer();
                        //jsonSerializer.Serialize()
                        String returnValue = "callback(";
                        returnValue = returnValue + JsonConvert.SerializeObject(Patient_DetailsList);
                        returnValue = returnValue + ");";

                        //return returnValue;

                        HttpContext.Current.Response.ContentType = "application/json; charset=utf-8";
                        HttpContext.Current.Response.Write(JsonConvert.SerializeObject(Patient_DetailsList));                        
                    }
                    else
                    {
                        //return null;
                    }
                }
            }
            catch (Exception ex)
            {
                //return null;
            }
        }

        public int CheckInDoctor_Details(String DoctorID, String DoctorName, String Doctor_Hospital_Address, String DoctorSpecialization)
        {
            try
            {
                int DocId = int.Parse(DoctorID);
                if (DocId != 0 && DoctorName != null && Doctor_Hospital_Address != null && DoctorSpecialization != null)
                {

                    using (var db = new Cmpe285ProjEntities())
                    {
                        var tempHealthServiceProvider_Day_Details1 = db.HealthServiceProvider_Day_Details.Where(p => p.HealthServiceProvider_ID == DocId).ToArray();

                        if (tempHealthServiceProvider_Day_Details1.Count() == 0)
                        {
                            //ResponseToSpecializationRequest Req;
                            //List<ResponseToSpecializationRequest> listResponseToSpecializationRequest = new List<ResponseToSpecializationRequest>();
                            //for (int j = 0; j < tempHealthServiceProvider_Day_Details.Count(); j++)
                            //{
                            //    Req = new ResponseToSpecializationRequest();
                            //    Req.DoctorName = tempHealthServiceProvider_Day_Details[j].HealthServiceProvider_Name.ToString();
                            //    Req.Address = tempHealthServiceProvider_Day_Details[j].HealthServiceProvider_Address;
                            //    listResponseToSpecializationRequest.Add(Req);
                            //    //ForId = HealthServiceProvider_DetailsList[j].Id;
                            //}




                            int ForId = 0;
                            var HealthServiceProvider_Day_DetailsVariable = db.HealthServiceProvider_Day_Details.ToArray();

                            for (int j = 0; j < HealthServiceProvider_Day_DetailsVariable.Count(); j++)
                            {
                                ForId = HealthServiceProvider_Day_DetailsVariable[j].Id;
                            }
                            HealthServiceProvider_Day_Details tempHealthServiceProvider_Day_Details = new HealthServiceProvider_Day_Details();
                            if (ForId != 0)
                            {
                                tempHealthServiceProvider_Day_Details.Id = (ForId) + 1;
                            }
                            else
                            {
                                tempHealthServiceProvider_Day_Details.Id = 1;
                            }
                            tempHealthServiceProvider_Day_Details.HealthServiceProvider_ID = DocId;
                            tempHealthServiceProvider_Day_Details.HealthServiceProvider_Name = DoctorName;
                            tempHealthServiceProvider_Day_Details.HealthServiceProvider_Address = Doctor_Hospital_Address;
                            tempHealthServiceProvider_Day_Details.Specialization = DoctorSpecialization;
                            db.HealthServiceProvider_Day_Details.Add(tempHealthServiceProvider_Day_Details);
                            db.SaveChanges();
                            return 1;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public String RequestHealthServiceWITHOUTGOOGLEMAPS(String PatientName, String Required_Specilization)
        {
            try
            {
                using (var db = new Cmpe285ProjEntities())
                {
                    //var HealthServiceProvider_DetailsList = db.HealthServiceProvider_Details.ToArray();//.ToList < Patient_Details>;
                    var tempHealthServiceProvider_Day_Details = db.HealthServiceProvider_Day_Details.Where(p => p.Specialization == Required_Specilization).ToArray();

                    ResponseToSpecializationRequest Req;
                    List<ResponseToSpecializationRequest> listResponseToSpecializationRequest = new List<ResponseToSpecializationRequest>();
                    for (int j = 0; j < tempHealthServiceProvider_Day_Details.Count(); j++)
                    {
                        Req = new ResponseToSpecializationRequest();
                        Req.DoctorName = tempHealthServiceProvider_Day_Details[j].HealthServiceProvider_Name.ToString();
                        Req.Address = tempHealthServiceProvider_Day_Details[j].HealthServiceProvider_Address;
                        listResponseToSpecializationRequest.Add(Req);
                        //ForId = HealthServiceProvider_DetailsList[j].Id;
                    }

                    JsonSerializer jsonSerializer = new JsonSerializer();

                    //hit bing maps api and get traffic data, by giving individual to bing maps and getting the traffic data.
                    //once you get the traffic data, calculate to which place will you reach faster and add those values to your json.
                    //return json string to UI.
                    String Url = "http://dev.virtualearth.net/REST/V1/Routes/Driving?wp.0=" + RequestAddress + "&wp.1=" + DestinationAddress + ",MN&optmz=distance&routeAttributes=routePath&key=" + BingMapsKey;

                    string key = "YOUR_BING_MAPS_KEY or SESSION_KEY";
                    string query = "1 Microsoft Way, Redmond, WA";

                    Uri geocodeRequest = new Uri(string.Format("http://dev.virtualearth.net/REST/v1/Locations?q={0}&key={1}", query, key));

                    //GetResponse(geocodeRequest, (x) =>
                    //{
                    //    Console.WriteLine(x.ResourceSets[0].Resources.Length + " result(s) found.");
                    //    Console.ReadLine();
                    //});

                    return JSonValue;
                    //return JsonConvert.SerializeObject(listResponseToSpecializationRequest);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //public List<Class1> GetData1(String id)
        //{
        //    List<Class1> returnVal;
        //    if (id == "test1")
        //    {
        //        returnVal = new List<Class1>();
        //        returnVal.Add(new Class1
        //        {
        //            Age = 2,
        //            Name = "test1"
        //        });
        //        returnVal.Add(new Class1
        //        {
        //            Age = 4,
        //            Name = "test1"
        //        });
        //    }
        //    else
        //    {
        //        returnVal = new List<Class1>();
        //        returnVal.Add(new Class1
        //        {
        //            Age = 2,
        //            Name = "someRandom"
        //        });
        //        returnVal.Add(new Class1
        //        {
        //            Age = 4,
        //            Name = "someRandom"
        //        });
        //    }

        //    return returnVal;
        //}

    }
}
