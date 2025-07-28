export const API_CONST =
{
    Auth:{
        Register: "Auth/Register",
        Login : "Auth/Login"
    },

    Admin:
    {
           GetAll: "Admin/GetAll"
    },

    Patient:
    {
        getPatientFile : "Patient/GetPatientFile",
        addNewPatientFile :"Patient/AddNewPatientFile",
        updatePatientFile:"Patient/UpdatePatient"
    },

    User:
    {
        getUserById: "User/GetUserById",
        getUsersByRole:"User/GetUsersByRole"
    },

    Medic:
    {
        addNewMedic:"Medic/AddNewMedic",
       getMedicDetails:"Medic/getMedicDetails",
       getMedicByService:"Medic/getMedicsByService"
    },

    Service:
    {
        addNewService:"Service/AddNewService",
        getAllServices:"Service/GetAllServices",
        deleteService:"Service/RemoveService"
    },

    Appointement:
    {
        createAppointement:"Appointement/createAppointement",
        getAppointementById:"Appointement/getAppointementById",
        getAppointementsByMedicId:"Appointement/getAppointementsByMedicId",
         getAppointementsByPatientId:"Appointement/getAppointementsByPatientId"

    }
}