using Microsoft.ResourceStaticAnalysis.Core.KnowledgeBase.Toolbox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseResults
{
    public class CSVParser
    {
        public List<ResultEntry> entryList = new List<ResultEntry>();
        public static string _filePath = @"D:\Other\POCResult\result\";
        public static int i = 0;
        public void ParseFile(string currentLineStr, int lineIndex, string lastNotEmptyLines, int lastNotEmptyIndex)
        {
            var currentStrList = currentLineStr.Split(',');
            if (currentStrList.Count() != 4)
            {
                return;
            }
            ResultEntry entry = new ResultEntry();
            string resultId = currentStrList[0];
            string sourcestr = currentStrList[1];

            string targetstr = currentStrList[2];


            string result = currentStrList[3];

            ParseStr(entry, sourcestr);
            ParseStr(entry, targetstr);
            entry.Positive = result;
            entry.ResultID = resultId;
            entry.SourceStr = sourcestr;
            entry.TargetStr = targetstr;
            entryList.Add(entry);
        }
        /// <summary>
        ///  parse string
        /// </summary>
        /// <param name="str"></param>
        public void ParseStr(ResultEntry entryItem, string str)
        {
            if (RSARuleRegexLib.AbsenceSpaceInXmlTagEnd.IsMatch(str))
            {
                entryItem.AbsenceSpaceInXmlTagEnd = true;
            }
            if (RSARuleRegexLib.attributeValueFromVirtualPlaceholder.IsMatch(str))
            {
                entryItem.attributeValueFromVirtualPlaceholder = true;
            }
            if (RSARuleRegexLib.BiDiCultures.IsMatch(str))
            {
                entryItem.BiDiCultures = true
;
            }
            if (RSARuleRegexLib.commentSuggestsFunctionName.IsMatch(str))
            {
                entryItem.commentSuggestsFunctionName = true;
            }
            if (RSARuleRegexLib.commentSuggestsLocaleSensitiveResource.IsMatch(str))
            {
                entryItem.commentSuggestsLocaleSensitiveResource = true;
            }
            if (RSARuleRegexLib.commentSuggestsLocalizabilityRestriction.IsMatch(str))
            {
                entryItem.commentSuggestsLocalizabilityRestriction = true;
            }
            if (RSARuleRegexLib.containsDateTimeFormatPatern.IsMatch(str))
            {
                entryItem.containsDateTimeFormatPatern = true;
            }
            if (RSARuleRegexLib.containsEmailAddress.IsMatch(str))
            {
                entryItem.containsEmailAddress = true;
            }
            if (RSARuleRegexLib.containsFunctionCall.IsMatch(str))
            {
                entryItem.containsFunctionCall = true;
            }
            if (RSARuleRegexLib.containsGlink.IsMatch(str))
            {
                entryItem.containsGlink = true;
            }
            if (RSARuleRegexLib.containsLetter.IsMatch(str))
            {
                entryItem.containsLetter = true;
            }
            if (RSARuleRegexLib.containsNumberOrPlaceholder.IsMatch(str))
            {
                entryItem.containsNumberOrPlaceholder = true;
            }
            if (RSARuleRegexLib.containsTime.IsMatch(str))
            {
                entryItem.containsTime = true
;
            }
            if (RSARuleRegexLib.containsURL.IsMatch(str)) { entryItem.containsURL = true; }

            if (RSARuleRegexLib.containsURLBeforeContext.IsMatch(str))
            {
                entryItem.containsURLBeforeContext = true;
            }
            if (RSARuleRegexLib.containsURLInContext.IsMatch(str))
            {
                entryItem.containsURLInContext = true;
            }
            if (RSARuleRegexLib.containsURLSurroundByPlaceholder.IsMatch(str))
            {
                entryItem.containsURLSurroundByPlaceholder = true;
            }
            if (RSARuleRegexLib.containsURLWithAtag.IsMatch(str))
            {
                entryItem.containsURLWithAtag = true;
            }
            if (RSARuleRegexLib.containsURLWithPlaceholder.IsMatch(str))
            {
                entryItem.containsURLWithPlaceholder = true;
            }
            if (RSARuleRegexLib.containsXmlLikeTag.IsMatch(str))
            {
                entryItem.containsXmlLikeTag = true;
            }
            if (RSARuleRegexLib.containsXmlLikeTagEnd.IsMatch(str))
            {
                entryItem.containsXmlLikeTagEnd = true;
            }
            if (RSARuleRegexLib.contosoEmailAddress.IsMatch(str))
            {
                entryItem.contosoEmailAddress = true;
            }
            if (RSARuleRegexLib.CorrepondNoiseBracketsInTarget.IsMatch(str))
            {
                entryItem.CorrepondNoiseBracketsInTarget = true;
            }
            if (RSARuleRegexLib.cssAttributeDetector.IsMatch(str))
            {
                entryItem.cssAttributeDetector = true;
            }
            if (RSARuleRegexLib.delCharacterDetector.IsMatch(str))
            {
                entryItem.delCharacterDetector = true;
            }
            if (RSARuleRegexLib.DetectFirstLetter.IsMatch(str))
            {
                entryItem.DetectFirstLetter = true;
            }
            if (RSARuleRegexLib.domainEmailAddress.IsMatch(str))
            {
                entryItem.domainEmailAddress = true;
            }
            if (RSARuleRegexLib.doubleQuotesDetector.IsMatch(str))
            {
                entryItem.doubleQuotesDetector = true;
            }
            if (RSARuleRegexLib.EAHotkey.IsMatch(str)) { entryItem.EAHotkey = true; }
            if (RSARuleRegexLib.emptyString.IsMatch(str)) { entryItem.emptyString = true; }

            if (RSARuleRegexLib.EmptyStringIndoubleQuotesDetector.IsMatch(str))
            {
                entryItem.EmptyStringIndoubleQuotesDetector = true;
            }
            if (RSARuleRegexLib.EntireLocLockBinaryLockPattern.IsMatch(str))
            {
                entryItem.EntireLocLockBinaryLockPattern = true;
            }
            if (RSARuleRegexLib.ErrorWords.IsMatch(str)) { entryItem.ErrorWords = true; }
            if (RSARuleRegexLib.EscapseCharactersHotkey.IsMatch(str))
            {
                entryItem.EscapseCharactersHotkey = true;
            }
            if (RSARuleRegexLib.exampleEmailAddress.IsMatch(str))
            {
                entryItem.exampleEmailAddress = true;
            }
            if (RSARuleRegexLib.extractLCIDs.IsMatch(str))
            {
                entryItem.extractLCIDs = true;
            }
            if (RSARuleRegexLib.extractLLCCs.IsMatch(str))
            {
                entryItem.extractLLCCs = true;
            }
            if (RSARuleRegexLib.extraSlash.IsMatch(str)) { entryItem.extraSlash = true; }
            if (RSARuleRegexLib.farEastHotkeyDetector.IsMatch(str))
            {
                entryItem.farEastHotkeyDetector = true;
            }
            if (RSARuleRegexLib.FileFilterString.IsMatch(str))
            {
                entryItem.FileFilterString = true;
            }
            if (RSARuleRegexLib.FilteredOutProtectedString.IsMatch(str))
            {
                entryItem.FilteredOutProtectedString = true;
            }
            if (RSARuleRegexLib.FilterNoisePairing.IsMatch(str))
            {
                entryItem.FilterNoisePairing = true;
            }
            if (RSARuleRegexLib.ForbiddenByDev.IsMatch(str))
            {
                entryItem.ForbiddenByDev = true;
            }
            if (RSARuleRegexLib.GUID.IsMatch(str)) { entryItem.GUID = true; }
            if (RSARuleRegexLib.hotkeyDetector.IsMatch(str))
            {
                entryItem.hotkeyDetector = true;
            }
            if (RSARuleRegexLib.htmlAttributeDetector.IsMatch(str))
            {
                entryItem.htmlAttributeDetector = true;
            }
            if (RSARuleRegexLib.htmlAttributeDetectorAsAWhole.IsMatch(str))
            {
                entryItem.htmlAttributeDetectorAsAWhole = true;
            }
            if (RSARuleRegexLib.htmlSpecialCharacterDetector.IsMatch(str))
            {
                entryItem.htmlSpecialCharacterDetector = true;
            }
            if (RSARuleRegexLib.htmlTagDetector.IsMatch(str))
            {
                entryItem.htmlTagDetector = true;
            }
            if (RSARuleRegexLib.IgnoreCommentsCategory.IsMatch(str))
            {
                entryItem.IgnoreCommentsCategory = true;
            }
            if (RSARuleRegexLib.ignoredHtmlAttribute.IsMatch(str))
            {
                entryItem.ignoredHtmlAttribute = true;
            }
            if (RSARuleRegexLib.ignoredHtmlAttributeForBiDi.IsMatch(str))
            {
                entryItem.ignoredHtmlAttributeForBiDi = true;
            }
            if (RSARuleRegexLib.ignoredUnLocalizableAttributeValue.IsMatch(str))
            {
                entryItem.ignoredUnLocalizableAttributeValue = true;
            }
            if (RSARuleRegexLib.ignoreSymbol.IsMatch(str))
            {
                entryItem.ignoreSymbol = true;
            }
            if (RSARuleRegexLib.InvalidChars.IsMatch(str))
            {
                entryItem.InvalidChars = true;
            }
            if (RSARuleRegexLib.IOSPlaceholderProtection.IsMatch(str))
            {
                entryItem.IOSPlaceholderProtection = true;
            }
            if (RSARuleRegexLib.isFileFilter.IsMatch(str))
            {
                entryItem.isFileFilter = true;
            }
            if (RSARuleRegexLib.isFileName.IsMatch(str)) { entryItem.isFileName = true; }
            if (RSARuleRegexLib.isFilePath.IsMatch(str)) { entryItem.isFilePath = true; }
            if (RSARuleRegexLib.isProductNameToken.IsMatch(str))
            {
                entryItem.isProductNameToken = true;
            }
            if (RSARuleRegexLib.isStartWithFileExtension.IsMatch(str))
            {
                entryItem.isStartWithFileExtension = true;
            }
            if (RSARuleRegexLib.isStartWithOrderWithBraces.IsMatch(str))
            {
                entryItem.isStartWithOrderWithBraces = true;
            }
            if (RSARuleRegexLib.largeNumberSeperator.IsMatch(str))
            {
                entryItem.largeNumberSeperator = true;
            }
            if (RSARuleRegexLib.lastLetterIsPunctuaion.IsMatch(str))
            {
                entryItem.lastLetterIsPunctuaion = true;
            }
            if (RSARuleRegexLib.lastPluralization.IsMatch(str))
            {
                entryItem.lastPluralization = true;
            }
            if (RSARuleRegexLib.letterWord.IsMatch(str)) { entryItem.letterWord = true; }
            if (RSARuleRegexLib.lineBreakerDetector.IsMatch(str))
            {
                entryItem.lineBreakerDetector = true;
            }
            if (RSARuleRegexLib.LineFeed.IsMatch(str)) { entryItem.LineFeed = true; }
            if (RSARuleRegexLib.LocalShortCutDetector.IsMatch(str))
            {
                entryItem.LocalShortCutDetector = true;
            }
            if (RSARuleRegexLib.matchWordCount.IsMatch(str))
            {
                entryItem.matchWordCount = true;
            }
            if (RSARuleRegexLib.mydomainEmailAddress.IsMatch(str))
            {
                entryItem.mydomainEmailAddress = true;
            }
            if (RSARuleRegexLib.NoiseBracketsPlaceholders.IsMatch(str))
            {
                entryItem.NoiseBracketsPlaceholders = true;
            }
            if (RSARuleRegexLib.noiseHtmlTagDetector.IsMatch(str))
            {
                entryItem.noiseHtmlTagDetector = true;
            }
            if (RSARuleRegexLib.NoisePairForInconsistentPairing.IsMatch(str))
            {
                entryItem.NoisePairForInconsistentPairing = true;
            }
            if (RSARuleRegexLib.NoiseStrForTranslationOrNot.IsMatch(str))
            {
                entryItem.NoiseStrForTranslationOrNot = true;
            }
            if (RSARuleRegexLib.NoiseStringForSpellerRule.IsMatch(str))
            {
                entryItem.NoiseStringForSpellerRule = true;
            }
            if (RSARuleRegexLib.NoiseTokenForSpellerRule.IsMatch(str))
            {
                entryItem.NoiseTokenForSpellerRule = true;
            }
            if (RSARuleRegexLib.nonStandardPlaceholder.IsMatch(str))
            {
                entryItem.nonStandardPlaceholder = true;
            }
            if (RSARuleRegexLib.NormalCUltureName.IsMatch(str))
            {
                entryItem.NormalCUltureName = true;
            }
            if (RSARuleRegexLib.NormalDomainName.IsMatch(str))
            {
                entryItem.NormalDomainName = true;
            }
            if (RSARuleRegexLib.numberString.IsMatch(str))
            {
                entryItem.numberString = true;
            }
            if (RSARuleRegexLib.ottmessagePlaceholder.IsMatch(str))
            {
                entryItem.ottmessagePlaceholder = true;
            }
            if (RSARuleRegexLib.percentageString.IsMatch(str))
            {
                entryItem.percentageString = true;
            }
            if (RSARuleRegexLib.PickOutNumberString.IsMatch(str))
            {
                entryItem.PickOutNumberString = true;
            }
            if (RSARuleRegexLib.placeHolderDetector.IsMatch(str))
            {
                entryItem.placeHolderDetector = true;
            }
            if (RSARuleRegexLib.pluralization.IsMatch(str))
            {
                entryItem.pluralization = true;
            }
            if (RSARuleRegexLib.residSuggestsLocaleSensitiveResource.IsMatch(str))
            {
                entryItem.residSuggestsLocaleSensitiveResource = true;
            }
            if (RSARuleRegexLib.singleWord.IsMatch(str)) { entryItem.singleWord = true; }
            if (RSARuleRegexLib.sourceIsPureNumber.IsMatch(str))
            {
                entryItem.sourceIsPureNumber = true;
            }
            if (RSARuleRegexLib.spaceDetector.IsMatch(str))
            {
                entryItem.spaceDetector = true;
            }
            if (RSARuleRegexLib.specialCharactersOnly.IsMatch(str))
            {
                entryItem.specialCharactersOnly = true;
            }
            if (RSARuleRegexLib.specialPlaceholderFormat.IsMatch(str))
            {
                entryItem.specialPlaceholderFormat = true;
            }
            if (RSARuleRegexLib.specialPlaceholderValue.IsMatch(str))
            {
                entryItem.specialPlaceholderValue = true;
            }
            if (RSARuleRegexLib.SpecifyContainerForNotLocalized.IsMatch(str))
            {
                entryItem.SpecifyContainerForNotLocalized = true;
            }
            if (RSARuleRegexLib.squareBracketLink.IsMatch(str))
            {
                entryItem.squareBracketLink = true;
            }
            if (RSARuleRegexLib.StringLockedPattern.IsMatch(str))
            {
                entryItem.StringLockedPattern = true;
            }
            if (RSARuleRegexLib.trailingSpaceDetector.IsMatch(str))
            {
                entryItem.trailingSpaceDetector = true;
            }
            if (RSARuleRegexLib.virtualPlaceholderWithAttributeValue.IsMatch(str))
            {
                entryItem.virtualPlaceholderWithAttributeValue = true;
            }
            if (RSARuleRegexLib.xmlTagDetector.IsMatch(str))
            {
                entryItem.xmlTagDetector = true;
            }


        }

        public void Parse()
        {
            string fileOutput = _filePath + i++ + ".csv";

            if (File.Exists(fileOutput)) File.Delete(fileOutput);
            var stream = File.Create(fileOutput);
            stream.Close();
            StreamWriter sw = new StreamWriter(fileOutput);
            sw.WriteLine(@"ResultID,Positive,SourceStr,TargetString,AbsenceSpaceInXmlTagEnd,attributeValueFromVirtualPlaceholder,BiDiCultures,commentSuggestsFunctionName,commentSuggestsLocaleSensitiveResource,commentSuggestsLocalizabilityRestriction,containsDateTimeFormatPatern,containsEmailAddress,containsFunctionCall,containsGlink,containsLetter,containsNumberOrPlaceholder,containsTime,containsURL,containsURLBeforeContext,containsURLInContext,containsURLSurroundByPlaceholder,containsURLWithAtag,containsURLWithPlaceholder,containsXmlLikeTag,containsXmlLikeTagEnd,contosoEmailAddress,CorrepondNoiseBracketsInTarget,cssAttributeDetector,delCharacterDetector,DetectFirstLetter,domainEmailAddress,doubleQuotesDetector,EAHotkey,emptyString,EmptyStringIndoubleQuotesDetector,EntireLocLockBinaryLockPattern,ErrorWords,EscapseCharactersHotkey,exampleEmailAddress,extractLCIDs,extractLLCCs,extraSlash,farEastHotkeyDetector,FileFilterString,FilteredOutProtectedString,FilterNoisePairing,ForbiddenByDev,GUID,hotkeyDetector,htmlAttributeDetector,htmlAttributeDetectorAsAWhole,htmlSpecialCharacterDetector,htmlTagDetector,IgnoreCommentsCategory,ignoredHtmlAttribute,ignoredHtmlAttributeForBiDi,ignoredUnLocalizableAttributeValue,ignoreSymbol,InvalidChars,IOSPlaceholderProtection,isFileFilter,isFileName,isFilePath,isProductNameToken,isStartWithFileExtension,isStartWithOrderWithBraces,largeNumberSeperator,lastLetterIsPunctuaion,lastPluralization,letterWord,lineBreakerDetector,LineFeed,LocalShortCutDetector,matchWordCount,mydomainEmailAddress,NoiseBracketsPlaceholders,noiseHtmlTagDetector,NoisePairForInconsistentPairing,NoiseStrForTranslationOrNot,NoiseStringForSpellerRule,NoiseTokenForSpellerRule,nonStandardPlaceholder,NormalCUltureName,NormalDomainName,numberString,ottmessagePlaceholder,percentageString,PickOutNumberString,placeHolderDetector,pluralization,residSuggestsLocaleSensitiveResource,singleWord,sourceIsPureNumber,spaceDetector,specialCharactersOnly,specialPlaceholderFormat,specialPlaceholderValue,SpecifyContainerForNotLocalized,squareBracketLink,StringLockedPattern,trailingSpaceDetector,virtualPlaceholderWithAttributeValue,xmlTagDetector");

            foreach (var item in entryList)
            {
                string strItemResult = item.ResultID + "," + item.Positive + "," + item.SourceStr + "," + item.TargetStr + "," +
                    item.AbsenceSpaceInXmlTagEnd + "," + item.attributeValueFromVirtualPlaceholder + "," + item.BiDiCultures + ","
                    + item.commentSuggestsFunctionName + "," + item.commentSuggestsLocaleSensitiveResource + "," +
                    item.commentSuggestsLocalizabilityRestriction + "," + item.containsDateTimeFormatPatern + "," +
                    item.containsEmailAddress + "," + item.containsFunctionCall + "," + item.containsGlink + "," +
                    item.containsLetter + "," + item.containsNumberOrPlaceholder + "," + item.containsTime + "," +
                    item.containsURL + "," + item.containsURLBeforeContext + "," + item.containsURLInContext + "," +
                    item.containsURLSurroundByPlaceholder + "," + item.containsURLWithAtag + "," + item.containsURLWithPlaceholder + ","
                    + item.containsXmlLikeTag + "," + item.containsXmlLikeTagEnd + "," + item.contosoEmailAddress + "," + item.CorrepondNoiseBracketsInTarget + ","
                    + item.cssAttributeDetector + "," + item.delCharacterDetector + "," + item.DetectFirstLetter + "," + item.domainEmailAddress +
                    "," + item.doubleQuotesDetector + "," + item.EAHotkey + "," + item.emptyString + "," + item.EmptyStringIndoubleQuotesDetector +
                    "," + item.EntireLocLockBinaryLockPattern + "," + item.ErrorWords + "," + item.EscapseCharactersHotkey + "," + item.exampleEmailAddress +
                    "," + item.extractLCIDs + "," + item.extractLLCCs + "," + item.extraSlash + "," + item.farEastHotkeyDetector + ","
                    + item.FileFilterString + "," + item.FilteredOutProtectedString + "," + item.FilterNoisePairing + "," + item.ForbiddenByDev +
                    "," + item.GUID + "," + item.hotkeyDetector + "," + item.htmlAttributeDetector + "," + item.htmlAttributeDetectorAsAWhole + "," +
                    item.htmlSpecialCharacterDetector + "," + item.htmlTagDetector + "," + item.IgnoreCommentsCategory + "," + item.ignoredHtmlAttribute +
                    "," + item.ignoredHtmlAttributeForBiDi + "," + item.ignoredUnLocalizableAttributeValue + "," + item.ignoreSymbol + "," + item.InvalidChars +
                    "," + item.IOSPlaceholderProtection + "," + item.isFileFilter + "," + item.isFileName + "," + item.isFilePath + "," + item.isProductNameToken +
                    "," + item.isStartWithFileExtension + "," + item.isStartWithOrderWithBraces + "," + item.largeNumberSeperator + "," + item.lastLetterIsPunctuaion +
                    "," + item.lastPluralization + "," + item.letterWord + "," + item.lineBreakerDetector + "," + item.LineFeed + "," + item.LocalShortCutDetector + ","
                    + item.matchWordCount + "," + item.mydomainEmailAddress + "," + item.NoiseBracketsPlaceholders + "," + item.noiseHtmlTagDetector + "," +
                    item.NoisePairForInconsistentPairing + "," + item.NoiseStrForTranslationOrNot + "," + item.NoiseStringForSpellerRule + "," +
                    item.NoiseTokenForSpellerRule + "," + item.nonStandardPlaceholder + "," + item.NormalCUltureName + "," + item.NormalDomainName + "," +
                    item.numberString + "," + item.ottmessagePlaceholder + "," + item.percentageString + "," + item.PickOutNumberString + "," +
                    item.placeHolderDetector + "," + item.pluralization + "," + item.residSuggestsLocaleSensitiveResource + "," + item.singleWord + "," +
                    item.sourceIsPureNumber + "," + item.spaceDetector + "," + item.specialCharactersOnly + "," + item.specialPlaceholderFormat + "," +
                    item.specialPlaceholderValue + "," + item.SpecifyContainerForNotLocalized + "," + item.squareBracketLink + "," + item.StringLockedPattern +
                    "," + item.trailingSpaceDetector + "," + item.virtualPlaceholderWithAttributeValue + "," + item.xmlTagDetector + ",";
                sw.WriteLine(strItemResult.Replace("False", "0").Replace("True", "1"));
            }
            sw.Close();

            entryList.Clear();
        }
    }
}

