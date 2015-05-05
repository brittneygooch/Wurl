using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Wurl.Data;
using Wurl.Data.Model;
using Wurl.Models;

namespace Wurl.Adapters.Data
{
    public class WurlDataAdapter : IWurlAdapter
    {
        public ApplicationUser UserCheck(string username)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ApplicationUser check = db.Users.FirstOrDefault(u => u.UserName == username);
                return check;
            }
        }
        public void ProfileManager(UserVm uVm)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == uVm.UserId);
                user.City = uVm.City;
                db.SaveChanges();
            }
        }
        public UserVm GetUserInfo(string userId)
        {
            UserVm user;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                user = db.Users.Where(x => x.Id == userId).Select(x => new UserVm()
                {
                    Username = x.UserName,
                    City = x.City,
                    UserId = userId
                }).FirstOrDefault();
            }
            return user;
        }
        public PostsVm GetHomePosts()
        {
            PostsVm pVm = new PostsVm();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var results = db.Posts.Where(p => p.IsDeleted == false).Select(a => new PostObjVm
                {
                    Title = a.Title,
                    DateCreated = a.DateCreated,
                    PostId = a.PostId,
                    UserId = a.UserId,
                    User = db.Users.FirstOrDefault(u => u.Id == a.UserId).UserName
                }).OrderByDescending(p => p.DateCreated).Take(3).ToList();
                pVm.AllPosts = results;
                return pVm;
            }
        }
        public PostsVm GetPosts()
        {
            PostsVm pVm = new PostsVm();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var results = db.Posts.Where(p => p.IsDeleted == false).Select(a => new PostObjVm
                {
                    Title = a.Title,
                    Body = a.Body,
                    DateCreated = a.DateCreated,
                    PostId = a.PostId,
                    UserId = a.UserId,
                    User = db.Users.FirstOrDefault(u => u.Id == a.UserId).UserName
                }).OrderByDescending(p => p.DateCreated).ToList();
                pVm.AllPosts = results;
                return pVm;
            }
        }
        public BlogsVm GetBlogs()
        {
            BlogsVm bVm = new BlogsVm();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var results = db.Blogs.Where(b => b.IsDeleted == false).Select(a => new BlogObjVm
                {
                    BlogId = a.BlogId,
                    Body = a.Body,
                    Title = a.Title,
                    DateCreated = a.DateCreated,
                    UserId = a.UserId,
                    User = db.Users.FirstOrDefault(u => u.Id == a.UserId).UserName
                }).ToList();
                bVm.BlogsList = results;
            }
            return bVm;
        }
        public BlogVm BlogDetail(int id)
        {
            BlogVm bVm = new BlogVm();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var blog = db.Blogs.Where(b => b.BlogId == id);
                bVm.ThisBlog = (Blog)blog;
            }
            return bVm;
        }
        public EventsVm GetEvents(string city)
        {
            EventsVm eVm = new EventsVm();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var loc = city;
                var results = db.Events.Where(e => e.IsDeleted == false && e.City == loc).Select(a => new EventObjVm
                {
                    EventId = a.EventId,
                    Title = a.Title,
                    Description = a.Description,
                    Location = a.Location,
                    Date = a.Date,
                    Time = a.Time,
                    DateCreated = a.DateCreated,
                    ImgUrl = a.ImgUrl,
                    UserId = a.UserId,
                    User = db.Users.FirstOrDefault(u => u.Id == a.UserId).UserName
                }).OrderByDescending(o => o.DateCreated).ToList();
                eVm.EventsList = results;
            }
            return eVm;
        }
        public EventVm EventDetail(int id)
        {
            EventVm eVm = new EventVm();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var tEvent = db.Events.FirstOrDefault(e => e.EventId == id);
                eVm.ThatEvent = tEvent;
            }
            return eVm;
        }
        public EditVm EditPost(int id)
        {
            EditVm eVm = new EditVm();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                eVm.ThisPost = db.Posts.FirstOrDefault(p => p.PostId == id);
            }
            return eVm;
        }
        public void UpdatePost(EditVm eVm)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var post = db.Posts.FirstOrDefault(p => p.PostId == eVm.ThisPost.PostId);
                post.Body = eVm.ThisPost.Body;
                post.DateEdited = DateTime.Now;
                db.SaveChanges();
            }
        }
        public EditVm EditBlog(int id)
        {
            EditVm eVm = new EditVm();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                eVm.ThisBlog = db.Blogs.FirstOrDefault(b => b.BlogId == id);
            }
            return eVm;
        }
        public void UpdateBlog(EditVm eVm)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var blog = db.Blogs.FirstOrDefault(b => b.BlogId == eVm.ThisBlog.BlogId);
                blog.Body = eVm.ThisBlog.Body;
                blog.DateEdited = DateTime.Now;
                db.SaveChanges();
            }
        }
        public EditVm EditEvent(int id)
        {
            EditVm eVm = new EditVm();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                eVm.ThisEvent = db.Events.FirstOrDefault(e => e.EventId == id);
            }
            return eVm;
        }
        public void UpdateEvent(EventObjVm eVm)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var uEvent = db.Events.FirstOrDefault(e => e.EventId == eVm.EventId);
                uEvent.Title = eVm.Title;
                uEvent.Description = eVm.Description;
                uEvent.Date = eVm.Date;
                uEvent.Time = eVm.Time;
                uEvent.DateEdited = DateTime.Now;
                db.SaveChanges();
            }
        }
        public void CreatePost(PostVm pVm)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Posts.Add(new Post() { Title = pVm.Title, Body = pVm.Body, UserId = pVm.UserId, DateCreated = DateTime.Now });
                db.SaveChanges();
            }
        }
        public void CreateEvent(EventObjVm eVm)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Events.Add(new Event() { Title = eVm.Title, Description = eVm.Description, Date = eVm.Date, Time = eVm.Time, Location = eVm.Location, City = eVm.City, UserId = eVm.UserId, ImgUrl = eVm.ImgUrl, DateCreated = DateTime.Now });
                db.SaveChanges();
            }
        }
        public void CreateBlog(BlogObjVm bVm)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Blogs.Add(new Blog() { Title = bVm.Title, Body = bVm.Body, UserId = bVm.UserId, DateCreated = DateTime.Now });
                db.SaveChanges();
            }
        }

        // Deletes go here, note that this is a soft delete and does not remove the object from the database
        public void DeletePost(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var post = db.Posts.FirstOrDefault(p => p.PostId == id);
                post.IsDeleted = true;
                db.SaveChanges();
            }
        }

        public void DeleteBlog(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var blog = db.Blogs.FirstOrDefault(b => b.BlogId == id);
                blog.IsDeleted = true;
                db.SaveChanges();
            }

        }
        public void DeleteEvent(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var eventDelete = db.Events.FirstOrDefault(e => e.EventId == id);
                eventDelete.IsDeleted = true;
                db.SaveChanges();
            }
        }

    }

}