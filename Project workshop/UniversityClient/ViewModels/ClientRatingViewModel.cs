using System.Windows;
using UniversityClient.Api;
using UniversityServer.ViewModels;

namespace UniversityClient.ViewModels
{
    class ClientRatingViewModel : ViewModelBase
    {
        private List<RatingTeacherData> teachersData { get; set; } = [];
        public List<RatingTeacherData> TeachersData
        {
            get { return teachersData; }
            set
            {
                teachersData = value;
                OnPropertyChanged("TeachersData");
            }
        }

        public async void FetchRating()
        {
            try
            {
                TeachersData = await GetRatingApi.Handle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
