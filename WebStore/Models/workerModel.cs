using System;
using System.Collections.Generic;
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
        public string password { get; set; }
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
                             select a.username).ToList();

                var passwordQuery = (from a in dbContext.workerAccounts
                                     select a.password).ToList();

                foreach(var item in query)
                {
                    newWorkerModel.username = item;
                    newWorkerList.Add(newWorkerModel);
                }

                return newWorkerList;
            }
        }
    }
}