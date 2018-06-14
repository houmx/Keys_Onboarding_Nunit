using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Pages.OwnerPages.Owners.Properties
{
    class SendRequestPage
    {
        public SendRequestPage()
        {
            PageFactory.InitElements(Global.Driver.driver, this);
        }

        #region  WebElements Definition 
        
        //Define tenant text      
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div/div[1]/div[1]/div[2]/div/div")]
        private IWebElement TenantText { set; get; }

        //Define tenant dropdown     
        [FindsBy(How = How.XPath, Using = "//select[@id='tenant-select']")]
        private IWebElement TenantDropdown { set; get; }

        //Define type dropdown   
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div/div[1]/div[1]/div[3]/select")]
        private IWebElement TypeDropdown { set; get; }

        //Define description text  
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div/div[1]/div[2]/form/div/textarea")]
        private IWebElement DescriptionText { set; get; }

        //Define choose files button  
        [FindsBy(How = How.XPath, Using = ".//*[@id='fileUpload']")]
        private IWebElement ChooseFilesButton { set; get; }

        //Define save button
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div/div[3]/button")]
        private IWebElement SaveButton { set; get; }

        //Define close button
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div/div[3]/a")]
        private IWebElement CloseButton { set; get; }

        #endregion

        //Enter request information in the send request form
        internal void AddRequstInformation()
        {
            // Populating the data from Excel
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Send Request");

            string tenant = ExcelLib.ReadData(2, "Tenant");
            string type = ExcelLib.ReadData(2, "Type");

            //choose tenant from dropdown list
            TenantText.Click();
            Driver.WaitForElementClickable(Driver.driver,By.XPath(String.Format("//div[@class='item'][contains(text(),'{0}')]", tenant)),5);
            Driver.driver.FindElement(By.XPath(String.Format("//div[@class='item'][contains(text(),'{0}')]", tenant))).Click();

            //choose type from dropdown list
            SelectElement select2 = new SelectElement(TypeDropdown);
            select2.SelectByText(type);
            //enter description
            DescriptionText.SendKeys(ExcelLib.ReadData(2,"Description"));
            //upload files
            ChooseFilesButton.SendKeys(ExcelLib.ReadData(2, "Choose Files"));

        }
        //Click Save button and send the request
        internal void SaveRequest()
        {
            SaveButton.Click();
        }
        //Click cancel button
        internal void CloseRequest()
        {
            CloseButton.Click();
        }
    }
}
