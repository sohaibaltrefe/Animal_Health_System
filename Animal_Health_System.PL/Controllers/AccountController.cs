﻿using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Models;
    using Animal_Health_System.PL.Helpers;
    using Animal_Health_System.PL.ViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
    using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Security.Claims;

    namespace Animal_Health_System.PL.Controllers
    {
        public class AccountController : Controller
        {
            private readonly UserManager<ApplicationUser> userManager;
            private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IUnitOfWork unitOfWork;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager,IUnitOfWork unitOfWork)
            {
                this.userManager = userManager;
                this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Register()
        {
            LoadRolesIntoViewBag(); // تحميل الأدوار إلى ViewBag
            return View();
        }

        private void LoadRolesIntoViewBag()
        {
            ViewBag.RolesList = new List<SelectListItem>
    {
        new SelectListItem { Value = "Owner", Text = "Owner" },
        new SelectListItem { Value = "FarmStaff", Text = "Farm Staff" },
        new SelectListItem { Value = "Veterinarian", Text = "Veterinarian" }
    };
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                LoadRolesIntoViewBag(); // تأكد من إعادة تحميل الأدوار عند حدوث خطأ
                return View(model);
            }

            if (string.IsNullOrEmpty(model.SelectedRole))
            {
                ModelState.AddModelError("SelectedRole", "You must select a role.");
                LoadRolesIntoViewBag(); // إعادة تحميل الأدوار
                return View(model);
            }

            var user = new ApplicationUser
            {
                FullName = model.FullName,
                Email = model.Email,
                UserName = model.Email,
                Address = model.Address,
                Role=model.SelectedRole
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, model.SelectedRole);
                await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, model.SelectedRole));

                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmEmailLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, protocol: HttpContext.Request.Scheme);
                var email = new DAL.Models.Email
                {
                    Subject = "Please Confirm Your Email",
                    Recivers = model.Email,
                    Body = $"Please confirm your account by clicking this link: {confirmEmailLink}"
                };

                try
                {
                    EmailSettings.SendEmail(email);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error sending confirmation email: {ex.Message}");
                    LoadRolesIntoViewBag();
                    return View(model);
                }

                return RedirectToAction(nameof(emailconf));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            LoadRolesIntoViewBag(); // إعادة تحميل الأدوار عند حدوث خطأ
            return View(model);
        }







        public IActionResult emailconf()
            {
                return View();
            }
        [HttpGet]
        public async Task<IActionResult> confirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var user = await userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    if (roles.Count == 0)
                    {
                        await userManager.DeleteAsync(user);
                        ModelState.AddModelError("", "No role assigned. Your account has been deleted. Please register again and select a role.");
                        return RedirectToAction(nameof(Register));
                    }

                    // Assign role and redirect based on the role
                    if (!string.IsNullOrEmpty(user.Role))  // التأكد من أن Role ليس فارغًا
                    {
                        var roleExists = await roleManager.RoleExistsAsync(user.Role);
                        if (!roleExists)
                        {
                            await roleManager.CreateAsync(new IdentityRole(user.Role));
                        }

                        await userManager.AddToRoleAsync(user, user.Role);
                    }

                    // Redirect based on role
                    if (user.Role == "Veterinarian")
                    {
                        var veterinarian = new Veterinarian
                        {
                            FullName = user.FullName,
                            PhoneNumber ="0000000000",
                            Email = user.Email,
                            ApplicationUserId = user.Id,
                            YearsOfExperience = 0,
                            salary = 0
                        };

                        await unitOfWork.veterinarianRepository.AddAsync(veterinarian);
                        await unitOfWork.SaveChangesAsync();
                    }
                    else if (user.Role == "Owner")
                    {
                        var owner = new Owner
                        {
                            FullName = user.FullName,
                            PhoneNumber = "0000000000",
                            Email = user.Email,
                            ApplicationUserId = user.Id
                        };

                        await unitOfWork.ownerRepository.AddAsync(owner);
                        await unitOfWork.SaveChangesAsync();
                    }
                    else if (user.Role == "FarmStaff")
                    {
                        var farm = await unitOfWork.farmStaffRepository.GetDefaultFarmForStaffAsync();
                        if (farm != null)
                        {
                            var farmStaff = new FarmStaff
                            {
                                FullName = user.FullName,
                                JobTitle = "Default Job Title",
                                PhoneNumber = "0000000000",
                                Email = user.Email,
                                FarmId = farm.Id,
                                ApplicationUserId = user.Id,
                                DateHired = DateTime.Now
                            };

                            await unitOfWork.farmStaffRepository.AddAsync(farmStaff);
                            await unitOfWork.SaveChangesAsync();
                        }
                    }

                    // Redirect to Login page after successful email confirmation
                    return RedirectToAction(nameof(Login));
                }
            }
            return RedirectToAction("Error", "Home");
        }



        public IActionResult Login()
            {
                return View();
            }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    var check = await userManager.CheckPasswordAsync(user, model.Password);
                    if (check)
                    {
                        var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                        if (result.Succeeded)
                        {
                            // تمرير معرف المستخدم إلى صفحة التفاصيل
                            return RedirectToAction("Index", "Owner", new { area = "Dashboard" });
                        }
                    }
                }
            }
            return View(model);
        }

        public IActionResult ForgotPassword()
            {
                return View();
            }
            public async Task<IActionResult> SendPasswordUrl(ForgotPasswordVM model)
            {

                var user = await userManager.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    var resetPasswordUrl = Url.Action("ResetPassword", "Account", new { email = model.Email, token = token }, protocol: HttpContext.Request.Scheme);
                    var email = new DAL.Models.Email()
                    {
                        Subject = "Reset Email",
                        Recivers = model.Email,
                        Body = resetPasswordUrl,
                    };
                    EmailSettings.SendEmail(email);
                }



                return View(model);
            }
            public IActionResult ResetPassword(string email, string token)
            {
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    var result = await userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Login));
                    }
                }

                return View(model);
            }

        }
    }
