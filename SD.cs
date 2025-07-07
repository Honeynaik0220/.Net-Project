using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject_1144.Utility
{
    public static class SD
    {


        //stored proocedure
        public const string Sp_GetCoverTypes = "Sp_GetCoverTypes";
        public const string Sp_GetCoverType = "Sp_GetCoverType";
        public const string Sp_CreateCoverType = "Sp_CreateCoverType";
        public const string Sp_UpdateCoverType = "Sp_UpdateCoverType";
        public const string Sp_DeleteCoverType = "Sp_DeleteCoverType";

        //Roles
        public const string Role_Admin = "Admin";
        public const string Role_EmployeeUser = "Employee";
        public const string Role_CompanyUser = "Company";
        public const string Role_IndividualUser = "Individual";

        //Order Status
        public const string OrderStatusPending = "Pending";
        public const string OrderStatusApproved = "Approved";
        public const string OrderStatusInProcessing = "Processing";
        public const string OrderStatusShipped = "Shipped";
        public const string OrderStatusCancelled = "Cancelled";
        public const string OrderStatusRefunded = "Refunded";

        //Payment Status
        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved";
        public const string PaymentStatusDelayedPayment = "PaymentStatusDelayed";
        public const string PaymentStatusRejected = "Rejected";

        //Session
        public const string Ss_CartSessionCount = "Cart Count Session";



        public static double GetPriceBasedOnQuality(double quantity, double price, double price50, double price100)
        {
            if (quantity < 50)
                return price;
            else if (quantity < 100)
                return price50; return price100;
        }
    }
}
