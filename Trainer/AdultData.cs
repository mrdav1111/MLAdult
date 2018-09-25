using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Runtime.Api;

namespace Trainer

{
    //Listing of attributes: 

    //>50K, <=50K.

    //age: continuous.
    //workclass: Private, Self-emp-not-inc, Self-emp-inc, Federal-gov, Local-gov, State-gov, Without-pay, Never-worked.
    //fnlwgt: continuous.
    //education: Bachelors, Some-college, 11th, HS-grad, Prof-school, Assoc-acdm, Assoc-voc, 9th, 7th-8th, 12th, Masters, 1st-4th, 10th, Doctorate, 5th-6th, Preschool.
    //education-num: continuous.
    //marital-status: Married-civ-spouse, Divorced, Never-married, Separated, Widowed, Married-spouse-absent, Married-AF-spouse.
    //occupation: Tech-support, Craft-repair, Other-service, Sales, Exec-managerial, Prof-specialty, Handlers-cleaners, Machine-op-inspct, Adm-clerical, Farming-fishing, Transport-moving, Priv-house-serv, Protective-serv, Armed-Forces.
    //relationship: Wife, Own-child, Husband, Not-in-family, Other-relative, Unmarried.
    //race: White, Asian-Pac-Islander, Amer-Indian-Eskimo, Other, Black.
    //sex: Female, Male.
    //capital-gain: continuous.
    //capital-loss: continuous.
    //hours-per-week: continuous.
    //native-country: United-States, Cambodia, England, Puerto-Rico, Canada, Germany, Outlying-US(Guam-USVI-etc), India, Japan, Greece, South, China, Cuba, Iran, Honduras, Philippines, Italy, Poland, Jamaica, Vietnam, Mexico, Portugal, Ireland, France, Dominican-Republic, Laos, Ecuador, Taiwan, Haiti, Columbia, Hungary, Guatemala, Nicaragua, Scotland, Thailand, Yugoslavia, El-Salvador, Trinadad&Tobago, Peru, Hong, Holand-Netherlands.
    class AdultData
    {
        [Column(ordinal:"0")]
        public int age;
        [Column(ordinal: "1", name: "workClass")]
        public string workClass;
        [Column(ordinal:"2")]
        public int fnlwgt;
        [Column(ordinal:"3")]
        public string education;
        [Column(ordinal:"5")]
        public string maritalStatus;
        [Column(ordinal:"6")]
        public string occupation;
        [Column(ordinal:"7")]
        public string relationship;
        [Column(ordinal:"8")]
        public string race;
        [Column(ordinal:"9")]
        public string sex;
        [Column(ordinal:"10")]
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

    class AdultPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool esMayorA50;
    }
}
