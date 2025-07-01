import React from "react";
import "../../css/Dashboards/P_Dashboard.css";
import "../../css/Dashboards/DS_Dashboard.css";
import Skeleton from "@mui/material/Skeleton";

function PrescriptionSkeleton() {
  return (
    <div className="single-dashboard">
      <div className="i-title flex-column" style={{ marginTop: "30px" }}>
        <Skeleton variant="text" width={200} height={30} />
        <Skeleton variant="text" width={150} height={20} />
      </div>

      <div className="ds-status-main">
        <div>
          <div className="ds-status-title">
            <Skeleton variant="text" width={130} height={20} />
          </div>
          <div>
            <Skeleton variant="rounded" width={130} height={90} />
          </div>
        </div>
        <div>
          <div className="ds-status-title">
            <Skeleton variant="text" width={140} height={20} />
          </div>
          <div>
            <Skeleton variant="rounded" width={140} height={50} />
          </div>
        </div>
        <div>
          <div className="ds-status-title">
            <Skeleton variant="text" width={140} height={20} />
          </div>
          <div>
            <Skeleton variant="rounded" width={140} height={50} />
          </div>
        </div>
      </div>
    </div>
  );
}

export default PrescriptionSkeleton;
