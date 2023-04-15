using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

using Excel = Microsoft.Office.Interop.Excel;
using TracNghiemOnline.Models;
using TracNghiemOnline.Common;


namespace TracNghiemOnline.Controllers
{
    public class ImportExcelController : Controller
    {
        trac_nghiem_onlineEntities db = new trac_nghiem_onlineEntities();
        AdminDA Model = new AdminDA();
        // GET: ImportExcel
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddStudentExcel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudentExcel(FormCollection form, HttpPostedFileBase excelfile)
        {
                if (excelfile.FileName.EndsWith("xls") || excelfile.FileName.EndsWith("xlsx"))
                {
                    string so_rd;
                    Random rd = new Random();
                    so_rd = rd.Next(1, 100000).ToString();
                    string path = Server.MapPath("~/Content/" + so_rd + excelfile.FileName);
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                    excelfile.SaveAs(path);
                    // Đọc file từ Excel 
                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(path);
                    Excel.Worksheet worksheet = workbook.ActiveSheet;
                    Excel.Range range = worksheet.UsedRange;
                    // add dữ liệu từ file excel vào csdl

                    List<student> list_student = new List<student>();
                    for (int row = 5; row <= range.Rows.Count; row++)
                    {
                        student sv = new student();
                        //g.grade_name = ((Excel.Range)range.Cells[row, 2]).Text;
                        string firstname = "HS2023";
                        string name_rd = rd.Next(1000, 9999).ToString();
                        sv.username = firstname + name_rd;
                        sv.name = ((Excel.Range)range.Cells[row, 2]).Text;
                        string pass_temp = ((Excel.Range)range.Cells[row, 3]).Text;
                        sv.password = Common.Encryptor.EncodePassword(pass_temp);
                        sv.email = ((Excel.Range)range.Cells[row, 4]).Text;
                        sv.gender = ((Excel.Range)range.Cells[row, 5]).Text;
                        sv.birthday = Convert.ToDateTime(((Excel.Range)range.Cells[row, 6]).Text);
                        sv.avatar = "avatar-default.jpg";
                        sv.phone = "";
                        sv.id_permission = 3;
                        sv.id_class = int.Parse(((Excel.Range)range.Cells[row, 7]).Text);
                        sv.id_speciality = int.Parse(((Excel.Range)range.Cells[row, 8]).Text);

                        if (sv.name != null && !String.IsNullOrEmpty(sv.name) && sv.password != null && !String.IsNullOrEmpty(sv.password))
                        {
                            list_student.Add(sv);
                        }
                    }
                    using (trac_nghiem_onlineEntities db = new trac_nghiem_onlineEntities())
                    {
                        foreach (var item in list_student)
                        {
                            db.students.Add(item);
                            db.SaveChanges();
                        }
                    }
                    ViewBag.Error = "Import thành công dữ liệu ";
                    return View("AddStudentExcel");
                }
                else
                {
                    ViewBag.Error = "Chỉ hỗ trợ file excel có đuôi là .xls và .xlsx. ";
                    return View("AddStudentExcel");
                }
        }
        public ActionResult AddQuestionExcel()
        {
            ViewBag.ListSubject = Model.GetSubjects();
            return View(Model.GetSubjects());
        }
        [HttpPost]

        public ActionResult AddQuestionExcel(FormCollection form, HttpPostedFileBase excelfile)
        {
            bool check = false;
            if (excelfile.FileName.EndsWith("xls") || excelfile.FileName.EndsWith("xlsx"))
            {
                string so_rd;
                Random rd = new Random();
                so_rd = rd.Next(1000, 9999).ToString();
                string path = Server.MapPath("~/Content/" + so_rd + excelfile.FileName);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                    excelfile.SaveAs(path);
                // Đọc file từ Excel 
                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Open(path);
                Excel.Worksheet worksheet = workbook.ActiveSheet;
                Excel.Range range = worksheet.UsedRange;
                // add dữ liệu từ file excel vào csdl

                List<question> list_question = new List<question>();
                for (int row = 4; row <= range.Rows.Count; row++)
                {
                    question q = new question();

                    q.id_subject = Convert.ToInt32(form["id_subject"]);
                    q.unit= Convert.ToInt32(form["id_subject"]);
                    q.img_content = "noimage.png";
                    q.content = ((Excel.Range)range.Cells[row, 2]).Text;
                    q.answer_a = ((Excel.Range)range.Cells[row, 3]).Text;                    
                    q.answer_b = ((Excel.Range)range.Cells[row, 4]).Text;
                    q.answer_c = ((Excel.Range)range.Cells[row, 5]).Text;
                    q.answer_d = ((Excel.Range)range.Cells[row, 6]).Text;                                   
                    q.correct_answer = ((Excel.Range)range.Cells[row, 7]).Text;

                    if (q.id_subject != null  && q.unit > 0  && q.answer_a != "" && q.answer_b != "" &&
                                                q.answer_c != "" && q.answer_d !="" && q.correct_answer !="")
                        {
                            if(q.answer_a == q.correct_answer || q.answer_b == q.correct_answer || q.answer_c == q.correct_answer || q.answer_d == q.correct_answer)
                            { 
                                list_question.Add(q);
                                check = true;
                            }
                            else
                             {
                                ViewBag.ListSubject = Model.GetSubjects();
                                ViewBag.Error = "Đã tìm thấy lỗi trong file excel đầu vào. Vui lòng kiểm tra lại file.";
                                return View("AddQuestionExcel");
                                }
                        }
                }
               if(check)
                {
                    using (trac_nghiem_onlineEntities db = new trac_nghiem_onlineEntities())
                    {
                        foreach (var item in list_question)
                        {
                            db.questions.Add(item);
                            db.SaveChanges();
                        }
                    }
                    ViewBag.ListSubject = Model.GetSubjects();
                    ViewBag.Error = "Import danh sách câu hỏi thành công. ";
                    return View("AddQuestionExcel");

                }
               else
                {
                    ViewBag.ListSubject = Model.GetSubjects();
                    ViewBag.Error = "Import Không thành công. Có lỗi xảy ra với file";
                    return View("AddQuestionExcel");
                }
            }
            else
            {
                ViewBag.ListSubject = Model.GetSubjects();
                ViewBag.Error = "Chỉ hỗ trợ file excel có đuôi là .xls và .xlsx. ";
                return View("AddQuestionExcel");
            }
        }
    }
}