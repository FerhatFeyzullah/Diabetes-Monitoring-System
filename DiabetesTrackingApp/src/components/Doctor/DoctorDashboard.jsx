import React from "react";
import "../../css/DoctorDashboard.css";
import "../../css/Doctor.css";

import BloodSugarDashboard from "../Doctor/Dashboards/BloodSugarDashboard";
import InsulinDashboard from "../Doctor/Dashboards/InsulinDashboard";
import DailyStatusDashboard from "../Doctor/Dashboards/DailyStatusDashboard";
import PrescriptionDashboard from "../Doctor/Dashboards/PrescriptionDashboard";

function DoctorDashboard() {
  return (
    <div className="dashboard-main">
      <div>
        <BloodSugarDashboard />
      </div>
      <div>
        <InsulinDashboard />
      </div>
      <div>
        <DailyStatusDashboard />
      </div>
      <div>
        <PrescriptionDashboard />
      </div>
    </div>
  );
}

export default DoctorDashboard;
