using System.Collections.Generic;

namespace Versatil.Web.Models
{
    public class JsonRetorno
    {
        public JsonRetorno(){
            Success = false;
            Messages = new List<string>();
        }

        public bool Success {get; set;}
        public string url {get; set;}
        public ICollection<string> Messages{get; set;}

    }
}