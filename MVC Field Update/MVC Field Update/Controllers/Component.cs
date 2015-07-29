using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Field_Update.Models;
using Sitecore.Mvc.Presentation;
using Sitecore.Data.Items;
using Sitecore.SecurityModel;

namespace MVC_Field_Update.Controllers
{
    public class Component : Controller
    {
        //
        // GET: /Component/

        public ActionResult SlideShow(string changedValue, string fieldName)
        {

            SlideShow ss = new SlideShow();
            ss.Initialize(RenderingContext.Current.Rendering);
            Item item = ss.Item;

            if (!String.IsNullOrEmpty(changedValue) && !String.IsNullOrEmpty(fieldName))
            {
                ss.Item.Editing.BeginEdit();
                using (new SecurityDisabler())
                {
                    switch (fieldName)
                    {
                        case ("PauseOnHover"):
                            ss.chPauseOnHover.Checked = (changedValue == "True" ? true : false);
                            break;
                        case ("FadeTransition"):
                            ss.chFadeTransition.Checked = (changedValue == "True" ? true : false);
                            break;
                        case ("SlideShowNoArrow"):
                            ss.chSlideShowNoArrow.Checked = (changedValue == "False" ? true : false);
                            break;
                        case ("SlideShowNoIndicator"):
                            ss.chSlideShowNoIndicator.Checked = (changedValue == "False" ? true : false);
                            break;
                    }
                }
                ss.Item.Editing.EndEdit();
            }

            return PartialView(ss);
        }

    }
}
