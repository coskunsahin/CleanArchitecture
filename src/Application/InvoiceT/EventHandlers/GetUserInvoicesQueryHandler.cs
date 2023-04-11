using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Invoices.Queries;
using CleanArchitecture.Application.InvoiceT.Queries;
using CleanArchitecture.Domain.Entities;

using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.InvoiceT.EventHandlers;
public class GetUserInvoicesQueryHandler : IRequestHandler<GetUserInvoicesQuery, IList<InvoiceVm>>
{
    private readonly IApplicationDbContext _context;
    private int total;
    
    //public string personel { get; set; }
    public GetUserInvoicesQueryHandler(IApplicationDbContext context)
    {
        _context = context;

    }

    public float Fpercent { get; set; }
    public double Paid { get; private set; }
     public string personel { get; set; }

    public async Task<IList<InvoiceVm>> Handle(GetUserInvoicesQuery request, CancellationToken cancellationToken)
    {
        var result = new List<InvoiceVm>();
        var invoices = await _context.Invoices.Include(i => i.InvoiceItems)
            .Where(i => i.CreatedBy == request.User).ToListAsync();
        var personel = new string("yes");
        var worker = new string("no");
        var years = new int?(2);
        var total= new int?(100);
        var categories = new string("groceries");
       
        
        
        if (personel == "yes")
        {

            Paid = 100;


            result = invoices.Select(i => new InvoiceVm
            {

                InvoiceItems = i.InvoiceItems.Select(item => new InvoiceItemVm
                {

                    Quantity = item.Quantity,
                    Amount = item.Price * item.Quantity / 100 * 70*Paid

                }).ToList(),
            }).ToList();
        }
        else if (worker == "no")
        {
            result = invoices.Select(i => new InvoiceVm
            {

                InvoiceItems = i.InvoiceItems.Select(item => new InvoiceItemVm
                {

                    Quantity = item.Quantity,
                    Amount = item.Price * item.Quantity / 100 * 90

                }).ToList(),
            }).ToList();

        }

        else if (years == 2 )
        {
            result = _context.Invoices.Select(i => new InvoiceVm
            {

                InvoiceItems = i.InvoiceItems.Select(item => new InvoiceItemVm
                {

                    Quantity = item.Quantity,
                    Amount = item.Price * item.Quantity / 100 * 95

                }).ToList(),
            }).ToList();

        }




       else  if (total > 100)
        {
            result = invoices.Select(i => new InvoiceVm
            {

                InvoiceItems = i.InvoiceItems.Select(item => new InvoiceItemVm
                {

                    Quantity = item.Quantity,
                    total = item.Price * item.Quantity,
                    Amount = item.Price * item.Quantity /100 -5,

                }).ToList(),
            }).ToList();

        }
        else if (categories== "groceries")
        {
            result = invoices.Select(i => new InvoiceVm
            {

                InvoiceItems = i.InvoiceItems.Select(item => new InvoiceItemVm
                {

                    Quantity = item.Quantity,
                    Amount = item.Price * item.Quantity


                }).ToList(),
            }).ToList();

        }
        else
        {
            result = invoices.Select(i => new InvoiceVm
            {

                InvoiceItems = i.InvoiceItems.Select(item => new InvoiceItemVm
                {

                    Quantity = item.Quantity,
                    Amount = item.Price * item.Quantity


                }).ToList(),
            }).ToList();
        }

        return result;
            }
     
}
   


