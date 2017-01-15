using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartHomeDemo.Models;

namespace SmartHomeDemo.Db.Models
{
    [Table("Devices")]
    public class Device
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int RoomId { get; set; }

        [Required]
        [DisplayName("Device name")]
        public string Name { get; set; }

        public DeviceStatus Status { get; set; }

        [ConcurrencyCheck]
        public byte[] Version { get; set; }

        #region Navigation properties 

        public virtual Room Room { get; set; }

        #endregion
    }
}