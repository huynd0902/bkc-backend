﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Api.ViewModel.Request
{
    public class TicketUpdateRequest
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLineManagerId { get; set; }
        public string EmployeeLineManagerName { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeBuId { get; set; }
        public string EmployeeBuName { get; set; }
        public string EmployeeDepartment { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public int TotalParticipant { get; set; }
        public string ReasonBooking { get; set; }
        public string Status { get; set; }
        public string ApproverName { get; set; }
        public string ApproverId { get; set; }
        public string ApprovedDate { get; set; }
        public string ReasonReject { get; set; }
        public List<LocationUpdateRequest> Locations { get; set; }
        public List<RelatedPeopleUpdateRequest> RelatedPeoples { get; set; }
    }
}
