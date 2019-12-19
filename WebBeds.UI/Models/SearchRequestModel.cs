namespace WebBeds.UI.Models
{
    using System.ComponentModel.DataAnnotations;
    public class SearchRequestModel
    {
        /// <summary>
        /// DestinationId
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Please select destination")]
        public int DestinationId { get; set; }

        /// <summary>
        /// Nights
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a non-zero positve integer")]
        public int Nights { get; set; }
    }
}
