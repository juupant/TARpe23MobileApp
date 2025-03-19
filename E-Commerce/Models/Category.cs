using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Category
    {
        public Category(short id,string name,short parentId,string image,string credit)
        {
            Id = id;
            Name = name;
            ParentId = parentId;
            Image = image;
            Credit = credit;

        }
        public short Id { get; set; }
        public string Name { get; set; }
        private string _image;
        public string Image { get=>_image; set { _image = $"https://localhost:12345/images/categories/{value}"; } }
        public short ParentId { get; set; }
        public string? Credit { get; set; }
        public bool IsMainCategory => ParentId == 0;
        //public string ImageUrl => $"https://localhost:12345/images/categories/{Image}";
    }
}
