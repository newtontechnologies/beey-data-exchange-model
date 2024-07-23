using System.ComponentModel;

namespace Beey.DataExchangeModel.Common.Enums;

public enum ErrorTypeEnum
{
    [Description("Required")]
    RequiredFieldMissing,
    [Description("Invalid")]
    Invalid,
    [Description("CannotValidate")]
    CannotValidate,
    [Description("NotSupported")]
    NotSupported,
    [Description("DataProtectionConsent:Required")]
    DataProtectionConsent
}

