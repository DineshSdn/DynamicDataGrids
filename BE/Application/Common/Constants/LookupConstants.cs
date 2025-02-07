namespace CleanArchitecture.ApplicationCore.Common.Constants
{
    public class LookupConstants
    {
        public class Position
        {
            public const int MP = 2;
            public const int NursePractitioner = 3;
        }

        public class Roles
        {
            public const string Administrators = "administrators";
            public const string HumanResources = "human_resources";
            public const string HR = "hr";
        }

        public class EmailNotification
        {
            public const string NewNPCandidateWelcomeEmail = "NewNPCandidateWelcomeEmail";
            public const string NewSchedulerCandidateWelcomeEmail = "NewSchedulerCandidateWelcomeEmail";
            public const string TimeSheetOnlyAccessActivated = "TimeSheetOnlyAccessActivated";
            public const string AvailabilityConfirmationReport = "AvailabilityConfirmationReport";
            public const string ContractedSignedNotification = "ContractedSignedNotification";
            public const string NewNPCandidateWelcomeEmailToLeadership = "NewNPCandidateWelcomeEmailToLeadership";
            public const string EquipmentNeededNotification = "EquipmentNeededNotification";
            public const string AvailabilityConfirmationReportOff = "AvailabilityConfirmationReportOFF";
        }
    }

}
