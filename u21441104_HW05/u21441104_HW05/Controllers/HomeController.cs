using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u21441104_HW05.ViewModels;

namespace u21441104_HW05.Controllers
{
    public class HomeController : Controller
    {

        private SqlConnection connection = new SqlConnection(@"Data Source=TYRONSSPEEDYBOY\SQLEXPRESS02;Initial Catalog=Library;Integrated Security=True");

        public ActionResult Index()
        {
            List<BooksVM> bookLIST = new List<BooksVM>();
            try
            {
                connection.Open();
                SqlCommand myCommand = new SqlCommand("SELECT bookId, books.name, authors.surname, types.name, pagecount, point FROM authors, books, types WHERE books.authorId = authors.authorId AND books.typeId = types.typeId; ", connection);
                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    BooksVM book = new BooksVM();
                    book.ID = myReader.GetInt32(0);
                    book.NAME = myReader.GetString(1);
                    book.AUTHOR = myReader.GetString(2);
                    book.TYPE = myReader.GetString(3);
                    book.PAGE_COUNT = myReader.GetInt32(4);
                    book.POINTS = myReader.GetInt32(5);
                    book.STATUS = true;

                    bookLIST.Add(book);
                }
            }
            catch (Exception err)
            {

                ViewBag.Status = 0;
            }
            finally
            {
                connection.Close();
            }

            return View(bookLIST);
        }

        public ActionResult ViewStudents()
        {
            List<StudentsVM> studentLIST = new List<StudentsVM>();
            try
            {
                connection.Open();
                SqlCommand myCommand = new SqlCommand("SELECT * FROM students; ", connection);
                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    StudentsVM student = new StudentsVM();
                    student.ID = myReader.GetInt32(0);
                    student.NAME = myReader.GetString(1);
                    student.SURNAME = myReader.GetString(2);
                    student.CLASS = myReader.GetString(5);
                    student.POINTS = myReader.GetInt32(6);

                    studentLIST.Add(student);
                }
            }
            catch (Exception err)
            {

                ViewBag.Status = 0;
            }
            finally
            {
                connection.Close();
            }

            return View(studentLIST);
        }

        public ActionResult BookDetails()
        {
            List<BorrowsVM> bookDetailLIST = new List<BorrowsVM>();
            try
            {
                connection.Open();
                SqlCommand myCommand = new SqlCommand("SELECT borrowId, takenDate, broughtDate, students.name FROM borrows, students WHERE borrowId = 1; ", connection);
                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    BorrowsVM book = new BorrowsVM();
                    book.ID = myReader.GetInt32(0);
                    book.TAKEN_DATE = myReader.GetDateTime(1);
                    book.BROUGHT_DATE = myReader.GetDateTime(2);
                    book.BORROWED_BY = myReader.GetString(3);

                    bookDetailLIST.Add(book);
                }
            }
            catch (Exception err)
            {

                ViewBag.Status = 0;
            }
            finally
            {
                connection.Close();
            }

            return View(bookDetailLIST);
        }

        public ActionResult ViewBook()
        {
            return View("BookDetails");
        }
        public ActionResult ViewStudent()
        {
            List<BorrowsVM> bookDetailLIST = new List<BorrowsVM>();
            try
            {
                connection.Open();
                SqlCommand myCommand = new SqlCommand("SELECT borrowId, takenDate, broughtDate, students.name FROM borrows, students; ", connection);
                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    BorrowsVM book = new BorrowsVM();
                    book.ID = myReader.GetInt32(0);
                    book.TAKEN_DATE = myReader.GetDateTime(1);
                    book.BROUGHT_DATE = myReader.GetDateTime(2);
                    book.BORROWED_BY = myReader.GetString(3);

                    bookDetailLIST.Add(book);
                }
            }
            catch (Exception err)
            {

                ViewBag.Status = 0;
            }
            finally
            {
                connection.Close();
            }

            return View(bookDetailLIST);
        }

        [HttpPost]
        public ActionResult btnSearchBook(string txtBookName, string slctType, string slctAuthor)
        {
            ViewBag.Test = "Test";
            return View();
        }
    }
}