using BookApp.Models;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace BookApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public BookController(ApplicationContext context)
        {
            _context = context;

        }

        [HttpPost]
        public BookListResult SaveBookDetails([FromBody] BookListRequest instance)
        {
            BookListResult res = new BookListResult();
            try
            {
                if (instance.BookList != null && instance.BookList.Count() > 0)
                {
                    using (var context = new KnilaTestEntities())
                    {
                        var clientIdParameter = new SqlParameter("@ParamList", instance.BookList);
                        var clientIdParameter1 = new SqlParameter("@TransTypeID", 1);
                        var clientIdParameter2 = new SqlParameter("@Res", "");
                        clientIdParameter.Direction = ParameterDirection.Output;

                        var result = context.Database
                            .SqlQuery<string>("splocal_Book_IUD @ParamList,@TransTypeID, @Res OUT", clientIdParameter, clientIdParameter1, clientIdParameter2);
                        string resultString = result.FirstOrDefault();

                        res.ErrorMessage = resultString;
                    }

                }
            }
            catch (Exception e)
            {
                res.HasError = true;
                res.ErrorMessage = e.Message;
            }


            return res;
        }

        [HttpGet]
        public BookPrice GetPriceofAllBooks()
        {
            BookPrice res = new BookPrice();
            using (var context = new KnilaTestEntities())
            {
                var query = (from PU in context.tblBook
                                select PU.Price).Sum();
                res.SumofPrice = Convert.ToDecimal(query);
                
            }

            return res;
        }
        [HttpGet]
        public BookListPLFT GetSortedListByPLFT()
        {
            BookListPLFT res = new BookListPLFT();
            try
            {
                using (var context = new KnilaTestEntities())
                {
                    var query = (from PU in context.tblBook
                                 orderby PU.Publisher,PU.AuthorLastName, PU.AuthorFirstName,PU.Title 
                                 select PU).ToList();
                    if(query.Count() > 0)
                    {

                        for (int i = 0; i < query.Count; i++)
                        {
                            res.bookList.Add(new BookDatatype
                            {
                                AuthorLastName = query[i].AuthorLastName,
                                AuthorFirstName = query[i].AuthorFirstName,
                                Publisher = query[i].Publisher,
                                Title = query[i].Title,
                                Price = Convert.ToDecimal( query[i].Price),
                                TitleofContainer = query[i].TitleofContainer,
                                PublicationDate =Convert.ToDateTime( query[i].PublicationDate),
                                PageNo = Convert.ToInt32(query[i].PageNo),
                                JournalTitle = query[i].JournalTitle,
                                Issueno = query[i].Issueno,
                                VolumeNo = query[i].VolumeNo,
                                PageRange = query[i].PageRange,
                                PageURL = query[i].PageURL,
                                UpdatedBy = Convert.ToInt32(query[i].UpdatedBy),
                                UpdatedAt = Convert.ToDateTime(query[i].UpdatedAt)
                            });
                        }
                    }
                }
                

            }
            catch (Exception e)
            {
                res.HasError = true;
                res.ErrorMessage = e.Message;
            }


            return res;
        }

        [HttpGet]
        public BookListPLFT GetSortedListByLFT()
        {
            BookListPLFT res = new BookListPLFT();
            try
            {
                using (KnilaTestEntities context = new KnilaTestEntities())
                {
                    var query = (from PU in context.tblBook
                                 orderby PU.AuthorLastName, PU.AuthorFirstName, PU.Title
                                 select PU).ToList();
                    if (query.Count() > 0)
                    {

                        for (int i = 0; i < query.Count; i++)
                        {
                            res.bookList.Add(new BookDatatype
                            {
                                AuthorLastName = query[i].AuthorLastName,
                                AuthorFirstName = query[i].AuthorFirstName,
                                Publisher = query[i].Publisher,
                                Title = query[i].Title,
                                Price = Convert.ToDecimal(query[i].Price),
                                TitleofContainer = query[i].TitleofContainer,
                                PublicationDate = Convert.ToDateTime(query[i].PublicationDate),
                                PageNo = Convert.ToInt32(query[i].PageNo),
                                JournalTitle = query[i].JournalTitle,
                                Issueno = query[i].Issueno,
                                VolumeNo = query[i].VolumeNo,
                                PageRange = query[i].PageRange,
                                PageURL = query[i].PageURL,
                                UpdatedBy = Convert.ToInt32(query[i].UpdatedBy),
                                UpdatedAt = Convert.ToDateTime(query[i].UpdatedAt)
                            });
                        }
                    }

                }

            }
            catch (Exception e)
            {
                res.HasError = true;
                res.ErrorMessage = e.Message;
            }


            return res;
        }
    }
}
