using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Invoices.Queries;
using CleanArchitecture.Domain.Entities;
 
using MediatR;
using Microsoft.VisualBasic;

namespace CleanArchitecture.Application.Invoices.Commands.CreateInvoice;
public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, int>
{
    private readonly IApplicationDbContext _context;
   

    public CreateInvoiceCommandHandler(IApplicationDbContext context)
    {
        _context = context;
     
    }
    public async Task<int> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {

        var entity = new Invoice
        {
            Name = request.Name,
            Date = request.Date,
            DueDate = request.DueDate,
            personel = request.personel,
            worker = request.worker,
            years = request.years,
            categories = request.categories,
            StartDateTime = request.StartDateTime,
            FinishDateTime = request.FinishDateTime,
            InvoiceNumber = request.InvoiceNumber,

            PaymentTerms = request.PaymentTerms,
            Tax = request.Tax,
         

            InvoiceItems = request.InvoiceItems.Select(i => new InvoiceItem
            {
                Item = i.Item,
                Quantity = i.Quantity,
                Price = i.Price,
            }).ToList(),




        };


       
        _context.Invoices.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
