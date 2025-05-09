using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using System.CodeDom;
using NexusAppProject.Automation.constanst;
using NexusAppProject.Automation.PageLocator;
using AngleSharp.Css;
using Allure.NUnit;
using System.Collections.ObjectModel;
using Allure.Net.Commons;
using System.Dynamic;
using OpenQA.Selenium.BiDi.Modules.Input;
using OpenQA.Selenium.Interactions;
using static System.Net.Mime.MediaTypeNames;
using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;
using System;
using System.Collections.Generic;
using System.Net;


namespace NexusAppProject.Automation.Utilities
{
    public class CommonBase
    {
        static AndroidDriver driver;
        public int initWait = 30;
        public AndroidDriver OpenApp(String package, String activity, String deviceID, String platformName, String projectName,
                                     Boolean noReset, String deviceName, String uri)
        {
            var options = new AppiumOptions();
            options.AddAdditionalAppiumOption("appium:appPackage", package);
            options.AddAdditionalAppiumOption("appium:appActivity", activity);
            options.AddAdditionalAppiumOption("appium:udid", deviceID);
            options.PlatformName = platformName;
            options.AutomationName = projectName;
            options.AddAdditionalAppiumOption("appium:noReset", noReset);
            options.DeviceName = deviceName;
            var serverUri = new Uri(uri);
            driver = new AndroidDriver(serverUri, options);
            return driver;

        }

