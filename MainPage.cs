using System.Net.Mime;
using Microsoft.VisualBasic;
using Microsoft.Maui.Controls.Shapes;
using GradientStop = Microsoft.Maui.Controls.GradientStop;
using System.Reflection.Metadata;
using System.ComponentModel;

namespace TodoApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		Border border = new Border
		{
			Stroke = Color.FromArgb("#C49B33"),
			Background = Color.FromArgb("#2B0B98"),
			StrokeThickness = 4,
			Padding = new Thickness(16, 8),
			HorizontalOptions = LayoutOptions.Center,
			StrokeShape = new RoundRectangle
			{
				CornerRadius = new CornerRadius(0, 40, 40, 0)
			},
			Content = new Label
			{
				Text = "Todo App",
				TextColor = Colors.White,
				FontSize = 18,
				FontAttributes = FontAttributes.Bold
			}
		};
		var button = new Button { Text = "Add"};
        var label = new Label{
            Text = "Hello World",
            FontSize = 30,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            HorizontalTextAlignment = TextAlignment.Center,
            VerticalTextAlignment = TextAlignment.Center
        };
		var todolist = new VerticalStackLayout{Spacing = 15};
		var entry = new Entry
		{
			Placeholder = "Entry From Code",
			WidthRequest = 350
			//HorizontalOptions = LayoutOptions.FillAndExpand
		};

        button.Clicked += async (s, e) =>
        {
            label.Text= entry.Text;
			count++;
			var dlbutton = new Button{Text = "Delete", FontAttributes = FontAttributes.Bold,BackgroundColor = Color.FromArgb("#f15006")};
			
			var todoBox = new HorizontalStackLayout{
				Spacing = 25,
				Children = {  new Label{
					WidthRequest = 300,
            Text = $"{count}: {entry.Text}",
            FontSize = 20,
            //HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            VerticalTextAlignment = TextAlignment.Center, 
        } ,dlbutton }
			}; 
			var borderBox = BorderCreater(todoBox);
			dlbutton.Clicked += async (s, e) => {todolist.Children.Remove(borderBox);};
			//todolist.Children.Add(todoBox);

			todolist.Children.Add(borderBox);
			entry.Text = "";
        };
		var entrytab = new HorizontalStackLayout
		{
			Spacing = 10,
			Children = { entry,button}
		};
		
		var scrollViews = new ScrollView
		{
			Content = todolist
		};
        Content = new VerticalStackLayout
        {
            Padding = 20,
			Spacing = 10,
            Children = { border,label, entrytab,scrollViews}
        };
	}
	public static Border BorderCreater(HorizontalStackLayout TodoItem)
	{
		Border border = new Border
		{
			Stroke = Color.FromArgb("#423d47"),
			//Background = Color.FromArgb("#2B0B98"),
			StrokeThickness = 1,
			Padding = 15,
			HorizontalOptions = LayoutOptions.Center,
			StrokeShape = new RoundRectangle
			{
				CornerRadius = new CornerRadius(15, 15, 15, 15)
			},
			Content = TodoItem
		};
		return border;
	}

}
