namespace HorrorMovieAPI.Dto
{
    /// <summary>
    /// Refers to the HATEOAS.
    /// </summary>
    public class LinkDto
    {
        /// <summary>
        /// The link.
        /// </summary>
        public string Href { get; set; }
        /// <summary>
        /// Explains the relationship between the link and the object.
        /// </summary>
        public string Rel { get; set; }
        /// <summary>
        /// Refers to the specific CRUD-method.
        /// </summary>
        public string Method { get; set; }

        public LinkDto(string href, string rel, string method)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }
    }
}