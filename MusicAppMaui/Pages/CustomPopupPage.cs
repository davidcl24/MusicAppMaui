using CommunityToolkit.Maui.Views;

namespace MusicAppMaui.Pages;

public class CustomPopupPage : Popup
{
    public Entry InputEntry { get; private set; }
    public Button AcceptButton { get; private set; }
    public Button CancelButton { get; private set; }

    public CustomPopupPage()
    {
        var nameEntry = new Entry
        {
            Placeholder = "Name",
            WidthRequest = 200
        };

        var descEntry = new Entry
        {
            Placeholder = "Description",
            WidthRequest = 200,
            Keyboard = Keyboard.Email
        };

        var acceptButton = new Button
        {
            Text = "OK"
        };
        acceptButton.Clicked += (s, e) =>
            Close((nameEntry.Text, descEntry.Text)); 
        var cancelButton = new Button
        {
            Text = "Cancel"
        };
        cancelButton.Clicked += (s, e) => Close(null); 

        Content = new VerticalStackLayout
        {
            Padding = 20,
            BackgroundColor = Colors.White,
            Children =
            {
                nameEntry,
                descEntry,
                new HorizontalStackLayout
                {
                    Spacing = 10,
                    Children = { acceptButton, cancelButton }
                }
            }
        };
    }
}
