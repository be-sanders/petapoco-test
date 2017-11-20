using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.cms.presentation;
using Umbraco.Core;
using umbraco.BusinessLogic;
using umbraco.cms.businesslogic;
using umbraco.cms.businesslogic.web;
using Umbraco.Core.Persistence;
using InstallUmbraco.Models;

public class RegisterEvents : ApplicationEventHandler
{
    //This happens everytime the Umbraco Application starts
    protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
    {
        //Get the Umbraco Database context
        var ctx = applicationContext.DatabaseContext;
        // var db = new DatabaseSchemaHelper(ctx.Database, applicationContext.ProfilingLogger.Logger, ctx.SqlSyntax);
        var db= ctx.Database;

        Log.Add(LogTypes.Debug, 5, "CRAPCRAPCRAP");

        //Check if the DB table does NOT exist
        if (!db.TableExist("Contacts"))
        {
            //Create DB table - and set overwrite to false
            try
            {
                db.CreateTable<ContactModel>(false);
            }
            catch (Exception e)
            {
                Log.Add(LogTypes.Debug, 6, "CRAPCRAP ERROR EXCEPTION");
            }
        }

        //Example of other events (such as before publish)
        Document.BeforePublish += Document_BeforePublish;
    }

    //Example Before Publish Event
    private void Document_BeforePublish(Document sender, PublishEventArgs e)
    {
        //Do what you need to do. In this case logging to the Umbraco log
        Log.Add(LogTypes.Debug, sender.Id, "the document " + sender.Text + " is about to be published");

        //cancel the publishing if you want.
        e.Cancel = true;
    }
}
