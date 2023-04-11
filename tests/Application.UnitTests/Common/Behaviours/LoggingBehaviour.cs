using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Invoices.Commands;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.UnitTests.Common.Behaviours;
internal class LoggingBehaviour<T>
{
    private ILogger<CreateInvoiceCommand> _object1;
    private ICurrentUserService _object2;
    private object _object3;

    public LoggingBehaviour(ILogger<CreateInvoiceCommand> object1, ICurrentUserService object2)
    {
        _object1 = object1;
        _object2 = object2;
    }

    public LoggingBehaviour(ILogger<CreateInvoiceCommand> object1, ICurrentUserService object2, object object3)
    {
        _object1 = object1;
        _object2 = object2;
        _object3 = object3;
    }

    internal Task Process(CreateInvoiceCommand createInvoiceCommand, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}