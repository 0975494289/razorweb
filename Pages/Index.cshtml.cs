using entity.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
//using MySql.EntityFrameworkCore;

namespace Entity.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private readonly MyBlogContext myBlogContext;
    public IndexModel(ILogger<IndexModel> logger, MyBlogContext _myBlogContext)
    {
        _logger = logger;
        myBlogContext = _myBlogContext;
    }

    public void OnGet()
    {
        var posts = from p in myBlogContext.articles
                    orderby p.Created
                    select p;
        ViewData["posts"] = posts.ToList();
    }
}
