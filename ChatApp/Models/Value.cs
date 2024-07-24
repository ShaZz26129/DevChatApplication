using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class Value
    {
        /// <summary>
        /// Gets or sets the domain.
        /// </summary>
        /// <value>The domain.</value>
        public string Domain { get; set; }
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        public int Key { get; set; }
        //public string Value { get; set; }
        /// <summary>
        /// Gets or sets the email identifier.
        /// </summary>
        /// <value>The email identifier.</value>
        public object EmailID { get; set; }
        /// <summary>
        /// Gets or sets the order by.
        /// </summary>
        /// <value>The order by.</value>
        public int OrderBy { get; set; }
        /// <summary>
        /// Gets or sets the p key.
        /// </summary>
        /// <value>The p key.</value>
        public int PKey { get; set; }
        /// <summary>
        /// Gets or sets the type of the ou.
        /// </summary>
        /// <value>The type of the ou.</value>
        public object OuType { get; set; }
        /// <summary>
        /// Gets or sets the name of the ou type.
        /// </summary>
        /// <value>The name of the ou type.</value>
        public object OuTypeName { get; set; }
        /// <summary>
        /// Gets or sets the short name.
        /// </summary>
        /// <value>The short name.</value>
        public object ShortName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [default designation].
        /// </summary>
        /// <value><c>true</c> if [default designation]; otherwise, <c>false</c>.</value>
        public bool DefaultDesignation { get; set; }
        /// <summary>
        /// Gets or sets the mess box identifier.
        /// </summary>
        /// <value>The mess box identifier.</value>
        public int MessBoxId { get; set; }
        /// <summary>
        /// Gets or sets the default name of the designation short.
        /// </summary>
        /// <value>The default name of the designation short.</value>
        public string DefaultDesignationShortName { get; set; }
        /// <summary>
        /// Gets or sets the default designation ou identifier.
        /// </summary>
        /// <value>The default designation ou identifier.</value>
        public int? DefaultDesignationOuID { get; set; }
        /// <summary>
        /// Gets or sets the parent company identifier.
        /// </summary>
        /// <value>The parent company identifier.</value>
        public object ParentCompanyID { get; set; }
        /// <summary>
        /// Gets or sets the parent department identifier.
        /// </summary>
        /// <value>The parent department identifier.</value>
        public object ParentDepartmentID { get; set; }
        /// <summary>
        /// Gets or sets the title ids.
        /// </summary>
        /// <value>The title ids.</value>
        public object TitleIds { get; set; }
        /// <summary>
        /// Gets or sets the title codes.
        /// </summary>
        /// <value>The title codes.</value>
        public object TitleCodes { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [roaster admin].
        /// </summary>
        /// <value><c>true</c> if [roaster admin]; otherwise, <c>false</c>.</value>
        public bool RoasterAdmin { get; set; }
        /// <summary>
        /// Gets or sets the head of department ids.
        /// </summary>
        /// <value>The head of department ids.</value>
        public object HeadOfDepartmentIds { get; set; }
    }
    public class Value2
    {
        /// <summary>
        /// Gets or sets the domain.
        /// </summary>
        /// <value>The domain.</value>
        public object Domain { get; set; }
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        public int Key { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; set; }
        /// <summary>
        /// Gets or sets the email identifier.
        /// </summary>
        /// <value>The email identifier.</value>
        public string EmailID { get; set; }
        /// <summary>
        /// Gets or sets the order by.
        /// </summary>
        /// <value>The order by.</value>
        public int OrderBy { get; set; }
        /// <summary>
        /// Gets or sets the p key.
        /// </summary>
        /// <value>The p key.</value>
        public int PKey { get; set; }
        /// <summary>
        /// Gets or sets the type of the ou.
        /// </summary>
        /// <value>The type of the ou.</value>
        public int OuType { get; set; }
        /// <summary>
        /// Gets or sets the name of the ou type.
        /// </summary>
        /// <value>The name of the ou type.</value>
        public string OuTypeName { get; set; }
        /// <summary>
        /// Gets or sets the short name.
        /// </summary>
        /// <value>The short name.</value>
        public string ShortName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [default designation].
        /// </summary>
        /// <value><c>true</c> if [default designation]; otherwise, <c>false</c>.</value>
        public bool DefaultDesignation { get; set; }
        /// <summary>
        /// Gets or sets the mess box identifier.
        /// </summary>
        /// <value>The mess box identifier.</value>
        public int MessBoxId { get; set; }
        /// <summary>
        /// Gets or sets the default name of the designation short.
        /// </summary>
        /// <value>The default name of the designation short.</value>
        public string DefaultDesignationShortName { get; set; }
        /// <summary>
        /// Gets or sets the default designation ou identifier.
        /// </summary>
        /// <value>The default designation ou identifier.</value>
        public int? DefaultDesignationOuID { get; set; }
        /// <summary>
        /// Gets or sets the parent company identifier.
        /// </summary>
        /// <value>The parent company identifier.</value>
        public int? ParentCompanyID { get; set; }
        /// <summary>
        /// Gets or sets the parent department identifier.
        /// </summary>
        /// <value>The parent department identifier.</value>
        public int? ParentDepartmentID { get; set; }
        /// <summary>
        /// Gets or sets the title ids.
        /// </summary>
        /// <value>The title ids.</value>
        public List<object> TitleIds { get; set; }
        /// <summary>
        /// Gets or sets the title codes.
        /// </summary>
        /// <value>The title codes.</value>
        public List<object> TitleCodes { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [roaster admin].
        /// </summary>
        /// <value><c>true</c> if [roaster admin]; otherwise, <c>false</c>.</value>
        public bool RoasterAdmin { get; set; }
        /// <summary>
        /// Gets or sets the head of department ids.
        /// </summary>
        /// <value>The head of department ids.</value>
        public List<object> HeadOfDepartmentIds { get; set; }
    }
}
