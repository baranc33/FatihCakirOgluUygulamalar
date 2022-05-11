using System.Text.Json.Serialization;

namespace NLayerApp.Core.ResponseDto
{
    public class CustomResponseDto<T>
    {
        // oluşturulacak Data
        public T Data { get; set; }


        // İşlemlerde Status code Zaten Gönderildiğinden Dolayı
        // Status code göndermicez fakat kod kısmında bize gerekli olduğu için kullnacağı
        [JsonIgnore]// ignore et diyerek bunu kullanıcıya  gösterme demiş oluyoruz
        public int StatusCode { get; set; }


        // varsa Hataları tutacak Property
        public List<String> Errors { get; set; }


        // static factory design pattern uygulayarak metotlar oluşturcaz

        // bu nesneler static olduğundan dolayı  Gönderdiğimiz Parametreye göre 
        // overloading yapcak
        // başarılı ve data var
        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T>
            {
                Data = data,
                StatusCode = statusCode
            };
        }
        // başarılı Data yok
        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T>
            {
                StatusCode = statusCode
            };
        }
        // başarısız Hatalar var
        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseDto<T>
            {
                StatusCode = statusCode,
                Errors = errors
            };
        }

        // başarısız 1 Hata  var
        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<T>
            {
                StatusCode = statusCode,
                Errors = new List<string> { error }
            };
        }
    }
}
