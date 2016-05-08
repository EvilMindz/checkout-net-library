using Checkout.ApiServices.SharedModels;
using Checkout.ApiServices.Shopping.RequestModels;
using Checkout.ApiServices.Shopping.ResponseModels;

namespace Checkout.ApiServices.Shopping
{
    public interface IShoppingListService
    {
        HttpResponse<PagedList<ShoppingListItem>> GetShoppingList(int page, int pageSize);
        HttpResponse<ShoppingListItem> GetShoppingListItem(string id);
        HttpResponse<ShoppingListItem> GetShoppingListItemByName(string name);
        HttpResponse<ShoppingListItem> AddShoppingListItem(ShoppingListItemAdd command);
        HttpResponse UpdateShoppingListItem(string id, ShoppingListItemUpdate command);
        HttpResponse DeleteShoppingListItem(string id);
    }
}
