using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Invoices.Queries;
using MediatR;

namespace CleanArchitecture.Application.InvoiceT.Queries;
public class GetUserInvoicesQuery : IRequest<IList<InvoiceVm>>
{
    public string? User { get; set; }
}
