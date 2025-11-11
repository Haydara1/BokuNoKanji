using CommunityToolkit.Maui.Views;

namespace BokuNoKanji.Popups;

public partial class InfoPopup : Popup
{
    public string Message { get; set; }

    public InfoPopup(string message)
    {
        InitializeComponent();
        Message = message;
        BindingContext = this;
    }
}