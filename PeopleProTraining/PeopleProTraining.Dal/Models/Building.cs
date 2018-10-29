using System.ComponentModel.DataAnnotations;

namespace PeopleProTraining.Dal.Models
{
    [MetadataType(typeof(BuildingMetaData))]
    public partial class Building
    {
    }
    public class BuildingMetaData
    {
        [Required]
        public string Address;
        [Required]
        public string Name;
    }
}
