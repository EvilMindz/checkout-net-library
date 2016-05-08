using Checkout.ApiServices.SharedModels;
using Checkout.ApiServices.Shopping.RequestModels;
using Checkout.ApiServices.Shopping.ResponseModels;
using System;

namespace Checkout.ApiServices.Shopping
{
    public class ShoppingListService : IShoppingListService
    {
        public const string HappyShopperApiUrl = "http://api.happyshopper.com";

        private readonly string baseUrl;

        public ShoppingListService() : this(HappyShopperApiUrl) 
        {

        }

        public ShoppingListService(string baseUrl)
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentNullException("baseUrl");
            }

            this.baseUrl = baseUrl;
        }

        public HttpResponse<PagedList<ShoppingListItem>> GetShoppingList(int page, int pageSize)
        {
            var uri = string.Format("{0}?page={1}&pageSize={2}", GetShoppingListPath(), page, pageSize);
            return new ApiHttpClient()
                .GetRequest<PagedList<ShoppingListItem>>(uri, AppSettings.SecretKey);
        }

        public HttpResponse<ShoppingListItem> GetShoppingListItem(string id)
        {
            return new ApiHttpClient()
                .GetRequest<ShoppingListItem>(GetShoppingListItemPath(id), AppSettings.SecretKey);
        }

        public HttpResponse<ShoppingListItem> GetShoppingListItemByName(string name)
        {
            var uri = baseUrl + string.Format(ShoppingPaths.ShoppingListItemNamePath, name);
            return new ApiHttpClient()
                .GetRequest<ShoppingListItem>(uri, AppSettings.SecretKey);
        }

        public HttpResponse<ShoppingListItem> AddShoppingListItem(ShoppingListItemAdd command)
        {
            return new ApiHttpClient()
                .PostRequest<ShoppingListItem>(GetShoppingListPath(), AppSettings.SecretKey, command);
        }

        public HttpResponse UpdateShoppingListItem(string id, ShoppingListItemUpdate command)
        {
            return new ApiHttpClient()
                .PutRequest(GetShoppingListItemPath(id), AppSettings.SecretKey, command);
        }

        public HttpResponse DeleteShoppingListItem(string id)
        {
            return new ApiHttpClient()
                .DeleteRequest(GetShoppingListItemPath(id), AppSettings.SecretKey);
        }

        private string GetShoppingListPath()
        {
            return baseUrl + ShoppingPaths.ShoppingListPath;
        }

        private string GetShoppingListItemPath(string id)
        {
            return baseUrl + string.Format(ShoppingPaths.ShoppingListItemPath, id);
        }
    }
}
