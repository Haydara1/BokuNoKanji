using BokuNoKanji.Views;

namespace BokuNoKanji
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(KanjiListPage), typeof(KanjiListPage));
        }
    }
}
