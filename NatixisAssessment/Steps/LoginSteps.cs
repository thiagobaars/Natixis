using System;
using TechTalk.SpecFlow;
using System.Threading;
using NatixisAssessment.Hooks;
using NatixisAssessment.PageObjects;

namespace NatixisAssessment.Steps
{
    [Binding]
    public sealed class LoginSteps
    {
        private readonly LoginPageObject _loginPageObject;

        public LoginSteps()
        {
            _loginPageObject = new LoginPageObject(Hooks.Hooks.getDriver());
        }

        [Given(@"I acess the url of aplication")]
        public void GivenIAcessTheUrlOfAplication()
        {
            _loginPageObject.AcessarUrl();
        }

        [Given(@"I fill the the fields Login and Password with the values '([^']*)' and '([^']*)'")]
        public void GivenIFillTheTheFieldsLoginAndPasswordWithTheValuesAnd(string user, string password)
        {
            _loginPageObject.EnterUsername(user);
            _loginPageObject.EnterPassword(password);
        }

        [When(@"I click to the button Login")]
        public void WhenIClickToTheButton()
        {
            _loginPageObject.ClickLogin();
        }

        [Then(@"the homepage must be shown")]
        public void ThenTheHomepageMustBeShown()
        {
            _loginPageObject.ValidarLogin();
        }

    }
}
