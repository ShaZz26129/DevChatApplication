namespace ChatApp.Models
{
    public class Result
    {
        //public bool IsSuccess { get; set; }
        //public string Message { get; set; }
        //public object Data { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public string UserId { get; set; }
        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        public string FullName { get; set; }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the user ex identifier.
        /// </summary>
        /// <value>The user ex identifier.</value>
        public int UserExId { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public int Status { get; set; }
        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        /// <value>The tenant identifier.</value>
        public int TenantID { get; set; }
        /// <summary>
        /// Gets or sets the email identifier.
        /// </summary>
        /// <value>The email identifier.</value>
        public string EmailID { get; set; }
        /// <summary>
        /// Gets or sets the user image URL.
        /// </summary>
        /// <value>The user image URL.</value>
        public string UserImageUrl { get; set; }
        /// <summary>
        /// Gets or sets the tenant claims.
        /// </summary>
        /// <value>The tenant claims.</value>
        public List<TenantClaim> TenantClaims { get; set; }
    }
}
