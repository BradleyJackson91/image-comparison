using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DeepAI;

namespace ImageComparriosn.src
{
    internal class DeepAILocal
    {
        internal static void compareImages(ref DeepAIComparison daic)
        {
            DeepAI_API api = new DeepAI_API(apiKey: "<INSERT API KEY HERE>");

            StandardApiResponse resp = api.callStandardApi("image-similarity", new
            {
                image1 = File.OpenRead(daic.img1),
                image2 = File.OpenRead(daic.img2),
            });

            string responseString = Newtonsoft.Json.JsonConvert.SerializeObject(resp);
            int distance = -1;
            //Console.WriteLine(responseString);
            try
            {
                string subString = responseString.Substring(responseString.IndexOf("distance"), responseString.Length - responseString.IndexOf("distance"));
                subString = subString.Substring(subString.IndexOf(":") + 1, subString.IndexOf("}") - (subString.IndexOf(":") + 1));
                Int32.TryParse(subString, out distance);
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }

            daic.distance = distance;
        }

    }
}
