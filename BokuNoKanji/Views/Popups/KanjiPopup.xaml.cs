using CommunityToolkit.Maui.Views;

namespace BokuNoKanji.Popups;

public partial class KanjiPopup : Popup
{
    public KanjiPopup()
    {
        InitializeComponent();

        BindingContext = this;
    }
}