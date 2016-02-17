using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    ShowTrackerEntities db = new ShowTrackerEntities();
    public int venueLogin(string password, string username)
    {
        int result = db.usp_venueLogin(username, password);
        if (result != -1)
        {
            var key = from k in db.Venues
                      where k.VenueName.Equals(username)
                      select new { k.VenueKey };
            foreach (var k in key)
            {
                result = (int)k.VenueKey;
            }
        }

        return result;
    }

    public int venueRegistration(venueLite l)
    {

        int result = db.usp_RegisterVenue(l.venueName, 
            l.venueAddress, l.venueCity, l.venueState, l.venueZipCode, l.venuePhone, 
            l.venueEmail, l.venueWebPage, 
            l.venueAgeRestriction, l.venueLoginUserName, l.venueLoginPasswordPlain);

        return result;
    }


    public int venueRegistration(VenueLogin l)
    {
        throw new NotImplementedException();
    }
}
