namespace CleanArchitecture.ApplicationCore.Common.Models
{
    public class ApiMessageResource
    {
        //Status Code
        public const int SuccessStatusCode = 200;
        public const int UnauthorizedStatusCode = 401;
        public const int ForbiddenStatusCode = 403;
        public const int NotFoundStatusCode = 404;
        public const int DuplicateStatusCode = 409;
        public const int duplicateNameCode = 410;
        public const int FailStatusCode = 500;
        public const int InvalidStatusCode = 501;

        // Return Messages
        public const string SuccessMessage = "Success";
        public const string SavedSuccessfulMessage = "Saved successfully";
        public const string UpdatedSuccessfulMessage = "Updated successfully";
        public const string NotFoundMessage = "No record found";
        public const string FailMessage = "Something went wrong.";
        public const string DeletedMessage = "Deleted successfully";
        public const string PatientNotFound = "Patient not found";
        public const string PatientAddressNotFound = "Patient address not found";
        public const string AppointmentSuccessfulCreated = "Appointment  has been successfully created on axle health";
        public const string AppointmentSuccessfulCreatedInternal = "Appointment has been successfully created";
        public const string SavedPatientStatus = "Patient status has been updated successfully";
        public const string UpdateApptStatus = "Appointment has been updated successfully";
        public const string UpdateUserStatus = "User status has been updated successfully";
        public const string ApptCancelled = "Appointment cancelled successfully";
        public const string BatchCreatedsuccessfully = "Batch Created successfully";
        public const string Unlocked = "This record has been unlocked.";
        public const string CallLogInserted = "Call log inserted successfully";
        public const string RpmDevicesRecordSaved = "Biometric reading saved successfully";
        public const string RpmDevicesRecordUpdate= "Biometric reading updated successfully";
        public const string ServiceIdNotFound = "Service Id not configured for this client";
        public const string UpdateMember = "Member updated successfully";
        public const string CreateMember = "Member created successfully";
        public const string MemberCurrentCallStatus = "Member Current Call Status updated successfully";

    }
}
