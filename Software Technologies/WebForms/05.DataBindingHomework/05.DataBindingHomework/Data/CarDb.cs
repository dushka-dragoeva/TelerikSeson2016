using _05.DataBindingHomework.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _05.DataBindingHomework.Data
{
    public class CarDb
    {
        public static List<Producer> GetProducers()
        {
            List<Producer> producers = new List<Producer>();

            Producer bmw = new Producer("BMW");

            bmw.Models.Add("320");
            bmw.Models.Add("325");
            bmw.Models.Add("330");
            bmw.Models.Add("530");
            bmw.Models.Add("550");
            bmw.Models.Add("5GT");
            bmw.Models.Add("740");
            bmw.Models.Add("850");
            bmw.Models.Add("Z8");

            producers.Add(bmw);

            Producer mercedes = new Producer("Mercedes");

            mercedes.Models.Add("C200");
            mercedes.Models.Add("C220");
            mercedes.Models.Add("E350");
            mercedes.Models.Add("E400");
            mercedes.Models.Add("GLA220");
            mercedes.Models.Add("S400");
            mercedes.Models.Add("S450");
            mercedes.Models.Add("S500");
            mercedes.Models.Add("SL60AMG");

            producers.Add(mercedes);

            Producer audi = new Producer("Audi");
            audi.Models.Add("A1");
            audi.Models.Add("A2");
            audi.Models.Add("A3");
            audi.Models.Add("A4");
            audi.Models.Add("A5");
            audi.Models.Add("A6");
            audi.Models.Add("A7");
            audi.Models.Add("S5");
            audi.Models.Add("S8");
            audi.Models.Add("TT");

            producers.Add(audi);


            return producers;
        }
        public static List<Extra> GetExtras()
        {
            List<Extra> extars = new List<Extra>();
            extars.Add(new Extra("Auto Start Stop function"));
            extars.Add(new Extra("Bluetooth \\ handsfree система"));
            extars.Add(new Extra("Steptronic, Tiptronic"));
            extars.Add(new Extra("Блокаж на диференциала"));
            extars.Add(new Extra("Бордкомпютър"));
            extars.Add(new Extra("Датчик за светлина"));
            extars.Add(new Extra("Ел.Огледала"));
            extars.Add(new Extra("Ел.Стъкла"));
            extars.Add(new Extra("Ел.регулиране на седалките"));
            extars.Add(new Extra("Ел.усилвател на волана"));
            extars.Add(new Extra("Климатроник"));
            extars.Add(new Extra("Мултифункционален волан"));
            extars.Add(new Extra("Навигация"));
            extars.Add(new Extra("Печка"));
            extars.Add(new Extra("Подгряване на предното стъкло"));
            extars.Add(new Extra("Подгряване на седалките"));
            extars.Add(new Extra("Регулиране на волана"));
            extars.Add(new Extra("Сензор за дъжд"));
            extars.Add(new Extra("Серво усилвател на волана"));
            extars.Add(new Extra("Система за контрол на скоростта -автопилот"));
            extars.Add(new Extra("Филтър за твърди частици"));

            return extars;
        }

        public static string[] GetEngineType()
        {
            string[] engineTypes = { "Дизел", "Бензин", "Хибрид", "Електрически", "Всички типове" };

            return engineTypes;
        }
    }
}