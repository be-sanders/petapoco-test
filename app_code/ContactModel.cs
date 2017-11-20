using System.ComponentModel.DataAnnotations;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace InstallUmbraco.Models
{
    [TableName("ContactsStore")]
    [PrimaryKey("Contact_ID", autoIncrement= true)]
    [ExplicitColumns]
    public class ContactModel
    {
        [Column("contract_id")]
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int ContactID { get; set; }

        [Required]
        [Display(Name = "First Name:")]
        [Column("firstname")]
        public string FirstName { get; set; }

        [Column("lastname")]
        [Required]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [Column("email")]
        [Required]
        [Display(Name = "Email Address:")]
        public string EmailAddress { get; set; }
    }
}