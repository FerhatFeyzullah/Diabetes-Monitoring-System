import React, { useState } from "react";
import Tabs from "@mui/material/Tabs";
import Tab from "@mui/material/Tab";
import { useParams } from "react-router-dom";
import "../../css/Archive/ArchivePanel.css";
import DailyStatusPanel from "./ResponsePanels/DailyStatusPanel";
import PrescriptionPanel from "./ResponsePanels/PrescriptionPanel";
import BloodSugarPanel from "./ResponsePanels/BloodSugarPanel";
import InsulinPanel from "./ResponsePanels/InsulinPanel";
import ArchivePatientsList from "./ArchivePatients/ArchivePatientsList";
import ArchiveFilterPanel from "./ArchiveFilterPanel";

function ArchivePanel() {
  const { doctorId } = useParams();

  const [selectedTab, setSelectedTab] = useState(0);

  const handleChange = (event, newValue) => {
    setSelectedTab(newValue);
  };
  return (
    <div className="archive-panel-main">
      <div className="archive-tabs-menu">
        <div>
          <Tabs
            value={selectedTab}
            onChange={handleChange}
            textColor="inherit"
            indicatorColor="primary"
          >
            <Tab label="Diet Ve Egzersiz" />
            <Tab label="Reçeteler" />
            <Tab label="Kan Şekeri Ölçümleri" />
            <Tab label="Insulin Değerleri" />
          </Tabs>
        </div>
      </div>
      <div className="archive-titles">
        <div className="archive-title">Hastalar</div>
        <div className="archive-title" style={{ margin: "0px 170px" }}>
          Sonuclar
        </div>
        <div className="archive-title">Filtreleme</div>
      </div>
      <div className="archive-cards">
        <div className="users">
          <ArchivePatientsList doctorId={doctorId} />
        </div>
        <div className="responses">
          {selectedTab === 0 && <DailyStatusPanel />}
          {selectedTab === 1 && <PrescriptionPanel />}
          {selectedTab === 2 && <BloodSugarPanel />}
          {selectedTab === 3 && <InsulinPanel />}
        </div>
        <div className="filter">
          <ArchiveFilterPanel />
        </div>
      </div>
    </div>
  );
}

export default ArchivePanel;
