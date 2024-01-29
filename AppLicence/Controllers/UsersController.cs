using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using AppLicence.DataAccessLayer.Interfaces;
using AppLicence.DataModels;
using AppLicence.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppLicence.Controllers
{
    public class UsersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UsersController(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public ActionResult Index()
        {
            var TestUser = _userRepository.GetAll();
            var usersList = new SelectList(TestUser, "Name", "Id").ToList();
            ViewBag.test = usersList[0];
            return Json(_userRepository.GetAll());
        }
    }
}
