using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Versatil.Domain.Interfaces;

namespace Versatil.Domain.Extensions
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Nome => IsAuthenticated() ? GetClaimsPrincipal().Identity.Name : "";

        public string Matricula => IsAuthenticated() ? GetNameIdentifier() : "";

        public string CodigoUnidadeFisica => IsAuthenticated() ? GetClaimsByType("CodigoUnidadeFisica") : "";

        public string CodigoUnidadeAdministrativa => IsAuthenticated() ? GetClaimsByType("CodigoUnidadeAdministrativa") : "";

        public bool IsAdministrador => IsAuthenticated() && Convert.ToBoolean(GetClaimsByType("IsAdministrador"));

        public bool IsAuthenticated()
        {
            var user = GetClaimsPrincipal();
            if (user != null)
                return user.Identity.IsAuthenticated;

            return false;
        }

        private ClaimsPrincipal GetClaimsPrincipal()
        {
            if (_accessor.HttpContext != null)
                return _accessor.HttpContext.User;

            return null;
        }

        private string GetClaimsByType(string type)
        {
            var principal = GetClaimsPrincipal();
            if (principal == null)
                return null;

            var claim = principal.FindFirst(type);
            return claim?.Value;
        }

        private string GetNameIdentifier()
        {
            var principal = GetClaimsPrincipal();
            if (principal == null)
                return null;

            var claim = principal.FindFirst(ClaimTypes.NameIdentifier);
            return claim?.Value;
        }
    }
}