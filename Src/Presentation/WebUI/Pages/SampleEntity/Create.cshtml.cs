using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.Entities.SampleEntity.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Pages.Base;

namespace WebUI.Pages.SampleEntity
{
    public class CreateModel : BasePageModel
    {
        [BindProperty]
        public CreateSampleEntityCommand NewSampleEntity { get; set; }

        public async Task<ActionResult> OnPostAsync()
        {
            ResultModel result = new ResultModel
            {
                IsSuccess = false,
                Message = ""
            };

            if (ModelState.IsValid)
            {
                 result = await Mediator.Send(NewSampleEntity);                
            }

            if (result.IsSuccess)
            {
                return RedirectToPage("Index", "GET", new { message = result.Message });
            }
            else
            {
                ViewData["ErrorMessage"] = result.Message;
                return Page();
            }
        }
    }
}