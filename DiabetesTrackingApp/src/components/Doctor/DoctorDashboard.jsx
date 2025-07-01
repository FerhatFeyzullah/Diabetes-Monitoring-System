import React, { useState } from "react";
import "../../css/DoctorDashboard.css";
import "../../css/Doctor.css";

import BloodSugarDashboard from "../Doctor/Dashboards/BloodSugarDashboard";
import InsulinDashboard from "../Doctor/Dashboards/InsulinDashboard";
import DailyStatusDashboard from "../Doctor/Dashboards/DailyStatusDashboard";
import PrescriptionDashboard from "../Doctor/Dashboards/PrescriptionDashboard";
import BloodSugarSkeleton from "../skeletons/BloodSugarSkeleton";
import InsulinSkeleton from "../skeletons/InsulinSkeleton";
import DailyStatusSkeleton from "../skeletons/DailyStatusSkeleton";
import PrescriptionSkeleton from "../skeletons/PrescriptionSkeleton";
import { useSelector } from "react-redux";

function DoctorDashboard() {
  const { bsLoading } = useSelector((store) => store.bloodSugar);
  const { iLoading } = useSelector((store) => store.insulin);
  const { dsLoading } = useSelector((store) => store.dailyStatus);
  const { pLoading } = useSelector((store) => store.prescription);
  return (
    <div className="dashboard-main">
      <div>{bsLoading ? <BloodSugarSkeleton /> : <BloodSugarDashboard />}</div>
      <div>{iLoading ? <InsulinSkeleton /> : <InsulinDashboard />}</div>
      <div>
        {dsLoading ? <DailyStatusSkeleton /> : <DailyStatusDashboard />}
      </div>
      <div>
        {pLoading ? <PrescriptionSkeleton /> : <PrescriptionDashboard />}
      </div>
    </div>
  );
}

export default DoctorDashboard;
