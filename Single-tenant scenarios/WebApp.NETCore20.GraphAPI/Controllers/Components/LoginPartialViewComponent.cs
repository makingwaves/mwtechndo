using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.NETCore20.GraphAPI.Helpers;

namespace WebApp.NETCore20.GraphAPI.Controllers.Components
{
    public class LoginPartialViewComponent : ViewComponent
    {
        private readonly GraphService graphService;

        public LoginPartialViewComponent(GraphService graphService)
        {
            this.graphService = graphService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string picture = null;

            if (User.Identity.IsAuthenticated)
            {
                picture = await this.graphService.GetPictureBase64(User.Identity.Name);
            }

            return View("Default", picture);
        }
    }
}
