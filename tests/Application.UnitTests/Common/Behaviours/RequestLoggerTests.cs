//using CleanArchitecture.Application.Common.Behaviours;
//using CleanArchitecture.Application.Common.Interfaces;
//using CleanArchitecture.Application.Invoices.Commands;

//using Microsoft.Extensions.Logging;
//using Moq;
//using NUnit.Framework;

//namespace CleanArchitecture.Application.UnitTests.Common.Behaviours;

//public class RequestLoggerTests
//{
//    private Mock<ILogger<CreateInvoiceCommand>> _logger = null!;
//    private Mock<ICurrentUserService> _currentUserService = null!;
    

//    [SetUp]
//    public void Setup()
//    {
//        _logger = new Mock<ILogger<CreateInvoiceCommand>>();
//        _currentUserService = new Mock<ICurrentUserService>();
 
//    }

   

//    [Test]
//    public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
//    {
//        _currentUserService.Setup(x => x.UserId).Returns(Guid.NewGuid().ToString());

//        var requestLogger = new LoggingBehaviour<CreateInvoiceCommand>(_logger.Object, _currentUserService.Object);

//        await requestLogger.Process(new CreateInvoiceCommand { Id = 1, Name = "title" }, new CancellationToken());

       
//    }

//    [Test]
//    public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
//    {
//        var requestLogger = new LoggingBehaviour<CreateInvoiceCommand>(_logger.Object, _currentUserService.Object);

//        await requestLogger.Process(new CreateInvoiceCommand { Id = 1, Name = "title" }, new CancellationToken());

        
//    }
//}



