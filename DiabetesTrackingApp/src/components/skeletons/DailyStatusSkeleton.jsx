import React from "react";
import "../../css/Dashboards/I_Dashboard.css";
import Skeleton from "@mui/material/Skeleton";

function DailyStatusSkeleton() {
  return (
    <div className="single-dashboard">
      <div className="i-title flex-column" style={{ marginTop: "30px" }}>
        <Skeleton variant="text" width={200} height={30} />
        <Skeleton variant="text" width={150} height={20} />
      </div>

      <div className="ds-status-main">
        <div>
          <div className="ds-status-title">
            <Skeleton variant="text" width={90} height={20} />
          </div>
          <div>
            <Skeleton variant="rounded" width={90} height={60} />
          </div>
        </div>
        <div>
          <div className="ds-status-title">
            <Skeleton variant="text" width={90} height={20} />
          </div>
          <div>
            <Skeleton variant="rounded" width={90} height={60} />
          </div>
        </div>
      </div>
    </div>
  );
}

export default DailyStatusSkeleton;
