using Clothes_Online_Shop.DB.Data;
using Clothes_Online_Shop.DB.Models;
using Clothes_Online_Shop.Models;
using System.Collections.Generic;
using System.Linq;

namespace Clothes_Online_Shop.Helpers
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductViewModels(this List<Product> products)
        {
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsViewModels.Add(ToProductViewModel(product));
            }
            return productsViewModels;
        }
        public static ProductViewModel ToProductViewModel(this Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Item = product.Item,
                Cost = product.Cost,
                Size = product.Size,
                Color = product.Color,
                Care = product.Care,
                Fabric = product.Fabric,
                Brand = product.Brand,
                Country = product.Country,
                Description = product.Description,
                ImgList = product.ImgList,
                Like = product.Like
            };
        }
        public static Product ToProduct(this ProductViewModel productViewModel)
        {
            return new Product
            {
                Id = productViewModel.Id,
                Name = productViewModel.Name,
                Item = productViewModel.Item,
                Cost = productViewModel.Cost,
                Size = productViewModel.Size,
                Color = productViewModel.Color,
                Care = productViewModel.Care,
                Fabric = productViewModel.Fabric,
                Brand = productViewModel.Brand,
                Country = productViewModel.Country,
                Description = productViewModel.Description,
                ImgList = productViewModel.ImgList,
                Like = productViewModel.Like
            };
        }
        public static Product ToProduct(this AddProductViewModel addProductViewModel, List<string> imagePaths)
        {
            return new Product
            {
                Name = addProductViewModel.Name,
                Item = addProductViewModel.Item,
                Cost = addProductViewModel.Cost,
                Size = addProductViewModel.Size,
                Color = addProductViewModel.Color,
                Care = addProductViewModel.Care,
                Fabric = addProductViewModel.Fabric,
                Brand = addProductViewModel.Brand,
                Country = addProductViewModel.Country,
                Description = addProductViewModel.Description,
                ImgList = imagePaths.ToImages()
            };
        }
        public static EditProductViewModel ToEditProductViewModel(this Product product)
        {
            return new EditProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Item = product.Item,
                Cost = product.Cost,
                Size = product.Size,
                Color = product.Color,
                Care = product.Care,
                Fabric = product.Fabric,
                Brand = product.Brand,
                Country = product.Country,
                Description = product.Description,
                ImagesPaths = product.ImgList.ToPaths()
            };
        }
        public static Product ToProduct(this EditProductViewModel editProductViewModel)
        {
            return new Product
            {
                Id = editProductViewModel.Id,
                Name = editProductViewModel.Name,
                Item = editProductViewModel.Item,
                Cost = editProductViewModel.Cost,
                Size = editProductViewModel.Size,
                Color = editProductViewModel.Color,
                Care = editProductViewModel.Care,
                Fabric = editProductViewModel.Fabric,
                Brand = editProductViewModel.Brand,
                Country = editProductViewModel.Country,
                Description = editProductViewModel.Description,
                ImgList = editProductViewModel.ImagesPaths.ToImages()
            };
        }
        public static List<ImgInfo> ToImages(this List<string> paths)
        {
            return paths.Select(x => new ImgInfo { Url = x }).ToList();
        }
        public static List<string> ToPaths(this ICollection<ImgInfo> images)
        {
            return images.Select(x => x.Url).ToList();
        }

        public static UserDeliveryInfo ToUser(this UserDeliveryInfoViewModel userInfo)
        {
            return new UserDeliveryInfo
            {
                Email = userInfo.Email,
                Name = userInfo.Name,
                Phone = userInfo.Phone
            };
        }

        public static CartViewModel ToCartViewModel(this Cart cart)
        {
            if (cart == null)
            {
                return null;
            }
            return new CartViewModel
            {
                Id = cart.Id,
                Items = ToCartItemViewModels(cart.Items),
                UserId = cart.UserId
            };
        }
        public static List<CartItemViewModel> ToCartItemViewModels(this List<CartItem> cartDBItems)
        {
            var cartItems = new List<CartItemViewModel>();
            foreach (var cartDBItem in cartDBItems)
            {
                var cartItem = new CartItemViewModel
                {
                    Id = cartDBItem.Id,
                    Amount = cartDBItem.Amount,
                    Product = ToProductViewModel(cartDBItem.Product)
                };
                cartItems.Add(cartItem);
            }
            return cartItems;
        }
        public static OrderViewModel ToOrderViewModel (this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                CreatedDateTime = order.CreatedDateTime,
                Status = (OrderStatusViewModel)(int)order.Status,
                UserInfo = ToUserDeliveryInfoViewModel(order.UserInfo),
                Items = ToCartItemViewModels(order.Items)
            };
        }
        public static UserDeliveryInfoViewModel ToUserDeliveryInfoViewModel(this UserDeliveryInfo userInfo)
        {
            return new UserDeliveryInfoViewModel
            {
                Name = userInfo.Name,
                Email = userInfo.Email,
                Phone = userInfo.Phone
            };
        }
        public static UserViewModel ToUserViewModel(this User user)
        {
            return new UserViewModel
            {
                Name = user.UserName,
                Roles = user.Roles,
                Email = user.Email,
                Phone = user.PhoneNumber
            };
        }
    }
}
