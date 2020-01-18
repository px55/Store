using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;


namespace WebStore.Models
{
    public class workerModel
    {
        public int worker_ID { get; set; }
        public string worker_firstNM { get; set; }
        public string worker_lastNM { get; set; }
        public string username { get; set; }
        [DisplayName("Username:")]
        public string usernameInput { get; set; }
        public string password { get; set; }
        [DisplayName("Password:")]
        public string passwordInput { get; set; }
        public int user_ID { get; set; }

        public workerModel returnWorkerID()
        {
            workerModel newWorkerModel = new workerModel();

            using (var dbContext = new StoreEntities())
            {
                var firstNM = (from w in dbContext.workerInfoes
                               select w.firstNM).FirstOrDefault();

                newWorkerModel.worker_firstNM = firstNM;

                return newWorkerModel;
            }
        }

        public List<workerModel> getAccounts()
        {
            List<workerModel> newWorkerList = new List<workerModel>();
            workerModel newWorkerModel = new workerModel();

            using (var dbContext = new StoreEntities())
            {
                var query = (from a in dbContext.workerAccounts
                             select a).ToList();

                foreach(var item in query)
                {
                    var test = new workerModel
                    {
                        username = item.username,
                        password = item.password
                    };
                    newWorkerList.Add(test);
                }
                return newWorkerList;
            }
        }
    }
}