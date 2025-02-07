namespace CleanArchitecture.ApplicationCore.Common.Constants
{
    public static class CommonUtility
    {
        public enum EncounterStatus
        {
            //Drafted = 1,
            //Quality_Review = 3,
            //Provider_Feedback = 5,
            //Quality_QA = 6,
            //Quality_Review_Complete = 4,

            Drafted_Field_Nurse = 1,
            Drafted_NP = 10,
            Complete_NP = 3,
            NP_Query = 5,
            Quality_Review = 6,
            Coding_Complete = 4,
            Is_Delete = 0,
        }
    }
}
