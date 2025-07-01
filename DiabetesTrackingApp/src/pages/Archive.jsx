import React from "react";
import DoctorNavbar from "../components/Doctor/DoctorNavbar";
import ArchivePanel from "../components/Archive/ArchivePanel";

function Archive() {
  return (
    <div>
      <DoctorNavbar />

      <div className="flex-row" style={{ marginTop: "50px" }}>
        <ArchivePanel />
      </div>
    </div>
  );
}

export default Archive;
