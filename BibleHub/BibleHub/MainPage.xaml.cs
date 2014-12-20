using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BibleHub.Resources;
using System.Windows.Data;
using Microsoft.Phone.Tasks;
using System.Windows.Media;

namespace BibleHub
{
    // 949 chapters in the Old Testament
    // 260 chapters in the New Testament
    public partial class MainPage : PhoneApplicationPage
    {
        AppSettings appSettings;
        BookList bookList;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            appSettings = new AppSettings();
            bookList = new BookList();
            BibleHubListBox.ItemsSource = bookList;
        }
       
        private void Book_Selected(object sender, SelectionChangedEventArgs e)
        {
            //get selected book info
            var selected = BibleHubListBox.SelectedValue as Book;
            string selectedBook = selected.BookName;
            string selectedAuthor = selected.BookAuthor;
            string selectedCategory = selected.BookCategory;
            string selectedDate = selected.BookDate;
            int selectedChapters = selected.BookChapters;
            string selectedStatus = selected.CompletedStatus;
            //update appSettings for selected book's name, author, category, date, and number of chapters
            appSettings.SelectedBookSetting = selectedBook;
            appSettings.SelectedAuthorSetting = selectedAuthor;
            appSettings.SelectedCategorySetting = selectedCategory;
            appSettings.SelectedDateSetting = selectedDate;
            appSettings.SelectedChaptersSetting = selectedChapters;
            //go to bookView (which will now have updated information on the selected book!)
            //NavigationService.Navigate(new Uri("/BookView.xaml", UriKind.Relative));
            //BibleHubPivot.SelectedIndex = 1;
            if (BibleHubPivot.SelectedIndex != -1)
            {
                BibleHubPivot.SelectedIndex = 1;
            }
        }
       
