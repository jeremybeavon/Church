using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Church.Data;
using Church.Web;
using Church.Web.Identity;

namespace Church.UnitTests.Web
{
    [TestClass]
    public sealed class IdentityExtensionsTests : MockTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAsUserReferenceThrowsArgumentExceptionIfIdentityParameterIsNotClaimsIdentity()
        {
            IdentityExtensions.AsUserReference(CreateMock<IIdentity>().Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ClaimNotFoundException))]
        public void TestAsUserReferenceThrowsClaimNotFoundExceptionIfIdentityDoesNotContainUserIdClaim()
        {
            // Arrange
            ClaimsIdentity identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(ChurchClaims.FullName, "Test User"));

            // Act
            IdentityExtensions.AsUserReference(identity);
        }

        [TestMethod]
        [ExpectedException(typeof(ClaimNotFoundException))]
        public void TestAsUserReferenceThrowsClaimNotFoundExceptionIfIdentityDoesNotContainFullNameClaim()
        {
            // Arrange
            ClaimsIdentity identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(ChurchClaims.UserId, "UserId"));

            // Act
            IdentityExtensions.AsUserReference(identity);
        }

        [TestMethod]
        public void TestAsUserReferenceReturnsValidUserReference()
        {
            // Arrange
            ClaimsIdentity identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(ChurchClaims.UserId, "UserId"));
            identity.AddClaim(new Claim(ChurchClaims.FullName, "Test User"));

            // Act
            UserReference userReference = IdentityExtensions.AsUserReference(identity);

            // Assert
            userReference.Should().NotBeNull();
            userReference.Id.Should().Be("UserId");
            userReference.Name.Should().Be("Test User");
        }
    }
}
