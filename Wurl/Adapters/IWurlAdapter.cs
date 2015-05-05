using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wurl.Data.Model;
using Wurl.Models;

namespace Wurl.Adapters
{
    public interface IWurlAdapter
    {
        ApplicationUser UserCheck(string username);
        void ProfileManager(UserVm uVm);
        UserVm GetUserInfo(string userId);
        PostsVm GetHomePosts();
        PostsVm GetPosts();
        BlogsVm GetBlogs();
        BlogVm BlogDetail(int id);
        EventsVm GetEvents(string city);
        EventVm EventDetail(int id);
        void CreatePost(PostVm pVm);
        void CreateEvent(EventObjVm eVm);
        void CreateBlog(BlogObjVm bVm);
        EditVm EditPost(int id);
        void UpdatePost(EditVm eVm);
        EditVm EditEvent(int id);
        void UpdateEvent(EventObjVm eVm);
        EditVm EditBlog(int id);
        void UpdateBlog(EditVm eVm);
        void DeletePost(int id);
        void DeleteEvent(int id);
        void DeleteBlog(int id);
    }
}
