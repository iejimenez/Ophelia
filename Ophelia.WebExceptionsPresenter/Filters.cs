using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Ophelia.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.WebExceptionsPresenter
{
    public static class Filters
    {
        public static void Register(MvcOptions options)
        {
            options.Filters.Add(new ApiExceptionFilterAttribute(
                new Dictionary<Type, IExceptionHandler>
                {
                    { typeof(GeneralException), new GeneralExceptionHandler() } ,
                    { typeof(ValidationException), new ValidationExceptionHandler() }
                }
            ));
        }
    }
}
