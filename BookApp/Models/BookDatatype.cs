using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.Security.Principal;

namespace BookApp.Models
{
    public class BookDatatype
    {
        public int AuthorID { get; set; }
        public string Publisher { get; set; }
        public string Title { get; set; }
        public string TitleofSource { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorFirstName { get; set; }
        public decimal Price { get; set; }
        public string TitleofContainer { get; set; }
        public DateTime PublicationDate { get; set; }
        public int PageNo { get; set; }
        public string JournalTitle { get; set; }
        public string Issueno { get; set; }
        public string VolumeNo { get; set; }
        public string PageRange { get; set; }
        public string PageURL { get; set; }
        public bool isActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    [DataContract]
    public class BookListRequest
    {
        [DataMember]
        public List<BookDatatype> BookList { get; set; }
    }
    [DataContract]
    public class BookListResult
    {
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public bool HasError { get; set; }
    }
    [DataContract]
    public class BookListPLFT : BookListResult
    {
        [DataMember]        public List<BookDatatype> bookList { get; set; }

    }
    [DataContract]
    public class BookPrice : BookListResult
    {
        [DataMember] public decimal SumofPrice { get; set; }

    }
}
