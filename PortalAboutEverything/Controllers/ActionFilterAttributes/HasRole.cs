﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using PortalAboutEverything.Data.Enums;
using PortalAboutEverything.Services.AuthStuff;

namespace PortalAboutEverything.Controllers.ActionFilterAttributes
{
    public class HasRoleAttribute : ActionFilterAttribute
    {
        private UserRole _role;

        public HasRoleAttribute(UserRole role)
        {
            _role = role;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var authService = context.HttpContext.RequestServices.GetRequiredService<AuthService>();

            if (!authService.HasRole(_role))
            {
                context.Result = new ForbidResult();
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
