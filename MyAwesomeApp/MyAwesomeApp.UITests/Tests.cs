using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

namespace MyAwesomeApp.UITests
{
    [TestFixture(Platform.Android)]
    public class Tests
    {
        IApp app;
        Platform _platform;

        public Tests(Platform platform)
        {
            _platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(_platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void LoginButtonIsDisabledOnAppStart()
        {
            var loginButton = app.WaitForElement("LoginPage.LoginButton")
                .FirstOrDefault();

            app.Screenshot("LoginButtonIsDisabledOnAppStart");

            Assert.IsFalse(loginButton.Enabled);
        }

        [Test]
        public void LoginButtonIsDisabledIfOnlyUsernameIsProvided()
        {
            app.Screenshot("LoginButtonIsDisabledIfOnlyUsernameIsProvided-1");

            app.WaitForElement("LoginPage.UsernameEntry");

            app.EnterText("LoginPage.UsernameEntry", "myuser");

            var loginButton = app.WaitForElement("LoginPage.LoginButton").FirstOrDefault();

            app.Screenshot("LoginButtonIsDisabledIfOnlyUsernameIsProvided-2");

            Assert.IsFalse(loginButton.Enabled);
        }

        [Test]
        public void LoginButtonIsDisabledIfOnlyPasswordIsProvided()
        {
            app.Screenshot("LoginButtonIsDisabledIfOnlyPasswordIsProvided-1");

            app.WaitForElement("LoginPage.PasswordEntry");

            app.EnterText("LoginPage.PasswordEntry", "myuser");

            var loginButton = app.WaitForElement("LoginPage.LoginButton").FirstOrDefault();

            app.Screenshot("LoginButtonIsDisabledIfOnlyPasswordIsProvided-2");

            Assert.IsFalse(loginButton.Enabled);
        }

        [Test]
        public void LoginButtonIsEnabledIfUsernameAndPasswordAreProvided()
        {
            app.Screenshot("LoginButtonIsEnabledIfUsernameAndPasswordAreProvided-1");

            app.WaitForElement("LoginPage.UsernameEntry").FirstOrDefault();
            app.EnterText("LoginPage.UsernameEntry", "myuser");

            app.Screenshot("LoginButtonIsEnabledIfUsernameAndPasswordAreProvided-2");

            app.WaitForElement("LoginPage.PasswordEntry").FirstOrDefault();
            app.EnterText("LoginPage.PasswordEntry", "myuser");

            var loginButton = app.WaitForElement("LoginPage.LoginButton")
                .FirstOrDefault();

            app.Screenshot("LoginButtonIsEnabledIfUsernameAndPasswordAreProvided-3");

            Assert.IsTrue(loginButton.Enabled);
        }

        [Test]
        public void MainPageIsShownAfterSuccessfulLogin()
        {
            app.Screenshot("MainPageIsShownAfterSuccessfulLogin-1");

            app.WaitForElement("LoginPage.UsernameEntry").FirstOrDefault();
            app.EnterText("LoginPage.UsernameEntry", "myuser");

            app.Screenshot("MainPageIsShownAfterSuccessfulLogin-2");

            app.WaitForElement("LoginPage.PasswordEntry").FirstOrDefault();
            app.EnterText("LoginPage.PasswordEntry", "myuser");

            app.Screenshot("MainPageIsShownAfterSuccessfulLogin-3");

            app.WaitForElement("LoginPage.LoginButton").FirstOrDefault();

            app.Tap("LoginPage.LoginButton");

            app.WaitForElement("MainPage.WelcomeLabel");
        }
    }
}
