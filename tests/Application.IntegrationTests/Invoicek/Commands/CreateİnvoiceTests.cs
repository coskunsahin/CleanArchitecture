//using CleanArchitecture.Application.Common.Exceptions;
//using CleanArchitecture.Application.Invoices.Commands;
//using CleanArchitecture.Domain.Entities;
//using FluentAssertions;
//using Google.Protobuf.WellKnownTypes;
//using NUnit.Framework;

//namespace CleanArchitecture.Application.IntegrationTests.Commands;



//public class CreateİnvoiceTests : BaseTestFixture
//{
//    [Test]
//    public async Task ShouldRequireMinimumFields()
//    {
//        var command = new CreateInvoiceCommand();
//        false = await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
//    }

//    private void SendAsync(CreateInvoiceCommand command)
//    {
//        throw new NotImplementedException();
//    }

//    [Test]
//    public async Task ShouldRequireUniqueTitle()
//    {
//        await SendAsync(new CreateInvoiceCommand
//        {
//            Name = "Shopping"
//        });

//        var command = new CreateInvoiceCommand
//        {
//            Name = "Shopping"
//        };

//        await FluentActions.Invoking(() =>
//            SendAsync(command)).Should().ThrowAsync<ValidationException>();
//    }

//    [Test]
//    public async Task ShouldCreateTodoList()
//    {
//        var userId = await RunAsDefaultUserAsync();

//        var command = new CreateInvoiceCommand
//        {
//            Name = "Tasks"
//        };

//        var id = await SendAsync(command);

//        var list = await FindAsync<Invoice>(id);

//        list.Should().NotBeNull();
//        list!.Name.Should().Be(command.Name);
//        list.CreatedBy.Should().Be(userId);
//        list.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
//    }

//    private Task RunAsDefaultUserAsync()
//    {
//        throw new NotImplementedException();
//    }
//}
