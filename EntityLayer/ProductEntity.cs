﻿using System;

namespace EntityLayer
{
    public class ProductEntity : BaseEntity
    {
        // Get a random commerce department.
        public string Department { get; set; }

        public Guid Categories { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }

        // Get a random EAN-8 barcode number.
        public string Ean8 { get; set; }

        // Get a random EAN-13 barcode number.
        public string Ean13 { get; set; }

        public bool? Status { get; set; }
        public int Quantity { get; set; }
        public string Fashion { get; set; }
        public string Description { get; set; }
    }
}