        public IWebElement GetElementVisibility(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(initWait));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            return driver.FindElement(locator);
        }
        public ReadOnlyCollection<AppiumElement> GetALlElementVisibility(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(initWait));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
            return driver.FindElements(locator); ;
        }
        public void ClickToElement(By locator)
        {
            IWebElement element = GetElementVisibility(locator);
            element.Click();
        }
        public void SendKeyToElement(By locator, String key)
        {
            IWebElement element = GetElementVisibility(locator);
            element.Clear();
            element.SendKeys(key);
        }
        public void SwipeRightToLeft()
        {
            var screenSize = driver.Manage().Window.Size;

            int startX = (int)(screenSize.Width * 0.9);   // start swiping from right side
            int endX = (int)(screenSize.Width * 0.1);     // swipe left
            int y = (int)(screenSize.Height * 0.4);       // swipe at the center of calendar

            var finger = new PointerInputDevice(PointerKind.Touch);
            var swipe = new ActionSequence(finger, 0);

            swipe.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, startX, y, TimeSpan.Zero));
            swipe.AddAction(finger.CreatePointerDown(0)); 
            swipe.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, endX, y, TimeSpan.FromMilliseconds(500)));
            swipe.AddAction(finger.CreatePointerUp(0));

            driver.PerformActions(new List<ActionSequence> { swipe });
            
        }

        public void CloseKeyBoard()
        {
            driver.HideKeyboard();
        }
        public void Pause(int milisecond)
        {
            try
            {
                Thread.Sleep(milisecond);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
namespace NexusAppProject.Automation.constanst
{
    public class CT_App_Constanst
    {
        public static String PACKAGE = "com.example.babylon_nexus";
        public static String ACTIVITY = "com.example.babylon_nexus.MainActivity";
        public static String DEVICE_ID = "192.168.56.102:5555";
        public static String PLATFORM_NAME = "Android";
        public static String PROJECT_NAME = "UiAutomator2";
        public static String DEVICE_NAME = "Android Device";
        public static Boolean NO_RESET = true;
        public static String URI = "http://127.0.0.1:4723/";
    }
    public class CT_OnboardScreen
    {
        public static String SIGNUP_BTN = "//android.widget.Button[@content-desc=\"Sign up\"]";
        public static String NEW_USER = "//android.view.View[@content-desc=\"New user?\"]";
        public static String LOGIN_BTN = "//android.widget.Button[@content-desc=\"Log in\"]";
    }
    public class CT_HomePage
    {
        public static String USER_LIST_LINK = "//android.widget.ImageView[contains(@content-desc, 'User List')]";
        public static String NOTIFY_LINK = "//android.widget.ImageView[contains(@content-desc, 'Notification')]"; //Notification
        public static String HOME_LINK = "//android.widget.ImageView[contains(@content-desc, 'Home')]"; //Home
        public static String LOGOUT_LINK = "//android.widget.ImageView[contains(@content-desc, 'Logout')]"; // Logout
        public static String LOGOUT_BTN = "//android.widget.Button[@content-desc=\"Logout\"]"; // Logout
        public static String MONTH_TITILE = "//android.view.View[@content-desc]";
        public static String DUE_DATE = "//android.view.View[@content-desc=\"{0}\"]";
        public static String CREATE_NEW_INV_BTN = "//android.widget.Button[@content-desc=\"Create new invoice log\"]";
        public static String INVOICE_NAME = "//android.widget.EditText";
        public static String OCCUPATION_DROPDOWN = "//android.widget.ImageView[@content-desc=\"Choose an occupation\"]";
        public static String OCCUPATION_OPTION = "//android.widget.Button[@content-desc=\"{0}\"]";
        public static String FULLNAME_DROPDOWN = "//android.widget.ImageView[@content-desc=\"Choose a user\"]";
        public static String FULLNAME_OPTION = "//android.view.View[@content-desc=\"{0} {1}\"]"; // EricCatona (dung.pham6+10@sotatek.com)
        public static String SUBMIT_BTN = "//android.widget.Button[@content-desc=\"Submit\"]";
    }
    public class CT_LoginPage
    {
        public static String USERNAME_LABEL = "//android.view.View[@content-desc=\"User name\"]";
        public static String USERNAME_INPUT = "//android.widget.EditText";
        public static String CONTINUE_BTN = "//android.widget.Button[@content-desc=\"Continue\"]";
        public static String PASSCODE_INPUT = "//android.widget.EditText";
    }
    public class CT_SigupPage
    {
        public static String FULLNAME_INPUT = "//android.widget.EditText";
        public static String EMAIL_INPUT = "//android.widget.EditText";
        public static String CONTINUE_BTN = "//android.widget.Button[@content-desc=\"Continue\"]";
        public static String OCCUPATION_RBTN = "//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View/android.widget.RadioButton[2]";
        public static String SIGNUP_BTN = "//android.widget.Button[@content-desc=\"Signup\"]";
        public static String SUCCESSFULLY_CREATE_ACCCOUNT = "//android.view.View[@content-desc=\"Successfully Created Account!\"]";
        public static String EMPTY_EERROR = "//android.view.View[@content-desc=\"This is a required field.\"]";
        public static String LOGIN_BTN = "//android.widget.Button[@content-desc=\"Login\"]";
        public static String INVALID_EMAIL_ERROR = "//android.view.View[@content-desc=\"Email is invalid.\"]";
    }
    public class CT_UserListPage
    {
        public static String FILTER_BTN = "//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View/android.view.View[1]/android.widget.ImageView[1]";
        public static String OCCUPATION_DROPDOWN = "//android.widget.ImageView[@content-desc=\"Occupation\"]";
        public static String OCCUPATION_OPTION = "//android.widget.Button[@content-desc=\"{0}\"]";
        public static String STATUS_DROPDOWN = "//android.widget.ImageView[@content-desc=\"Status\"]";
        public static String STATUS_OPTION = "//android.widget.Button[@content-desc=\"{0}\"]";
        public static String SHOW_RESULTS = "//android.widget.Button[@content-desc=\"Show results\"]";
        public static String RESULTS_OCCUPATION = "//android.view.View[contains(@content-desc, '{0}')]";
        public static String RESULTS_STATUS = "//android.view.View[contains(@content-desc, '{0} {1}')]";
    }

}
namespace NexusAppProject.Automation.PageLocator
{
    public class OnboardPage : NexusAppProject.Automation.Utilities.CommonBase
    {
        public AndroidDriver driver;
        public OnboardPage(AndroidDriver driver)
        {
            this.driver = driver;
        }
        public void AccessSignup()
        {
            ClickToElement(By.XPath(CT_OnboardScreen.SIGNUP_BTN));
        }
        public void AccessLogin()
        {
            ClickToElement(By.XPath(CT_OnboardScreen.LOGIN_BTN));
        }
    }
    public class HomePage : NexusAppProject.Automation.Utilities.CommonBase
    {
        public AndroidDriver driver;
        public HomePage(AndroidDriver _driver)
        {
            this.driver = _driver;
        }
        public void LogoutSuccessfully()
        {
            ClickToElement(By.XPath(CT_HomePage.LOGOUT_LINK));
            ClickToElement(By.XPath(CT_HomePage.LOGOUT_BTN));
        }
        public void AccessUserList()
        {
            ClickToElement(By.XPath(CT_HomePage.USER_LIST_LINK));
            Pause(2000);
        }
        public void SwipeToMonth(String targetMonthYear, int maxSwipes)
        {
            IWebElement currentMonthTitle = GetElementVisibility(By.XPath(CT_HomePage.MONTH_TITILE));
            Console.WriteLine("Current month: " + currentMonthTitle.GetAttribute("content-desc"));
            for (int i = 0; i < maxSwipes; i++)
            {
                // swipe left
                SwipeRightToLeft();

                Thread.Sleep(3000); // wait to update UI
                IWebElement nextMonthTitle = GetElementVisibility(By.XPath(CT_HomePage.MONTH_TITILE));
                Console.WriteLine(nextMonthTitle.GetAttribute("content-desc"));
                if (nextMonthTitle.GetAttribute("content-desc").Contains(targetMonthYear))
                {
                    Console.WriteLine($"Found month: {targetMonthYear}");
                    return;
                }
            }

            throw new Exception($"Not found target month '{targetMonthYear}' after {maxSwipes} times swiping");
        
    }
        public void ChooseDueDateOnCalendarScreen(int duedate)
        {
            String xpath_duedate = String.Format(CT_HomePage.DUE_DATE, duedate);
            ClickToElement(By.XPath(xpath_duedate));
            Pause(2000);
        }
        public void CreatNewInvoiceLog(String invName)
        {
            ClickToElement(By.XPath(CT_HomePage.CREATE_NEW_INV_BTN));
            Pause(2000);
            ClickToElement(By.XPath(CT_HomePage.INVOICE_NAME));
            SendKeyToElement(By.XPath(CT_HomePage.INVOICE_NAME), invName);
            Pause(2000);
        }
        public void ChooseOccupationOnNewInvoiceLog(String occupation)
        {
            ClickToElement(By.XPath(CT_HomePage.OCCUPATION_DROPDOWN));
            String xpath_occupation = String.Format(CT_HomePage.OCCUPATION_OPTION, occupation);
            ClickToElement(By.XPath(xpath_occupation));
            Pause(2000);
        }
        public void ChooseFullnameOnNewInvoiceLog(String name, String email)
        {
            ClickToElement(By.XPath(CT_HomePage.FULLNAME_DROPDOWN));
            String xpath_fullname = String.Format(CT_HomePage.FULLNAME_OPTION, name, email);
            ClickToElement(By.XPath(xpath_fullname));
            Pause(2000);
        }
        public void SubmitNewInvoiceLog()
        {
            ClickToElement(By.XPath(CT_HomePage.SUBMIT_BTN));
        }
    }
    public class LoginPage : NexusAppProject.Automation.Utilities.CommonBase

    {
        public AndroidDriver driver;
        public LoginPage(AndroidDriver _driver)
        {
            this.driver = _driver;
        }
        public void LoginWithEmailAndPassCode(String username, String passcode)
        {
            // enter user name
            ClickToElement(By.XPath(CT_LoginPage.USERNAME_INPUT));
            SendKeyToElement(By.XPath(CT_LoginPage.USERNAME_INPUT), username);
            ClickToElement(By.XPath(CT_LoginPage.CONTINUE_BTN));
            Pause(1000);
            //enter passcode
            ClickToElement(By.XPath(CT_LoginPage.PASSCODE_INPUT));
            SendKeyToElement(By.XPath(CT_LoginPage.PASSCODE_INPUT), passcode);
            ClickToElement(By.XPath(CT_LoginPage.CONTINUE_BTN));
            Pause(1000);
        }
    }
    public class SignUpPage : Automation.Utilities.CommonBase
    {
        public AndroidDriver driver;
        public SignUpPage(AndroidDriver _driver)
        {
            this.driver = _driver;
        }
        public void SignupFullName(String fullName)
        {
            ClickToElement(By.XPath(CT_SigupPage.FULLNAME_INPUT));
            SendKeyToElement(By.XPath(CT_SigupPage.FULLNAME_INPUT), fullName);
            ClickToElement(By.XPath(CT_SigupPage.CONTINUE_BTN));
            Pause(3000);
        }
        public void SignupEmail(String email)
        {
            ClickToElement(By.XPath(CT_SigupPage.EMAIL_INPUT));
            SendKeyToElement(By.XPath(CT_SigupPage.EMAIL_INPUT), email);
            ClickToElement(By.XPath(CT_SigupPage.CONTINUE_BTN));
            Pause(3000);
        }

        public void SignupOccupation(String occupationIndex)
        {

            ClickToElement(By.XPath(CT_SigupPage.OCCUPATION_RBTN));
            ClickToElement(By.XPath(CT_SigupPage.SIGNUP_BTN));
            Pause(2000);
        }
    }
    public class UserListPage : NexusAppProject.Automation.Utilities.CommonBase
    {
        public AndroidDriver driver;
        public UserListPage(AndroidDriver driver)
        {
            this.driver = driver;
        }
        public void AccessFilterPopup()
        {
            ClickToElement(By.XPath(CT_UserListPage.FILTER_BTN));
            Pause(2000);
        }
        public void ChooseOccupation(String occupation)
        {
            String xpath_occupation = String.Format(CT_UserListPage.OCCUPATION_OPTION, occupation);
            ClickToElement(By.XPath(CT_UserListPage.OCCUPATION_DROPDOWN));
            ClickToElement(By.XPath(xpath_occupation));
            Pause(2000);
        }
        public void ChooseBankerOccupation(String occupation)
        {
            String xpath_occupation = String.Format(CT_UserListPage.OCCUPATION_OPTION, occupation);
            ClickToElement(By.XPath(CT_UserListPage.OCCUPATION_DROPDOWN));
            ScrollToBankerOccupation(occupation);
            ClickToElement(By.XPath(xpath_occupation));
            Pause(2000);
        }
        public void ScrollToBankerOccupation(string occupation)
        {
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    string xpath = string.Format(CT_UserListPage.OCCUPATION_OPTION, occupation);
                    var element = driver.FindElement(By.XPath(xpath));
                    if (element.Displayed)
                    {
                        Console.WriteLine($"Found element: {element.GetAttribute("content-desc")}");
                        return;
                    }
                }
                catch (NoSuchElementException)
                {
                    var scrollArgs = new Dictionary<string, object>
                    {
                        ["strategy"] = "accessibility id",  // Hoặc "text" nếu không dùng content-desc
                        ["selector"] = occupation,
                        ["maxSwipes"] = 1
                    };
                    driver.ExecuteScript("mobile: scroll", scrollArgs);
                    Thread.Sleep(500);
                }
            }

            throw new Exception($"Element with occupation '{occupation}' not found after scrolling.");
        }
        public void ChooseStatus(String status)
        {
            String xpath_status = String.Format(CT_UserListPage.STATUS_OPTION, status);
            ClickToElement(By.XPath(CT_UserListPage.STATUS_DROPDOWN));
            ClickToElement(By.XPath(xpath_status));
            Pause(2000);
        }
        public void ShowResults()
        {
            ClickToElement(By.XPath(CT_UserListPage.SHOW_RESULTS));
            Pause(2000);
        }
        public Boolean VerifyOnlyThisOccupationShown(String occupation)
        {
            String xpath_result = String.Format(CT_UserListPage.RESULTS_OCCUPATION, occupation);
            ReadOnlyCollection<AppiumElement> list = GetALlElementVisibility(By.XPath(xpath_result));
            foreach (var item in list)
            {
                Console.WriteLine(item.GetAttribute("content-desc"));
                if (!item.GetAttribute("content-desc").Contains(occupation))
                {
                    return false;
                }
            }
            return true;
        }
        public Boolean VerifyOnlyThisStatusShown(String status)
        {
            String xpath_result = String.Format(CT_UserListPage.RESULTS_STATUS, status);
            ReadOnlyCollection<AppiumElement> list = GetALlElementVisibility(By.XPath(xpath_result));
            foreach (var item in list)
            {
                Console.WriteLine(item.GetAttribute("content-desc"));
                if (!item.GetAttribute("content-desc").Contains(status))
                {
                    Console.WriteLine(item.Text);
                    return false;
                }
            }
            return true;
        }
        public Boolean VerifyOnlyThisOccupationAndStatusShown(String occupation, String status)
        {
            String xpath_result = String.Format(CT_UserListPage.RESULTS_STATUS, status);
            ReadOnlyCollection<AppiumElement> list = GetALlElementVisibility(By.XPath(xpath_result));
            foreach (var item in list)
            {
                Console.WriteLine(item.GetAttribute("content-desc"));
                if (!item.GetAttribute("content-desc").Contains(occupation) && !item.Text.Contains(status))
                {
                    return false;
                }
            }

            return true;
        }
    }
}

