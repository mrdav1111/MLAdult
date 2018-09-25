using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Runtime.Api;

namespace MLWeb

{

    public class AdultData
    {
        [Column(ordinal: "0")]
        public int age;
        [Column(ordinal: "1", name: "workClass")]
        public string workClass;
        [Column(ordinal: "2")]
        public int fnlwgt;
        [Column(ordinal: "3")]
        public string education;
        [Column(ordinal: "5")]
        public string maritalStatus;
        [Column(ordinal: "6")]
        public string occupation;
        [Column(ordinal: "7")]
        public string relationship;
        [Column(ordinal: "8")]
        public string race;
        [Column(ordinal: "9")]
        public string sex;
        [Column(ordinal: "10")]
        public int capitalGain;
        [Column(ordinal: "11")]
        public int capitalLoss;
        [Column(ordinal: "12")]
        public int hoursPerWeek;
        [Column(ordinal: "13")]
        public string nativeCountry;
        [Column(ordinal: "15", name: "Label")]
        public bool esMayorA50;
    }

    public class AdultPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool esMayorA50;
    }
}
