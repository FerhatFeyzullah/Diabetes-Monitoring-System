import React from "react";
import PrescriptionDashboard from "./Dashboards/PrescriptionDashboard";
import DailyStatusDashboard from "./Dashboards/DailyStatusDashboard";
import "../../css/Patient/Patient.css";
import InfoCard from "./Dashboards/InfoCard";

function PatientDashboard() {
  return (
    <div className="p-dashboard-main">
      <div className="flex-column">
        <div>
          <PrescriptionDashboard />
        </div>
        <div>
          <DailyStatusDashboard />
        </div>
      </div>

      <div className="info-card">
        <InfoCard />
      </div>
    </div>
  );
}

export default PatientDashboard;
