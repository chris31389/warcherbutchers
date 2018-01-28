using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WArcherButchers.ServerApp.PaymentSense
{
    public class HashDigestFactory
    {
        public string Create(PaymentSenseRequestDto paymentSenseRequestDto)
        {
            string stringToHash = GetStringToHash(paymentSenseRequestDto);
            byte[] body = StringToByteArray(stringToHash);
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] hashDigest = sha1.ComputeHash(body);
            return ByteArrayToHexString(hashDigest);
        }

        public static string GetStringToHash(PaymentSenseRequestDto paymentSenseRequestDto)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("PreSharedKey", paymentSenseRequestDto.PreSharedKey);
            pairs.Add("MerchantID", paymentSenseRequestDto.MerchantID);
            pairs.Add("Password", paymentSenseRequestDto.Password);
            pairs.Add("Amount", paymentSenseRequestDto.AmountInPence);
            pairs.Add("CurrencyCode", paymentSenseRequestDto.CurrencyCode);
            pairs.Add("EchoAVSCheckResult", paymentSenseRequestDto.EchoAVSCheckResult);
            pairs.Add("EchoCV2CheckResult", paymentSenseRequestDto.EchoCV2CheckResult);
            pairs.Add("EchoThreeDSecureAuthenticationCheckResult", paymentSenseRequestDto.EchoThreeDSecureAuthenticationCheckResult);
            pairs.Add("EchoCardType", paymentSenseRequestDto.EchoCardType);
            pairs.Add("EchoCardNumberFirstSix", paymentSenseRequestDto.EchoCardNumberFirstSix);
            pairs.Add("EchoCardNumberLastFour", paymentSenseRequestDto.EchoCardNumberLastFour);
            pairs.Add("EchoCardExpiryDate", paymentSenseRequestDto.EchoCardExpiryDate);
            pairs.Add("EchoDonationAmount", paymentSenseRequestDto.EchoDonationAmount);
            pairs.Add("AVSOverridePolicy", paymentSenseRequestDto.AVSOverridePolicy);
            pairs.Add("CV2OverridePolicy", paymentSenseRequestDto.CV2OverridePolicy);
            pairs.Add("ThreeDSecureOverridePolicy", paymentSenseRequestDto.ThreeDSecureOverridePolicy);
            pairs.Add("OrderID", paymentSenseRequestDto.OrderID);
            pairs.Add("TransactionType", paymentSenseRequestDto.TransactionType);
            pairs.Add("TransactionDateTime", paymentSenseRequestDto.TransactionDateTime);
            pairs.Add("CallbackURL", paymentSenseRequestDto.CallbackURL);
            pairs.Add("OrderDescription", paymentSenseRequestDto.OrderDescription);
            pairs.Add("CustomerName", paymentSenseRequestDto.CustomerName);
            pairs.Add("Address1", paymentSenseRequestDto.Address1);
            pairs.Add("Address2", paymentSenseRequestDto.Address2);
            pairs.Add("Address3", paymentSenseRequestDto.Address3);
            pairs.Add("Address4", paymentSenseRequestDto.Address4);
            pairs.Add("City", paymentSenseRequestDto.City);
            pairs.Add("State", paymentSenseRequestDto.State);
            pairs.Add("PostCode", paymentSenseRequestDto.PostCode);
            pairs.Add("CountryCode", paymentSenseRequestDto.CountryCode);
            pairs.Add("EmailAddress", paymentSenseRequestDto.EmailAddress);
            pairs.Add("PhoneNumber", paymentSenseRequestDto.PhoneNumber);
            pairs.Add("DateOfBirth", paymentSenseRequestDto.DateOfBirth);
            pairs.Add("EmailAddressEditable", paymentSenseRequestDto.EmailAddressEditable);
            pairs.Add("PhoneNumberEditable", paymentSenseRequestDto.PhoneNumberEditable);
            pairs.Add("DateOfBirthEditable", paymentSenseRequestDto.DateOfBirthEditable);
            pairs.Add("CV2Mandatory", paymentSenseRequestDto.CV2Mandatory);
            pairs.Add("Address1Mandatory", paymentSenseRequestDto.Address1Mandatory);
            pairs.Add("CityMandatory", paymentSenseRequestDto.CityMandatory);
            pairs.Add("PostCodeMandatory", paymentSenseRequestDto.PostCodeMandatory);
            pairs.Add("StateMandatory", paymentSenseRequestDto.StateMandatory);
            pairs.Add("CountryMandatory", paymentSenseRequestDto.CountryMandatory);
            pairs.Add("ResultDeliveryMethod", paymentSenseRequestDto.ResultDeliveryMethod);
            pairs.Add("ServerResultURL", paymentSenseRequestDto.ServerResultURL);
            pairs.Add("PaymentFormDisplaysResult", paymentSenseRequestDto.PaymentFormDisplaysResult);
            pairs.Add("PrimaryAccountName", paymentSenseRequestDto.PrimaryAccountName);
            pairs.Add("PrimaryAccountNumber", paymentSenseRequestDto.PrimaryAccountNumber);
            pairs.Add("PrimaryAccountDateOfBirth", paymentSenseRequestDto.PrimaryAccountDateOfBirth);
            pairs.Add("PrimaryAccountPostCode", paymentSenseRequestDto.PrimaryAccountPostCode);

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
}