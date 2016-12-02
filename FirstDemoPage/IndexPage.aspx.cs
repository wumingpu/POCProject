using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstDemoPage
{
    public class StringTable
    {
        public string[] ColumnNames { get; set; }
        //public string[,] Values { get; set; }
        public List<string[]> Values { get; set; }
    }
    public partial class IndexPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private async void GetMLResultFromAzure()
        {
            using (var client = new HttpClient())
            {
                var csvData = new List<string[]>();
                var lines = File.ReadAllLines(HttpContext.Current.Server.MapPath("~/Uploads/0_bak1.csv"));
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
                    //Response.Write(result);
                    //MLResult.InnerText = result;
                    DataTable dt = JsonToDatatable(result, csvData);
                    gvMLData.DataSource = dt;
                    gvMLData.DataBind();
                }
                else
                {
                    MLResult.InnerHtml = "";
                    MLResult.InnerHtml += string.Format("The request failed with status code: {0}<br/>", response.StatusCode);

                    // Print the headers - they include the requert ID and the timestamp, which are useful for debugging the failure
                    MLResult.InnerHtml += response.Headers.ToString()+ "<br/>";

                    string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    MLResult.InnerHtml += responseContent;
                }
            }
        }

        protected void btnProcessML_Click(object sender, EventArgs e)
        {
            GetMLResultFromAzure();
        }



        private DataTable JsonToDatatable(string strJson, List<string[]> csvData)
        {
            //DataTable dt = (DataTable)JsonConvert.DeserializeObject(strJson., (typeof(DataTable)));
            //object obj = JsonConvert.DeserializeObject(strJson);
            //return dt;
            //Results outobj = (Results)JsonConvert.DeserializeObject(strJson, (typeof(Results)));
            var MLData = JsonConvert.DeserializeObject<Rootobject>(strJson);
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("SourceStr");
            dt.Columns.Add("TargetString");
            dt.Columns.Add("Positive");
            dt.Columns.Add("Labels");
            dt.Columns.Add("Scored Probabilities");

            for (int i = 0; i < csvData.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = (i + 1);
                dr["SourceStr"] = csvData[i][2];
                dr["TargetString"] = csvData[i][3];
                dr["Positive"] = MLData.Results.output1.value.Values[i][0];
                dr["Labels"] = MLData.Results.output1.value.Values[i][100];
                dr["Scored Probabilities"] = MLData.Results.output1.value.Values[i][101];
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public class Rootobject
        {
            public Results Results { get; set; }
        }

        public class Results
        {
            public Output1 output1 { get; set; }
        }

        public class Output1
        {
            public string type { get; set; }
            public Value value { get; set; }
        }

        public class Value
        {
            public string[] ColumnNames { get; set; }
            public string[] ColumnTypes { get; set; }
            public string[][] Values { get; set; }
        }

        protected void gvMLData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex >= 0)
            {
                double number1 = double.Parse(e.Row.Cells[3].Text.ToString());//数量1
                double number2 = double.Parse(e.Row.Cells[4].Text.ToString());//数量2
                if (number1 != number2)
                {
                    e.Row.BackColor = System.Drawing.Color.FromArgb(255,228,225);//显示颜色，可自定义
                }
            }
        }
    }
    //{"Results":{"output1":{"type":"table","value":{"ColumnNames":["Positive","AbsenceSpaceInXmlTagEnd","attributeValueFromVirtualPlaceholder","BiDiCultures","commentSuggestsFunctionName","commentSuggestsLocaleSensitiveResource","commentSuggestsLocalizabilityRestriction","containsDateTimeFormatPatern","containsEmailAddress","containsFunctionCall","containsGlink","containsLetter","containsNumberOrPlaceholder","containsTime","containsURL","containsURLBeforeContext","containsURLInContext","containsURLSurroundByPlaceholder","containsURLWithAtag","containsURLWithPlaceholder","containsXmlLikeTag","containsXmlLikeTagEnd","contosoEmailAddress","CorrepondNoiseBracketsInTarget","cssAttributeDetector","delCharacterDetector","DetectFirstLetter","domainEmailAddress","doubleQuotesDetector","EAHotkey","emptyString","EmptyStringIndoubleQuotesDetector","EntireLocLockBinaryLockPattern","ErrorWords","EscapseCharactersHotkey","exampleEmailAddress","extractLCIDs","extractLLCCs","extraSlash","farEastHotkeyDetector","FileFilterString","FilteredOutProtectedString","FilterNoisePairing","ForbiddenByDev","GUID","hotkeyDetector","htmlAttributeDetector","htmlAttributeDetectorAsAWhole","htmlSpecialCharacterDetector","htmlTagDetector","IgnoreCommentsCategory","ignoredHtmlAttribute","ignoredHtmlAttributeForBiDi","ignoredUnLocalizableAttributeValue","ignoreSymbol","InvalidChars","IOSPlaceholderProtection","isFileFilter","isFileName","isFilePath","isProductNameToken","isStartWithFileExtension","isStartWithOrderWithBraces","largeNumberSeperator","lastLetterIsPunctuaion","lastPluralization","letterWord","lineBreakerDetector","LineFeed","LocalShortCutDetector","matchWordCount","mydomainEmailAddress","NoiseBracketsPlaceholders","noiseHtmlTagDetector","NoisePairForInconsistentPairing","NoiseStrForTranslationOrNot","NoiseStringForSpellerRule","NoiseTokenForSpellerRule","nonStandardPlaceholder","NormalCUltureName","NormalDomainName","numberString","ottmessagePlaceholder","percentageString","PickOutNumberString","placeHolderDetector","pluralization","residSuggestsLocaleSensitiveResource","singleWord","sourceIsPureNumber",


    public class Values
    {
        public int ResultID;
        public int Positive;
        public int SourceStr;
        public int TargetString;
        public int AbsenceSpaceInXmlTagEnd;
        public int attributeValueFromVirtualPlaceholder;
        public int BiDiCultures;
        public int commentSuggestsFunctionName;
        public int commentSuggestsLocaleSensitiveResource;
        public int commentSuggestsLocalizabilityRestriction;
        public int containsDateTimeFormatPatern;
        public int containsEmailAddress;
        public int containsFunctionCall;
        public int containsGlink;
        public int containsLetter;
        public int containsNumberOrPlaceholder;
        public int containsTime;
        public int containsURL;
        public int containsURLBeforeContext;
        public int containsURLInContext;
        public int containsURLSurroundByPlaceholder;
        public int containsURLWithAtag;
        public int containsURLWithPlaceholder;
        public int containsXmlLikeTag;
        public int containsXmlLikeTagEnd;
        public int contosoEmailAddress;
        public int CorrepondNoiseBracketsInTarget;
        public int cssAttributeDetector;
        public int delCharacterDetector;
        public int DetectFirstLetter;
        public int domainEmailAddress;
        public int doubleQuotesDetector;
        public int EAHotkey;
        public int emptyString;
        public int EmptyStringIndoubleQuotesDetector;
        public int EntireLocLockBinaryLockPattern;
        public int ErrorWords;
        public int EscapseCharactersHotkey;
        public int exampleEmailAddress;
        public int extractLCIDs;
        public int extractLLCCs;
        public int extraSlash;
        public int farEastHotkeyDetector;
        public int FileFilterString;
        public int FilteredOutProtectedString;
        public int FilterNoisePairing;
        public int ForbiddenByDev;
        public int GUID;
        public int hotkeyDetector;
        public int htmlAttributeDetector;
        public int htmlAttributeDetectorAsAWhole;
        public int htmlSpecialCharacterDetector;
        public int htmlTagDetector;
        public int IgnoreCommentsCategory;
        public int ignoredHtmlAttribute;
        public int ignoredHtmlAttributeForBiDi;
        public int ignoredUnLocalizableAttributeValue;
        public int ignoreSymbol;
        public int InvalidChars;
        public int IOSPlaceholderProtection;
        public int isFileFilter;
        public int isFileName;
        public int isFilePath;
        public int isProductNameToken;
        public int isStartWithFileExtension;
        public int isStartWithOrderWithBraces;
        public int largeNumberSeperator;
        public int lastLetterIsPunctuaion;
        public int lastPluralization;
        public int letterWord;
        public int lineBreakerDetector;
        public int LineFeed;
        public int LocalShortCutDetector;
        public int matchWordCount;
        public int mydomainEmailAddress;
        public int NoiseBracketsPlaceholders;
        public int noiseHtmlTagDetector;
        public int NoisePairForInconsistentPairing;
        public int NoiseStrForTranslationOrNot;
        public int NoiseStringForSpellerRule;
        public int NoiseTokenForSpellerRule;
        public int nonStandardPlaceholder;
        public int NormalCUltureName;
        public int NormalDomainName;
        public int numberString;
        public int ottmessagePlaceholder;
        public int percentageString;
        public int PickOutNumberString;
        public int placeHolderDetector;
        public int pluralization;
        public int residSuggestsLocaleSensitiveResource;
        public int singleWord;
        public int sourceIsPureNumber;
        public int spaceDetector;
        public int specialCharactersOnly;
        public int specialPlaceholderFormat;
        public int specialPlaceholderValue;
        public int SpecifyContainerForNotLocalized;
        public int squareBracketLink;
        public int StringLockedPattern;
        public int trailingSpaceDetector;
        public int virtualPlaceholderWithAttributeValue;
        public int xmlTagDetector;
    }
}