using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models.Models.ViewModels
{
    public class ProductVM
    {
        public Product product { get; set; }

        /// <summary>
        /// Validate never is used to not allow vaidation of items of Category type in category list
        /// It happens when we need specific item from object
        /// </summary>
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
