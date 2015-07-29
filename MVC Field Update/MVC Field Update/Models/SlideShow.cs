using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace MVC_Field_Update.Models
{
    public class SlideShow : IRenderingModel
    {
        public string Title { get; set; }
        public string StyleClass { get; set; }
        public string HtmlID { get; set; }
        public string TransitionTime { get; set; }
        public string PauseOnHover { get; set; }
        public string FadeTransition { get; set; }
        public string SlideShowNoArrow { get; set; }
        public string SlideShowNoIndicator { get; set; }
        public string FolderItem { get; set; }

        public Item Item { get; set; }
        public Item PageItem { get; set; }
        public HtmlString Error { get; set; }
        public Sitecore.Mvc.Presentation.Rendering Rendering { get; set; }
        public Sitecore.Data.Fields.CheckboxField chPauseOnHover { get; set; }
        public Sitecore.Data.Fields.CheckboxField chFadeTransition { get; set; }
        public Sitecore.Data.Fields.CheckboxField chSlideShowNoArrow { get; set; }
        public Sitecore.Data.Fields.CheckboxField chSlideShowNoIndicator { get; set; }
        public IEnumerable<SelectListItem> PauseOnHoverList { get; set; }
        public IEnumerable<SelectListItem> FadeTransitionList { get; set; }
        public IEnumerable<SelectListItem> SlideShowNoArrowList { get; set; }
        public IEnumerable<SelectListItem> SlideShowNoIndicatorList { get; set; }

        public HtmlString inputType { get; set; }

        public void Initialize(Sitecore.Mvc.Presentation.Rendering rendering)
        {
            Rendering = rendering;
            Item = rendering.Item;
            PageItem = Sitecore.Mvc.Presentation.PageContext.Current.Item;

            Title = FieldRenderer.Render(Item, "Title");
            StyleClass = FieldRenderer.Render(Item, "StyleClass");
            HtmlID = FieldRenderer.Render(Item, "htmlID");
            TransitionTime = FieldRenderer.Render(Item, "TransitionTime");

            chPauseOnHover = Item.Fields["PauseOnHover"];
            chFadeTransition = Item.Fields["FadeTransition"];
            chSlideShowNoArrow = Item.Fields["SlideshowNoArrow"];
            chSlideShowNoIndicator = Item.Fields["SlideshowNoIndicator"];

            PauseOnHover = (!chPauseOnHover.Checked) ? "" : "hover";
            FadeTransition = (!chFadeTransition.Checked) ? "" : "slideshow-fade";
            SlideShowNoArrow = (chSlideShowNoArrow.Checked) ? "slideshow-no-arrows" : "";
            SlideShowNoIndicator = (chSlideShowNoIndicator.Checked) ? "slideshow-no-indicators" : "";
            Error = new HtmlString("<center><br /><h3>Slide Show<br />Please set associated content or edit related item</h3><br /></center>");
            FolderItem = Item.Name;
        }

        public string DataItems(Item item2, string fieldName, string parm)
        {
            return FieldRenderer.Render(item2, fieldName, parm);
        }

        public HtmlString ActionItemButton(string action, string buttonName, Item parentItem)
        {
            return new HtmlString(string.Format(@"<input type=""button"" class=""button"" value=""{1}"" onclick=""javascript:Sitecore.PageModes.PageEditor.postRequest('webedit:{0}(id={2})')"" />", action, buttonName, parentItem.ID));
        }

        public HtmlString MoveItemButton(string action, string buttonName, Item parentItem)
        {
            return new HtmlString(string.Format(@"<input type=""button"" class=""button"" value=""{1}"" onclick=""javascript:Sitecore.PageModes.PageEditor.postRequest('item:{0}(id={2})')"" />", action, buttonName, parentItem.ID));
        }
    }
}