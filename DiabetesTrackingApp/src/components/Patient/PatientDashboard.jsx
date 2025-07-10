import React from "react";
import PrescriptionDashboard from "./Dashboards/PrescriptionDashboard";
import DailyStatusDashboard from "./Dashboards/DailyStatusDashboard";
import "../../css/Patient/Patient.css";
import InfoCard from "./Dashboards/InfoCard";
import InsulinDailyDashboard from "./Dashboards/InsulinDailyDashboard";

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
      <div className="insulin-daily-dashboard">
        <div>
          <InsulinDailyDashboard />
        </div>

        <div className="info-card">
          <InfoCard />
        </div>
      </div>
    </div>
  );
}

export default PatientDashboard;
