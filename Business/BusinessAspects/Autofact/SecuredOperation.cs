using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessAspects.Autofact
{
    public class SecuredOperation(string roles) : MethodInterception
    {
        private readonly string[] _roles = roles?.Split(',') ?? [];
        private readonly IHttpContextAccessor _httpContextAccessor = ServiceTool.ServiceProvider?.GetService<IHttpContextAccessor>()
             ?? throw new InvalidOperationException("IHttpContextAccessor not found or ServiceProvider is null.");

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext?.User?.ClaimRoles() ?? Enumerable.Empty<string>();

            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied); 
        }   
    }
}
