using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core.Infrastructure;
using RealEstate.BusinessLayer.Abstract;
using RealEstate.BusinessLayer.ValidationRules;
using RealEstate.DataAccessLayer.Abstract;
using RealEstate.EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace RealEstate.PresentationLayer.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberservice;

        public MemberController(IMemberService memberservice)
        {
            _memberservice = memberservice;
        }

        public IActionResult Index()
        {
            var values = _memberservice.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddMember()
        {
            return View();

        }

        [HttpPost]
        public IActionResult AddMember(Member member)
        {
            MemberValidator validationRules = new MemberValidator();

            ValidationResult result = validationRules.Validate(member);

                if (result.IsValid) 
            {

                _memberservice.TInsert(member);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteMember(int id)
        {
            var values = _memberservice.TGetByID(id);
            _memberservice.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateMember(int id)
        {
            var values = _memberservice.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateMember(Member member)
        {

            MemberValidator validationRules = new MemberValidator();

            ValidationResult result = validationRules.Validate(member);

            if (result.IsValid)
            {

                _memberservice.TInsert(member);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
