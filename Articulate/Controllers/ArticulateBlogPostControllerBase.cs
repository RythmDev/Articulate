﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Articulate.Models;
using Umbraco.Core;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Articulate.Controllers
{
    public abstract class BlogPostControllerBase : RenderMvcController
    {

        public override ActionResult Index(RenderModel model)
        {   
            var post = new PostModel(model.Content);
            return View(PathHelper.GetThemeViewPath(post, ViewName), post);
        }

        protected abstract string ViewName { get; }
    }

    public class ArticulateListController : RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            var post = new ListModel(model.Content);
            return View(PathHelper.GetThemeViewPath(post, "List"), post);
        }
    }

    public class ArticulateMarkdownController : BlogPostControllerBase
    {
        protected override string ViewName
        {
            get { return "Markdown"; }
        }
    }

    public class ArticulateRichTextController : BlogPostControllerBase
    {
        protected override string ViewName
        {
            get { return "RichText"; }
        }
    }
}
