using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using schoolsSystems.Models;

namespace schoolsSystems.Controllers
{
    public class TimeTableController : Controller
    {
        EMEntities db;

        public TimeTableController()
        {
            db = new EMEntities();
        }
        //
        // GET: /TimeTable/

        public ActionResult Index(int schoolId=0,int schoolFormId=0)
        {
            School school = db.School.FirstOrDefault(s => s.Id == schoolId);
            ViewData.Add("school", school);
            List<TimeTable> timeTable = db.TimeTable.Where(tt => tt.SchoolId == schoolId && tt.SchoolFormId==schoolFormId).ToList();
            ViewBag.BodyTitle = "Расписание";
            ViewBag.schoolId = schoolId;
            ViewBag.schoolFormId = schoolFormId;
            return View(timeTable);
        }

        public ActionResult Edit(int schoolId=0,int schoolFormId=0,int dayOfWeek=0 )
        {
            School school = db.School.FirstOrDefault(s => s.Id == schoolId);
            ViewData.Add("school", school);
            IEnumerable<TimeTable> timeTable = db.TimeTable.Where(tt => tt.SchoolId == schoolId && tt.SchoolFormId == schoolFormId && tt.DayOfWeek == dayOfWeek);
            List<TimeTable> res = new List<TimeTable>();
            for (int i = 1; i < 10; i++)
            {
                TimeTable lesson = timeTable.FirstOrDefault(tt=>tt.LessonNumber==i);
                if(lesson==null)
                    res.Add(new TimeTable{SchoolId=schoolId,SchoolFormId=schoolFormId,DayOfWeek=dayOfWeek,LessonNumber=i});
                else
                    res.Add(lesson);
            }
            ViewData.Add("subjects",db.Subject.ToList());
            return View(new DayOfTimeTable { SchoolId=schoolId,SchoolFormId=schoolFormId,listOfDay=res});
        }
        public ActionResult Save(DayOfTimeTable dayOfTimeTable)
        {
            List<TimeTable> onSave = dayOfTimeTable.listOfDay.Where(tt => tt.SubjectId != 0).ToList();
            foreach (var tt in onSave)
            {
                db.TimeTable.Add(tt);
            }
            db.SaveChanges();
            return RedirectToAction("Index", new { schoolId=dayOfTimeTable.SchoolId,schoolFormId=dayOfTimeTable.SchoolFormId});
        }

        public PartialViewResult ListOfDay(List<TimeTable> timeTable, int dayOfWeek)
        {
            return PartialView(timeTable.Where(tt=>tt.DayOfWeek==dayOfWeek).ToList());
        }
    }
}
