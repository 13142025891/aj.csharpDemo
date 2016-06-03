using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
namespace MiniMvc
{
    public class DefauletModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, string modelName, Type modelType)
        {
            if (modelType.IsValueType || modelType == typeof(string))
            {
                object instance;
                if (GetValueTypeInstance(controllerContext, modelName, modelType,out instance))
                {
                    return instance;
                }
                return Activator.CreateInstance(modelType);
           }
            object modelInstance= Activator.CreateInstance(modelType);
            foreach (PropertyInfo proper in modelType.GetProperties())
            {
                if (!proper.CanWrite || (!proper.PropertyType.IsValueType && proper.PropertyType != typeof(string)))
                {
                    continue;
                }
                object properInstance;
                if (GetValueTypeInstance(controllerContext, proper.Name, proper.PropertyType, out properInstance))
                {
                     proper.SetValue(modelInstance,properInstance,null);
                }
            }
            return modelInstance;
        }

        private bool GetValueTypeInstance(ControllerContext context, string modelName, Type modelType, out object value)
        {
            Dictionary<string, object> source = new Dictionary<string, object>();

            foreach (string key in HttpContext.Current.Request.Form)
            {
                if (source.ContainsKey(key.ToLower()))
                {
                    continue;
                }
                source.Add(key.ToLower(),HttpContext.Current.Request.Form[key]);
            }
            foreach (string key in HttpContext.Current.Request.QueryString)
            {
                if (source.ContainsKey(key.ToLower()))
                {
                    continue;
                }
                source.Add(key.ToLower(), HttpContext.Current.Request.QueryString[key]);
            }

            foreach (string key in context.RequestContext.RouteData.Values.Keys)
            {
                if (source.ContainsKey(key.ToLower()))
                {
                    continue;
                }
                source.Add(key.ToLower(), context.RequestContext.RouteData.Values[key]);
            }
            foreach (string key in context.RequestContext.RouteData.DataTokens.Keys)
            {
                if (source.ContainsKey(key.ToLower()))
                {
                    continue;
                }
                source.Add(key.ToLower(), context.RequestContext.RouteData.DataTokens[key]);
            }

            if (source.TryGetValue(modelName.ToLower(), out value))
            {
                value = Convert.ChangeType(value,modelType);
                return true;
            }
            return false;
        }

    }
}