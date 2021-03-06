﻿
namespace ParseResults
{
    public class ResultEntry
    {
        public string ResultID;     
        public string Positive;
        public string Culture;
        public string SourceStr;
        public string TargetStr;
        // Fields
        public bool AbsenceSpaceInXmlTagEnd = false;
        public bool attributeValueFromVirtualPlaceholder = false;
        public bool BiDiCultures = false;
        public bool commentSuggestsFunctionName = false;
        public bool commentSuggestsLocaleSensitiveResource = false;
        public bool commentSuggestsLocalizabilityRestriction = false;
        public bool containsDateTimeFormatPatern = false;
        public bool containsEmailAddress = false;
        public bool containsFunctionCall = false;
        public bool containsGlink = false;
        public bool containsLetter = false;
        public bool containsNumberOrPlaceholder = false;
        public bool containsTime = false;
        public bool containsURL = false;
        public bool containsURLBeforeContext = false;
        public bool containsURLInContext = false;
        public bool containsURLSurroundByPlaceholder = false;
        public bool containsURLWithAtag = false;
        public bool containsURLWithPlaceholder = false;
        public bool containsXmlLikeTag = false;
        public bool containsXmlLikeTagEnd = false;
        public bool contosoEmailAddress = false;
        public bool CorrepondNoiseBracketsInTarget = false;
        public bool cssAttributeDetector = false;
        public bool delCharacterDetector = false;
        public bool DetectFirstLetter = false;
        public bool domainEmailAddress = false;
        public bool doubleQuotesDetector = false;
        public bool EAHotkey = false;
        public bool emptyString = false;
        public bool EmptyStringIndoubleQuotesDetector = false;
        public bool EntireLocLockBinaryLockPattern = false;
        public bool ErrorWords = false;
        public bool EscapseCharactersHotkey = false;
        public bool exampleEmailAddress = false;
        public bool extractLCIDs = false;
        public bool extractLLCCs = false;
        public bool extraSlash = false;
        public bool farEastHotkeyDetector = false;
        public bool FileFilterString = false;
        public bool FilteredOutProtectedString = false;
        public bool FilterNoisePairing = false;
        public bool ForbiddenByDev = false;
        public bool GUID = false;
        public bool hotkeyDetector = false;
        public bool htmlAttributeDetector = false;
        public bool htmlAttributeDetectorAsAWhole = false;
        public bool htmlSpecialCharacterDetector = false;
        public bool htmlTagDetector = false;
        public bool IgnoreCommentsCategory = false;
        public bool ignoredHtmlAttribute = false;
        public bool ignoredHtmlAttributeForBiDi = false;
        public bool ignoredUnLocalizableAttributeValue = false;
        public bool ignoreSymbol = false;
        public bool InvalidChars = false;
        public bool IOSPlaceholderProtection = false;
        public bool isFileFilter = false;
        public bool isFileName = false;
        public bool isFilePath = false;
        public bool isProductNameToken = false;
        public bool isStartWithFileExtension = false;
        public bool isStartWithOrderWithBraces = false;
        public bool largeNumberSeperator = false;
        public bool lastLetterIsPunctuaion = false;
        public bool lastPluralization = false;
        public bool letterWord = false;
        public bool lineBreakerDetector = false;
        public bool LineFeed = false;
        public bool LocalShortCutDetector = false;
        public bool matchWordCount = false;
        public bool mydomainEmailAddress = false;
        public bool NoiseBracketsPlaceholders = false;
        public bool noiseHtmlTagDetector = false;
        public bool NoisePairForInconsistentPairing = false;
        public bool NoiseStrForTranslationOrNot = false;
        public bool NoiseStringForSpellerRule = false;
        public bool NoiseTokenForSpellerRule = false;
        public bool nonStandardPlaceholder = false;
        public bool NormalCUltureName = false;
        public bool NormalDomainName = false;
        public bool numberString = false;
        public bool ottmessagePlaceholder = false;
        public bool percentageString = false;
        public bool PickOutNumberString = false;
        public bool placeHolderDetector = false;
        public bool pluralization = false;
        public bool residSuggestsLocaleSensitiveResource = false;
        public bool singleWord = false;
        public bool sourceIsPureNumber = false;
        public bool spaceDetector = false;
        public bool specialCharactersOnly = false;
        public bool specialPlaceholderFormat = false;
        public bool specialPlaceholderValue = false;
        public bool SpecifyContainerForNotLocalized = false;
        public bool squareBracketLink = false;
        public bool StringLockedPattern = false;
        public bool trailingSpaceDetector = false;
        public bool virtualPlaceholderWithAttributeValue = false;
        public bool xmlTagDetector = false;
    }
}

