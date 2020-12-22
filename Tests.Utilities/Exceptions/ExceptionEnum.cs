namespace Tests.Utilities.Exceptions
{
    public enum ExceptionEnum
    {
        InvalidCredentials = 1,
        SecurityKeyIsNull = 2,
        AuthorizationHeaderNotExist = 3,
        Unauthorized = 4,
        EmployeeIsNotYours = 5,
        EmployeeNotFound = 6,
        AvatarIsNotBase64 = 7,
        ResumeIsNotBase64 = 8,
        EditedUserIsNotYours = 9,
        SubscriptionNotFound = 10,
        ExceededMaximumTests = 11,
        AvatarRecordDoesntExist = 12,
        ResumeRecordDoesntExist = 13,
        PositionDoesNotExist = 14,
        CompanyNameCantBeEmpty = 15,
        EmailCantBeEmpty = 16,
        PasswordCantBeEmpty = 17,
        OldPasswordDontMatch = 18,
    }
}
