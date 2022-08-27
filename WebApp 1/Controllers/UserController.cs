using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_1.Data;
using WebApp_1.Models;

namespace WebApp_1.Controllers
{
    public class UserController : Controller
    {
        private Applicationclass _context;

        public UserController(Applicationclass context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User_Master_Table_1 model)
        {
          
            if (ModelState.IsValid)
            {
                User_Master_Table_1 obj = new User_Master_Table_1();

                obj.User_MasterFName = model.User_MasterFName;
                obj.User_MasterSName = model.User_MasterSName;
                obj.User_MasterEmail = model.User_MasterEmail;
                obj.User_Master_MO_BO = model.User_Master_MO_BO;


                if (model.User_MasterID == 0)
                {
                    if (_context.User_Master_Table_1.Where(x => x.User_MasterEmail == model.User_MasterEmail).Count() > 0)
                    {
                        ViewBag.TotalStudents = "User Email id is a Already Exist";

                        return View("Index");
                    }
                    else if (_context.User_Master_Table_1.Where(y => y.User_Master_MO_BO == model.User_Master_MO_BO).Count() > 0)
                    {
                        ViewBag.TotalStudents = "User Mobile Number is a Already Exist";
                        return View("Index");
                    }
                    else
                    {
                        _context.User_Master_Table_1.Add(obj);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    if (_context.User_Master_Table_1.Where(x => x.User_MasterEmail == model.User_MasterEmail
                        && x.User_Master_MO_BO == model.User_Master_MO_BO 
                        && x.User_MasterID == x.User_MasterID).FirstOrDefault() != null)
                    {
                        /*_ = _context.User_Master_Table_1.Update(model);*/
                        var ui = _context.User_Master_Table_1.Where(x => x.User_MasterID == model.User_MasterID).First();

                        ui.User_MasterFName = model.User_MasterFName;
                        ui.User_MasterEmail = model.User_MasterEmail;
                        ui.User_MasterSName = model.User_MasterSName;
                        ui.User_Master_MO_BO = model.User_Master_MO_BO;
                        _context.SaveChanges();
                    }
                    else
                    {
                        if (_context.User_Master_Table_1.Where(y => y.User_Master_MO_BO == model.User_Master_MO_BO).Count() > 0)
                        {
                            ViewBag.TotalStudents = "User Mobile Number is a Already Exist";
                            return View("User");
                        }
                        else if (_context.User_Master_Table_1.Where(y => y.User_MasterEmail == model.User_MasterEmail).Count() > 0)
                        {
                            ViewBag.TotalStudents = "User Email id is a Already Exist";
                            return View("User");
                        }
                    }
                }
            }
            ModelState.Clear();

            return RedirectToAction("UserList");
        }

        [HttpPost]
        public IActionResult UserList(string searchtext)
        {
            var data = _context.User_Master_Table_1.ToList();
            if(searchtext != null)
            {
                data = _context.User_Master_Table_1.Where(x => x.User_MasterFName.Contains(searchtext) || x.User_MasterSName.Contains(searchtext) || x.User_MasterEmail.Contains(searchtext) || x.User_Master_MO_BO.Contains(searchtext)).ToList();
            }
            return View(data);
        }

        public IActionResult UserList(string SortOrder, string SortBy)
        {
            ViewBag.SortOrder = SortOrder;

            var data = _context.User_Master_Table_1.ToList();

            switch (SortBy)
            {
                case "Name":
                    {
                        switch (SortOrder)
                        {
                            case "Asc":
                                {
                                    data = data.OrderBy(x => x.User_MasterFName).ToList();
                                    break;
                                }
                            case "Desc":
                                {
                                    data = data.OrderByDescending(x => x.User_MasterFName).ToList();
                                    break;
                                }
                            default:
                                {
                                    data = data.OrderBy(x => x.User_MasterFName).ToList();
                                    break;
                                }
                        }
                        break;
                    }

                case "SurName":
                    {
                        switch (SortOrder)
                        {
                            case "Asc":
                                {
                                    data = data.OrderBy(x => x.User_MasterSName).ToList();
                                    break;
                                }
                            case "Desc":
                                {
                                    data = data.OrderByDescending(x => x.User_MasterSName).ToList();
                                    break;
                                }
                            default:
                                {
                                    data = data.OrderBy(x => x.User_MasterSName).ToList();
                                    break;
                                }
                        }
                        break;
                    }
                case "Email":
                    {
                        switch (SortOrder)
                        {
                            case "Asc":
                                {
                                    data = data.OrderBy(x => x.User_MasterEmail).ToList();
                                    break;
                                }
                            case "Desc":
                                {
                                    data = data.OrderByDescending(x => x.User_MasterEmail).ToList();
                                    break;
                                }
                            default:
                                {
                                    data = data.OrderBy(x => x.User_MasterEmail).ToList();
                                    break;

                                }
                        }
                        break;
                    }
                case "Mobile Number":
                    {
                        switch (SortOrder)
                        {
                            case "Asc":
                                {
                                    data = data.OrderBy(x => x.User_Master_MO_BO).ToList();
                                    break;
                                }
                            case "Desc":
                                {
                                    data = data.OrderByDescending(x => x.User_Master_MO_BO).ToList();
                                    break;
                                }
                            default:
                                {
                                    data = data.OrderBy(x => x.User_Master_MO_BO).ToList();
                                    break;

                                }
                        }
                        break;
                    }
                default:
                    {
                        data = data.OrderBy(x => x.User_MasterFName).ToList();
                        break;
                    }
            }



            return View(data);
        }

        public IActionResult Edit(int id)
        {
            var ui = _context.User_Master_Table_1.Where(x => x.User_MasterID == id).First();
            return View(ui);
        }

        public IActionResult Delete(int id)
        {
            var res = _context.User_Master_Table_1.Where(x => x.User_MasterID == id).First();

            _context.User_Master_Table_1.Remove(res);

            _context.SaveChanges();

            return RedirectToAction("UserList");
        }

        public IActionResult Details(int id)
        {
            var res = _context.User_Master_Table_1.Where(x => x.User_MasterID == id).First();

            return View(res);
        }


    }
}
