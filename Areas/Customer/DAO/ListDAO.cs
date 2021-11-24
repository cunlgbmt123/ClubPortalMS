using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClubPortalMS.Models;

namespace ClubPortalMS.Areas.Customer.DAO
{
    public class ListDAO
    {
        ApplicationDbContext db = null;
        public ListDAO()
        {
            db = new ApplicationDbContext();
        }
        public List<HoatDong> ListAllHD()
        {
            return db.HoatDong.OrderByDescending(x => x.ID).ToList();
        }
        public List<HoatDong> listHD(int top)
        {
            return db.HoatDong.OrderByDescending(x => x.ID).Take(top).ToList();
        }
        public List<TinTuc> ListAllNews()
        {
            return db.TinTucs.OrderByDescending(x => x.ID).ToList();
        }
        public List<TinTuc> ListNews(int top)
        {
            return db.TinTucs.OrderByDescending(x => x.ID).Take(top).ToList();
        }
        public List<Album> ListAllAlbums()
        {
            return db.Album.OrderByDescending(x => x.ID).ToList();
        }
        public List<Album> ListAlbums(int top)
        {
            return db.Album.OrderByDescending(x => x.ID).Take(top).ToList();
        }
    }
   
}