using System;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Shell;
using System.Diagnostics;

namespace BibleHub
{
    public class AppSettings
    {
        // isolated storage settings 
        IsolatedStorageSettings isolatedStoreSettings;

        // Constructor for the application settings. 
        public AppSettings()
        {
            try
            {
                // Get the settings for this application. 
                isolatedStoreSettings = IsolatedStorageSettings.ApplicationSettings;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception getting IsolatedStorageSettings.ApplicationSettings: " + e.ToString());
            }
        }

        // Update the settings. If the setting does not exist, then add the setting. 
        public bool AddUpdateSetting(string Key, Object value)
        {
            bool updated = false;

            try
            {
                if (!isolatedStoreSettings.Contains(Key))
                {
                    isolatedStoreSettings.Add(Key, value);
                    updated = true;
                }
                else
                {
                    // if new value is different, set the new value. 
                    if (isolatedStoreSettings[Key] != value)
                    {
                        isolatedStoreSettings[Key] = value;
                        updated = true;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception in IsolatedStoreSettings: " + e.ToString());
                throw e;
            }
            return updated;
        }

        // In the read routine, we will get the value from the isolateStoreSettings dictionary using our key 

        // Get the current value of the setting, or if not found, set to the setting. 
        public valueType GetSettingValue<valueType>(string Key, valueType val)
        {
            try
            {
                if (!isolatedStoreSettings.Contains(Key))
                {
                    isolatedStoreSettings.Add(Key, val);
                    return val;
                }
                else
                {
                    return (valueType)isolatedStoreSettings[Key];
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception in IsolatedStoreSettings: " + e.ToString());
                throw e;
            }
        }
        // Save the settings. 
        public void Save()
        {
            isolatedStoreSettings.Save();
        }
        // isolated storage key names of our settings 
        const string SelectedBookSettingKeyName = "SelectedBookSetting";
        const string SelectedAuthorSettingKeyName = "SelectedAuthorSetting";
        const string SelectedCategorySettingKeyName = "SelectedCategorySetting";
        const string SelectedDateSettingKeyName = "SelectedDateSetting";
        const string SelectedChaptersSettingKeyName = "SelectedChaptersSetting";
        const string CompletedBooksSettingKeyName = "CompletedBooksSetting";
        const string InProgressBooksSettingKeyName = "InProgressBooksSetting";
        const string CompletedDatesSettingKeyName = "CompletedDatesSetting";
        const string CheckedCheckBoxesSettingKeyName = "CheckedCheckBoxesSetting";
        const string ChaptersCompleteSettingKeyName = "ChaptersCompleteSetting";
        const string CurrentCheckedChaptersSettingKeyName = "CurrentCheckedChaptersSetting";
        const string PercentCompleteSettingKeyName = "PercentCompleteSetting";
        
        

        // default values for our settings 
        const string SelectedBookSettingDefault = "Genesis";
        const string SelectedAuthorSettingDefault = "Moses";
        const string SelectedCategorySettingDefault = "Law";
        const string SelectedDateSettingDefault = "1445-1405 BC";
        const string CompletedBooksSettingDefault = "";
        const string InProgressBooksSettingDefault = "";
        const string CompletedDatesSettingDefault = "";
        const int SelectedChaptersSettingDefault = 50;
        const string CheckedCheckBoxesSettingDefault = "";
        const string ChaptersCompleteSettingDefault = "";
        const int CurrentCheckedChaptersSettingDefault = 0;
        const string PercentCompleteSettingDefault = "0%";

        public string PercentCompleteSetting
        {
            get
            {
                return (GetSettingValue<string>(PercentCompleteSettingKeyName, PercentCompleteSettingDefault));
            }

            set
            {
                AddUpdateSetting(PercentCompleteSettingKeyName, value);
                Save();
            }
        }
        public string CompletedBooksSetting
        {
            get
            {
                return (GetSettingValue<string>(CompletedBooksSettingKeyName, CompletedBooksSettingDefault));
            }

            set
            {
                AddUpdateSetting(CompletedBooksSettingKeyName, value);
                Save();
            }
        }
        public string InProgressBooksSetting
        {
            get
            {
                return (GetSettingValue<string>(InProgressBooksSettingKeyName, InProgressBooksSettingDefault));
            }

            set
            {
                AddUpdateSetting(InProgressBooksSettingKeyName, value);
                Save();
            }
        }

        public void SetBookCompletedDate(String sCompletedDate)
        {
            String sBookCompletedKey = SelectedBookSetting + "CompletedDate";

            AddUpdateSetting(sBookCompletedKey, sCompletedDate);
            Save();
        }

        public String GetBookCompletedDate()
        {
            String sBookKey = SelectedBookSetting + "CompletedDate";
            return (GetSettingValue<string>(sBookKey, ""));
        }

        public string CompletedDatesSetting
        {
            get
            {
                return (GetSettingValue<string>(CompletedDatesSettingKeyName, CompletedDatesSettingDefault));
            }

            set
            {
                
            }
        }
          public string ChaptersCompleteSetting
        {
            get
            {
                return (GetSettingValue<string>(ChaptersCompleteSettingKeyName, ChaptersCompleteSettingDefault));
            }

            set
            {
                AddUpdateSetting(ChaptersCompleteSettingKeyName, value);
                Save();
            }
        }
        public string CheckedCheckBoxesSetting
        {
            get
            {
                return (GetSettingValue<string>(CheckedCheckBoxesSettingKeyName, CheckedCheckBoxesSettingDefault));
            }

            set
            {
                AddUpdateSetting(CheckedCheckBoxesSettingKeyName, value);
                Save();
            }
        }
       
        public string SelectedBookSetting
        {
            get
            {
                return (GetSettingValue<string>(SelectedBookSettingKeyName, SelectedBookSettingDefault));
            }

            set
            {
                AddUpdateSetting(SelectedBookSettingKeyName, value);
                Save();
            }
        }
        public string SelectedAuthorSetting
        {
            get
            {
                return (GetSettingValue<string>(SelectedAuthorSettingKeyName, SelectedAuthorSettingDefault));
            }

            set
            {
                AddUpdateSetting(SelectedAuthorSettingKeyName, value);
                Save();
            }
        }
        public string SelectedCategorySetting
        {
            get
            {
                return (GetSettingValue<string>(SelectedCategorySettingKeyName, SelectedCategorySettingDefault));
            }

            set
            {
                AddUpdateSetting(SelectedCategorySettingKeyName, value);
                Save();
            }
        }
        public string SelectedDateSetting
        {
            get
            {
                return (GetSettingValue<string>(SelectedDateSettingKeyName, SelectedDateSettingDefault));
            }

            set
            {
                AddUpdateSetting(SelectedDateSettingKeyName, value);
                Save();
            }
        }
        public int SelectedChaptersSetting
        {
            get
            {
                return (GetSettingValue<int>(SelectedChaptersSettingKeyName, SelectedChaptersSettingDefault));
            }

            set
            {
                AddUpdateSetting(SelectedChaptersSettingKeyName, value);
                Save();
            }
        }
        public int CurrentCheckedChaptersSetting
        {
            get
            {
                return (GetSettingValue<int>(CurrentCheckedChaptersSettingKeyName, CurrentCheckedChaptersSettingDefault));
            }

            set
            {
                AddUpdateSetting(CurrentCheckedChaptersSettingKeyName, value);
                Save();
            }
        }

    }
}
