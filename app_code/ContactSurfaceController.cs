using Umbraco.Web.Mvc;
using System.Web.Mvc;
using InstallUmbraco.Models;
using System.Net.Mail;
using umbraco.BusinessLogic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace InstallUmbraco.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {
        public ActionResult RenderForm()
        {
            return PartialView("_Contact");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ContactModel model)
        {
            if (ModelState.IsValid)
            {
  
                TempData["ContactSuccess"] = true;
                // return RedirectToCurrentUmbracoPage();
                return PartialView("~/Views/Partials/_FormSuccess.cshtml");
            }

            var db = ApplicationContext.DatabaseContext.Database;

            SqlConnection myConnection = new SqlConnection("user id=sa;server=localhost;password=ariela;database=CONTACTS");
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                Log.Add(LogTypes.Debug, 50, "TEST TEST TEST");
            }

            SqlCommand myCommand = new SqlCommand("INSERT INTO CONTACTS (contact_id, firstname, lastname, email) " +
                                     "Values (0, 'brian', 'sanders', 'brian@briansanders.net')", myConnection);

            myCommand.ExecuteNonQuery();

            // TODO: Write the fields to the database

            var contactToAdd = new ContactModel();

            contactToAdd.FirstName = "Brian";
            contactToAdd.LastName = "Brian";
            contactToAdd.EmailAddress = "Brian";

            object identity= db.Insert(contactToAdd);

            Log.Add(LogTypes.Debug, 5, "INSERTING INTO DATABASE" + identity);

            return CurrentUmbracoPage();
        }
    }
}