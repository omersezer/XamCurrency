using System;
namespace XamCurrency.Models
{
    public class CurrencyModel
    {
        public string pair { get; set; }
        public double high { get; set; }
        public double last { get; set; }
        public double timestamp { get; set; }
        public double bid { get; set; }
        public double volume { get; set; }
        public double low { get; set; }
        public double ask { get; set; }
        public double open { get; set; }
        public double average { get; set; }
        public double daily { get; set; }
        public double dailyPercent { get; set; }
        public string denominatorsymbol { get; set; }
        public string numeratorsymbol { get; set; }
    }
}
