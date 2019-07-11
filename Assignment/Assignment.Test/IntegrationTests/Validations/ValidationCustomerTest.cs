using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Services.Customers;
using Xunit;

namespace Assignment.Test.IntegrationTests.Validations
{
    public class ValidationCustomerTest
    {
        [Fact]
        public void Validation_CustomerID_Should_MoreThanZero()
        {
            var service = new CustomerValidationService();
            int value = 1;
            var result = service.IsValidationId(value);
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validation_CustomerID_ShouldNotAllow_Zero()
        {
            var service = new CustomerValidationService();
            int value = 0;
            var result = service.IsValidationId(value);
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validation_CustomerID_ShouldNotAllow_Negative()
        {
            var service = new CustomerValidationService();
            int value = -1;
            var result = service.IsValidationId(value);
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validation_Email_NoInquiryCriteria()
        {
            var service = new CustomerValidationService();
            string value = null;
            string errorMessage = "";
            var result = service.IsValidationEmail(value);
            foreach (var error in result.Errors)
            {
                errorMessage = error.ErrorMessage;
            }
            Assert.False(result.IsValid);
            Assert.Equal("No inquiry criteria", errorMessage);
        }

        [Fact]
        public void Validation_Email_FormatNoTCorrect()
        {
            var service = new CustomerValidationService();
            string value = "test";
            string errorMessage = "";
            var result = service.IsValidationEmail(value);
            foreach (var error in result.Errors)
            {
                errorMessage = error.ErrorMessage;
            }
            Assert.False(result.IsValid);
            Assert.Equal("Invalid Email", errorMessage);
        }

        [Fact]
        public void Validation_Email_FormatIsCorrect()
        {
            var service = new CustomerValidationService();
            string value = "test@gmail.com";
            var result = service.IsValidationEmail(value);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validation_IDandEmail_Data_IsCorrect()
        {
            var service = new CustomerValidationService();
            int valueID = 1;
            string valueEmail = "test@gmail.com";
            var result = service.IsValidationIdAndEmail(valueID, valueEmail);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validation_IDandEmail_DataBoth_IsNotCorrect()
        {
            var service = new CustomerValidationService();
            int valueID = 0;
            string valueEmail = "test", messageErrorId = "", messageErrorEmail = "";
            var result = service.IsValidationIdAndEmail(valueID, valueEmail);
            foreach (var error in result.Errors)
            {
                if (error.PropertyName == "id")
                    messageErrorId = error.ErrorMessage;

                if (error.PropertyName == "email")
                    messageErrorEmail = error.ErrorMessage;
            }
            Assert.False(result.IsValid);
            Assert.Equal("Invalid Customer ID", messageErrorId);
            Assert.Equal("Invalid Email", messageErrorEmail);
        }

        [Fact]
        public void Validation_IDandEmail_Email_NotFillIn()
        {
            var service = new CustomerValidationService();
            int valueID = 1;
            string valueEmail =null, messageErrorId = "", messageErrorEmail = "";
            var result = service.IsValidationIdAndEmail(valueID, valueEmail);
            foreach (var error in result.Errors)
            {
                if (error.PropertyName == "id")
                    messageErrorId = error.ErrorMessage;

                if (error.PropertyName == "email")
                    messageErrorEmail = error.ErrorMessage;
            }
            Assert.False(result.IsValid);
            Assert.NotEqual("Invalid Customer ID", messageErrorId);
            Assert.Equal("No inquiry criteria", messageErrorEmail);
        }
    }
}
