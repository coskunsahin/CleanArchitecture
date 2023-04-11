//using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Invoices.Commands;
using CleanArchitecture.Application.Invoices.Queries;
using CleanArchitecture.Application.InvoiceT.Queries;

using CleanArchitecture.WebUI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]

public class InvoiceController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateInvoiceCommand command)
    {
        return await Mediator.Send(command);
    }
    [HttpGet]
    public async Task<IList<InvoiceVm>> Get()
    {
        return await Mediator.Send(new GetUserInvoicesQuery { });
    }
 
}