using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Piramida_web.Features.Filters
{
    public class DevelopmentOnlyFilter : ActionFilterAttribute
    {
        private readonly IWebHostEnvironment _env;

        public DevelopmentOnlyFilter(IWebHostEnvironment env)
        {
            _env = env;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!_env.IsDevelopment())
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}