namespace NexusAppProject.Automation.TestSuite
{
    [AllureNUnit]
    public class TestLogin : NexusAppProject.Automation.Utilities.CommonBase
    {
        public AndroidDriver driver;
        [SetUp]
        public void InitApp()
        {
            driver = OpenApp(CT_App_Constanst.PACKAGE, CT_App_Constanst.ACTIVITY, CT_App_Constanst.DEVICE_ID, CT_App_Constanst.PLATFORM_NAME,
                             CT_App_Constanst.PROJECT_NAME, CT_App_Constanst.NO_RESET, CT_App_Constanst.DEVICE_NAME, CT_App_Constanst.URI);
            OnboardPage onboard = new OnboardPage(driver);
            onboard.AccessLogin();
        }
        [Test]
        [Order(1)]
        public void Login_Successfully_1()
        {
            LoginPage login = new LoginPage(driver);
            login.LoginWithEmailAndPassCode("dung.pham6@sotatek.com", "123456");

        }
        [Test]
        [Order(2)]
        public void Login_Successfully_2()
        {
            LoginPage login = new LoginPage(driver);
            login.LoginWithEmailAndPassCode("dung.pham6+10@sotatek.com", "123456");

        }
        [TearDown]
        public void QuitApp()
        {
            HomePage home = new HomePage(driver);
            home.LogoutSuccessfully();
            driver.TerminateApp(CT_App_Constanst.PACKAGE);
        }
    }
    public class TestSignUp : NexusAppProject.Automation.Utilities.CommonBase
    {
        public AndroidDriver driver;
        public String nameUser = "Viet dung";
        public String nameEmail = "dung.pham6";
        public int index = 10005;
        public String domain = "@sotatek.com";
        public String email = "dung.pham6+10005@sotatek.com";

