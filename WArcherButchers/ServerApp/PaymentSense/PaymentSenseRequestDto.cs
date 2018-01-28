using System;

namespace WArcherButchers.ServerApp.PaymentSense
{
    public class PaymentSenseRequestDto
    {
        public string PreSharedKey { get; set; }
        public string MerchantID { get; set; }
        public int AmountInPence { get; set; }
        public int CurrencyCode { get; set; }
        public bool EchoAVSCheckResult { get; set; }
        public bool EchoCV2CheckResult { get; set; }
        public bool EchoThreeDSecureAuthenticationCheckResult { get; set; }
        public bool EchoCardType { get; set; }
        public bool EchoCardNumberFirstSix { get; set; }
        public bool EchoCardNumberLastFour { get; set; }
        public bool EchoCardExpiryDate { get; set; }
        public bool EchoDonationAmount { get; set; }
        public string AVSOverridePolicy { get; set; }
        public string CV2OverridePolicy { get; set; }
        public bool ThreeDSecureOverridePolicy { get; set; }
        public string OrderID { get; set; }
        public string TransactionType { get; set; }
        public DateTime? TransactionDateTime { get; set; }
        public string CallbackURL { get; set; }
        public string OrderDescription { get; set; }
        public string CustomerName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public int CountryCode { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public bool EmailAddressEditable { get; set; }
        public bool PhoneNumberEditable { get; set; }
        public bool DateOfBirthEditable { get; set; }
        public bool CV2Mandatory { get; set; }
        public bool Address1Mandatory { get; set; }
        public bool CityMandatory { get; set; }
        public bool PostCodeMandatory { get; set; }
        public bool StateMandatory { get; set; }
        public bool CountryMandatory { get; set; }
        public string ResultDeliveryMethod { get; set; }
        public string ServerResultURL { get; set; }
        public bool PaymentFormDisplaysResult { get; set; }
        public string PrimaryAccountName { get; set; }
        public string PrimaryAccountNumber { get;set;}
        public string PrimaryAccountDateOfBirth { get;set;}
        public string PrimaryAccountPostCode { get;set;}
        public string Password { get; set; }
    }
}