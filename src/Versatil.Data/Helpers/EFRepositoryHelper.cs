using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace Core.Infra.Data.Helpers
{
    public static class EFRepositoryHelper
    {
        public static string GetExecProcedure(string procedureName, DbParameter[] parameters)
        {
            if (parameters != null && parameters.Any())
                return $"EXEC {procedureName} {GetParametersNames(parameters)}";
            else
                return $"EXEC {procedureName}";
        }

        private static string GetParametersNames(DbParameter[] parameters)
        {
            if (parameters != null && parameters.Any())
            {
                var list = new List<string>();

                foreach (var parameter in parameters)
                {
                    if (parameter.ParameterName.Contains("@"))
                    {
                        list.Add(parameter.ParameterName);
                    }
                    else
                    {
                        list.Add("@" + parameter.ParameterName);
                    }
                }

                if (list.Any())
                    return string.Join(",", list.ToArray());
            }
            return "";
        }
    }
}
