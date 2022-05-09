using System.Text.Json.Serialization;

namespace NLayerApp.Core.ResponseDto
{
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<String> Errors { get; set; }


        // static factory design pattern uygulayarak metotlar oluşturcaz

        /// <summary>
        /// Başarılı Data var
        /// </summary>
        /// <param name="202"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T> { Data = data, StatusCode = statusCode };
        }
        /// <summary>
        /// Başarılı Data yok
        /// </summary>
        /// <param name="200"></param>
        /// <returns></returns>
        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode };
        }
        /// <summary>
        /// Başarısız Hatalar
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors };
        }

        /// <summary>
        /// Başarısız Hata var
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }
}
