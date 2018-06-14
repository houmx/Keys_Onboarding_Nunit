using Keys_Onboarding.Global;
using Keys_Onboarding.Pages;
using Keys_Onboarding.Pages.LoginRegister;
using Keys_Onboarding.Pages.OwnerPages.Owners.Properties;
using Keys_Onboarding.Pages.OwnerPages.PropertiesForRent;
using Keys_Onboarding.Pages.Owners.Properties;
using Keys_Onboarding.Pages.Owners.Rental_Listings_and_Applications;
using Keys_Onboarding.Pages.TenantPages.Dashboard;
using Keys_Onboarding.Pages.TenantPages.Tenants;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Test
{
    class Sprint1
    {
        [TestFixture]
        [Category("Sprint1:OwnerProperties")]
        class Owner : Base
        {

            [Test]
            public void PO_AddNewProperty()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Add a new property");
                test.AssignCategory("New Add Property");

                //Go to my properties page
                DashboardPage dashboard = new DashboardPage();
                dashboard.GoToMyPropertiesPage();

                //Get new property name from the excel file
                ExcelLib.PopulateInCollection(Base.ExcelPath, "Property Details");
                String PropertyName = ExcelLib.ReadData(2, "Property Name");

                //Search this property under my properties page and delete the property which has the same name as new property
                MyPropertiesPage myProperty = new MyPropertiesPage();
                if(myProperty.SearchAPropertySuccessfully(PropertyName))
                {
                    myProperty.DeleteAProperty(PropertyName);
                }

                //Click add new property button and go to add new property page
                myProperty.AddNewProperty();

                #region Add new property
                //Fill out property details form and go to finance details form
                AddNewPropertyPage addNewProperty = new AddNewPropertyPage();
                addNewProperty.AddPropertyDetails();
                addNewProperty.GotoFinanceForm();
                //Fill out finance details form and go to tenant details form
                addNewProperty.AddFinanceDetails();
                addNewProperty.GotoTenantForm();
                //Fill out tenant details page and save new property
                addNewProperty.AddTenantDetails();
                addNewProperty.SaveProperty();
                #endregion

                //Do the validation
                if (myProperty.IsMyPropertiesPageHeaderVisible())
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test passed, successfully navigated to my properties page after adding a new property");
                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test falied, fail to navigated to my properties page after adding a new property");
                }

            }

            [Test]
            public void PO_SearchPropertyAfterAddingNewProperty()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Search property after adding a new property");
                test.AssignCategory("New Add Property");

                //Go to my properties page
                DashboardPage dashboard = new DashboardPage();
                dashboard.GoToMyPropertiesPage();

                //Get new property name from the excel file
                ExcelLib.PopulateInCollection(Base.ExcelPath, "Property Details");
                String PropertyName = ExcelLib.ReadData(2, "Property Name");

                //Search this property under my properties page and delete the property which has the same name as new property
                MyPropertiesPage myProperty = new MyPropertiesPage();
                if (myProperty.SearchAPropertySuccessfully(PropertyName))
                {
                    myProperty.DeleteAProperty(PropertyName);
                }

                //Click add new property button and go to add new property page
                myProperty.AddNewProperty();

                #region Add new property
                AddNewPropertyPage addNewProperty = new AddNewPropertyPage();
                //Fill out property details form and go to finance details form
                addNewProperty.AddPropertyDetails();
                addNewProperty.GotoFinanceForm();
                //Fill out finance details form and go to tenant details form
                addNewProperty.AddFinanceDetails();
                addNewProperty.GotoTenantForm();
                //Fill out tenant details page and save new property
                addNewProperty.AddTenantDetails();
                addNewProperty.SaveProperty();
                #endregion
                
                //Do the validation
                if (myProperty.SearchAPropertySuccessfully(PropertyName))
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test passed, successfully search this new added property");
                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test falied, fail to search this new added property");
                }

            }

            [Test]
            public void PO_ListAsRental()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("List a property as rental");
                test.AssignCategory("List A Rental");

                //Go to my properties page
                DashboardPage dashboard = new DashboardPage();
                dashboard.GoToMyPropertiesPage();

                //Click list rental button and go to add list rental proeprty page
                MyPropertiesPage myProperty = new MyPropertiesPage();
                myProperty.ListARental();

                //Fill out the list rental property form and save
                ListRentalPropertyPage listrentalProerty = new ListRentalPropertyPage();
                listrentalProerty.AddRentalPropertyDetails();
                listrentalProerty.SaveListRentalProperty();

                //handle the alert and click ok
                Driver.driver.SwitchTo().Alert().Accept();

                RentalListingsAndTenantApplications rentalApplication = new RentalListingsAndTenantApplications();

                if (rentalApplication.IsHeaderDisplayed())
                {
                    test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test passed, successfully navigate to rental listings&applications page after listing a rental");
                }
                else
                {
                    test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test failed, fail to navigate to rental listings&applications page after listing a rental");

                }

            }

            [Test]
            public void PO_SearchPropertyAfterListingRental() 
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Search the property after listing as rental");
                test.AssignCategory("List A Rental");

                //Go to my properties page
                DashboardPage dashboard = new DashboardPage();
                dashboard.GoToMyPropertiesPage();

                //Click list rental button and go to add list rental proeprty page
                MyPropertiesPage myProperty = new MyPropertiesPage();
                myProperty.ListARental();

                //Fill out the list rental property form and save
                ListRentalPropertyPage listrentalProerty = new ListRentalPropertyPage();
                listrentalProerty.AddRentalPropertyDetails();
                listrentalProerty.SaveListRentalProperty();
                //handle the alert and click ok
                Driver.driver.SwitchTo().Alert().Accept();

                //Go to the properties for rent page
                dashboard.GotoPropertiesForRentPage();

                // Got the property title from excel
                ExcelLib.PopulateInCollection(Base.ExcelPath, "List Rental Property");
                String searchPropertyTitle = ExcelLib.ReadData(2, "Title");

                PropertiesForRentPage propertyForRent = new PropertiesForRentPage();

                if (propertyForRent.SearchRentalPropertySuccessfully(searchPropertyTitle))
                {
                    test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test passed, successfully search this property after listing as a rental");
                }
                else
                {
                    test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test failed, fail to search this property after listing as a reantal");
                }

            }

            [Test]
            public void PO_AddNewTenant()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Add a new tenant for a property");
                test.AssignCategory("Add New Tenant");

                #region Delete the existing tenant
                //Before adding new tenant, check whether the tenant already exist, if exist ,delete it
                ExcelLib.PopulateInCollection(Base.ExcelPath, "Add Tenant");
                String propertyName = ExcelLib.ReadData(2, "Property Name");
                String tenantEmail = ExcelLib.ReadData(2, "Tenant Email");

                //go to my properties page from dashboard
                DashboardPage dashBoard = new DashboardPage();
                dashBoard.GoToMyPropertiesPage();

                //search a property
                MyPropertiesPage myProperty = new MyPropertiesPage();
                myProperty.SearchAPropertySuccessfully(propertyName);

                //go to manage tenant page and delete the tenant which user want to add
                myProperty.GoToManageTenantPage();
                ManageTenantPage manageTenant = new ManageTenantPage();
                manageTenant.RemoveTenant(tenantEmail);

                //go back to my properties page and then go to add tenant page
                manageTenant.GoBackToProperties();
                myProperty.AddTenant();

                #endregion

                #region Add new tenant
                //Fill out the add tenant details form and go to liability details form
                AddTenantPage addTenant = new AddTenantPage();
                addTenant.AddTenantDetails();
                addTenant.NextToLiabilityDetails();
                //Add a new liability and go to sumamry form
                addTenant.ClickAddNewLiability();
                addTenant.AddLiabilityDetails();
                addTenant.SaveNewLiability();
                addTenant.NextToSummary();
                //Save the new tenant
                addTenant.Submit();
                #endregion

                if (myProperty.IsMyPropertiesPageHeaderVisible())
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test passed, successfully navigated to my properties page after adding a new tenant for a given property");
                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test falied, fail to navigated to my properties page after adding a new tenant for a given property");
                }

            }

            [Test]
            public void PO_SearchTenantAfterAddingNewTenant()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Search the tenant after adding new tenant for a given property");
                test.AssignCategory("Add New Tenant");

                #region Delete the existing tenant of the given proeprty
                //Before adding new tenant, check whether the tenant already exist, if exist ,delete it
                ExcelLib.PopulateInCollection(Base.ExcelPath, "Add Tenant");
                String propertyName = ExcelLib.ReadData(2, "Property Name");
                String tenantEmail = ExcelLib.ReadData(2, "Tenant Email");

                //go to my properties page from dashboard
                DashboardPage dashBoard = new DashboardPage();
                dashBoard.GoToMyPropertiesPage();

                //search the given property
                MyPropertiesPage myProperty = new MyPropertiesPage();
                myProperty.SearchAPropertySuccessfully(propertyName);

                //go to manage tenant page and delete the tenant which user want to add
                myProperty.GoToManageTenantPage();
                ManageTenantPage manageTenant = new ManageTenantPage();
                manageTenant.RemoveTenant(tenantEmail);

                //go back to my properties page and then go to add tenant page
                manageTenant.GoBackToProperties();
                myProperty.AddTenant();

                #endregion

                #region Add new tenant
                //Fill out the add tenant details form and go to liability details form
                AddTenantPage addTenant = new AddTenantPage();
                addTenant.AddTenantDetails();
                addTenant.NextToLiabilityDetails();
                //Add a new liability and go to sumamry form
                addTenant.ClickAddNewLiability();
                addTenant.AddLiabilityDetails();
                addTenant.SaveNewLiability();
                addTenant.NextToSummary();
                //Save the new tenant
                addTenant.Submit();
                #endregion

                //Search the given property under my properties page
                myProperty.SearchAPropertySuccessfully(propertyName);

                //Go to manage tenant page
                myProperty.GoToManageTenantPage();

                if (manageTenant.FindATenant(tenantEmail))
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test passed, successfully find the new tenant under manage tenant page");

                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test failed, fail to find the new tenant under manage tenant page");
                }
            }

            [Test]
            public void PO_SendRequest()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Send a request and login as tenant check this request");
                test.AssignCategory("Send Request");

                //go to my properties page from dashboard
                DashboardPage dashBoard = new DashboardPage();
                dashBoard.GoToMyPropertiesPage();

                //Get the data from excel file
                ExcelLib.PopulateInCollection(Base.ExcelPath, "Send Request");
                String propertyName = ExcelLib.ReadData(2, "Property Name");

                //search this property
                MyPropertiesPage myProperty = new MyPropertiesPage();
                myProperty.SearchAPropertySuccessfully(propertyName);

                //Click send request button and go to send request page
                myProperty.SendRequest();

                //Fill out the send request form and save
                SendRequestPage sendRequest = new SendRequestPage();
                sendRequest.AddRequstInformation();
                sendRequest.SaveRequest();

                //Logout from owner account
                DashboardPage dashboard = new DashboardPage();
                dashboard.SignOut();

                //Login as tenant
                LoginPage login = new LoginPage();
                login.LoginSuccessfull(3);

                //Go to Landlord's Request page
                TenantDashboardPage tenantDashboard = new TenantDashboardPage();
                tenantDashboard.GoToLandlordRequestPage();

                
                LandlordRequestPage landlordRequest = new LandlordRequestPage();
                string ActualLandlord = landlordRequest.GetCurrentRequestLandlord();
                string ActualType = landlordRequest.GetCurrentRequestType();
                string ActualMessage = landlordRequest.GetCurrentRequestMessage();

                ExcelLib.PopulateInCollection(Base.ExcelPath, "Send Request");
                string ExpectType = ExcelLib.ReadData(2, "Type");
                string ExpectMessage = ExcelLib.ReadData(2, "Description");
                ExcelLib.PopulateInCollection(Base.ExcelPath, "LoginPage");
                String ExpectLandlord = ExcelLib.ReadData(2, "Owner Name");

                if (ActualLandlord.Equals(ExpectLandlord) & ActualType.Equals(ExpectType) & ActualMessage.Equals(ExpectMessage))
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test passed, successfully send a request to tenant");

                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test failed, fail to send a request to tenant");
                }

            }
        }

    }
}
