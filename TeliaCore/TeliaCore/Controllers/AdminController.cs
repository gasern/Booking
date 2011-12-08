using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeliaCore.Models;
using TeliaCore.Services.Interfaces;

namespace TeliaCore.Controllers
{
    public class AdminController : Controller
    {
        public Model1Container _db { get; set; }
        public AdminController()
        {
            _db = new Model1Container();
        
        }

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        #region Contacts
        public ActionResult ContactCreate()
        {
            return View("Contact/Create");
        }

        public ActionResult ContactSave(Contact contact)
        {
            contact.LastOnline = DateTime.Now;
            contact.CreateDate = DateTime.Now;

            _db.Contacts.Add(contact);
            _db.SaveChanges();

            return RedirectToAction("ContactList");
        }

        public ActionResult ContactList()
        {
            return View("Contact/List",_db.Contacts.ToList());
        }

        public ActionResult ContactDetails(int id)
        {
            var contactDetails = _db.Contacts.Find(id);
            return View("Contact/Details", contactDetails);
        }

        public ActionResult ContactEdit(int id)
        {

            var contact = _db.Contacts.Find(id);
            return View("Contact/Edit", contact);
        }

        public ActionResult ContactDelete(int id)
        {
            var contactToDelete = _db.Contacts.Find(id);
            return View("Contact/Delete", contactToDelete);
        }

        public ActionResult ContactDeleteConfirm(int id)
        {
            var contact = _db.Contacts.Find(id);

            _db.Entry(contact).State = EntityState.Deleted;
            _db.SaveChanges();
            return RedirectToAction("ContactList");
        }
        #endregion

        #region Meal
        
        public ActionResult ProductCreate()
        {
            return View("Product/Create");
        }

        public ActionResult ProductDelete(int id)
        {
            var Product = _db.Products.Find(id);
            _db.Entry(Product).State = EntityState.Deleted;
            _db.SaveChanges();
       
            return View("Product/Delete");
        }

        public ActionResult ProductList()
        {
            return View("Product/List",_db.Products.ToList());
        }


        public ActionResult ProductEdit(Product refreshment)
        {
            return View("Product/Edit");
        }

        public ActionResult ProductDetails(int id)
        {
            return View("Product/Edit",_db.Products.Find(id));
        }


        public ActionResult ProductSave(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("ProductList");
        }
        
        #endregion
        
        
        public ActionResult RoomCreate()
        {
            return View("Room/Create");
        }

        public ActionResult RoomSave(Room room)
        {
            _db.Rooms.Add(room);
            _db.SaveChanges();
            return RedirectToAction("RoomList");
        }

        public ActionResult RoomList()
        {
            return View("Room/List",_db.Rooms.ToList());
        }


        public ActionResult CreateDatabaseContent()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                    {
                        Name = "Coca cola",
                        Description = "Coca cola 0,5 l.",
                        Price = 15,
                        Size = "0.5"
                    },
                new Product()
                    {
                        Name = "Spaghetti",
                        Description = "Spaghetti bolognese med parmesan",
                        Price = 35,
                        Size = "Voksen"
                    },
                    new Product()
                    {
                        Name = "Æggesandwich",
                        Description = "Baguette med æg",
                        Price = 20,
                        Size = "Voksen"
                    }
            };

            List<Contact> contacts = new List<Contact>()
            {
                new Contact()
                    {
                        FirstName = "Jimmie",
                        LastName = "R",
                        Initials = "JR",
                        Department = "IT",
                        Email = "Jimmi@gmail.com",
                        PhoneNumber = 41611985,
                        MobileNumber = 41611985,
                        IsOnline = true,
                        LastOnline = DateTime.Now,
                        CreateDate = DateTime.Now,
                        UserName = "Gasern",
                        Password = "TestTest",
                        RememberMe = true
                    },
                    new Contact()
                    {
                        FirstName = "Yusuf",
                        LastName = "K",
                        Initials = "YK",
                        Department = "IT",
                        Email = "frugtfjols@gmail.com",
                        PhoneNumber = 41611985,
                        MobileNumber = 41611985,
                        IsOnline = true,
                        LastOnline = DateTime.Now,
                        CreateDate = DateTime.Now,
                        UserName = "Yusuf",
                        Password = "TestTest",
                        RememberMe = true
                    },
                    new Contact()
                    {
                        FirstName = "Mette",
                        LastName = "J",
                        Initials = "MJ",
                        Department = "Sales",
                        Email = "mette.jensen@teliasonera.com",
                        PhoneNumber = 41611985,
                        MobileNumber = 41611985,
                        IsOnline = true,
                        LastOnline = DateTime.Now,
                        CreateDate = DateTime.Now,
                        UserName = "Mette",
                        Password = "TestTest",
                        RememberMe = true
                    }
                };
            List<Room> rooms = new List<Room>()
            {
                new Room()
                    {
                        Name = "Audiotorium",
                        Description = "Fællessalen",
                        Nr = 1,
                        Location = "Kantinen",
                        NumberOfSeats = 300,
                        InternetAvailable = true,
                        PhoneAvailable = false,
                        ProjectorAvailable = true,
                        VideoconferenceAvailable = false,
                        WhiteboardAvailable = false
                    },
                    new Room()
                    {
                        Name = "Q",
                        Description = "Kælderens største",
                        Nr = 65,
                        Location = "Kælderen",
                        NumberOfSeats = 20,
                        InternetAvailable = true,
                        PhoneAvailable = true,
                        ProjectorAvailable = true,
                        VideoconferenceAvailable = false,
                        WhiteboardAvailable = true
                    },
                    new Room()
                    {
                        Name = "A45",
                        Description = "4 sal, nr 5",
                        Nr = 45,
                        Location = "4 sal.",
                        NumberOfSeats = 12,
                        InternetAvailable = true,
                        PhoneAvailable = true,
                        ProjectorAvailable = true,
                        VideoconferenceAvailable = true,
                        WhiteboardAvailable = true
                    }
            };

            foreach (var contact in contacts)
            {
                _db.Contacts.Add(contact);
            }
            foreach (var product in products)
            {
                _db.Products.Add(product);
            }
            foreach (var room in rooms)
            {
                _db.Rooms.Add(room);
            }
            _db.SaveChanges();

            return View("Index");
        }
    }
}
