using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Genomix;

public partial class MainWindow : Window
{
    private object? _overviewContent;

    public event Action? SamplesRequested;
    public event Action? OverviewRequested;

    public MainWindow()
    {
        InitializeComponent();
        _overviewContent = Content;
        SamplesButton.Click += OnSamplesClick;
    }

    private void OnSamplesClick(object? sender, RoutedEventArgs e)
    {
        SamplesRequested?.Invoke();
    }

    public void ShowSamples()
    {
        var backButton = new Button
        {
            Content = "Back to overview",
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Left,
            Padding = new Avalonia.Thickness(16, 8)
        };
        backButton.Click += (_, _) => OverviewRequested?.Invoke(); 

        var samplesPage = new StackPanel
        {
            Margin = new Avalonia.Thickness(24),
            Spacing = 12
        };
        samplesPage.Children.Add(new TextBlock
        {
            Text = "Samples",
            FontSize = 28,
            FontWeight = Avalonia.Media.FontWeight.Bold
        });
        samplesPage.Children.Add(new TextBlock
        {
            Text = "The sample workspace is ready for the upload and validation step."
        });
        samplesPage.Children.Add(backButton);

        Content = samplesPage;
    }

    public void ShowOverview()
    {
        Content = _overviewContent;
    }
}
