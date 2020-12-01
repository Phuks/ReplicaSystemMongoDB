using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReplicaSystemMongoDB.Models;

namespace ReplicaSystemMongoDB.Controllers
{
    public class ApprenticeshipController : Controller
    {
        // GET: Apprenticeship
        public ActionResult Index()
        {
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.apprenticeships_collection =
                Models.MongoHelper.database.GetCollection<Models.Apprenticeship>("apprenticeship_tb");
            var filter = Builders<Models.Apprenticeship>.Filter.Ne("Id", "");
            var apprenticeship = Models.MongoHelper.apprenticeships_collection.Find(filter).ToList();

            return View(apprenticeship);
        }

        // GET: Apprenticeship/Details/5
        public ActionResult Details(string id)
        {
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.apprenticeships_collection =
                Models.MongoHelper.database.GetCollection<Models.Apprenticeship>("apprenticeship_tb");
            var filter = Builders<Models.Apprenticeship>.Filter.Ne("Id", id);
            var apprenticeship = Models.MongoHelper.apprenticeships_collection.Find(filter).FirstOrDefault();
            return View(apprenticeship);
        }

        // GET: Apprenticeship/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Apprenticeship/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Apprenticeship/Edit/5
        public ActionResult Edit(string id)
        {
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.apprenticeships_collection =
                Models.MongoHelper.database.GetCollection<Models.Apprenticeship>("apprenticeship_tb");
            var filter = Builders<Models.Apprenticeship>.Filter.Ne("Id", id);
            var apprenticeship = Models.MongoHelper.apprenticeships_collection.Find(filter).FirstOrDefault();
            return View(apprenticeship);
        }

        // POST: Apprenticeship/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Apprenticeship/Delete/5
        public ActionResult Delete(string id)
        {
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.apprenticeships_collection =
                Models.MongoHelper.database.GetCollection<Models.Apprenticeship>("apprenticeship_tb");
            var filter = Builders<Models.Apprenticeship>.Filter.Ne("Id", id);
            var apprenticeship = Models.MongoHelper.apprenticeships_collection.Find(filter).FirstOrDefault();
            return View(apprenticeship);
        }

        // POST: Apprenticeship/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                Models.MongoHelper.ConnectToMongoService();
                Models.MongoHelper.apprenticeships_collection =
                    Models.MongoHelper.database.GetCollection<Models.Apprenticeship>("apprenticeship_tb");
                var filter = Builders<Models.Apprenticeship>.Filter.Ne("Id", id);

                var apprenticeship = Models.MongoHelper.apprenticeships_collection.DeleteOneAsync(filter);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Dashboard()
        {
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.apprenticeships_collection =
                Models.MongoHelper.database.GetCollection<Models.Apprenticeship>("apprenticeship_tb");
            var filter = Builders<Models.Apprenticeship>.Filter.Ne("Id", "");
            var result = Models.MongoHelper.apprenticeships_collection.Find(filter).ToList();

            List<int> repartitions = new List<int>();
            var dates = result.Select(x => x.OpenDate).Distinct();

            foreach (var item in dates)
            {
                repartitions.Add(result.Count(x => x.OpenDate == item));
            }

            var rep = repartitions;
            ViewBag.DATES = dates;
            ViewBag.REP = repartitions.ToList();
            return View();
        }
    }

}
