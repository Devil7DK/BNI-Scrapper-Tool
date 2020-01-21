using RestSharp;
using Serilog;
using System;
using System.Text.RegularExpressions;

namespace  Devil7.Automation.BNI.Scrapper.Utils
{
    class API
    {
        #region Variables
        private static RestClient restClient;
        #endregion

        #region Private Methods
        private static void InitializeClient(string userAgent)
        {
            if (restClient == null)
            {
                Log.Information("Initializing Rest Client...");
                restClient = new RestClient("https://www.bniconnectglobal.com/");
                restClient.AddDefaultHeader("Host", "www.bniconnectglobal.com");
                restClient.AddDefaultHeader("User-Agent", userAgent);
                restClient.AddDefaultHeader("Accept", "*/*");
                restClient.AddDefaultHeader("Accept-Language", "en-US,en;q=0.5");
                restClient.AddDefaultHeader("Accept-Encoding", "gzip, deflate, br");
                restClient.AddDefaultHeader("Content-Type", "application/x-www-form-urlencoded");
                restClient.AddDefaultHeader("X-Requested-With", "XMLHttpRequest");
                restClient.AddDefaultHeader("Connection", "keep-alive");
                restClient.AddDefaultHeader("Upgrade-Insecure-Requests", "1");
            }
        }
        private static void UpdateCookies(string cookieString)
        {
            restClient.CookieContainer = new System.Net.CookieContainer();
            foreach (string cookieData in cookieString.Split(';'))
            {
                Match match = Regex.Match(cookieData.Trim(), @"(.*)=(.*)");
                if (match.Success)
                {
                    string key = match.Groups[1].Value.Trim();
                    string value = match.Groups[2].Value.Trim();

                    if (key.Equals("logCurTime"))
                    {
                        value = (new DateTimeOffset(DateTime.Now)).ToUnixTimeSeconds().ToString();
                    }

                    restClient.CookieContainer.Add(new System.Net.Cookie(key, value, "/", "www.bniconnectglobal.com"));
                }
            }
        }
        #endregion

        #region Public Methods
        public static void GetDetailedInfo(Models.ExportData userData, string cookieString, string userAgent)
        {
            InitializeClient(userAgent);
            UpdateCookies(cookieString);

            if (userData == null || userData.ID < 1)
            {
                Log.Warning("Skipping Fetching UserInfo as UserData is Null");
                return;
            }
            else if (userData.ID < 1)
            {
                Log.Warning("Skipping Fetching UserInfo for ID: {0} Name: '{1}'", userData.ID, userData.Name);
                return;
            }
            else
            {
                Log.Information("Fetching Details for ID: {0} Name: '{1}'", userData.ID, userData.Name);
            }

            try
            {
                RestRequest restRequest = new RestRequest(string.Format("/web/secure/networkProfile?userId={0}&canAddNetwok=true&_={1}", userData.ID, (new DateTimeOffset(DateTime.Now.AddSeconds(5))).ToUnixTimeSeconds().ToString()), Method.GET);
                restRequest.AddHeader("Referer", string.Format("https://www.bniconnectglobal.com/web/secure/networkHome?userId={0}", userData.ID));
                RestResponse restResponse = (RestResponse)restClient.Execute(restRequest);
                if (restResponse.IsSuccessful)
                {
                    Log.Information("Successfully Fetched Details. Parsing...");
                    try
                    {
                        HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                        document.LoadHtml(restResponse.Content);

                        foreach (HtmlAgilityPack.HtmlNode container in document.DocumentNode.SelectNodes("//div[contains(@class, 'networkhometabs')]"))
                        {
                            foreach (HtmlAgilityPack.HtmlNode displayLabel in container.Descendants("label"))
                            {
                                string labelFor = displayLabel.GetAttributeValue("for", "");
                                string labelValue = "";
                                foreach (HtmlAgilityPack.HtmlNode span in displayLabel.Descendants("span"))
                                    if (span.HasClass("fieldtext"))
                                        labelValue = span.InnerText.Trim();


                                if (!string.IsNullOrEmpty(labelFor) && !string.IsNullOrEmpty(labelValue))
                                {
                                    switch (labelFor)
                                    {
                                        case "memberLanguage":
                                            userData.MemberLanguage = labelValue;
                                            break;
                                        case "memberPersonalStatementMemoryHook":
                                            userData.PersonalStatement = labelValue;
                                            break;
                                        case "memberKeywords":
                                            userData.Keywords = labelValue;
                                            break;
                                        case "memberCompanyName":
                                            userData.Company = labelValue;
                                            break;
                                        case "memberPhoneNumber":
                                            userData.PhoneNumber = labelValue;
                                            break;
                                        case "personDirectNumber":
                                            userData.DirectNumber = labelValue;
                                            break;
                                        case "memberAlternatePhoneNumber":
                                            userData.AlternatePhoneNumber = labelValue;
                                            break;
                                        case "memberMobileNumber":
                                            userData.MobileNumber = labelValue;
                                            break;
                                        case "memberPagerNumber":
                                            userData.PagerNumber = labelValue;
                                            break;
                                        case "memberVoicemailNumber":
                                            userData.VoicemailNumber = labelValue;
                                            break;
                                        case "memberTollfreeNumber":
                                            userData.TollfreeNumber = labelValue;
                                            break;
                                        case "memberFax":
                                            userData.Fax = labelValue;
                                            break;
                                        case "memberEmail":
                                            userData.Email = labelValue;
                                            break;
                                        case "memberWebsite":
                                            userData.Website = labelValue;
                                            break;
                                        case "memberSocialNetworkingLinks":
                                            userData.SocialNetworkingLinks = labelValue;
                                            break;
                                        case "memberAddressLine1":
                                            userData.AddressLine1 = labelValue;
                                            break;
                                        case "memberCity":
                                            userData.City = labelValue;
                                            break;
                                        case "memberState":
                                            userData.State = labelValue;
                                            break;
                                        case "memberCountry":
                                            userData.Country = labelValue;
                                            break;
                                        case "memberZipCode":
                                            userData.ZipCode = labelValue;
                                            break;
                                    }
                                }
                            }
                        }

                        Log.Information("Successfully Parsed.");
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, "Failed to Parse Data! ID: {0}", userData.ID);
                    }
                }
                else
                {
                    Log.Error("Error on UserInfo Request. {0}", restResponse.ErrorMessage);
                }
            }
            catch (Exception ex)
            {

                Log.Error(ex, "Failed to Fetch UserInfo! {0}", ex.Message);
            }
        } 
        #endregion
    }
}
