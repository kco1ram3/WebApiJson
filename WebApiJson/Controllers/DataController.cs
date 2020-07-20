using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiJson.Controllers
{
    public class DataController : ApiController
    {
        private static List<TableData> listTableData = new List<TableData>();

        public dynamic Get()
        {
            if (!listTableData.Any()) InitializeData();
            return Json(listTableData);
        }

        public dynamic Get(int id)
        {
            if (!listTableData.Any()) InitializeData();
            return Json(listTableData.FirstOrDefault(x => x.RowId == id));
        }

        private void InitializeData()
        {
            listTableData.Add(new TableData()
            {
                RowId = 1,
                Data = "{title: \"Mr.\", name: \"Michal\", surname: \"Bay\"}"
            });
            listTableData.Add(new TableData()
            {
                RowId = 2,
                Data = "[{name: \"Michal\", surname: \"Bay\", age: 35}, {name: \"John\", surname: \"Wick\", age: 46}]"
            });
            listTableData.Add(new TableData()
            {
                RowId = 3,
                Data = "[{name: \"Michal\", surname: \"Bay\", address: {street: \"Sub\", district: \"Bang Ruk\", province: \"Bangkok\", zipcode: \"10500\"}, email: {individual: \"admin@gmail.com\", office: \"admin@company.com\"}}, {name: \"John\", surname: \"Wick\", address: [{street: \"-\", district: \"-\", province: \"Chiangmai\", zipcode: \"50160\"}, {street: \"N/A\", district: \"N/A\", province: \"Phuket\", zipcode: \"83130\"}]}]"
            });
        }
    }

    public class TableData
    {
        private string _data;
        public int RowId { get; set; }
        public dynamic Data {
            get
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<object>(_data);
            }
            set
            {
                _data = value;
            }
        }
    }
}
