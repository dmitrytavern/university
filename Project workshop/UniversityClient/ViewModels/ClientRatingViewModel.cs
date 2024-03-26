using System.Windows;
using UniversityClient.Api;
using UniversityServer.ViewModels;

namespace UniversityClient.ViewModels
{
    /// <summary>
    /// View model for handling client rating data.
    /// </summary>
    class ClientRatingViewModel : ViewModelBase
    {
        private List<RatingTeacherData> teachersData { get; set; } = new List<RatingTeacherData>();

        /// <summary>
        /// Gets or sets the list of teachers' rating data.
        /// </summary>
        public List<RatingTeacherData> TeachersData
        {
            get { return teachersData; }
            set
            {
                teachersData = value;
                OnPropertyChanged("TeachersData");
            }
        }

        /// <summary>
        /// Fetches the rating data asynchronously.
        /// </summary>
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
