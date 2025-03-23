using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.Dtos
{
    public partial class ProductDto : ObservableObject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [ObservableProperty]
        public string? _image;
        public decimal Price { get; set; }

        public string Unit { get; set; }

        [ObservableProperty]

        public int _cartQuantity = Random.Shared.Next(0, 3);
        //public int CartQuantity => Random.Shared.Next(0, 3);
        public short CategoryId { get; set; }
        public ProductDto(int id, string name, string? image, decimal price, string unit, short categoryId)
        {
            Id = id;
            Name = name;
            Image = image;
            Price = price;
            Unit = unit;
            CategoryId = categoryId;
        }
    }
}