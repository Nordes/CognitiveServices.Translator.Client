using System.ComponentModel;

/// <summary>
/// Error codes available at: 
/// https://docs.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-reference
/// </summary>
public enum CommonErrorCode {
  [Description("One of the request inputs is not valid.")]
  RequestInputIsInvalid = 400000,
  [Description("The \"scope\" parameter is invalid.")]
  ParameterScopeIsInvalid = 400001,
  [Description("The \"category\" parameter is invalid.")]
  ParameterCategoryIsInvalid = 400002,
  [Description("A language specifier is missing or invalid.")]
  LanguageSpecifierIsMissingOrInvalid = 400003,
  [Description("A target script specifier (\"To script\") is missing or invalid.")]
  SpecifierToScriptIsMissingOrInvalid = 400004,
  [Description("An input text is missing or invalid.")]
  InputTextIsMissingOrInvalid = 400005,
  [Description("The combination of language and script is not valid.")]
  LanguageAndScriptCombinationIsInvalid = 400006,
  [Description("A source script specifier (\"From script\") is missing or invalid.")]
  SpecifierFromScriptIsMissingOrInvalid = 400018,
  [Description("One of the specified language is not supported.")]
  LanguageSpecifiedIsNotSupported = 400019,
  [Description("One of the elements in the array of input text is not valid.")]
  InputTextElementsAreInvalid = 400020,
  [Description("The API version parameter is missing or invalid.")]
  VersionParameterIsMissingOrInvalid = 400021,
  [Description("One of the specified language pair is not valid.")]
  LanguagePairIsInvalid = 400023,
	[Description("The source language (\"From\" field) is not valid.")]
  FromFieldIsInvalid = 400035,
	[Description("The target language (\"To\" field) is missing or invalid.")]
  TargetLanguageIsMissingOrInvalid = 400036,
	[Description("One of the options specified (\"Options\" field) is not valid.")]
  OptionsSpecifiedAreInvalid = 400042,
	[Description("The client trace ID (ClientTraceId field or X-ClientTranceId header) is missing or invalid.")]
  ClientTraceIdIsMissingOrInvalid = 400043,
	[Description("The input text is too long.")]
  InputTextIsTooLong = 400050,
	[Description("The \"translation\" parameter is missing or invalid.")]
  TranslationParameterIsMissingOrInvalid = 400064,
	[Description("The number of target scripts (ToScript parameter) does not match the number of target languages (To parameter).")]
  NumberOfToScriptNotMatchingNumberOfTargetLanguages = 400070,
	[Description("The value is not valid for TextType.")]
  ValueForTextTypeIsInvalid = 400071,
	[Description("The array of input text has too many elements.")]
  InputTextArrayHasTooManyElements = 400072,
  [Description("The script parameter is not valid.")]
  ScriptParameterIsInvalid = 400073,
	[Description("The body of the request is not valid JSON.")]
  RequestBodyJsonIsInvalid = 400074,
	[Description("The language pair and category combination is not valid.")]
  LanguagePairAndCategoryCombinationAreInvalid = 400075,
	[Description("The maximum request size has been exceeded.")]
  RequestSizeMaximumExceeded = 400077,
	[Description("The custom system requested for translation between from and to language does not exist.")]
  FromAndToSystemRequestedDoesNotExists = 400079,
	[Description("The request is not authorized because credentials are missing or invalid.")]
  RequestUnauthorized = 401000,
	[Description("The credentials provided are for the Speech API. This request requires credentials for the" +
               "Text API. Please use a subscription to Translator Text API.")]
  SpeechApiCredentialProvidedInsteadOfTextApi = 401015,
	[Description("The operation is not allowed.")]
  OperationNotAllowed = 403000,
	[Description("The operation is not allowed because the subscription has exceeded its free quota.")]
  SubscriptionFreeQuotaExceeded = 403001,
	[Description("The request method is not supported for the requested resource.")]
  RequestMethodNotSupporded = 405000,
	[Description("The custom translation system requested is not yet available. Please retry in a few minutes.")]
  TranslationSystemNotYetAvailableRetryLater = 408001,
	[Description("The Content-Type header is missing or invalid.")]
  ContentTypeHeaderIsMissingOrInvalid = 415000,
  [Description("The server rejected the request because the client is sending too many requests. Reduce the" + 
              " frequency of requests to avoid throttling.")]
  TooManyRequestsAvoidThrottling0 = 429000,
  [Description("The server rejected the request because the client is sending too many requests. Reduce the" + 
              " frequency of requests to avoid throttling.")]
  TooManyRequestsAvoidThrottling1 = 429001,
  [Description("The server rejected the request because the client is sending too many requests. Reduce the" + 
              " frequency of requests to avoid throttling.")]
  TooManyRequestsAvoidThrottling2 = 429002,
	[Description("An unexpected error occurred. If the error persists, report it with date/time of error, request" +
              " identifier from response header X-RequestId, and client identifier from request header X-ClientTraceId.")]
  UnexpectedErrorOccured = 500000,
	[Description("Service is temporarily unavailable. Please retry. If the error persists, report it with date/time" +
              " of error, request identifier from response header X-RequestId, and client identifier from request" +
              " header X-ClientTraceId.  ")]
  ServiceTemporarilyUnavailablePleaseRetry = 503000
}