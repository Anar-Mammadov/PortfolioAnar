using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.WebUI.Appcode.Extension;
using Portfolio.WebUI.Model.DataContexts;
using Portfolio.WebUI.Model.Entity;
using Portfolio.WebUI.Model.Entity.FormModel;
using Portfolio.WebUI.Model.Entity.Memvership;
using Portfolio.WebUI.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        readonly PortfolioDbContext db;
        readonly UserManager<PortUser> userManager;
        readonly SignInManager<PortUser> signInManager;
        readonly Iconfiguration iconfiguration;
        public HomeController(PortfolioDbContext db, UserManager<PortUser> userManager, SignInManager<PortUser> signInManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.iconfiguration = iconfiguration;
        }

        //+
        public IActionResult Index()
        {
            var vm = new HomeViewModel();
            vm.Services = db.Services.Where(e => e.DeleteByUserId == null).Include(e => e.Icons).ToList();
            vm.Skills = db.Skills.Where(e => e.DeleteByUserId == null).ToList();
            vm.Aboutme = db.Aboutme.FirstOrDefault(e => e.DeleteByUserId == null);



            return View(vm);

        }

        public IActionResult Portfolio()
        {
            return View();
        }

        //+
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contact model)
        {

            if (ModelState.IsValid)
            {
                db.Contactss.Add(model);
                db.SaveChanges();

                return Json(new
                {
                    error = false,
                    message = "Sorgunuz qeyd alindi"
                });
            }
            return Json(new
            {
                error = true,
                message = "Sorgunuz qeyde alinmadi"
            });
        }


        public IActionResult Signin()
        {
            //Eger giris edibse routda myaccount/sing yazanda o seyfe acilmasin homa tulaasin
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");

            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signin(LoginFormModel user)
        {


            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");

            }

            if (ModelState.IsValid)
            {

                PortUser founderUser = null;

                if (user.Name.IsEmail())
                {
                    founderUser = await userManager.FindByEmailAsync(user.Name); //Eger Isdifadeci email gore giris edibse onu yoxlayir 
                }
                else
                {
                    founderUser = await userManager.FindByNameAsync(user.Name); //YOX EGER USERNAME GORE GIRIBSE ONU AXTARIS EDIR.

                }

                if (founderUser == null) //Eger login ola bilmirse gonderir view gonderir yeni isdifadeci tapilmiyanda
                {
                    ViewBag.Ms = "Isdifadeci sifresi ve parol sefdir gagas";
                    return View(user);

                }

               

                //Eger database isdifadeci user deyilse onda gire bilmez.

                if (!await userManager.IsInRoleAsync(founderUser, "User"))
                {
                    ViewBag.Ms = "Isdifadeci sifresi ve parol sefdir gagas";
                    return View(user);
                }







                var sRuselt = await signInManager.PasswordSignInAsync(founderUser, user.Password,true,true); //Burda giwi edirik.

                if (sRuselt.Succeeded != true) // Eger giriw zamani ugurlu deyilse yeni gire bilmirse 
                {
                    ViewBag.Ms = "Isdifadeci sifresi ve parol sefdir gagas";
                    return View(user);

                }
                var redirectUrl = Request.Query["ReturnUrl"];

                if (!string.IsNullOrWhiteSpace(redirectUrl))
                {
                    return Redirect(redirectUrl);
                }

                return RedirectToAction("Index", "Home");


            }

            ViewBag.Ms = "Melumatlari doldur gagas";
            return View(user);











            //PortUser foundedUser = null;



            ////Isdifadecinin user ve ya email ile giriw etdiyni yoxlyuruq;
            //if (user.UserName.IsEmail())
            //{
            //    foundedUser = await userManager.FindByEmailAsync(user.UserName);
            //}
            //else
            //{
            //    foundedUser = await userManager.FindByNameAsync(user.UserName);

            //}

            //if (foundedUser==null)
            //{
            //    ViewBag.ms = "Isdifadeci sifresi ve Parolu sefdi";
            //    goto end;
            //}

            //var signinResult = await signInManager.PasswordSignInAsync(foundedUser, user.Password, true, true);




            //if (!signinResult.Succeeded)
            //{
            //    ViewBag.ms = "Isdifadeci sifresi ve Parolu sefdi";
            //    goto end;
            //}

            //var callbackurl = Request.Query["ReturnUrl"];

            //if (!string.IsNullOrWhiteSpace(callbackurl))
            //{
            //    return Redirect(callbackurl);
            //}

            //return RedirectToAction("Blog", "Details");

            //end:
            //return View();
        }

        public IActionResult Register()
        {
            //Eger giris edibse routda myaccount/sing yazanda o seyfe acilmasin homa tulaasin
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");

            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel register)
        {

            //Eger giris edibse routda myaccount/sing yazanda o seyfe acilmasin homa tulaasin
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");

            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            //Yeni user yaradiriq.
            PortUser user = new PortUser
            {

                UserName = register.UserName,
                Email = register.Email,
                EmailConfirmed = true
            };



            //string token = $"subscribetoken-{register.UserName}-{DateTime.Now:yyyyMMddHHmmss}"; // token yeni id goturuk

            //token = token.Encrypt("");

            //string path = $"{Request.Scheme}://{Request.Host}/subscribe-confirmm?token={token}"; // path duzeldirik



            //var mailSended = iconfiguration.SendEmail(user.Email, "Riode seyfesi gagas", $"Zehmet olmasa <a href={path}>Link</a> vasitesile abuneliyi tamamlayin");


            var person = await userManager.FindByNameAsync(user.UserName);


            if (person == null)
            {
                //Burda biz userManager vasitesile user ve RegistirVM passwword yoxluyuruq.(yaradiriq)
                var identityRuselt = await userManager.CreateAsync(user, register.Password);


                //Startupda yazdigimiz qanunlara uymursa Configure<IdentityOptions> onda error qaytariq summary ile.;
                if (!identityRuselt.Succeeded)
                {
                    foreach (var error in identityRuselt.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                //Yratdigimiz user ilk yarananda user rolu verik.

                await userManager.AddToRoleAsync(user, "User");

                return RedirectToAction("Signin", "Home");

            }


            if (person.UserName != null)
            {
                ViewBag.ms = "Bu username evvelceden qeydiyyatdan kecib";

                return View(register);
            }
            return null;

        }
    }
}
