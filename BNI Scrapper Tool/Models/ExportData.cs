using System.ComponentModel;

namespace  Devil7.Automation.BNI.Scrapper.Models
{
    class ExportData
    {
        #region Primary Details
        public int ID { get; set; }
        public string Name { get; set; }
        public string Chapter { get; set; }
        public string Company { get; set; }
        public string City { get; set; }

        [DisplayName("Profession And Specialty")]
        public string Profession { get; set; }
        #endregion

        #region Secondary Details
        public string Position { get; set; }
        public string MemberLanguage { get; set; }
        public string PersonalStatement { get; set; }
        public string Keywords { get; set; }
        public string PhoneNumber { get; set; }
        public string DirectNumber { get; set; }
        public string AlternatePhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string PagerNumber { get; set; }
        public string VoicemailNumber { get; set; }
        public string TollfreeNumber { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string SocialNetworkingLinks { get; set; }
        public string AddressLine1 { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        #endregion

        #region Constructor
        public ExportData(int ID, string Name, string Chapter, string Company, string City, string Profession)
        {
            this.ID = ID;
            this.Name = Name;
            this.Chapter = Chapter;
            this.Company = Company;
            this.City = City;
            this.Profession = Profession;

            this.Position = "";
            this.MemberLanguage = "";
            this.PersonalStatement = "";
            this.Keywords = "";
            this.PhoneNumber = "";
            this.DirectNumber = "";
            this.AlternatePhoneNumber = "";
            this.MobileNumber = "";
            this.PagerNumber = "";
            this.VoicemailNumber = "";
            this.TollfreeNumber = "";
            this.Fax = "";
            this.Email = "";
            this.Website = "";
            this.SocialNetworkingLinks = "";
            this.AddressLine1 = "";
            this.State = "";
            this.Country = "";
            this.ZipCode = "";
        } 
        #endregion
    }
}
