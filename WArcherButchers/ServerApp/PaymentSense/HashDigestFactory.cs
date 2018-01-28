using System;
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

        public static string GetStringToHash(Dictionary<string,object> formValues, string preSharedKey, string password)
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
            pairs.AddIfExists(formValues, "CallbackURL");
            pairs.AddIfExists(formValues, "OrderDescription");
            pairs.AddIfExists(formValues, "CustomerName");
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
            pairs.AddIfExists(formValues, "EmailAddressEditable");
            pairs.AddIfExists(formValues, "PhoneNumberEditable");
            pairs.AddIfExists(formValues, "DateOfBirthEditable");
            pairs.AddIfExists(formValues, "CV2Mandatory");
            pairs.AddIfExists(formValues, "Address1Mandatory");
            pairs.AddIfExists(formValues, "CityMandatory");
            pairs.AddIfExists(formValues, "PostCodeMandatory");
            pairs.AddIfExists(formValues, "StateMandatory");
            pairs.AddIfExists(formValues, "CountryMandatory");
            pairs.AddIfExists(formValues, "ResultDeliveryMethod");
            pairs.AddIfExists(formValues, "ServerResultURL");
            pairs.AddIfExists(formValues, "PaymentFormDisplaysResult");
            pairs.AddIfExists(formValues, "PrimaryAccountName");
            pairs.AddIfExists(formValues, "PrimaryAccountNumber");
            pairs.AddIfExists(formValues, "PrimaryAccountDateOfBirth");
            pairs.AddIfExists(formValues, "PrimaryAccountPostCode");

            return string.Join("&", pairs.Select(x => $"{x.Key}={x.Value.ToString()}"));
        }

        private static byte[] StringToByteArray(string stringToConvert) =>
            new UTF8Encoding().GetBytes(stringToConvert);

        public static string ByteArrayToHexString(byte[] aByte)
        {
            StringBuilder sbStringBuilder;
            int nCount = 0;

            sbStringBuilder = new StringBuilder();
            for (nCount = 0; nCount < aByte.Length; nCount++)
            {
                sbStringBuilder.Append(aByte[nCount].ToString("x2"));
            }

            return (sbStringBuilder.ToString());
        }
    }

    public static class DictionaryExistions
    {
        public static void AddIfExists(this Dictionary<string, object> to, Dictionary<string, object> from, string key)
        {
            if (from.TryGetValue(key, out object value)) to.Add(key, value);
        }
        public static void Add(this Dictionary<string, object> to, Dictionary<string, object> from, string key)
        {
            if (from.TryGetValue(key, out object value))
            {
                to.Add(key, value);
            }
            else
            {
                throw new ArgumentException($"{key} should exist in dictionary");
            }
        }
    }
}