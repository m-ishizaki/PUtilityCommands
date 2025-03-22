using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RKSoftware.PUtilityCommands.Commands
{
    internal class RdsConfig
    {
        Lazy<HttpClient> httpClient = new Lazy<HttpClient>(() => new HttpClient());
        public async Task Execute()
        {
            var test = await httpClient.Value.GetAsync("https://raw.githubusercontent.com/pleasanter-developer-community/Implem.Pleasanter/6d57a986218bf39d58e572189ff15f7bfe1b8a8a/Implem.Pleasanter/App_Data/Parameters/Rds.json");
            var result = await test.Content.ReadAsStringAsync() ?? string.Empty;
            dynamic jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            jsonObject.Dbms = "SQLServer";
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject);
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "Rds.json"), jsonString);
        }
    }
}