        [SetUp]
        public void InitApp()
        {
            driver = OpenApp(CT_App_Constanst.PACKAGE, CT_App_Constanst.ACTIVITY, CT_App_Constanst.DEVICE_ID, CT_App_Constanst.PLATFORM_NAME,
                            CT_App_Constanst.PROJECT_NAME, CT_App_Constanst.NO_RESET, CT_App_Constanst.DEVICE_NAME, CT_App_Constanst.URI);
            OnboardPage onboard = new OnboardPage(driver);
            onboard.AccessSignup();

        }
        [Test]
        [Order(1)]
        public void SignupSuccessfully_1()
        {
            SignUpPage signUp = new SignUpPage(driver);
            signUp.SignupFullName(nameUser);
            signUp.SignupEmail(email);
            signUp.SignupOccupation("2");
            // 2: builder
            Assert.That(GetElementVisibility(By.XPath(CT_SigupPage.SUCCESSFULLY_CREATE_ACCCOUNT)).Displayed, Is.True);


        }
        [Test]
        [Order(2)]
        public void SignupWithEmptyFullName()
        {
            SignUpPage signup = new SignUpPage(driver);
            signup.SignupFullName("");
            Assert.That(GetElementVisibility(By.XPath(CT_SigupPage.EMPTY_EERROR)).Displayed, Is.True);
        }
        [Test]
        [Order(3)]
        public void SignuoWithEmptyEmail()
        {
            SignUpPage signup = new SignUpPage(driver);
            signup.SignupFullName("Viet Dung");
            signup.SignupEmail("");
            Assert.That(GetElementVisibility(By.XPath(CT_SigupPage.EMPTY_EERROR)).Displayed, Is.True);
        }
        [Test]
        [Order(4)]
        public void SignUp_InvalidEmail_1()
        {
            SignUpPage signup = new SignUpPage(driver);
            signup.SignupFullName("Viet Dung");
            signup.SignupEmail("dung.pham6+2000sotatek.com");
            Assert.That(GetElementVisibility(By.XPath(CT_SigupPage.INVALID_EMAIL_ERROR)).Displayed, Is.True);
        }
        [Test]
        [Order(5)]
        public void SignUp_InvalidEmail_2()
        {
            SignUpPage signup = new SignUpPage(driver);
            signup.SignupFullName("Viet Dung");
            signup.SignupEmail("dung.pham6+2000@sotatek");
            Assert.That(GetElementVisibility(By.XPath(CT_SigupPage.INVALID_EMAIL_ERROR)).Displayed, Is.True);
        }
        [Test]
        [Order(6)]
        public void SignUp_InvalidEmail_3()
        {
            SignUpPage signup = new SignUpPage(driver);
            signup.SignupFullName("Viet Dung");
            signup.SignupEmail("dung.pham6+2000");
            Assert.That(GetElementVisibility(By.XPath(CT_SigupPage.INVALID_EMAIL_ERROR)).Displayed, Is.True);
        }
        [Test]
        [Order(7)]
        public void SignUp_InvalidEmail_4()
        {
            SignUpPage signup = new SignUpPage(driver);
            signup.SignupFullName("Viet Dung");
            signup.SignupEmail("dung.pham6+2000@@sotatek");
            Assert.That(GetElementVisibility(By.XPath(CT_SigupPage.INVALID_EMAIL_ERROR)).Displayed, Is.True);
        }
        [Test]
        [Order(7)]
        public void SignUp_InvalidEmail_5()
        {
            SignUpPage signup = new SignUpPage(driver);
            signup.SignupFullName("Viet Dung");
            signup.SignupEmail("dung.pham6+2000!@sotatek");
            Assert.That(GetElementVisibility(By.XPath(CT_SigupPage.INVALID_EMAIL_ERROR)).Displayed, Is.True);
        }
        [TearDown]
        public void QuitApp()
        {

            driver.TerminateApp(CT_App_Constanst.PACKAGE);
        }

    }
    public class TestFilterUserByAdmin : NexusAppProject.Automation.Utilities.CommonBase
    {
        public AndroidDriver driver;
        public String fullname = "admin@nexus.com";
        public String passcode = "123456";
        String builder = "Builder";
        String electrician = "Electrician";
        String construction = "Construction";
        String contractor = "Contractor";
        String banker = "Banker";
        String signup = "Signup";
        String registered = "Registered";
        String deleted = "Deleted";

