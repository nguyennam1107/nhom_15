using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Nhom_15.Model
{
    public class DataProvider:DbContext
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            }
            set { instance = value; }
        }
        public QuanLyMusicEntities DB { get; set; }
        public DataProvider() : base("QuanLyMusicEntities")
        {
            DB = new QuanLyMusicEntities();
        }
        public bool KiemtraUser(NetworkCredential credential)
        {
            var user = DB.TaiKhoans.FirstOrDefault(u => u.TenDangNhap == credential.UserName && u.MatKhau == credential.Password);
            return user != null;
        }
        public void AddUser(TaiKhoan taiKhoan)
        {
            DB.TaiKhoans.Add(taiKhoan);
            DB.SaveChanges();
        }
        public TaiKhoan GetByUsername(string username)
        {
            TaiKhoan taiKhoan = DB.TaiKhoans.FirstOrDefault(u => u.TenDangNhap == username);
            return taiKhoan;
        }
        public void Addmusic(MusicYour music)
        {
            try
            {
                DB.MusicYours.Add(music);
                DB.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }
        public int[] GetIdMusicArray(string tenDangNhap)
        {
            var idTinChiArray = DB.MusicYours
                                  .Where(t => t.TenDangNhap == tenDangNhap)
                                  .Select(t => t.IdProduct)
                                  .ToArray();
            return idTinChiArray;
        }
        public List<Music> GetDetails(int[] idArray)
        {
            var tinChiDetails = DB.Musics
                                  .Where(t => idArray.Contains(t.IdProduct))
                                  .ToList();
            return tinChiDetails;
        }
        public void AddMusic(Music music)
        {
            try
            {
                DB.Musics.Add(music);
                DB.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        public void EditMusic(Music music)
        {
            try
            {
                DB.Entry(music).State = EntityState.Modified;
                DB.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        public void DeleteMusic(Music music)
        {
            try
            {
                var relatedMusicYours = DB.MusicYours.Where(my => my.IdProduct == music.IdProduct).ToList();
                foreach (var relatedMusicYour in relatedMusicYours)
                {
                    DB.MusicYours.Remove(relatedMusicYour);
                }

                DB.SaveChanges();

                DB.Musics.Remove(music);
                DB.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }


    }
}
