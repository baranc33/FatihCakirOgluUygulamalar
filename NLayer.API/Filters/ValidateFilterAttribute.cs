using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerApp.Core.ResponseDto;

namespace NLayer.API.Filters
{
    public class ValidateFilterAttribute : ActionFilterAttribute// atribute sınıfı
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                // model state içindeki hataları seçip mesajları alıyoruz
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                // BadRequestResult => boş döner biz object olanı kullancaz bodye hataları doldurcaz
                context.Result = new BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(400, errors));


            }
        }
    }
}
