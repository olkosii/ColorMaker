using CommunityToolkit.Maui.Alerts;

namespace ColorMaker;

public partial class MainPage : ContentPage
{
    private bool isRandom;
	public MainPage()
	{
		InitializeComponent();
	}

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (!isRandom)
        {
            var red = sliderRed.Value;
            var blue = sliderBlue.Value;
            var green = sliderGreen.Value;

            Color color = Color.FromRgb(red, green, blue);

            SetColor(color);
        }
    }

    private void buttonRandom_Clicked(object sender, EventArgs e)
    {
        isRandom = true;

        var random = new Random();

        var color = Color.FromRgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));

        SetColor(color);

        sliderRed.Value = color.Red;
        sliderBlue.Value = color.Blue;
        sliderGreen.Value = color.Green;

        isRandom = false;
    }

    private void SetColor(Color color)
    {
        buttonRandom.BackgroundColor = color;
        Container.BackgroundColor = color;
        labelHex.Text = color.ToHex();
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(labelHex.Text);
        var toast = Toast.Make("Color copied",CommunityToolkit.Maui.Core.ToastDuration.Short,12);
        await toast.Show();
    }
}

