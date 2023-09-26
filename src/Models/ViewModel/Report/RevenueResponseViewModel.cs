using Newtonsoft.Json;

namespace CarRentalManagement.Models.ViewModel.Report;

public class RevenueResponseViewModel
{
    public RevenueResponseViewModel()
    {
        Data = new DataObject();
    }

    [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
    public DataObject Data { get; set; }
    public class DataObject
    {
        public DataObject()
        {
            Datasets = new List<DataSet>();
            Labels = Enumerable.Empty<string>();
        }

        [JsonProperty("labels", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Labels { get; set; }

        [JsonProperty("datasets", NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<DataSet> Datasets { get; set; }

        public class DataSet
        {
            public DataSet()
            {
                Data = Enumerable.Empty<decimal>();
            }

            [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
            public string Label { get; set; }

            [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
            public IEnumerable<decimal> Data { get; set; }
        }
    }
}