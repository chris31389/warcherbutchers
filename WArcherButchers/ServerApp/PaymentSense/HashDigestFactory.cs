using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WArcherButchers.ServerApp.PaymentSense
{
    public class HashDigestFactory
    {
        public string Create(Dictionary<string, object> formValues, string preSharedKey, string password)
        {
            string stringToHash = GetStringToHash(formValues, preSharedKey, password);
            byte[] body = StringToByteArray(stringToHash);
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] hashDigest = sha1.ComputeHash(body);
            return ByteArrayToHexString(hashDigest);
        }

        public static string GetStringToHash(Dictionary<string, object> formValues, string preSharedKey,
            string password)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("PreSharedKey", preSharedKey);
            pairs.Add(formValues, "MerchantID");
            pairs.Add("Password", password);
            pairs.Add(formValues, "Amount");
            pairs.Add(formValues, "CurrencyCode");
            pairs.AddIfExists(formValues, "EchoAVSCheckResult");
            pairs.AddIfExists(formValues, "EchoCV2CheckResult");
            pairs.AddIfExists(formValues, "EchoThreeDSecureAuthenticationCheckResult");
            pairs.AddIfExists(formValues, "EchoFraudProtectionCheckResult");
            pairs.AddIfExists(formValues, "EchoCardType");
            pairs.AddIfExists(formValues, "EchoCardNumberFirstSix");
            pairs.AddIfExists(formValues, "EchoCardNumberLastFour");
            pairs.AddIfExists(formValues, "EchoCardExpiryDate");
            pairs.AddIfExists(formValues, "EchoDonationAmount");
            pairs.AddIfExists(formValues, "AVSOverridePolicy");
            pairs.AddIfExists(formValues, "CV2OverridePolicy");
            pairs.AddIfExists(formValues, "ThreeDSecureOverridePolicy");
            pairs.AddIfExists(formValues, "OrderID");
            pairs.AddIfExists(formValues, "TransactionType");
            pairs.AddIfExists(formValues, "TransactionDateTime");
            pairs.AddIfExists(formValues, "DisplayCancelButton");
            pairs.AddIfExists(formValues, "CallbackURL");
            pairs.AddIfExists(formValues, "OrderDescription");
            pairs.AddIfExists(formValues, "LineItemSalesTaxAmount");
            pairs.AddIfExists(formValues, "LineItemSalesTaxDescription");
            pairs.AddIfExists(formValues, "LineItemQuantity");
            pairs.AddIfExists(formValues, "LineItemAmount");
            pairs.AddIfExists(formValues, "LineItemDescription");
            pairs.AddIfExists(formValues, "CustomerName");
            pairs.AddIfExists(formValues, "DisplayBillingAddress");
            pairs.AddIfExists(formValues, "Address1");
            pairs.AddIfExists(formValues, "Address2");
            pairs.AddIfExists(formValues, "Address3");
            pairs.AddIfExists(formValues, "Address4");
            pairs.AddIfExists(formValues, "City");
            pairs.AddIfExists(formValues, "State");
            pairs.AddIfExists(formValues, "PostCode");
            pairs.AddIfExists(formValues, "CountryCode");
            pairs.AddIfExists(formValues, "EmailAddress");
            pairs.AddIfExists(formValues, "PhoneNumber");
            pairs.AddIfExists(formValues, "DateOfBirth");
            pairs.AddIfExists(formValues, "DisplayShippingDetails");
            pairs.AddIfExists(formValues, "ShippingName");
            pairs.AddIfExists(formValues, "ShippingAddress1");
            pairs.AddIfExists(formValues, "ShippingAddress2");
            pairs.AddIfExists(formValues, "ShippingAddress3");
            pairs.AddIfExists(formValues, "ShippingAddress4");
            pairs.AddIfExists(formValues, "ShippingCity");
            pairs.AddIfExists(formValues, "ShippingState");
            pairs.AddIfExists(formValues, "ShippingPostCode");
            pairs.AddIfExists(formValues, "ShippingCountryCode");
            pairs.AddIfExists(formValues, "ShippingEmailAddress");
            pairs.AddIfExists(formValues, "ShippingPhoneNumber");
            pairs.AddIfExists(formValues, "CustomerNameEditable");
            pairs.AddIfExists(formValues, "EmailAddressEditable");
            pairs.AddIfExists(formValues, "PhoneNumberEditable");
            pairs.AddIfExists(formValues, "DateOfBirthEditable");
            pairs.AddIfExists(formValues, "CV2Mandatory");
            pairs.AddIfExists(formValues, "Address1Mandatory");
            pairs.AddIfExists(formValues, "CityMandatory");
            pairs.AddIfExists(formValues, "PostCodeMandatory");
            pairs.AddIfExists(formValues, "StateMandatory");
            pairs.AddIfExists(formValues, "CountryMandatory");
            pairs.AddIfExists(formValues, "ShippingAddress1Mandatory");
            pairs.AddIfExists(formValues, "ShippingCityMandatory");
            pairs.AddIfExists(formValues, "ShippingPostCodeMandatory");
            pairs.AddIfExists(formValues, "ShippingStateMandatory");
            pairs.AddIfExists(formValues, "ShippingCountryMandatory");
            pairs.AddIfExists(formValues, "ResultDeliveryMethod");
            pairs.AddIfExists(formValues, "ServerResultURL");
            pairs.AddIfExists(formValues, "PaymentFormDisplaysResult");
            pairs.AddIfExists(formValues, "ServerResultURLCookieVariables");
            pairs.AddIfExists(formValues, "ServerResultURLFormVariables");
            pairs.AddIfExists(formValues, "ServerResultURLQueryStringVariables");
            pairs.AddIfExists(formValues, "PrimaryAccountName");
            pairs.AddIfExists(formValues, "PrimaryAccountNumber");
            pairs.AddIfExists(formValues, "PrimaryAccountDateOfBirth");
            pairs.AddIfExists(formValues, "PrimaryAccountPostCode");
            pairs.AddIfExists(formValues, "Skin");
            pairs.AddIfExists(formValues, "PaymentFormContentMode");
            pairs.AddIfExists(formValues, "BreakoutOfIFrameOnCallback");

            return string.Join("&", pairs.Select(WriteOutPair));
        }

        private static string WriteOutPair(KeyValuePair<string, object> x)
        {
            string value = x.Value is bool ? x.Value.ToString().ToLower() : x.Value.ToString();
            return $"{x.Key}={value}";
        }

        private static byte[] StringToByteArray(string stringToConvert) =>
            new UTF8Encoding().GetBytes(stringToConvert);

        public static string ByteArrayToHexString(byte[] aByte)
        {
            int nCount;
            StringBuilder sbStringBuilder = new StringBuilder();
            for (nCount = 0; nCount < aByte.Length; nCount++)
            {
                sbStringBuilder.Append(aByte[nCount].ToString("x2"));
            }

            return (sbStringBuilder.ToString());
        }
    }
}