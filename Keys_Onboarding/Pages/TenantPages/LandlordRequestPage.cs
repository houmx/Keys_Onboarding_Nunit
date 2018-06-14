using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keys_Onboarding.Pages.TenantPages.Tenants
{
    class LandlordRequestPage
    {
        public LandlordRequestPage()
        {
            PageFactory.InitElements(Global.Driver.driver, this);
        }

        #region Property Section WebElements Definition

        //Define current request landlord name
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/table/tbody/tr/td[1]/h5")]
        private IWebElement CurrentRequestLandlord { set; get; }

        //Define current request request type
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/table/tbody/tr/td[2]")]
        private IWebElement CurrentRequestType { set; get; }

        //Define current request message
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/table/tbody/tr/td[3]")]
        private IWebElement CurrentRequestMessage { set; get; }

        //Define no landlord request message
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/div[4]/p")]
        private IWebElement CurrenNoRequestText { set; get; }


        
        #endregion

        internal string GetCurrentRequestLandlord()
        {
            if(CurrenNoRequestText.Displayed)
            {
                return "1";
            }
            else
            {
                return CurrentRequestLandlord.Text;
            }
        }
        internal string GetCurrentRequestType()
        {
            if (CurrenNoRequestText.Displayed)
            {
                return "1";
            }
            else
            {
                return CurrentRequestType.Text;
            }
        }
        internal string GetCurrentRequestMessage()
        {
            if (CurrenNoRequestText.Displayed)
            {
                return "1";
            }
            else
            {
                return CurrentRequestMessage.Text;
            }
        }
    }
}
