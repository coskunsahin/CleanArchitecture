using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public class Invoice : BaseAuditableEntity
{
    public Invoice()
    {
        this.InvoiceItems = new List<InvoiceItem>();
    }
    public string personel { get; set; }
    public string worker { get; set; }
    public int years { get; set; }
    public  string categories { get; set; }
    public DateTime? StartDateTime { get; set; }
    public DateTime? FinishDateTime {  get; set; }
    public new int Id { get; set; }
    public string Name { get; set; }
    public string InvoiceNumber { get; set; }
   
    public DateTime Date { get; set; }
    public string PaymentTerms { get; set; }
    public DateTime? DueDate { get; set; }
    public double Discount { get; set; }
   
    public double Tax { get; set; }
   
    public double AmountPaid { get; set; }
    public IList<InvoiceItem> InvoiceItems { get; set; }
     
}