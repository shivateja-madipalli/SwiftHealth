using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Services;

namespace TestWcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(UriTemplate = "Data/{id}")]
        string GetData(String id);

        //[OperationContract]
        //[WebGet(UriTemplate = "Data?Value={id}",ResponseFormat = WebMessageFormat.Json)]
        //List<Class1> GetData1(String id);

        [OperationContract]
        [WebInvoke(UriTemplate = "Patient/{Value1}/{Value2}", Method = "POST")]
        int GetDataPostMethod(String Value1, String Value2);

        //[OperationContract]
        //[WebInvoke(UriTemplate = "Insert_PatientDetails/{FName}/{LName}/{UserName}/{Password}/{House_Address}/{City}/{State}/{Zip}", Method = "POST")]
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                                   BodyStyle = WebMessageBodyStyle.Bare,
                                   UriTemplate = "Insert_PatientDetails/{FName}/{LName}/{UserName}/{Password}/{House_Address}/{City}/{State}/{Zip}")]
        int InsertPatientDetails(String FName, String LName, String UserName, String Password, String House_Address, String City, String State, String Zip);

        
        //[OperationContract]
        //[WebInvoke(UriTemplate = "Insert_HealthServiceProvider_Details/{FName}/{LName}/{UserName}/{Password}/{HostpitalName}/{Specialization}/{Designation}/{WorkPlace_Address}/{City}/{State}/{Zip}", Method = "POST")]
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                                   BodyStyle = WebMessageBodyStyle.Bare,
                                   UriTemplate = "Insert_HealthServiceProvider_Details/{FName}/{LName}/{UserName}/{Password}/{HostpitalName}/{Specialization}/{Designation}/{WorkPlace_Address}/{City}/{State}/{Zip}")]
        int InsertHealthServiceProviderDetails(String FName, String LName, String UserName, String Password, String HostpitalName, String Specialization, String Designation, String WorkPlace_Address, String City, String State, String Zip);

        ////Old//////////////[OperationContract]
        //////////////////[WebInvoke(UriTemplate = "DoctorLogin/{UserName}/{Password}")]
        //////////////////String CheckAndRequestPatientDetails(String UserName, String Password);

        //////////////////[OperationContract]
        //////////////////[WebGet(UriTemplate = "RequestHealthService_Details/{PatientName}/{Required_Specilization}")]
        //////////////////String RequestHealthService(String PatientName, String Required_Specilization);

        //[OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        //                           BodyStyle = WebMessageBodyStyle.Bare,
        //                           UriTemplate = "RequestHealthService_Details/{PatientName}/{Required_Specilization}")]
        //String RequestHealthService(String PatientName, String Required_Specilization);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                   BodyStyle = WebMessageBodyStyle.Bare,
                                   UriTemplate = "RequestHealthService_Details/{PatientName}/{Required_Specilization}")]
        void RequestHealthService(String PatientName, String Required_Specilization);

        ////OLD////////////[OperationContract]
        ////////////////[WebGet(UriTemplate = "CheckAndRequestDoctor_Details/{UserName}/{Password}")]
        ////////////////String CheckAndRequestDoctorDetails(String UserName, String Password);

        ////////////////[OperationContract]
        ////////////////[WebGet(UriTemplate = "CheckAndRequestPatient_Details/{UserName}/{Password}")]


        //[OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        //                           BodyStyle = WebMessageBodyStyle.Bare,
        //                           UriTemplate = "CheckAndRequestPatient_Details/{UserName}/{Password}")]
        //String CheckAndRequestPatientDetails(String UserName, String Password);


        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                   BodyStyle = WebMessageBodyStyle.Bare,
                                   UriTemplate = "CheckAndRequestPatient_Details/{UserName}/{Password}")]
        void CheckAndRequestPatientDetails(String UserName, String Password);

        //<-------->
        //[OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        //                           BodyStyle = WebMessageBodyStyle.Bare,
        //                           UriTemplate = "CheckAndRequestDoctor_Details/{UserName}/{Password}")]
        //String CheckAndRequestDoctorDetails(String UserName, String Password);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                   BodyStyle = WebMessageBodyStyle.Bare,
                                   UriTemplate = "CheckAndRequestDoctor_Details/{UserName}/{Password}")]
        void CheckAndRequestDoctorDetails(String UserName, String Password);

        //<-------->

        //////////OLD//////////////[OperationContract]
        ////////////////////////[WebInvoke(Method = "Post", ResponseFormat = WebMessageFormat.Json,
        ////////////////////////                           BodyStyle = WebMessageBodyStyle.Bare,
        ////////////////////////                           UriTemplate = "CheckInDoctor_Details/{DoctorID}/{DoctorName}/{Doctor_Hospital_Address}/{DoctorSpecialization}")]
        ////////////////////////int CheckInDoctor_Details(String DoctorID, String DoctorName, String Doctor_Hospital_Address, String DoctorSpecialization);


        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                                   BodyStyle = WebMessageBodyStyle.Bare,
                                   UriTemplate = "CheckInDoctor_Details/{DoctorID}/{DoctorName}/{Doctor_Hospital_Address}/{DoctorSpecialization}")]
        int CheckInDoctor_Details(String DoctorID, String DoctorName, String Doctor_Hospital_Address, String DoctorSpecialization);

    }
}
//(int DoctorID, String DoctorName, String Doctor_Hospital_Address, String DoctorSpecialization)