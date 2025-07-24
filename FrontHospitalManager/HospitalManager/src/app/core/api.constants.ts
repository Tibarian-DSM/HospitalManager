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
    }
}