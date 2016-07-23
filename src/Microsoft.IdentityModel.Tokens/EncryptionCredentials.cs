using Microsoft.IdentityModel.Logging;

namespace Microsoft.IdentityModel.Tokens
{
    public class EncryptionCredentials
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SigningCredentials"/> class.
        /// </summary>
        /// <param name="key"><see cref="SecurityKey"/></param>
        /// <param name="algorithm">The signature algorithm to apply.</param>
        public EncryptionCredentials(SecurityKey key, /*SecurityKey contentEncryptionKey,*/ string keyEncryptionAlgorithm, string contentEncryptionAlgorithm, byte[] iv)
        {
            if (key == null)
                throw LogHelper.LogArgumentNullException("key");
            
            if (string.IsNullOrEmpty(keyEncryptionAlgorithm))
                throw LogHelper.LogArgumentNullException("keyEncryptionAlgorithm");

            if (string.IsNullOrEmpty(contentEncryptionAlgorithm))
                throw LogHelper.LogArgumentNullException("contentEncryptionAlgorithm");
            
            Key = key;
          //  ContentEncryptionKey = contentEncryptionKey;
            KeyEncryptionAlgorithm = keyEncryptionAlgorithm;
            ContentEncryptionAlgorithm = contentEncryptionAlgorithm;
            InitializationVector = iv;
        }

        /// <summary>
        /// Gets or sets the encryption key used for encrypting Content Encryption Key.
        /// </summary>
        public SecurityKey Key
        {
            get;
            private set;
        }
        
        public string Kid
        {
            get { return Key.KeyId; }
        }

        /// <summary>
        /// Gets or sets the key used for encrypting the plain text
        /// </summary>
        //public byte[] ContentEncryptionKey
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// Gets or sets the encryption algorithm used to encrypt the Content Encryption Key.
        /// </summary>
        public string KeyEncryptionAlgorithm
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the encryption algorithm used to encrypt the plain text.
        /// </summary>
        public string ContentEncryptionAlgorithm
        {
            get;
            private set;
        }

        public byte[] InitializationVector { get; set; }

        public string AuthenticationTag { get; set; }

        public byte[] AdditionalAuthenticationData { get; set; }

        /// <summary>
        /// Users can override the default <see cref="CryptoProviderFactory"/> with this property. This factory will be used for creating signature providers.
        /// </summary>
        public CryptoProviderFactory CryptoProviderFactory { get; set; }
                
    }
}