        private void BibleHubPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var selected = BibleHubListBox.SelectedValue as Book;
            //string selectedStatus = selected.CompletedStatus;
            BookTitle.Text = appSettings.SelectedBookSetting;
            BookAuthor.Text = appSettings.SelectedAuthorSetting;
            BookDate.Text = appSettings.SelectedDateSetting;
            BookCategory.Text = appSettings.SelectedCategorySetting;
            BookStatus.Text = "";
            //BookStatus.Text = selectedStatus;
            //BookStatus.Text = appSettings.SelectedStatusSetting;
            BookViewScroller.ScrollToVerticalOffset(0);
            
            
            if (CheckBoxContainer != null) // It could be null during page creation (add event handler after construction to avoid this)
            {
                //Resets the checkboxes since each book has a different number 
                CheckBoxContainer.Children.Clear();
                appSettings.CurrentCheckedChaptersSetting = 0;
                

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
                    if (appSettings.CheckedCheckBoxesSetting.Contains("#" + appSettings.SelectedBookSetting + number.ToString() + "#"))
                    {
                        aCheckBox.IsChecked = true;
                        if (appSettings.SelectedChaptersSetting != appSettings.CurrentCheckedChaptersSetting)
                        {
                            BookStatus.Text = " In Progress";
                        }
                        //finds current number of checked chapters
                        //appSettings.CurrentCheckedChaptersSetting = appSettings.CurrentCheckedChaptersSetting + 1;
                    }
                    
                    if ((Visibility)Resources["PhoneLightThemeVisibility"] == Visibility.Visible)
                    {

                        BibleHubListBox.Foreground = new SolidColorBrush(Color.FromArgb(250, 255, 255, 255));
                        aCheckBox.Foreground = new SolidColorBrush(Color.FromArgb(250, 255, 255, 255));
                        aCheckBox.BorderBrush = new SolidColorBrush(Color.FromArgb(250, 255, 255, 255));
                        aCheckBox.Background = new SolidColorBrush(Color.FromArgb(250, 255, 255, 255));
                    }
                }

            }
            if (appSettings.SelectedChaptersSetting == appSettings.CurrentCheckedChaptersSetting)
            {
                String sBookCompletedDate = appSettings.GetBookCompletedDate();
                //CompletedTextDate.Text = sBookCompletedDate;
                BookStatus.Text = sBookCompletedDate;

                //CompletedText.Visibility = Visibility.Visible;
                //CompletedTextDate.Visibility = Visibility.Visible;
            }
            else
            {
                //CompletedText.Visibility = Visibility.Collapsed;
                //CompletedTextDate.Visibility = Visibility.Collapsed;
            }
        }
        private void OnCheckBoxChecked(object sender, EventArgs e)
        {
            //-----------1. MAINTAIN CHECKBOXES

            //appSettings.CurrentCheckedChaptersSetting tells us how many checkboxes are checked. When an additional checkbox is checked, we add 1 to appSettings.CurrentCheckedChaptersSetting
            appSettings.CurrentCheckedChaptersSetting = appSettings.CurrentCheckedChaptersSetting + 1;
            if (appSettings.ChaptersCompleteSetting.Contains(appSettings.SelectedBookSetting))
            {
                //to update the setting, we first get the old number of checkboxes that were checked.
                var oldNumberOfChapters = appSettings.CurrentCheckedChaptersSetting - 1;
                //then delete the old string
                appSettings.ChaptersCompleteSetting.Replace("#" + appSettings.SelectedBookSetting + oldNumberOfChapters + "#", "#" + appSettings.SelectedBookSetting + appSettings.CurrentCheckedChaptersSetting + "#");
            }
            else
            {
                //create the chapters complete setting for the new book (format example: #Genesis13#)
                appSettings.ChaptersCompleteSetting = appSettings.ChaptersCompleteSetting + "#" + appSettings.SelectedBookSetting + appSettings.CurrentCheckedChaptersSetting + "#";
            }
            var completeSenderName = sender.ToString();
            var parsedSenderName = completeSenderName.Replace("System.Windows.Controls.CheckBox Content:Chapter ", "");
            var superParsedSenderName = parsedSenderName.Replace(" IsChecked:True", "");
            var checkBoxName = superParsedSenderName; //Control.NameProperty.ToString(); sender.ToString(); 
            if (appSettings.CheckedCheckBoxesSetting.Contains("#" + appSettings.SelectedBookSetting + checkBoxName + "#") == false)
            {
                appSettings.CheckedCheckBoxesSetting = appSettings.CheckedCheckBoxesSetting + "#" + appSettings.SelectedBookSetting + checkBoxName + "#";
            }

            //-----------2. IF BOOK IS STILL IN PROGRESS

            //IF CURRENT BOOK = IN PROGRESS!
            

            //-----------3. IF BOOK IS COMPLETE

            //IF CURRENT BOOK = COMPLETE!
            if (appSettings.SelectedChaptersSetting == appSettings.CurrentCheckedChaptersSetting && appSettings.CompletedBooksSetting.Contains("#" + appSettings.SelectedBookSetting + "#") == false)
            {
                String sCompletedDate = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
                appSettings.SetBookCompletedDate(sCompletedDate);
                BookStatus.Text = " Completed " + sCompletedDate;

                //SET COMPLETE ICON
                appSettings.CompletedBooksSetting = appSettings.CompletedBooksSetting + "#" + appSettings.SelectedBookSetting + "#";
              

                //4. UPDATE LISTBOX
                //this prompts the ObservableCollection into throwing a onPropertyChanged, resulting in an updated listbox
            }
            if (appSettings.CurrentCheckedChaptersSetting == appSettings.SelectedChaptersSetting)
            {
                if (appSettings.InProgressBooksSetting.Contains("#" + appSettings.SelectedBookSetting + "#"))
                {
                    appSettings.InProgressBooksSetting = appSettings.InProgressBooksSetting.Replace("#" + appSettings.SelectedBookSetting + "#", "");
                    //this prompts the ObservableCollection into throwing a onPropertyChanged, resulting in an updated listbox
                    foreach (Book item in BibleHubListBox.Items)
                    {
                        item.CompletedStatus = "Visible";
                        item.InProgressStatus = "Visible";
                        item.CompletedStatus = appSettings.CompletedBooksSetting;
                        item.InProgressStatus = appSettings.InProgressBooksSetting;
                    }
                }
            }
            else if (appSettings.CurrentCheckedChaptersSetting != appSettings.SelectedChaptersSetting && appSettings.InProgressBooksSetting.Contains("#" + appSettings.SelectedBookSetting + "#") == false)
            {
                //SET PROGRESS ICON & STATUS TEXT
               appSettings.InProgressBooksSetting = appSettings.InProgressBooksSetting + "#" + appSettings.SelectedBookSetting + "#";
               BookStatus.Text = " In Progress";
               foreach (Book item in BibleHubListBox.Items)
               {
                   item.CompletedStatus = "Visible";
                   item.InProgressStatus = "Visible";
                   item.CompletedStatus = appSettings.CompletedBooksSetting;
                   item.InProgressStatus = appSettings.InProgressBooksSetting;
               }
            }
            //Compute Percent Completed
            int hashtagCount = 0;
            foreach (char c in appSettings.CheckedCheckBoxesSetting)
                if (c == '#') hashtagCount++;
            //int hashtagCount = appSettings.ChaptersCompleteSetting.Count(f => f == '#');
            int chaptersComplete = hashtagCount / 2;
            double fractionComplete = (double)chaptersComplete / (double)1209;
            double percentComplete = fractionComplete * 100;
            percentComplete = Math.Round(percentComplete, 0);
            string percentString = percentComplete.ToString();
            //percentString = percentString.TakeWhile(char => char != ".")
            //if (percentString.Contains(".") )
            //{
            //    percentString = percentString.Replace(".", "");
            //}
            //string percentCompleteShortened = StringTool.Truncate(percentString, 3);
            appSettings.PercentCompleteSetting = percentString + "%";
            PercentCompleteTextBlock.Text = appSettings.PercentCompleteSetting;
        }
        private void OnCheckBoxUnchecked(object sender, EventArgs e)
        {

            appSettings.CurrentCheckedChaptersSetting = appSettings.CurrentCheckedChaptersSetting - 1;
            if (appSettings.ChaptersCompleteSetting.Contains(appSettings.SelectedBookSetting))
            {
                //update the chapters complete setting for new number of chapters complete
                var oldNumberOfChapters = appSettings.CurrentCheckedChaptersSetting + 1;
                appSettings.ChaptersCompleteSetting.Replace("#" + appSettings.SelectedBookSetting + oldNumberOfChapters + "#", "#" + appSettings.SelectedBookSetting + appSettings.CurrentCheckedChaptersSetting + "#");
            }
            else
            {
                //create the chapters complete setting for the new book
                appSettings.ChaptersCompleteSetting = appSettings.ChaptersCompleteSetting + "#" + appSettings.SelectedBookSetting + appSettings.CurrentCheckedChaptersSetting + "#";
            }

            var completeSenderName = sender.ToString();
            var parsedSenderName = completeSenderName.Replace("System.Windows.Controls.CheckBox Content:Chapter ", "");
            var superParsedSenderName = parsedSenderName.Replace(" IsChecked:False", "");
            var checkBoxName = superParsedSenderName;
            if (appSettings.CheckedCheckBoxesSetting.Contains("#" + appSettings.SelectedBookSetting + checkBoxName + "#"))
            {
                appSettings.CheckedCheckBoxesSetting = appSettings.CheckedCheckBoxesSetting.Replace("#" + appSettings.SelectedBookSetting + checkBoxName + "#", "");
            }
            
            //IF CURRENT BOOK = IN PROGRESS!
            if (appSettings.SelectedChaptersSetting != appSettings.CurrentCheckedChaptersSetting)
            {

                appSettings.SetBookCompletedDate("");
                //CompletedTextDate.Visibility = Visibility.Collapsed;
                if (appSettings.CompletedBooksSetting.Contains("#" + appSettings.SelectedBookSetting + "#"))
                {
                    appSettings.CompletedBooksSetting = appSettings.CompletedBooksSetting.Replace("#" + appSettings.SelectedBookSetting + "#", "");
                    //appSettings.CompletedDatesSetting = appSettings.CompletedDatesSetting.Replace(appSettings.SelectedBookSetting + "#", "");
                }
                //if (appSettings.InProgressBooksSetting.Contains("#" + appSettings.SelectedBookSetting + "#") == false)
                //{
                //    appSettings.InProgressBooksSetting = appSettings.InProgressBooksSetting + "#" + appSettings.SelectedBookSetting + "#";
                //}
                
                //CompletedText.Visibility = Visibility.Collapsed;
                //this prompts the ObservableCollection into throwing a onPropertyChanged, resulting in an updated listbox with NO thumbs up
                foreach (Book item in BibleHubListBox.Items)
                {
                    item.CompletedStatus = "Visible";
                    item.InProgressStatus = "Visible";
                    item.CompletedStatus = appSettings.CompletedBooksSetting;
                    item.InProgressStatus = appSettings.InProgressBooksSetting;
                }
                BookStatus.Text = " In Progress";
            }

            //IF CURRENT BOOK = NOT STARTED!
            if (appSettings.CurrentCheckedChaptersSetting == 0)
            {
                BookStatus.Text = "";
                if (appSettings.InProgressBooksSetting.Contains("#" + appSettings.SelectedBookSetting + "#"))
                {
                    appSettings.InProgressBooksSetting = appSettings.InProgressBooksSetting.Replace("#" + appSettings.SelectedBookSetting + "#", "");
                    //this prompts the ObservableCollection into throwing a onPropertyChanged, resulting in an updated listbox
                    foreach (Book item in BibleHubListBox.Items)
                    {
                        item.CompletedStatus = "Visible";
                        item.InProgressStatus = "Visible";
                        item.CompletedStatus = appSettings.CompletedBooksSetting;
                        item.InProgressStatus = appSettings.InProgressBooksSetting;
                    }
                }
               
            }
            //Compute Percent Completed
            int hashtagCount = 0;
            foreach (char c in appSettings.CheckedCheckBoxesSetting)
                if (c == '#') hashtagCount++;
            //int hashtagCount = appSettings.ChaptersCompleteSetting.Count(f => f == '#');
            int chaptersComplete = hashtagCount / 2;
            double fractionComplete = (double)chaptersComplete / (double)1209;
            double percentComplete = fractionComplete * 100;
            percentComplete = Math.Round(percentComplete, 0);
            string percentString = percentComplete.ToString();
            //percentString = percentString.TakeWhile(char => char != ".")
            //if (percentString.Contains(".") )
            //{
            //    percentString = percentString.Replace(".", "");
            //}
            //string percentCompleteShortened = StringTool.Truncate(percentString, 3);
            appSettings.PercentCompleteSetting = percentString + "%";
            PercentCompleteTextBlock.Text = appSettings.PercentCompleteSetting;
        }
        public static class StringTool
        {
            // Get a substring of the first N characters.
            public static string Truncate(string source, int length)
            {
                if (source.Length > length)
                {
                    source = source.Substring(0, length);
                }
                return source;
            }
        }

        private void OT_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //BibleHubListBox.SelectedIndex = 43;

            BibleHubListBox.ScrollIntoView(BibleHubListBox.Items[0]);
        }

        private void NT_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            BibleHubListBox.ScrollIntoView(BibleHubListBox.Items[51]);
        }

        private void Reset_All_Click(object sender, EventArgs e)
        {
            if (BibleHubPivot.SelectedIndex == 0)
            {
                if (System.Windows.MessageBox.Show("Are you sure you want to reset ALL Bible Hub progress? THIS CANNOT BE UNDONE!", "Reset All Progress", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    PercentCompleteTextBlock.Text = "0%";
                    appSettings.ChaptersCompleteSetting = "";
                    appSettings.CompletedBooksSetting = "";
                    appSettings.InProgressBooksSetting = "";
                    appSettings.CompletedDatesSetting = "";
                    appSettings.ChaptersCompleteSetting = "";
                    appSettings.CurrentCheckedChaptersSetting = 0;
                    appSettings.CheckedCheckBoxesSetting = "";
                    foreach (Book item in BibleHubListBox.Items)
                    {
                        item.CompletedStatus = "Visible";
                        item.InProgressStatus = "Visible";
                        item.CompletedStatus = appSettings.CompletedBooksSetting;
                        item.InProgressStatus = appSettings.InProgressBooksSetting;
                    }
                }

            }
            else if (BibleHubPivot.SelectedIndex == 1)
            {
                if (System.Windows.MessageBox.Show("Would you like to reset progress for " + appSettings.SelectedBookSetting + "?", "Reset Current Book", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    int number = 0;
                    while (number < appSettings.SelectedChaptersSetting)
                    {
                        number = number + 1;
                        if (appSettings.CheckedCheckBoxesSetting.Contains("#" + appSettings.SelectedBookSetting + number + "#") == true)
                        {
                            appSettings.CheckedCheckBoxesSetting = appSettings.CheckedCheckBoxesSetting.Replace("#" + appSettings.SelectedBookSetting + number + "#", "");
                        }
                    }
                    if (appSettings.CompletedBooksSetting.Contains("#" + appSettings.SelectedBookSetting + "#"))
                    {
                        appSettings.CompletedBooksSetting = appSettings.CompletedBooksSetting.Replace("#" + appSettings.SelectedBookSetting + "#", "");
                    }
                    //this prompts the ObservableCollection into throwing a onPropertyChanged, resulting in an updated listbox
                    foreach (Book item in BibleHubListBox.Items)
                    {
                        item.CompletedStatus = "Visible";
                        item.InProgressStatus = "Visible";
                        item.CompletedStatus = appSettings.CompletedBooksSetting;
                        item.InProgressStatus = appSettings.InProgressBooksSetting;
                    }
                    if (BibleHubPivot.SelectedIndex != -1)
                    {
                        BibleHubPivot.SelectedIndex = 0;
                    }
                }
            }

        }

        private void Rate_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();

            marketplaceReviewTask.Show();
        }

        private void CompleteBook_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (System.Windows.MessageBox.Show("Would you like to mark this book as complete?", "Complete " + appSettings.SelectedBookSetting, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                int number = 0;
                while (number < appSettings.SelectedChaptersSetting)
                {
                    number = number + 1;
                    if (appSettings.CheckedCheckBoxesSetting.Contains("#" + appSettings.SelectedBookSetting + number + "#") == false)
                    {
                        appSettings.CheckedCheckBoxesSetting = appSettings.CheckedCheckBoxesSetting + "#" + appSettings.SelectedBookSetting + number + "#";
                    }
                }
                if (BibleHubPivot.SelectedIndex != -1)
                {
                    BibleHubPivot.SelectedIndex = 0;
                }
            }
        }

        private void About_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }


        }
    }