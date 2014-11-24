using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainAspects;
using Church.Data;
using Church.DataAccess.RavenDb;
using Church.IntegrationTests.Pages;
using FluentAssertions;
using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Raven.Client;
using Raven.Client.Embedded;
using Zombie.Net;

namespace Church.IntegrationTests
{
    [TestClass]
    [Serializable]
    public sealed class LoginTests
    {
        [NonSerialized]
        private IDocumentStore documentStore;

        [TestInitialize]
        [RunInDifferentAppDomain]
        public void SetUp()
        {
            documentStore = new EmbeddableDocumentStore()
            {
                Configuration =
                {
                    RunInMemory = true
                }
            };
            documentStore.Initialize();
            AbstractDataAccess.Store = documentStore;
        }

        [TestCleanup]
        [RunInDifferentAppDomain]
        public void TearDown()
        {
            documentStore.Dispose();
            AbstractDataAccess.Store = null;
        }

        [TestMethod]
        [RunInDifferentAppDomain]
        public void TestSuccessfulLogin()
        {
            // Arrange
            IDocumentSession session = documentStore.OpenSession();
            User user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FullName = "Test User",
                UserName = "TestUser",
                PasswordHash = new PasswordHasher().HashPassword("test")
            };
            session.Store(user);
            session.SaveChanges();

            // Act
            string hash = null;
            string title = null;
            ((Func<Task>)(async () =>
            {
                Browser browser = await BrowserFactory.CreateAsync();
                await browser.VisitAsync(new Uri("https://localhost.test/"));
                await browser.FillAsync(LoginPage.UserName, "TestUser");
                await browser.FillAsync(LoginPage.Password, "test");
                await browser.PressButtonAsync(LoginPage.LogInButton);
                hash = await (await browser.GetLocationAsync()).GetHashAsync();
                title = await browser.TextAsync(LoginPage.Title);
            }))().Wait();

            // Assert
            hash.Should().NotBeNull();
            hash.ToLower().Should().Contain("private");
        }

        [TestMethod]
        [RunInDifferentAppDomain]
        public void TestLoginFailedMessageIsVisibleWhenLoginIsUnsuccessful()
        {
            // Act
            Element element = null;
            ((Func<Task>)(async () =>
            {
                Browser browser = await BrowserFactory.CreateAsync();
                await browser.VisitAsync(new Uri("https://localhost.test/"));
                await browser.FillAsync(LoginPage.UserName, "TestUser");
                await browser.FillAsync(LoginPage.Password, "test");
                await browser.PressButtonAsync(LoginPage.LogInButton);
                element = await browser.QueryAsync("#loginFailedMessage");
            }))().Wait();

            // Assert
            element.Should().NotBeNull();
        }
    }
}
