import React from "react";
import "../../css/Dashboards/I_Dashboard.css";
import Skeleton from "@mui/material/Skeleton";

function InsulinSkeleton() {
  const timePeriods = ["Sabah", "Öğle", "İkindi", "Akşam", "Gece"];

  return (
    <div className="single-dashboard">
      <div className="i-title flex-column" style={{ marginTop: "30px" }}>
        <Skeleton variant="text" width={200} height={30} />
        <Skeleton variant="text" width={150} height={20} />
      </div>

      <div className="i-periods-main">
        {timePeriods.map((label, index) => (
          <div key={index}>
            <div className="i-period-title">
              <Skeleton variant="text" width={70} height={20} />
            </div>
            <div className="flex-row">
              <Skeleton variant="circular" width={70} height={70} />
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}

export default InsulinSkeleton;