        // Signup, Registered, Deleted
        // Builder , Electrician, Construction, Contractor, Banker
        [SetUp]
        public void InitApp()
        {
            driver = OpenApp(CT_App_Constanst.PACKAGE, CT_App_Constanst.ACTIVITY, CT_App_Constanst.DEVICE_ID, CT_App_Constanst.PLATFORM_NAME,
                            CT_App_Constanst.PROJECT_NAME, CT_App_Constanst.NO_RESET, CT_App_Constanst.DEVICE_NAME, CT_App_Constanst.URI);
            OnboardPage onboard = new OnboardPage(driver);
            onboard.AccessLogin();
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginWithEmailAndPassCode(fullname, passcode);
            HomePage homePage = new HomePage(driver);
            homePage.AccessUserList();
        }
        [Test]
        [Order(1)]
        public void FilterByOccupation_Builer()
        {
            UserListPage userList = new UserListPage(driver);
            userList.AccessFilterPopup();
            userList.ChooseOccupation(builder);
            userList.ShowResults();
            Assert.That(userList.VerifyOnlyThisOccupationShown(builder), Is.True);
        }
        [Test]
        [Order(2)]
        public void FilterByOccpation_Electrician()
        {
            UserListPage userList = new UserListPage(driver);
            userList.AccessFilterPopup();
            userList.ChooseOccupation(electrician);
            userList.ShowResults();
            Assert.That(userList.VerifyOnlyThisOccupationShown(electrician), Is.True);
        }
        [Test]
        [Order(3)]
        public void FilterByOccpation_Construction()
        {
            UserListPage userList = new UserListPage(driver);
            userList.AccessFilterPopup();
            userList.ChooseOccupation(construction);
            userList.ShowResults();
            Assert.That(userList.VerifyOnlyThisOccupationShown(construction), Is.True);
        }
        [Test]
        [Order(4)]
        public void FilterByOccpation_Contractor()
        {
            UserListPage userList = new UserListPage(driver);
            userList.AccessFilterPopup();
            userList.ChooseOccupation(contractor);
            userList.ShowResults();
            Assert.That(userList.VerifyOnlyThisOccupationShown(contractor), Is.True);
        }
        [Test]
        [Order(5)]
        public void FilterByOccpation_Banker()
        {
            UserListPage userList = new UserListPage(driver);
            userList.AccessFilterPopup();
            userList.ChooseOccupation(banker);
            userList.ShowResults();
            Assert.That(userList.VerifyOnlyThisOccupationShown(banker), Is.True);
        }
        [Test]
        [Order(6)]
        public void FilterByStatus_Signup()
        {
            UserListPage userList = new UserListPage(driver);
            userList.AccessFilterPopup();
            userList.ChooseStatus(signup);
            userList.ShowResults();
            Assert.That(userList.VerifyOnlyThisStatusShown(signup), Is.True);
        }
        [Test]
        [Order(7)]
        public void FilterByStatus_Registered()
        {
            UserListPage userList = new UserListPage(driver);
            userList.AccessFilterPopup();
            userList.ChooseStatus(registered);
            userList.ShowResults();
            Assert.That(userList.VerifyOnlyThisStatusShown(registered), Is.True);
            Pause(5000);
        }
        [Test]
        [Order(8)]
        public void FilterByStatus_Deleted()
        {
            UserListPage userList = new UserListPage(driver);
            userList.AccessFilterPopup();
            userList.ChooseStatus(deleted);
            userList.ShowResults();
            Assert.That(userList.VerifyOnlyThisStatusShown(deleted), Is.True);
            Pause(5000);
        }
        [Test]
        [Order(9)]
        public void Filter_BuilderAndSignup()
        {
            UserListPage userList = new UserListPage(driver);
            userList.AccessFilterPopup();
            userList.ChooseOccupation(builder);
            userList.ChooseStatus(signup);
            userList.ShowResults();
            Assert.That(userList.VerifyOnlyThisOccupationAndStatusShown(builder, signup), Is.True);
            Pause(5000);
        }
        [Test]
        [Order(10)]
        public void Filter_BuilderAndRegistered()
        {
            UserListPage userList = new UserListPage(driver);
            userList.AccessFilterPopup();
            userList.ChooseOccupation(builder);
            userList.ChooseStatus(registered);
            userList.ShowResults();
            Assert.That(userList.VerifyOnlyThisOccupationAndStatusShown(builder, registered), Is.True);
            Pause(5000);
        }
        [Test]
        [Order(11)]
        public void Filter_BuilderAndDeleted()
        {
            UserListPage userList = new UserListPage(driver);
            userList.AccessFilterPopup();
            userList.ChooseOccupation(builder);
            userList.ChooseStatus(deleted);
            userList.ShowResults();
            Assert.That(userList.VerifyOnlyThisOccupationAndStatusShown(builder, deleted), Is.True);
            Pause(5000);
        }
        [Test]
        [Order(12)]
        public void Filter_ElectricianAndSignup()
        {
            UserListPage userList = new UserListPage(driver);
            userList.AccessFilterPopup();
            userList.ChooseOccupation(electrician);
            userList.ChooseStatus(signup);
            userList.ShowResults();
            Assert.That(userList.VerifyOnlyThisOccupationAndStatusShown(electrician, signup), Is.True);
            Pause(5000);
        }
        [Test]
        [Order(13)]
        public void Filter_ElectricianAndRegistered()
        {
            UserListPage userList = new UserListPage(driver);
            userList.AccessFilterPopup();
            userList.ChooseOccupation(electrician);
            userList.ChooseStatus(registered);
            userList.ShowResults();
            Assert.That(userList.VerifyOnlyThisOccupationAndStatusShown(electrician, registered), Is.True);
            Pause(5000);
        }
        [Test]
        [Order(14)]
        public void Filter_ElectricianAndDeleted()
        {
            UserListPage userList = new UserListPage(driver);
            userList.AccessFilterPopup();
            userList.ChooseOccupation(electrician);
            userList.ChooseStatus(deleted);
            userList.ShowResults();
            Assert.That(userList.VerifyOnlyThisOccupationAndStatusShown(electrician, deleted), Is.True);
            Pause(5000);
        }
        [Test]
        [Order(15)]
        public void Filter_ConstructionAndSignup()
        {
            UserListPage userList = new UserListPage(driver);
            userList.AccessFilterPopup();
            userList.ChooseOccupation(construction);
            userList.ChooseStatus(signup);
            userList.ShowResults();
            Assert.That(userList.VerifyOnlyThisOccupationAndStatusShown(construction, signup), Is.True);
            Pause(5000);
        }
        [Test]
        [Order(16)]
        public void Filter_ConstructionAndRegistered()
        {
            UserListPage userList = new UserListPage(driver);
            userList.AccessFilterPopup();
            userList.ChooseOccupation(construction);
            userList.ChooseStatus(registered);
            userList.ShowResults();
            Assert.That(userList.VerifyOnlyThisOccupationAndStatusShown(construction, registered), Is.True);
            Pause(5000);
        }
        [Test]
        [Order(17)]
        public void Filter_ConstructionAndDeleted()
        {
            UserListPage userList = new UserListPage(driver);
            userList.AccessFilterPopup();
            userList.ChooseOccupation(construction);
            userList.ChooseStatus(deleted);
            userList.ShowResults();
            Assert.That(userList.VerifyOnlyThisOccupationAndStatusShown(construction, deleted), Is.True);
            Pause(5000);
        }
        [Test]
        [Order(18)]
        public void Filter_ContractorAndSignup()
        {
            UserListPage userList = new UserListPage(driver);
            userList.AccessFilterPopup();
            userList.ChooseOccupation(contractor);
            userList.ChooseStatus(signup);
            userList.ShowResults();
            Assert.That(userList.VerifyOnlyThisOccupationAndStatusShown(contractor, signup), Is.True);
            Pause(5000);
        }
        [Test]
        [Order(19)]
        public void Filter_ContractorAndRegistered()
        {
            UserListPage userList = new UserListPage(driver);
            userList.AccessFilterPopup();
            userList.ChooseOccupation(contractor);
            userList.ChooseStatus(registered);
            userList.ShowResults();
            Assert.That(userList.VerifyOnlyThisOccupationAndStatusShown(contractor, registered), Is.True);
            Pause(5000);
        }
        [Test]
        [Order(20)]
        public void Filter_ContractorAndDeleted()
        {
            UserListPage userList = new UserListPage(driver);
            userList.AccessFilterPopup();
            userList.ChooseOccupation(contractor);
            userList.ChooseStatus(deleted);
            userList.ShowResults();
            Assert.That(userList.VerifyOnlyThisOccupationAndStatusShown(contractor, deleted), Is.True);
            Pause(5000);
        }
        [Test]
        [Order(21)]
        public void Filter_BankerAndSignup()
        {
            UserListPage userList = new UserListPage(driver);
            userList.AccessFilterPopup();
            userList.ChooseBankerOccupation(banker);
            userList.ChooseStatus(signup);
            userList.ShowResults();
            Assert.That(userList.VerifyOnlyThisOccupationAndStatusShown(banker, signup), Is.True);
            Pause(5000);
        }
        [Test]
        [Order(22)]
        public void Filter_BankerAndRegistered()
        {
            UserListPage userList = new UserListPage(driver);
            userList.AccessFilterPopup();
            userList.ChooseBankerOccupation(banker);
            userList.ChooseStatus(registered);
            userList.ShowResults();
            Assert.That(userList.VerifyOnlyThisOccupationAndStatusShown(banker, registered), Is.True);
            Pause(5000);
        }
        [Test]
        [Order(23)]
        public void Filter_BankerAndDeleted()
        {
            UserListPage userList = new UserListPage(driver);
            userList.AccessFilterPopup();
            userList.ChooseBankerOccupation(banker);
            userList.ChooseStatus(deleted);
            userList.ShowResults();
            Assert.That(userList.VerifyOnlyThisOccupationAndStatusShown(banker, deleted), Is.True);
            Pause(5000);
        }
        [TearDown]
        public void QuitApp()
        {
            HomePage homePage = new HomePage(driver);
            homePage.LogoutSuccessfully();
            driver.TerminateApp(CT_App_Constanst.PACKAGE);
        }

    }
    public class TestHomeCaLendar : NexusAppProject.Automation.Utilities.CommonBase
    {
        public AndroidDriver driver;
        public String payeeEmail = "dung.pham6@sotatek.com";
        public String passcode = "123456";
        public String payorEmail = "dung.pham6+10@sotatek.com";
        [SetUp]
        public void InitApp()
        {
            driver = OpenApp(CT_App_Constanst.PACKAGE, CT_App_Constanst.ACTIVITY, CT_App_Constanst.DEVICE_ID, CT_App_Constanst.PLATFORM_NAME,
                            CT_App_Constanst.PROJECT_NAME, CT_App_Constanst.NO_RESET, CT_App_Constanst.DEVICE_NAME, CT_App_Constanst.URI);
            OnboardPage onboard = new OnboardPage(driver);
            onboard.AccessLogin();
        }
        [Test]
        public void CreateInvoiceLogSuccessfully()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginWithEmailAndPassCode(payeeEmail, passcode);
            
            HomePage home = new HomePage(driver);
            home.SwipeToMonth("January 2026", 8);
            home.ChooseDueDateOnCalendarScreen(20);
            home.CreatNewInvoiceLog("TestAutomation-01");
            home.ChooseOccupationOnNewInvoiceLog("Builder");
            home.ChooseFullnameOnNewInvoiceLog("EricCatona", "(dung.pham6+10@sotatek.com)"); // EricCatona (dung.pham6+10@sotatek.com)
            home.SubmitNewInvoiceLog();

        }
        [TearDown]
        public void QuitApp()
        {
            HomePage home = new HomePage(driver);
            home.LogoutSuccessfully();
            driver.TerminateApp(CT_App_Constanst.PACKAGE);
        }

    }
}

