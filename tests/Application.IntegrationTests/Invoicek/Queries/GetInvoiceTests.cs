using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Invoices.Queries;
using CleanArchitecture.Application.InvoiceT.Queries;
using CleanArchitecture.Domain.Entities;

using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Invoicek.Queries;
using Testing;

public class GetInvoiceTests : BaseTestFixture
{
    [Test]
    public async Task ShouldReturnPriorityLevels()
    {
        await RunAsDefaultUserAsync();

        var query = new GetUserInvoicesQuery();

        var result = await SendAsync(query);

        result.Should().NotBeEmpty();
    }

    [Test]
    public async Task ShouldReturnAllListsAndItems()
    {
        await RunAsDefaultUserAsync();

        await AddAsync(new Invoice
        {
            Name = "Shopping",
            InvoiceItems =
            {
                        new  InvoiceItem { Quantity = 30, Item="milk",Price=30 },
                         new  InvoiceItem { Quantity = 30, Item="milk",Price=30 },
                         new  InvoiceItem { Quantity = 30, Item="milk",Price=30 },
                          new  InvoiceItem { Quantity = 30, Item="milk",Price=30 },
                           new  InvoiceItem { Quantity = 30, Item="milk",Price=30 },

                    }
        });

        //var query = new GetUserInvoicesQuery();

        //var result = await SendAsync(query);

        //result.Lists.Should().HaveCount(1);
        //result.Lists.First().Items.Should().HaveCount(7);
    }

    [Test]
    public async Task ShouldDenyAnonymousUser()
    {
        var query = new GetUserInvoicesQuery();

        var action = () => SendAsync(query);

        await action.Should().ThrowAsync<UnauthorizedAccessException>();
    }
}
