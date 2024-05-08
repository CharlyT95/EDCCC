using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCCC.Application.Behaviours
{
    public class UnhandledExceptionBehavior<Trequest, Tresponse> : IPipelineBehavior<Trequest, Tresponse> where Trequest : IRequest<Tresponse>
    {

        private readonly ILogger<Trequest> _logger;

        public UnhandledExceptionBehavior(ILogger<Trequest> logger)
        {
            _logger = logger;
        }

        public async Task<Tresponse> Handle(Trequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Tresponse> next)
        {
            try
            {
                return await next();
            }
            catch(Exception ex) { 
                var requestName = typeof(Trequest).Name;
                _logger.LogError(ex, "Excepcion! {Name} {@Request}", requestName, request);
                throw;
            }
        }
    }
}
