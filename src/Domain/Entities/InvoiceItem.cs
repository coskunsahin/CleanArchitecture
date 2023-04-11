using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public class InvoiceItem : BaseAuditableEntity
{
    public new int Id { get; set; }
    
    public string? Item { get; set; }
    public double Quantity { get; set; }
    public double Price { get; set; }
    public Invoice? Invoice { get; set; }
}
