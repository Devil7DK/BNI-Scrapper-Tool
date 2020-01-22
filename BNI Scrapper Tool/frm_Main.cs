using Devil7.Automation.BNI.Scrapper.Controls;
using Devil7.Automation.BNI.Scrapper.Models;
using Devil7.Automation.BNI.Scrapper.Utils;
using DevExpress.Spreadsheet;
using Gecko;
using Gecko.DOM;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Devil7.Automation.BNI.Scrapper
{
    public partial class frm_Main : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        private BrowserAction CurrentAction;

        private string lastCookie = "";
        private string userAgent = "";

        private List<string> queuedSearches;
        private int totalSearch, currentSearch;
        private string currentCountry = "";

        private Dictionary<string, List<ExportData>> countryWiseData;

        private ObservableCollection<LogEvent> LogEvents;

        private GeckoWebBrowser Browser { get; }
        #endregion

        #region Delegates
        private delegate void BrowserAction();
        #endregion

        #region Constructor
        public frm_Main(ObservableCollection<LogEvent> LogEvents)
        {
            InitializeComponent();

            // Initialize Browser
            Xpcom.Initialize("Firefox");

            BrowserContainer browserContainer = new BrowserContainer() { Dock = DockStyle.Fill };
            this.splitContainerControl1.Panel2.Controls.Add(browserContainer);
            this.Browser = browserContainer.Browser;

            Browser.UseHttpActivityObserver = true;
            Browser.ObserveHttpModifyRequest += Browser_ObserveHttpModifyRequest;
            Browser.DocumentCompleted += Browser_DocumentCompleted;

            ResponseObserver responseObserver = new ResponseObserver();
            responseObserver.AuthResponseReceived += ResponseObserver_AuthResponseReceived;
            responseObserver.SearchResponseReceived += ResponseObserver_SearchResponseReceived; ;
            ObserverService.AddObserver(responseObserver);

            // Initialize Variables
            this.LogEvents = LogEvents;
            this.countryWiseData = new Dictionary<string, List<ExportData>>();
        }
        #endregion

        #region Private Functions
        private List<ExportData> getCountryData(string country)
        {
            if (countryWiseData.ContainsKey(country))
            {
                if (countryWiseData[country] == null)
                    countryWiseData[country] = new List<ExportData>();
            }
            else
            {
                countryWiseData[country] = new List<ExportData>();
            }

            return countryWiseData[country];
        }
        #endregion

        #region Private Methods
        private void ExportToExcel()
        {
            try
            {
                Workbook workbook = new Workbook();

                foreach (string country in countryWiseData.Keys)
                {
                    List<ExportData> data = countryWiseData[country];

                    Worksheet worksheet = workbook.Worksheets.Add(country);

                    string[] columnHeaders = {
                    "Name", "Chapter", "Company", "City", "Profession And Specialty" ,
                    "Position", "MemberLanguage", "PersonalStatement", "Keywords",
                    "PhoneNumber", "DirectNumber", "AlternatePhoneNumber", "MobileNumber",
                    "PagerNumber", "VoicemailNumber", "TollfreeNumber", "Fax", "Email",
                    "Website", "SocialNetworkingLinks", "AddressLine1", "State",
                    "Country","ZipCode"
                };

                    for (int i = 0; i < columnHeaders.Length; i++)
                        worksheet.Cells[0, i].SetValueFromText(columnHeaders[i]);

                    for (int rowIndex = 1; rowIndex <= data.Count(); rowIndex++)
                    {
                        ExportData exportItem = data[rowIndex - 1];
                        // Primary
                        worksheet.Cells[rowIndex, 0].SetValueFromText(exportItem.Name);
                        worksheet.Cells[rowIndex, 1].SetValueFromText(exportItem.Chapter);
                        worksheet.Cells[rowIndex, 2].SetValueFromText(exportItem.Company);
                        worksheet.Cells[rowIndex, 3].SetValueFromText(exportItem.City);
                        worksheet.Cells[rowIndex, 4].SetValueFromText(exportItem.Profession);

                        // Secondary
                        worksheet.Cells[rowIndex, 5].SetValueFromText(exportItem.Position);
                        worksheet.Cells[rowIndex, 6].SetValueFromText(exportItem.MemberLanguage);
                        worksheet.Cells[rowIndex, 7].SetValueFromText(exportItem.PersonalStatement);
                        worksheet.Cells[rowIndex, 8].SetValueFromText(exportItem.Keywords);
                        worksheet.Cells[rowIndex, 9].SetValueFromText(exportItem.PhoneNumber);
                        worksheet.Cells[rowIndex, 10].SetValueFromText(exportItem.DirectNumber);
                        worksheet.Cells[rowIndex, 11].SetValueFromText(exportItem.AlternatePhoneNumber);
                        worksheet.Cells[rowIndex, 12].SetValueFromText(exportItem.MobileNumber);
                        worksheet.Cells[rowIndex, 13].SetValueFromText(exportItem.PagerNumber);
                        worksheet.Cells[rowIndex, 14].SetValueFromText(exportItem.VoicemailNumber);
                        worksheet.Cells[rowIndex, 15].SetValueFromText(exportItem.TollfreeNumber);
                        worksheet.Cells[rowIndex, 16].SetValueFromText(exportItem.Fax);
                        worksheet.Cells[rowIndex, 17].SetValueFromText(exportItem.Email);
                        worksheet.Cells[rowIndex, 18].SetValueFromText(exportItem.Website);
                        worksheet.Cells[rowIndex, 19].SetValueFromText(exportItem.SocialNetworkingLinks.Replace('\n', ' '));
                        worksheet.Cells[rowIndex, 20].SetValueFromText(exportItem.AddressLine1);
                        worksheet.Cells[rowIndex, 21].SetValueFromText(exportItem.State);
                        worksheet.Cells[rowIndex, 22].SetValueFromText(exportItem.Country);
                        worksheet.Cells[rowIndex, 23].SetValueFromText(exportItem.ZipCode);
                    }
                }

                workbook.SaveDocument(txt_Path_Excel.Text);

                Log.Information("Export to Excel Successful!");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Export to Excel Failed! {0}", ex.Message);
            }
        }

        private void LoadDataFromJSON()
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_Path_JSON.Text) && System.IO.File.Exists(txt_Path_JSON.Text))
                {
                    Dictionary<string, List<ExportData>> jsonData = JsonConvert.DeserializeObject<Dictionary<string, List<ExportData>>>(System.IO.File.ReadAllText(txt_Path_JSON.Text));
                    if (jsonData != null && jsonData.Count > 0)
                    {
                        countryWiseData = jsonData;
                        Log.Information("Loaded Existing Data from JSON!");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to Load Existing Data from JSON! {0}", ex.Message);
            }
        }

        private void SaveDataToJSON()
        {
            try
            {
                if (countryWiseData != null && countryWiseData.Count > 0 && !string.IsNullOrEmpty(txt_Path_JSON.Text))
                {
                    System.IO.File.WriteAllText(txt_Path_JSON.Text, JsonConvert.SerializeObject(countryWiseData));
                    Log.Information("Saved Data to JSON!");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to Save Data to JSON! {0}", ex.Message);
            }
        }

        private void UpdateSearchStatus()
        {
            lbl_Search_Count.Text = string.Format("{0} of {1}", currentSearch, totalSearch);
            if (totalSearch != 0 && currentSearch <= totalSearch)
                prog_Search.Position = ((currentSearch / totalSearch) * 100);
            else
                prog_Search.Position = 0;
        }
        #endregion

        #region Form Events
        private void frm_Main_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Constants.COUNTRIES.Length; i++)
            {
                this.cbl_Countries.Items.Add(i, Constants.COUNTRIES[i]);
            }

            if (Properties.Settings.Default.Remember)
            {
                txt_Username.Text = Properties.Settings.Default.Username;
                txt_Password.Text = Properties.Settings.Default.Password;
                cb_Remember.Checked = true;
            }

            if (string.IsNullOrEmpty(Properties.Settings.Default.JSONPath))
                txt_Path_JSON.Text = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "BNI JSON.json");
            else
                txt_Path_JSON.Text = Properties.Settings.Default.JSONPath;

            if (string.IsNullOrEmpty(Properties.Settings.Default.ExcelPath))
                txt_Path_Excel.Text = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "BNI Excel.xlsx");
            else
                txt_Path_Excel.Text = Properties.Settings.Default.ExcelPath;

            LoadDataFromJSON();

            gc_Logs.DataSource = LogEvents;
        }

        private void frm_Main_Shown(object sender, EventArgs e)
        {
            this.Browser.Navigate(URLs.LOGIN);
        }
        #endregion

        #region Browser Events
        private void Browser_ObserveHttpModifyRequest(object sender, GeckoObserveHttpModifyRequestEventArgs e)
        {
            if (e.Uri.AbsoluteUri.Contains(Utils.Constants.SEARCH_RESPONSE_ENDPOINT))
            {
                foreach (KeyValuePair<string, string> header in e.RequestHeaders)
                {
                    if (header.Key.Equals("Cookie"))
                    {
                        this.lastCookie = header.Value;
                    }
                    else if (header.Key.Equals("User-Agent"))
                    {
                        this.userAgent = header.Value;
                    }
                }
            }
        }

        private void Browser_DocumentCompleted(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            if (CurrentAction != null)
            {
                BrowserAction tmpAction = CurrentAction;
                CurrentAction = null;
                tmpAction.Invoke();
            }
            else
            {
                Console.WriteLine("");
            }
        }

        private void ResponseObserver_AuthResponseReceived(object sender, ResponseEventArgs e)
        {
            AuthResponse authResponse = JsonConvert.DeserializeObject<AuthResponse>(e.Data);
            if (authResponse != null)
            {
                if (authResponse.error == null)
                {
                    Log.Information("Authendication Success! Navigating to Search...");
                    this.CurrentAction = QueueNavigateToSearch;
                }
                else
                {
                    try
                    {
                        MessageBox.Show("Login Failed! " + authResponse.error.apiErrors[0].message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Login Failed! Unknown Error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Log.Warning("Authendication Failed!");
                }
            }
        }

        private void ResponseObserver_SearchResponseReceived(object sender, ResponseEventArgs e)
        {
            List<ExportData> countryData = getCountryData(currentCountry);
            List<ExportData> exportDatas = new List<ExportData>();
            SearchResult searchResult = JsonConvert.DeserializeObject<SearchResult>(e.Data);
            foreach (string html in searchResult.aaData)
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                foreach (HtmlNode row in doc.DocumentNode.Descendants("tr"))
                {
                    IEnumerable<HtmlNode> Cells = row.Descendants("td");
                    if (Cells.Count() == 7 && Cells.ElementAt(0).InnerText.Trim().Equals("Exact Matches"))
                    {
                        int ID = -1;

                        HtmlNode link = Cells.ElementAt(1).Element("a");
                        if (link != null)
                        {
                            string href = link.GetAttributeValue("href", "");
                            Match match = Regex.Match(href, @".*\?userId=([0-9]*)");
                            if (match.Success)
                            {
                                ID = int.Parse(match.Groups[1].Value);
                            }
                        }

                        string Name = Cells.ElementAt(1).InnerText;
                        string Chapter = Cells.ElementAt(2).InnerText;
                        string Company = Cells.ElementAt(3).InnerText;
                        string City = Cells.ElementAt(4).InnerText;
                        string Profession = Cells.ElementAt(5).InnerText;

                        if (countryData.Find(data => data.ID == ID) == null)
                        {
                            ExportData exportData = new ExportData(ID, Name, Chapter, Company, City, Profession);
                            exportDatas.Add(exportData);
                        }
                    }
                }
            }

            if (exportDatas.Count > 0)
            {
                for (int i = 0; i < exportDatas.Count; i++)
                {
                    ExportData exportData = exportDatas[i];

                    lbl_User_Count.Text = string.Format("{0} of {1}", i + 1, exportDatas.Count);
                    lbl_User_Name.Text = exportData.ID.ToString();

                    prog_UserQuery.Position = (((i + 1) / exportDatas.Count) * 100);

                    API.GetDetailedInfo(exportData, lastCookie, userAgent);

                    countryData.Add(exportData);

                    Stopwatch timer = new Stopwatch();
                    timer.Start();
                    while (timer.Elapsed.TotalSeconds <= 3)
                    {
                        Application.DoEvents();
                    }
                }
            }
            SaveDataToJSON();
            SearchNext();
        }
        #endregion

        #region Button Events
        private void txt_Path_Excel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            dlg_Excel.FileName = txt_Path_Excel.Text;
            if (dlg_Excel.ShowDialog() == DialogResult.OK)
            {
                txt_Path_Excel.Text = dlg_Excel.FileName;
                Properties.Settings.Default.ExcelPath = dlg_Excel.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void txt_Path_JSON_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            dlg_JSON.FileName = txt_Path_JSON.Text;
            if (dlg_JSON.ShowDialog() == DialogResult.OK)
            {
                txt_Path_JSON.Text = dlg_JSON.FileName;
                Properties.Settings.Default.JSONPath = dlg_JSON.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Username.Text))
            {
                MessageBox.Show("Username can't be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txt_Password.Text))
            {
                MessageBox.Show("Password can't be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txt_Keywords.Text) || txt_Keywords.Text.Split(',').Length < 0)
            {
                MessageBox.Show("Atleast one keyword required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbl_Countries.SelectedItems.Count == 0)
            {
                MessageBox.Show("Atleast one country must be selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                queuedSearches = new List<string>();
                foreach (string keyword in txt_Keywords.Text.Split(','))
                {
                    foreach (var country in cbl_Countries.CheckedItems)
                    {
                        queuedSearches.Add(string.Format("{0}:{1}", keyword.Trim(), country.ToString().Trim()));
                    }
                }
                totalSearch = queuedSearches.Count;

                Login();
            }
        }
        #endregion

        #region Browser Actions
        private void Login()
        {
            GeckoInputElement username = null;
            GeckoInputElement password = null;
            GeckoButtonElement signIn = null;

            if (Browser.Document.GetElementsByName("username").Count() > 0)
                username = Browser.Document.GetElementsByName("username")[0] as GeckoInputElement;
            if (Browser.Document.GetElementsByName("password").Count() > 0)
                password = Browser.Document.GetElementsByName("password")[0] as GeckoInputElement;
            if (Browser.Document.GetElementsByClassName("styles__SignInButton-dSRDTk").Count() > 0)
                signIn = Browser.Document.GetElementsByClassName("styles__SignInButton-dSRDTk")[0] as GeckoButtonElement;

            if (username != null && password != null && signIn != null)
            {
                Browser.Focus();

                username.Click();
                username.Focus();
                username.Value = txt_Username.Text;
                password.Click();
                password.Focus();
                password.Value = txt_Password.Text;
                SendKeys.SendWait("\t");
                SendKeys.SendWait("\n");
            }
        }

        private void QueueNavigateToSearch()
        {
            this.CurrentAction = NavigateToSearch;
        }

        private void NavigateToSearch()
        {
            Stopwatch timer = new Stopwatch();
            int timeout = 30;

            timer.Start();

            GeckoHtmlElement search = null;

            while (timer.Elapsed.TotalSeconds < timeout && search == null)
            {
                var elements = Browser.Document.GetElementsByClassName("searchpeople");
                if (elements.Count() > 0)
                    search = (GeckoHtmlElement)elements[0];

                if (search != null)
                {
                    search.Click();
                    this.CurrentAction = EnableAdvancedSearch;
                    break;
                }

                Application.DoEvents();
            }
        }

        private void EnableAdvancedSearch()
        {
            Stopwatch timer = new Stopwatch();
            int timeout = 30;

            timer.Start();

            GeckoHtmlElement advancedSearch = null;

            while (timer.Elapsed.TotalSeconds < timeout && advancedSearch == null)
            {
                advancedSearch = Browser.Document.GetHtmlElementById("advancedSearch");

                if (advancedSearch != null)
                {
                    advancedSearch.Click();
                    for (int i = 0; i < 100; i++)
                        Application.DoEvents();
                    SearchNext();
                    break;
                }

                Application.DoEvents();
            }
        }

        private void SearchNext()
        {
            if (queuedSearches.Count == 0)
            {
                ExportToExcel();
                MessageBox.Show("Search Completed! Data Exported to Selected Location.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                currentSearch++;
                UpdateSearchStatus();

                string strKeyword = queuedSearches[0].Split(':')[0];
                string strCountry = queuedSearches[0].Split(':')[1];

                if (!string.IsNullOrEmpty(strKeyword) && !string.IsNullOrEmpty(strCountry))
                {
                    Log.Information("Searching for Keyword '{0}' in Country '{1}'", strKeyword, strCountry);

                    lbl_Search_Keyword.Text = strKeyword;
                    lbl_Search_Country.Text = strCountry;
                    currentCountry = strCountry;

                    GeckoInputElement keyword = (GeckoInputElement)Browser.Document.GetElementById("memberKeywords");
                    GeckoHtmlElement country = (GeckoHtmlElement)Browser.Document.GetElementById("memberIdCountry");
                    GeckoHtmlElement submit = (GeckoHtmlElement)Browser.Document.GetElementById("searchConnections");

                    keyword.Click();
                    keyword.Focus();
                    keyword.Value = strKeyword;

                    this.Focus();
                    Browser.Focus();
                    country.Focus();
                    SendKeys.SendWait(strCountry);

                    submit.Focus();
                    submit.Click();
                }

                queuedSearches.RemoveAt(0);
            }
        }
        #endregion

        #region Other Events
        private void cb_Remember_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Remember = cb_Remember.Checked;
            Properties.Settings.Default.Save();
        }

        private void txt_Username_EditValueChanged(object sender, EventArgs e)
        {
            if (cb_Remember.Checked)
                Properties.Settings.Default.Username = txt_Username.Text;
            else
                Properties.Settings.Default.Username = "";
            Properties.Settings.Default.Save();
        }

        private void txt_Password_EditValueChanged(object sender, EventArgs e)
        {
            if (cb_Remember.Checked)
                Properties.Settings.Default.Password = txt_Password.Text;
            else
                Properties.Settings.Default.Password = "";
            Properties.Settings.Default.Save();
        }
        #endregion
    }
}
