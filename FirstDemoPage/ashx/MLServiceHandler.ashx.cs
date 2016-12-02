using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.IO;

namespace FirstDemoPage.ashx
{
    public class StringTable
    {
        public string[] ColumnNames { get; set; }
        //public string[,] Values { get; set; }
        public List<string[]> Values { get; set; }
    }
    /// <summary>
    /// Summary description for MLServiceHandler
    /// </summary>
    public class MLServiceHandler : HttpTaskAsyncHandler
    {

        public override async Task ProcessRequestAsync(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["mode"] != null)
            {
                string mode = context.Request["mode"].ToString();
                switch (mode)
                {
                    case "GetMLResultFromAzure":
                        GetMLResultFromAzure(context);
                        break;
                    case "Test":
                        test(context);
                        break;
                }
            }
        }

        private async void test(HttpContext context)
        {
            context.Response.Write("222222");
        }
        //private int getint()
        //{
        //    return 111;
        //}

        private async void GetMLResultFromAzure(HttpContext context)
        {
            using (var client = new HttpClient())
            {
                var csvData = new List<string[]>();
                var lines = File.ReadAllLines(HttpContext.Current.Server.MapPath("~/Uploads/0.csv"));
                //foreach(string line in lines)
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] stringArr = lines[i].Split(',');
                    csvData.Add(stringArr);
                }

                var scoreRequest = new
                {

                    Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            new StringTable()
                            {
                                ColumnNames = new string[] {"ResultID", "Positive", "SourceStr", "TargetString", "AbsenceSpaceInXmlTagEnd", "attributeValueFromVirtualPlaceholder", "BiDiCultures", "commentSuggestsFunctionName", "commentSuggestsLocaleSensitiveResource", "commentSuggestsLocalizabilityRestriction", "containsDateTimeFormatPatern", "containsEmailAddress", "containsFunctionCall", "containsGlink", "containsLetter", "containsNumberOrPlaceholder", "containsTime", "containsURL", "containsURLBeforeContext", "containsURLInContext", "containsURLSurroundByPlaceholder", "containsURLWithAtag", "containsURLWithPlaceholder", "containsXmlLikeTag", "containsXmlLikeTagEnd", "contosoEmailAddress", "CorrepondNoiseBracketsInTarget", "cssAttributeDetector", "delCharacterDetector", "DetectFirstLetter", "domainEmailAddress", "doubleQuotesDetector", "EAHotkey", "emptyString", "EmptyStringIndoubleQuotesDetector", "EntireLocLockBinaryLockPattern", "ErrorWords", "EscapseCharactersHotkey", "exampleEmailAddress", "extractLCIDs", "extractLLCCs", "extraSlash", "farEastHotkeyDetector", "FileFilterString", "FilteredOutProtectedString", "FilterNoisePairing", "ForbiddenByDev", "GUID", "hotkeyDetector", "htmlAttributeDetector", "htmlAttributeDetectorAsAWhole", "htmlSpecialCharacterDetector", "htmlTagDetector", "IgnoreCommentsCategory", "ignoredHtmlAttribute", "ignoredHtmlAttributeForBiDi", "ignoredUnLocalizableAttributeValue", "ignoreSymbol", "InvalidChars", "IOSPlaceholderProtection", "isFileFilter", "isFileName", "isFilePath", "isProductNameToken", "isStartWithFileExtension", "isStartWithOrderWithBraces", "largeNumberSeperator", "lastLetterIsPunctuaion", "lastPluralization", "letterWord", "lineBreakerDetector", "LineFeed", "LocalShortCutDetector", "matchWordCount", "mydomainEmailAddress", "NoiseBracketsPlaceholders", "noiseHtmlTagDetector", "NoisePairForInconsistentPairing", "NoiseStrForTranslationOrNot", "NoiseStringForSpellerRule", "NoiseTokenForSpellerRule", "nonStandardPlaceholder", "NormalCUltureName", "NormalDomainName", "numberString", "ottmessagePlaceholder", "percentageString", "PickOutNumberString", "placeHolderDetector", "pluralization", "residSuggestsLocaleSensitiveResource", "singleWord", "sourceIsPureNumber", "spaceDetector", "specialCharactersOnly", "specialPlaceholderFormat", "specialPlaceholderValue", "SpecifyContainerForNotLocalized", "squareBracketLink", "StringLockedPattern", "trailingSpaceDetector", "virtualPlaceholderWithAttributeValue", "xmlTagDetector"},
                                //Values = new string[,] {  { "0", "0", "value", "value", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },  { "0", "0", "value", "value", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" }, { "0", "0", "value", "value", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" } }
                                Values = csvData
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };
                


                //string jsonValue = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(scoreRequest);



                const string apiKey = "Ckf0RePLenWPOSHnnzuGepzwrsGbUv8JNJI1HnhkeNjq58tZGIQ46WnDzQa09WOyCE9dPQc+8GQovM/qyaCcKg=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/41222af3ee2b4987b90f69ceadd0af6a/services/60f437c3926247eeb084342fa1821196/execute?api-version=2.0&details=true");

                // WARNING: The 'await' statement below can result in a deadlock if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false) so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)


                //HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);
                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    //Console.WriteLine("Result: {0}", result);
                    context.Response.Write(result);
                }
                else
                {
                    Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));

                    // Print the headers - they include the requert ID and the timestamp, which are useful for debugging the failure
                    Console.WriteLine(response.Headers.ToString());

                    string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Console.WriteLine(responseContent);
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}