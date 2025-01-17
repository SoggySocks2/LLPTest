﻿using LLPTest.Data.Retailers;
using System.Text.Json.Serialization;

namespace LLPTest.Data.Customers
{
    public class CustomerRetailerSite
    {
        public Guid CustomerId { get; private set; }
        public Guid RetailerSiteId { get; private set; }
        public bool IsActive { get; private set; }

        [JsonIgnore]
        public Customer Customer { get; private set; } = default!;

        [JsonIgnore]
        public RetailerSite RetailerSite { get; private set; } = default!;

        public CustomerRetailerSite(Guid customerId, Guid retailerSiteId)
        {
            if (customerId.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(customerId));
            if (retailerSiteId.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(retailerSiteId));

            CustomerId = customerId;
            RetailerSiteId = retailerSiteId;
            IsActive = true;
        }

        public void EndRelationship()
        {
            IsActive = false;
        }
    }
}
