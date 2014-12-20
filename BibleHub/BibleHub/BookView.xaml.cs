using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace BibleHub
{
    public partial class BookView : PhoneApplicationPage
    {
        AppSettings appSettings;
        public BookView()
        {
            InitializeComponent();
            appSettings = new AppSettings();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            BookTitle.Text = appSettings.SelectedBookSetting;
            BookAuthor.Text = appSettings.SelectedAuthorSetting;
            BookDate.Text = appSettings.SelectedDateSetting;
            BookCategory.Text = appSettings.SelectedCategorySetting;

            if (CheckBoxContainer != null) // It could be null during page creation (add event handler after construction to avoid this)
            {
                // The following works because the both the small and large change are one
                // If they were larger you may have to add (or remove) more at a time
                //if (CheckBoxContainer.Children.Count() < appSettings.SelectedChaptersSetting)
                //{
                int number = 0;

                while (number < appSettings.SelectedChaptersSetting)
                {
                    number = number + 1;
                    CheckBox aCheckBox = new CheckBox();
                    aCheckBox.Content = "Chapter " + number.ToString();
                    aCheckBox.Name = "Checkbox" + appSettings.SelectedChaptersSetting + number.ToString();
                    aCheckBox.Checked += OnCheckBoxChecked;
                    aCheckBox.Unchecked += OnCheckBoxUnchecked;
                    CheckBoxContainer.Children.Add(aCheckBox);
                    if (appSettings.CheckedCheckBoxesSetting.Contains(appSettings.SelectedBookSetting + number.ToString() + "#"))
                    {
                        aCheckBox.IsChecked = true;
                    }
                    //CheckBoxContainer.Children.Add(new CheckBox { Content = "Chapter " + number.ToString(), Name = appSettings.SelectedBookSetting + number.ToString(), IsChecked = true });
                }

                //}
                //else
                //{
                //    int number = CheckBoxContainer.Children.Count();
                //    while (number < appSettings.SelectedChaptersSetting)
                //    {
                //        CheckBoxContainer.Children.RemoveAt(int.Parse(number.ToString()));
                //    }
                //}
            }

        }
        private void OnCheckBoxChecked(object sender, EventArgs e)
        {
            var completeSenderName = sender.ToString();
            var parsedSenderName = completeSenderName.Replace("System.Windows.Controls.CheckBox Content:Chapter ", "");
            var superParsedSenderName = parsedSenderName.Replace(" IsChecked:True", "");
            var checkBoxName = superParsedSenderName; //Control.NameProperty.ToString(); sender.ToString(); 
            if (appSettings.CheckedCheckBoxesSetting.Contains(appSettings.SelectedBookSetting + checkBoxName + "#"))
            {
            }
            else
            {
                appSettings.CheckedCheckBoxesSetting = appSettings.CheckedCheckBoxesSetting + appSettings.SelectedBookSetting + checkBoxName + "#";
            }
        }
        private void OnCheckBoxUnchecked(object sender, EventArgs e)
        {
            var completeSenderName = sender.ToString();
            var parsedSenderName = completeSenderName.Replace("System.Windows.Controls.CheckBox Content:Chapter ", "");
            var superParsedSenderName = parsedSenderName.Replace(" IsChecked:False", "");
            var checkBoxName = superParsedSenderName;
            if (appSettings.CheckedCheckBoxesSetting.Contains(appSettings.SelectedBookSetting + checkBoxName + "#"))
            {
                appSettings.CheckedCheckBoxesSetting = appSettings.CheckedCheckBoxesSetting.Replace(appSettings.SelectedBookSetting + checkBoxName + "#", "");
            }
            else
            {
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsDebug.Text = appSettings.CheckedCheckBoxesSetting;
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {

            //try
            //{
            //    if (CheckBoxContainer.FindName(Genesis1) != null)
            //    {
            //        appSettings.GenesisBooleanSetting = true;
            //    }
            //}
            //catch
            //{

            //}
            
        }
    }
}