using System;

namespace Domain.Entities
{
    public class PaginingInfo
    {
        public int TotalItem { get; set; }
        public int ItemPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages
        {
            get { return (int)(Math.Ceiling((decimal)TotalItem / ItemPerPage)); }
        }
    }
}
