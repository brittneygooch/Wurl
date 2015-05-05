using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.AspNet.Identity;
using Wurl.Adapters;
using Wurl.Adapters.Data;
using Wurl.Data.Model;
using Wurl.Models;
using System.Threading.Tasks;
using System.Configuration;

namespace Wurl.Controllers
{ 
    //[Authorize]
    public class WurlController : ApiController
    {
        private IWurlAdapter _adapter;
        private IImageAdapter _imgur;
        public WurlController()
            : this(new AzureAdapter(CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["Azure"].ConnectionString), "img"))
        {
            _adapter = new WurlDataAdapter();
        }
        public WurlController(IImageAdapter imgur)
        {
            this._imgur = imgur;
        }
        public WurlController(IWurlAdapter Adapter)
        {
            _adapter = Adapter;
        }

        [Route("getImage")]
        public async Task<IHttpActionResult> GetImage()
        {
            var results = await _imgur.Get();
            return Ok(new { images = results });
        }

        [Route("postImage")]
        public async Task<IHttpActionResult> PostImage()
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                return BadRequest("Unsupported media type");
            }

            try
            {
                var images = await _imgur.Add(Request);
                return Ok(new { Successful = true, Message = "All images uploaded ok", Images = images });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        [HttpGet]
        [Route("userCheck/{str}")]
        public IHttpActionResult UserCheck(string str)
        {
            ApplicationUser check = _adapter.UserCheck(str);
            return Ok(check);
        }

        [Authorize]
        [Route("getUser")]
        public IHttpActionResult Get()
        {
            string id = User.Identity.GetUserId();
            UserVm user = _adapter.GetUserInfo(id);
            return Ok(user);
        }

        [Route("homePosts")]
        public IHttpActionResult GetHome()
        {
            var posts = _adapter.GetHomePosts();
            return Ok(posts);
        }

        [Route("getPosts")]
        public IHttpActionResult GetPosts()
        {
            var posts = _adapter.GetPosts();
            return Ok(posts);
        }

        [Route("getBlogs")]
        public IHttpActionResult GetBlogs()
        {
            var blogs = _adapter.GetBlogs();
            return Ok(blogs);
        }

        [Route("blogDetail/{id}")]
        public IHttpActionResult BlogDetail(int id)
        {
            var blog = _adapter.BlogDetail(id);
            return Ok(blog);
        }

        [Route("getEvents/{str}")]
        public IHttpActionResult GetEvents(string str)
        {
            var events = _adapter.GetEvents(str);
            return Ok(events);
        }

        [Route("eventDetail/{id}")]
        [HttpGet]
        public IHttpActionResult EventDetail(int id)
        {
            var dEvent = _adapter.EventDetail(id);
            return Ok(dEvent);
        }

        [Route("createPost")]
        public IHttpActionResult CreatePost(PostVm obj)
        {
            _adapter.CreatePost(obj);
            return Ok();
        }

        [Route("createEvent")]
        public IHttpActionResult CreateEvent(EventObjVm obj)
        {
            _adapter.CreateEvent(obj);
            return Ok();
        }

        [Route("createBlog")]
        public IHttpActionResult CreateBlog(BlogObjVm obj)
        {
            _adapter.CreateBlog(obj);
            return Ok();
        }

        [HttpGet]
        [Route("editPost/{id}")]
        public IHttpActionResult EditPost(int id)
        {
            var post = _adapter.EditPost(id);
            return Ok(post);
        }
        
        [Route("updatePost")]
        public IHttpActionResult UpdatePost(EditVm eVm)
        {
            EditVm Post = new EditVm();
            Post.ThisPost = eVm.ThisPost;
            _adapter.UpdatePost(Post);
            return Ok();
        }

        [HttpGet]
        [Route("editEvent/{id}")]
        public IHttpActionResult EditEvent(int id)
        {
            var thisEvent = _adapter.EditEvent(id);
            return Ok(thisEvent);
        }

        [HttpPost]
        [Route("updateEvent")]
        public IHttpActionResult UpdateEvent(EventObjVm eVm)
        {
            EventObjVm tEvent = new EventObjVm();
            tEvent = eVm;
            _adapter.UpdateEvent(tEvent);
            return Ok();
        }

        [HttpGet]
        [Route("editBlog/{id}")]
        public IHttpActionResult EditBlog(int id)
        {
            var blog = _adapter.EditBlog(id);
            return Ok(blog);
        }

        [Route("updateBlog")]
        public IHttpActionResult UpdateBlog(EditVm eVm)
        {
            EditVm Blog = new EditVm();
            Blog.ThisBlog = eVm.ThisBlog;
            _adapter.UpdateBlog(Blog);
            return Ok();
        }
        
        [HttpGet]
        [Route("deletePost/{id}")]
        public IHttpActionResult DeletePost(int id)
        {
            _adapter.DeletePost(id);
            return Ok();
        }

        [HttpPatch]
        [Route("deleteEvent/{id}")]
        public IHttpActionResult DeleteEvent(int id)
        {
            _adapter.DeleteEvent(id);
            return Ok();
        }

        [HttpGet]
        [Route("deleteBlog/{id}")]
        public IHttpActionResult DeleteBlog(int id)
        {
            _adapter.DeleteBlog(id);
            return Ok();
        }
    }
}
