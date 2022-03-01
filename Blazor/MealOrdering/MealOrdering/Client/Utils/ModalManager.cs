using Blazored.Modal;
using Blazored.Modal.Services;
using MealOrdering.Client.CustomComponents.Modals;

namespace MealOrdering.Client.Utils
{
    public class ModalManager
    {
        private readonly IModalService _modalService;
        public ModalManager(IModalService modalService)
        {
            _modalService = modalService;
        }

        public async Task ShowMessageAsync(string title,string message,int duration=0)
        {
            ModalParameters mParams = new();
            mParams.Add("Message", message);
            var modalRef = _modalService.Show<ShowMessage>(title, mParams);
            if (duration>0)
            {
                await Task.Delay(duration);
                modalRef.Close();
            }
        }

        public async Task<bool> ConfirmStatusAsync(string title, string message)
        {
            ModalParameters mParams = new();
            mParams.Add("Message", message);
            var modalRef = _modalService.Show<ConfirmStatus>(title, mParams);
            var modalResult = await modalRef.Result;

            return !modalResult.Cancelled;      
        }

    }
}
