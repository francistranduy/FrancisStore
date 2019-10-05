﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Data.Migrations
{
    public static class Seeder
    {
        private static readonly string Base = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string Resource = "Seed";
        private static readonly string JsonExtension = ".json";

        public static IEnumerable<T> ReadFile<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return default;
            var path = Path.Combine(Base, Resource, fileName + JsonExtension);
            if (!File.Exists(path))
                return default;

            var json = File.ReadAllText(path);
            var items = JsonConvert.DeserializeObject<IEnumerable<T>>(json);
            return items;
        }
    }
}
