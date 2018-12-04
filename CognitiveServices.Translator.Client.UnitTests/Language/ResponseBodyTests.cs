using CognitiveServices.Translator.Client.Language;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;

namespace CognitiveServices.Translator.Client.UnitTests.Language
{
    [Trait("Category", "Unit")]
    public class ResponseBodyTests
    {
        [Fact]
        public void Ctor_WhenDeserializing_ExpectSuccess()
        {
            // to make it fully working: https://app.quicktype.io?share=8GNEl0vZsi3eAQnZmG6I?
            string path = AppDomain.CurrentDomain.BaseDirectory;

            var content = File.ReadAllText(Path.Combine(path, "Fixtures/Language_AllScopes.json"));
            dynamic dynamicResult = JsonConvert.DeserializeObject(content);
            var result = JsonConvert.DeserializeObject<ResponseBody>(content);
            var jo = JObject.Parse(content);
            var tmpSettings = new JsonSerializerSettings() { Converters = new JsonConverter[] { new JsonGenericDictionaryOrArrayConverter() } };
            var tmpstuff = jo.SelectToken("translation").ToString();
            var tr2 = JsonConvert.DeserializeObject<Dictionary<CultureInfo, TranslationBase>>(tmpstuff, tmpSettings);
            var tr = jo.SelectToken("translation").ToObject<Dictionary<CultureInfo, TranslationBase>>();

        }
    }
    public class JsonGenericDictionaryOrArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.GetDictionaryKeyValueTypes().Count() == 1;
        }

        public override bool CanWrite { get { return false; } }

        object ReadJsonGeneric<TKey, TValue>(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var tokenType = reader.TokenType;

            var dict = existingValue as IDictionary<TKey, TValue>;
            if (dict == null)
            {
                var contract = serializer.ContractResolver.ResolveContract(objectType);
                dict = (IDictionary<TKey, TValue>)contract.DefaultCreator();
            }

            if (tokenType == JsonToken.StartArray)
            {
                var pairs = new JsonSerializer().Deserialize<KeyValuePair<TKey, TValue>[]>(reader);
                if (pairs == null)
                    return existingValue;
                foreach (var pair in pairs)
                    dict.Add(pair);
            }
            else if (tokenType == JsonToken.StartObject)
            {
                // Using "Populate()" avoids infinite recursion.
                // https://github.com/JamesNK/Newtonsoft.Json/blob/ee170dc5510bb3ffd35fc1b0d986f34e33c51ab9/Src/Newtonsoft.Json/Converters/CustomCreationConverter.cs
                serializer.Populate(reader, dict);
            }
            return dict;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var keyValueTypes = objectType.GetDictionaryKeyValueTypes().Single(); // Throws an exception if not exactly one.

            var method = GetType().GetMethod("ReadJsonGeneric", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            var genericMethod = method.MakeGenericMethod(new[] { keyValueTypes.Key, keyValueTypes.Value });
            return genericMethod.Invoke(this, new object[] { reader, objectType, existingValue, serializer });
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    public static class TypeExtensions
    {
        /// <summary>
        /// Return all interfaces implemented by the incoming type as well as the type itself if it is an interface.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetInterfacesAndSelf(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException();
            if (type.IsInterface)
                return new[] { type }.Concat(type.GetInterfaces());
            else
                return type.GetInterfaces();
        }

        public static IEnumerable<KeyValuePair<Type, Type>> GetDictionaryKeyValueTypes(this Type type)
        {
            foreach (Type intType in type.GetInterfacesAndSelf())
            {
                if (intType.IsGenericType
                    && intType.GetGenericTypeDefinition() == typeof(IDictionary<,>))
                {
                    var args = intType.GetGenericArguments();
                    if (args.Length == 2)
                        yield return new KeyValuePair<Type, Type>(args[0], args[1]);
                }
            }
        }
    }
}
