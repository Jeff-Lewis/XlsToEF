﻿namespace XlsToEf.Tests.Models
{
    public abstract class Entity<T> : BaseEntity
    {
        public T Id { get; set; }
    }
}