using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdolgozat
{
    class Transporter
    {
        static private Transporter instance = null;

        private User currentUser;
        

        private Transporter()
        {

        }

        private int orderid;

        private int offerid;

        public void setOrderId(int value) { orderid = value; }
        public int getOrderID() { return orderid; }

        public void setOfferId(int value) { offerid = value; }
        public int getOfferID() { return offerid; }

     

        internal User CurrentUser { get => currentUser; set => currentUser = value; }

        public static Transporter getInstance()
        {
            if (instance == null)
            {
                instance = new Transporter();
            }
            return instance;
        }
    }
}
