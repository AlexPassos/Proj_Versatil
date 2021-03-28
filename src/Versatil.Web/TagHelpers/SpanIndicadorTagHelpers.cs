using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Versatil.Web.TagHelpers{
    [HtmlTargetElement(Attributes = "is-alerta")]
    public class SpanIndicadorTagHelpers: TagHelper{
        
        public bool IsAlerta {get; set;}

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            output.Attributes.SetAttribute("class", IsAlerta ? "span-indicador text-bold" : "span-indicador");
        }
    }
}