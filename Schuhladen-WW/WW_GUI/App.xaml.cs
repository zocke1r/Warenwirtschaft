using MahApps.Metro;
using System;
using System.Windows;

namespace WW_GUI
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // get the current app style (theme and accent) from the application
            // you can then use the current theme and custom accent instead set a new theme
            Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        // ThemeManager.GetAccent("Red"),
                                        // ThemeManager.GetAccent("Green"),
                                        ThemeManager.GetAccent("Blue"),
                                        // ThemeManager.GetAccent("Purple"),
                                        // ThemeManager.GetAccent("Orange"),
                                        // ThemeManager.GetAccent("Lime"),
                                        // ThemeManager.GetAccent("Emerald"),
                                        // ThemeManager.GetAccent("Teal"),
                                        // ThemeManager.GetAccent("Cyan"),
                                        // ThemeManager.GetAccent("Cobalt"),
                                        // ThemeManager.GetAccent("Indigo"),
                                        // ThemeManager.GetAccent("Violet"),
                                        // ThemeManager.GetAccent("Pink"),
                                        // ThemeManager.GetAccent("Magenta"),
                                        // ThemeManager.GetAccent("Crimson"),
                                        // ThemeManager.GetAccent("Amber"),
                                        // ThemeManager.GetAccent("Yellow"),
                                        // ThemeManager.GetAccent("Brown"),
                                        // ThemeManager.GetAccent("Olive"),
                                        // ThemeManager.GetAccent("Steel"),
                                        // ThemeManager.GetAccent("Mauve"),
                                        // ThemeManager.GetAccent("Taupe"),
                                        // ThemeManager.GetAccent("Sienna"),
                                        ThemeManager.GetAppTheme("BaseLight")); // or appStyle.Item1

            base.OnStartup(e);
        }
    }
}