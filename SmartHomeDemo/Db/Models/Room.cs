using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHomeDemo.Db.Models
{
    [Table("Rooms")]
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Room")]
        public string Name { get; set; }

        #region Navigation properties 

        public virtual ICollection<Device> Devices { get; set; }

        #endregion
    }
}