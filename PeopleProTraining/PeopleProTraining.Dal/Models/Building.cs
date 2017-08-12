using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleProTraining.Dal.Models
{
    [MetadataType(typeof(BuildingMetaData))]
    public partial class Building
    {
    }

    public class BuildingMetaData
    {
        [Display (Name = "Building Code")]
        [Required (ErrorMessage = "Building code required")]
        public int BuildingId;

        [Display (Name = "Building Name")]
        [Required (ErrorMessage = "Building name required.")]
        [StringLength (20, MinimumLength = 2)]
        public string BuildingName;
    }
}
