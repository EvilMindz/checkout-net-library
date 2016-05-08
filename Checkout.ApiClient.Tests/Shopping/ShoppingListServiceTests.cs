using Checkout;
using Checkout.ApiServices.SharedModels;
using Checkout.ApiServices.Shopping;
using Checkout.ApiServices.Shopping.RequestModels;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System.Net;

namespace Tests.Shopping
{
    [TestFixture(Category = "ShoppingListApi")]
    public class ShoppingListServiceTests : BaseServiceTests
    {
        IShoppingListService shoppingListService;

        [SetUp]
        public void BeforeEach()
        {
            shoppingListService = new ShoppingListService(baseUrl: "http://localhost:50427");

            // Clear the shopping list before each test run
            new ApiHttpClient().DeleteRequest<OkResponse>("http://localhost:50427/shoppinglist", "xxx");
        }

        [Test]
        public void Can_add_shopping_list_item()
        {
            var response = shoppingListService.AddShoppingListItem(new ShoppingListItemAdd
            {
                Name = "Coca Cola",
                Quantity = 5
            });

            response.HttpStatusCode.Should().Be(HttpStatusCode.Created);
            response.Model.Should().NotBeNull();
            response.Model.Name.Should().Be("Coca Cola");
            response.Model.Quantity.Should().Be(5);
        }

        [Test]
        public void Can_get_shopping_list_item_by_id()
        {
            var response = shoppingListService.AddShoppingListItem(new ShoppingListItemAdd { Name = "Pepsi", Quantity = 2 });

            var getByIdResponse = shoppingListService.GetShoppingListItem(response.Model.Id);

            getByIdResponse.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            getByIdResponse.Model.Should().NotBeNull();
            getByIdResponse.Model.Name.Should().Be("Pepsi");
            getByIdResponse.Model.Quantity.Should().Be(2);
        }

        [Test]
        public void Can_get_shopping_list_item_by_name()
        {
            var response = shoppingListService.AddShoppingListItem(new ShoppingListItemAdd { Name = "Lemonade", Quantity = 3 });

            var getByNameResponse = shoppingListService.GetShoppingListItemByName(response.Model.Name);

            getByNameResponse.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            getByNameResponse.Model.Should().NotBeNull();
            getByNameResponse.Model.Name.Should().Be("Lemonade");
            getByNameResponse.Model.Quantity.Should().Be(3);
        }

        [Test]
        public void Can_list_shopping_list_items()
        {
            for (int i = 1; i < 11; i++)
            {
                shoppingListService.AddShoppingListItem(new ShoppingListItemAdd { Name = "Item " + i, Quantity = 1 });
            }

            var response = shoppingListService.GetShoppingList(2, 5);

            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Should().NotBeNull();
            response.Model.TotalCount.Should().Be(10);
            response.Model.CurrentPageCount.Should().Be(5);
            response.Model.Items.Count().Should().Be(5);
            response.Model.Items.First().Name.Should().Be("Item 6");
        }

        [Test]
        public void Can_page_shopping_list_items()
        {
            for (int i = 1; i < 11; i++)
            {
                shoppingListService.AddShoppingListItem(new ShoppingListItemAdd { Name = "Item " + i, Quantity = 1 });
            }

            var response = shoppingListService.GetShoppingList(1, 20);
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Should().NotBeNull();
            response.Model.TotalCount.Should().Be(10);
            response.Model.CurrentPageCount.Should().Be(10);
            response.Model.Items.Count().Should().Be(10);
            response.Model.Items.First().Name.Should().Be("Item 1");
        }

        [Test]
        public void Can_update_shopping_list_item()
        {
            var response = shoppingListService.AddShoppingListItem(new ShoppingListItemAdd { Name = "Dr Pepper", Quantity = 10 });

            var updateResponse = shoppingListService.UpdateShoppingListItem(response.Model.Id, new ShoppingListItemUpdate { Quantity = 5 });
            updateResponse.HttpStatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Test]
        public void Can_delete_shopping_list_item()
        {
            var response = shoppingListService.AddShoppingListItem(new ShoppingListItemAdd { Name = "Mojito", Quantity = 3 });

            var deleteResponse = shoppingListService.DeleteShoppingListItem(response.Model.Id);
            deleteResponse.HttpStatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}
