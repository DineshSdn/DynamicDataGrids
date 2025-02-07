using System;

namespace CleanArchitecture.ApplicationCore.Common.Interfaces
{
    public interface IDateTime
    {
        DateTime Now { get; }
        DateTime UtcNow { get; }
    }
}
