using System;

namespace Trade.Services
{
    public interface ICurrentUserScope
    {
        bool IsAuthorized { get; }
        int UserId { get; }
    }
}