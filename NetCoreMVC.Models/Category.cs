using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreMVC.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("類別名稱")]
        public string NAME {  get; set; }
        [DisplayName("顯示順序")]
        [Range(1, 100, ErrorMessage = "輸入範圍應該要在1-100之間")]
        public int DISPLAYORDER { get; set; }

    }
}
