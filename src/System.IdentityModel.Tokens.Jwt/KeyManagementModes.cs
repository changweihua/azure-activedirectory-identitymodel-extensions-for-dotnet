using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.IdentityModel.Tokens.Jwt
{
    public enum KeyManagementModes
    {
        DirectEncryption,
        DirectKeyAgreement,
        KeyWrapping,
        KeyEncryption,
        KeyAgreementWithKeyWrapping
    }
}
