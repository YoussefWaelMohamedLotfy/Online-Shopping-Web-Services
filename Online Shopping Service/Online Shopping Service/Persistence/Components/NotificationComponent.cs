using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Online_Shopping_Service.Hubs;
using Online_Shopping_Service.Models;
using Online_Shopping_Service.Models.Store;

namespace Online_Shopping_Service.Persistence.Components
{
    public class NotificationComponent
    {
        public void RegisterNotification(DateTime currentTime)
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string command = @"SELECT * FROM [dbo].[Items] WHERE [AddedOn] > @AddedOn";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@AddedOn", currentTime);

                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                cmd.Notification = null;
                SqlDependency dependency = new SqlDependency(cmd);
                dependency.OnChange += Dependency_OnChange;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                }
            }

        }

        private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                SqlDependency dependency = sender as SqlDependency;
                dependency.OnChange -= Dependency_OnChange;

                var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
                notificationHub.Clients.All.notify("added");

                RegisterNotification(DateTime.Now);
            }
        }

        public List<Item> GetItems(DateTime afterDate)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
                return context.Items.Where(c => c.AddedOn > afterDate).OrderByDescending(c => c.AddedOn).ToList();
        }
    }
}