using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Invoices.Queries;
public class InvoiceItemVm
{
    public int Id { get; set; }
    public string? Item { get; set; }
    public double Quantity { get; set; }
    public double Price { get; set; }
    public double Amount { get; set; }
    public double total { get; internal set; }
}
