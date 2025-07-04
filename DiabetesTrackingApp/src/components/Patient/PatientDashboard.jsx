import React from "react";
import PrescriptionDashboard from "./Dashboards/PrescriptionDashboard";
import DailyStatusDashboard from "./Dashboards/DailyStatusDashboard";
import "../../css/Patient/Patient.css";

function PatientDashboard() {
  return (
    <div className="flex-column">
      <div>
        <PrescriptionDashboard />
      </div>
      <div>
        <DailyStatusDashboard />
      </div>
    </div>
  );
}

export default PatientDashboard;
