using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Invoices.Queries;
using CleanArchitecture.Domain.Entities;

using MediatR;

namespace CleanArchitecture.Application.Invoices.Commands;
public class CreateInvoiceCommand : IRequest<int>
{
    public CreateInvoiceCommand(string v, string v1, string v2)
    {
        this.InvoiceItems = new List<InvoiceItemVm>();
    }
    public string personel { get; set; }
    public string worker { get; set; }
    public int years { get; set; }
    public string categories { get; set; }
    public DateTime? StartDateTime { get; set; }
    public DateTime? FinishDateTime { get; set; }
    public new int Id { get; set; }
    public string Name { get; set; }
    public string InvoiceNumber { get; set; }

    public DateTime Date { get; set; }
    public string PaymentTerms { get; set; }
    public DateTime? DueDate { get; set; }
    public double Discount { get; set; }
    
    public double Tax { get; set; }
 
 
    public IList<InvoiceItemVm> InvoiceItems { get; set; }
}
