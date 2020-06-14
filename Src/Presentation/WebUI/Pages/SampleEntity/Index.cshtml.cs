using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Entities.SampleEntity.Queries.GetSampleEntityList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Pages.Base;

namespace WebUI.Pages.SampleEntity
{
    public class IndexModel : BasePageModel
    {
        [BindProperty]
        public GetSampleEntityListVm SampleEntityList { get; set; }

        public async Task<ActionResult> OnGetAsync(string message)
        {
            ViewData["Message"] = string.IsNullOrEmpty(message) ? "" : message;
            try
            {
                SampleEntityList = await Mediator.Send(new GetSampleEntityListQuery());
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message; // Can be displayed in the page using JS library like SweetAlert or Toastr
            }

            return Page();
        }
    }
}