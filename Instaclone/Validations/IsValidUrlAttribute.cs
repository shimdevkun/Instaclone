using System;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Instaclone.Validations
{
    public class IsValidUrlAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return false;

            string url = value.ToString();

            Uri uriResult;
            bool isValid =  Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (!isValid)
                return false;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "HEAD";

            bool exists;
            try
            {
                request.GetResponse();
                exists = true;
            }
            catch { exists = false; }

            return exists;
        }
    }
}