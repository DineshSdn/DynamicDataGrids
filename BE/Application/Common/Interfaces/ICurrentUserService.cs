namespace CleanArchitecture.ApplicationCore.Common.Interfaces
{
    public interface ICurrentUserService
    {
        int UserId { get; }
        string UserEmail { get; }
        string UserRoles { get; }
        /// <summary>
        /// Excluding few exceptions almost all browsers sends this header.
        /// Reference - https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Origin
        /// </summary>
        string Origin { get; }

        /// <summary>
        /// Excluding few exceptions almost all browsers sends this header.
        /// Reference - https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Referer
        /// </summary>
        string Referer { get; }

    }
}
