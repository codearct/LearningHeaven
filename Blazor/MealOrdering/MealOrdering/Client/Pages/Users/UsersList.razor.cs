using System.Net.Http.Json;
using MealOrdering.Shared.DTO;
using Microsoft.AspNetCore.Components;
using Shared.ResponseModels;

namespace Client.Pages.Users
{
    public class UsersListBase : ComponentBase
    {
        [Inject]
        public HttpClient _client { get; set; }

        protected List<UserDTO> users = new();

        protected async override Task OnInitializedAsync()
        {
            await LoadList();
        }

        protected async Task LoadList()
        {
            var result = await _client.GetFromJsonAsync<ServiceResponse<List<UserDTO>>>("api/users");
            if (result.Success)
            {
                users = result.Value;
            }
        }
    }
}