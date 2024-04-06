using View.View.Interfaces;

namespace Model.Services.ViewNotifier;

public class ViewNotifierService : IViewNotifierService
{
    private readonly IView _view;

    public ViewNotifierService(IView view)
    {
        _view = view;
    }

    public void Notify(string update)
    {
        _view.Update(update);
    }
}