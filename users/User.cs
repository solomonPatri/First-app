using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace first_app.users
{

    [Table("users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id;

        [Required]
        [Column("username")]
        public string Username;

        [Required]
        [Column("password")]
        public string Password;

        [Required]
        [Column("Age: ")]
        public int Age;

        [Required]
        [Column("Height")]
        public double Height;

        [Required]
        [Column("Country: ")]
        public string country;

        [Required]
        [Column("Job")]
        public string Job;



    }








}
