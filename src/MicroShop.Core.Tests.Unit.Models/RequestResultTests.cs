using MicroShop.Core.Models.Requests;
using MicroShop.Core.Errors;
using FluentAssertions;
using System.Net;

namespace MicroShop.Core.Tests.Unit.Models
{
    public class RequestResultTests
    {
        private class TestErrors : Error
        {
            public static readonly Error BASIC_ERROR = new BasicError();

            public static readonly Error PARAMETRIZED_ERROR = new ParametrizedError();

            public TestErrors(string name, int value) : base(name, value)
            {
            }

            public override HttpStatusCode HttpStatusCode { get; }

            private sealed class BasicError : Error
            {
                public override HttpStatusCode HttpStatusCode => HttpStatusCode.BadRequest;

                public BasicError() : base(nameof(BASIC_ERROR), 10001)
                {
                    Message = "This is basic error.";
                }
            }

            private sealed class ParametrizedError : Error
            {
                public override HttpStatusCode HttpStatusCode => HttpStatusCode.BadRequest;

                public ParametrizedError() : base(nameof(PARAMETRIZED_ERROR), 10002)
                {
                    Message = "This is parametrized error: {0}";
                }
            }
        }

        [Fact]
        public void RequestResult_BasicFailureTest()
        {
            //Arrange

            var error = TestErrors.BASIC_ERROR;

            //Act

            var requestResult = RequestResult.Failure(error);

            //Assert

            requestResult.Should().NotBeNull();
            requestResult.Error.Name.Should().Be(error.Name);
            requestResult.Message.Should().Be(error.Message);
            requestResult.Error.HttpStatusCode.Should().Be(HttpStatusCode.BadRequest);
            requestResult.Error.Value.Should().Be(error.Value);
            requestResult.IsFailure.Should().BeTrue();
            requestResult.IsSuccessful.Should().BeFalse();
        }

        [Fact]
        public void RequestResult_BasicSuccessTest()
        {
            //Arrange

            var error = Error.ERROR_NONE;

            //Act
            
            var requestResult = RequestResult.Success();

            //Assert

            requestResult.Should().NotBeNull();
            requestResult.Error.Name.Should().Be(error.Name);
            requestResult.Error.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            requestResult.Error.Value.Should().Be(error.Value);
            requestResult.Message.Should().Be(error.Message);
            requestResult.IsFailure.Should().BeFalse();
            requestResult.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void
            RequestResult_WhenFailureAndErrorMessageIsParametrized_ReturnRequestResultFailureWithReplacedMessage()
        {
            //Arrange

            var error = TestErrors.PARAMETRIZED_ERROR;

            //Act

            var requestResult = RequestResult.Failure(error, nameof(TestErrors.PARAMETRIZED_ERROR));

            //Assert

            requestResult.Should().NotBeNull();
            requestResult.Error.Name.Should().Be(error.Name);
            requestResult.Error.HttpStatusCode.Should().Be(HttpStatusCode.BadRequest);
            requestResult.Error.Value.Should().Be(error.Value);
            requestResult.Message.Should().Be("This is parametrized error: PARAMETRIZED_ERROR");
            requestResult.Error.HttpStatusCode.Should().Be(HttpStatusCode.BadRequest);
            requestResult.IsFailure.Should().BeTrue();
            requestResult.IsSuccessful.Should().BeFalse();
        }

        [Fact]
        public void RequestResult_UnknownErrorTest()
        {
            //Arrange

            var error = Error.ERROR_UNKNOWN;

            //Act

            var requestResult = RequestResult.Failure(error);

            //Assert

            requestResult.Should().NotBeNull();
            requestResult.Error.Name.Should().Be(error.Name);
            requestResult.Error.HttpStatusCode.Should().Be(HttpStatusCode.InternalServerError);
            requestResult.Error.Value.Should().Be(error.Value);
            requestResult.Message.Should().Be(error.Message);
            requestResult.IsFailure.Should().BeTrue();
            requestResult.IsSuccessful.Should().BeFalse();
        }

        [Fact]
        public void GenericRequestResult_BasicSuccessTest()
        {
            #region Arrange

            var error = Error.ERROR_NONE;

            #endregion

            #region Act

            var requestResult = RequestResult<int>.Success(0);

            #endregion

            #region Assert

            requestResult.Should().NotBeNull();
            requestResult.Error.Name.Should().Be(error.Name);
            requestResult.Error.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            requestResult.Error.Value.Should().Be(error.Value);
            requestResult.Message.Should().Be(error.Message);
            requestResult.Result.Should().Be(0);
            requestResult.IsFailure.Should().BeFalse();
            requestResult.IsSuccessful.Should().BeTrue();

            #endregion
        }

        [Fact]
        public void GenericRequestResult_BasicFailureTest()
        {
            #region Arrange

            var error = TestErrors.BASIC_ERROR;

            #endregion

            #region Act

            var requestResult = RequestResult<int>.Failure(error);

            #endregion

            #region Assert

            requestResult.Should().NotBeNull();
            requestResult.Error.Name.Should().Be(error.Name);
            requestResult.Message.Should().Be(error.Message);
            requestResult.Error.HttpStatusCode.Should().Be(HttpStatusCode.BadRequest);
            requestResult.Error.Value.Should().Be(error.Value);
            requestResult.Result.Should().Be(default);
            requestResult.IsFailure.Should().BeTrue();
            requestResult.IsSuccessful.Should().BeFalse();

            #endregion
        }
    }
}