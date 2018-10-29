using System.ComponentModel.DataAnnotations;

namespace PeopleProTraining.Dal.Models
{
    [MetadataType(typeof(DepartmentMetaData))]
    public partial class Department
    {

    }
    public class DepartmentMetaData
    {
        [Required]
        public string Name;
    }
}
