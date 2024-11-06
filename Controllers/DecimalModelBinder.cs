using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LW_1.Controllers
{
    public class DecimalModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueResult == null)
                return null;

            string attemptedValue = valueResult.AttemptedValue.Replace(",", ".");

            decimal parsedValue;
            if (decimal.TryParse(attemptedValue, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out parsedValue))
            {
                return parsedValue;
            }

            bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Некорректное значение для decimal.");
            return null;
        }
    }
}