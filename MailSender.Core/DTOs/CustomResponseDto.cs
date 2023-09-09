using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MailSender.Core.DTOs
{
    public class CustomResponseDto<T> 
    {
        //Endpoint sonunda Döneceğimiz tek bir model olması için kuruldu .

        public T Data { get; set; }

        [JsonIgnore] // Client bu bilgiyi zaten alıyor bir daha göstermemize gerek olmadığı için engelledik 
        public int StatusCode { get; set; }

        public List<String> Erors { get; set; }

        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T> { Data = data, StatusCode = statusCode };
        }
        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode };

        }
        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Erors = errors };
        }

        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Erors = new List<string> { error } };
        }


    }
}
