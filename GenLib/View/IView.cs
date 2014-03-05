namespace GenLib.View
{
    public interface IView
    {
        void OnSetTitle(StringEventArgs args);
        void OnShowDialog();
        void OnClose();
        void Subscribe();
    }
}