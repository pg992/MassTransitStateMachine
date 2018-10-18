﻿using Contracts;
using System;

namespace PickService
{
    public class OrderPicked : IPicked
    {
        public Guid CorrelationId { get; set; }
        public string Text { get; set; }
    }
}