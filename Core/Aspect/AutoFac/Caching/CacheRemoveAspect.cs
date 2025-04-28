using Castle.DynamicProxy;
using Core.CrossCuttingConserns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspect.AutoFac.Caching
{
    public class CacheRemoveAspect(string pattern) : MethodInterception
    {
        private readonly string _pattern = pattern;
        private readonly ICacheManager _cacheManager = ServiceTool.ServiceProvider?.GetService<ICacheManager>() ?? null!;

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
