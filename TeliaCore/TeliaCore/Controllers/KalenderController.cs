using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeliaCore.Models;

namespace TeliaCore.Controllers
{
    public class CalendarActionResponseModel
    {
        public String Status;
        public Int64 SourceId;
        public Int64 TargetId;

        public CalendarActionResponseModel(String status, Int64 sourceId, Int64 targetId)
        {
            Status = status;
            SourceId = sourceId;
            TargetId = targetId;
        }
    }

    public class KalenderController : Controller
    {
        //
        // GET: /Calendar/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Data()
        {
            var data = new MyEventsDataContext();
            return View(data.Events);
        }

        public ActionResult Save(Event changedEvent, FormCollection actionValues)
        {
            String actionType = actionValues["!nativeeditor_status"];
            Int64 sourceId = Int64.Parse(actionValues["id"]);
            Int64 targetId = sourceId;


            var data = new MyEventsDataContext();
            try
            {
                switch (actionType)
                {
                    case "inserted":
                        data.Events.InsertOnSubmit(changedEvent);
                        break;
                    case "deleted":
                        changedEvent = data.Events.SingleOrDefault(ev => ev.id == sourceId);
                        if (changedEvent != null) data.Events.DeleteOnSubmit(changedEvent);
                        break;
                    default: // "updated"
                        changedEvent = data.Events.SingleOrDefault(ev => ev.id == sourceId);
                        UpdateModel(changedEvent);
                        break;
                }
                data.SubmitChanges();
                if (changedEvent != null) targetId = changedEvent.id;
            }
            catch
            {
                actionType = "error";
            }

            return View(new CalendarActionResponseModel(actionType, sourceId, targetId));
        }
    }
}
