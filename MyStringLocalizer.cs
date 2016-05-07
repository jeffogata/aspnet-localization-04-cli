namespace AspNetLocalization04
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Microsoft.Extensions.Localization;

    public class MyStringLocalizer : IStringLocalizer
    {
        private readonly CultureInfo _culture;

        private readonly List<MyStringData> _stringData; 
               
        public MyStringLocalizer()
        {
            _stringData = new List<MyStringData>();
            
            InitializeLocalizedStrings(_stringData);
        }
        
        public MyStringLocalizer(CultureInfo culture) : this()
        {
            _culture = culture;
        }
        
        public LocalizedString this[string name]
        {
            get
            {
                var culture = _culture ?? CultureInfo.CurrentUICulture;
                var translation = _stringData.FirstOrDefault(x => x.CultureName == culture.Name && x.Name == name)?.Value;
                
                return new LocalizedString(name, translation ?? name, translation != null);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var culture = _culture ?? CultureInfo.CurrentUICulture;
                var translation = _stringData.FirstOrDefault(x => x.CultureName == culture.Name && x.Name == name)?.Value;

                if (translation != null)
                {
                    translation = string.Format(translation, arguments);
                }
                
                return new LocalizedString(name, translation ?? name, translation != null);
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            return _stringData.Select(x => new LocalizedString(x.Name, x.Value, true)).ToList();
        }
        
        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return new MyStringLocalizer(culture);
        }
        
        private void InitializeLocalizedStrings(List<MyStringData> localizedStrings)
        {
            localizedStrings.Clear();
            
            localizedStrings.Add(new MyStringData("it-IT", "Hello", "Ciao"));
            localizedStrings.Add(new MyStringData("it-IT", "Goodbye", "Arrivederci"));
            localizedStrings.Add(new MyStringData("it-IT", "The Current Date", "La Data Corrente"));
            localizedStrings.Add(new MyStringData("it-IT", "A Formatted Number", "Un Numero Formattato"));
            localizedStrings.Add(new MyStringData("it-IT", "A Currency Value", "Un Valore di Valuta"));
            
            localizedStrings.Add(new MyStringData("ja-JP", "Hello", "こんにちは"));
            localizedStrings.Add(new MyStringData("ja-JP", "Goodbye", "さようなら"));
            localizedStrings.Add(new MyStringData("ja-JP", "The Current Date", "現在の日付"));
            localizedStrings.Add(new MyStringData("ja-JP", "A Formatted Number", "フォーマットされた数値"));
            localizedStrings.Add(new MyStringData("ja-JP", "A Currency Value", "通貨の値"));
            
            localizedStrings.Add(new MyStringData("sv-SE", "Hello", "Hej"));
            localizedStrings.Add(new MyStringData("sv-SE", "Goodbye", "Hej då"));
            localizedStrings.Add(new MyStringData("sv-SE", "The Current Date", "Aktuellt Datum"));
            localizedStrings.Add(new MyStringData("sv-SE", "A Formatted Number", "En Formaterad Rad"));
            localizedStrings.Add(new MyStringData("sv-SE", "A Currency Value", "Ett Valutavärde"));

            localizedStrings.Add(new MyStringData("nl-NL", "Hello", "Hallo"));
            localizedStrings.Add(new MyStringData("nl-NL", "Goodbye", "Tot ziens"));
            localizedStrings.Add(new MyStringData("nl-NL", "The Current Date", "De Huidige Datum"));
            localizedStrings.Add(new MyStringData("nl-NL", "A Formatted Number", "Een Opgemaakte Nummer"));
            localizedStrings.Add(new MyStringData("nl-NL", "A Currency Value", "Een Valutawaarde"));

            localizedStrings.Add(new MyStringData("ru-RU", "Hello", "Привет"));
            localizedStrings.Add(new MyStringData("ru-RU", "Goodbye", "До свидания"));
            localizedStrings.Add(new MyStringData("ru-RU", "The Current Date", "Текущая дата"));
            localizedStrings.Add(new MyStringData("ru-RU", "A Formatted Number", "Отформатированный номер"));
            localizedStrings.Add(new MyStringData("ru-RU", "A Currency Value", "Значение валюты"));
        }
        
        private class MyStringData
        {
            public MyStringData(string cultureName, string name, string value)
            {
                CultureName = cultureName;
                Name = name;
                Value = value;
            }
        
            public string CultureName { get; private set; }
            
            public string Name {get; private set; }

            public string Value {get; private set; }
        }
    }
}