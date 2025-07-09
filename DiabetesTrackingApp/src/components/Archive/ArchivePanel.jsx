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
import PercentagePanel from "./ResponsePanels/PercentagePanel";
import AlertPanel from "./ResponsePanels/AlertPanel";
import { Badge } from "@mui/material";

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
            <Tab label="DİET VE EGZERSİZ" sx={{ textTransform: "none" }} />
            <Tab label="REÇETELER" sx={{ textTransform: "none" }} />
            <Tab label="KAN ŞEKERİ ÖLÇÜMLERİ" sx={{ textTransform: "none" }} />
            <Tab label="İNSULİN DEĞERLERİ" sx={{ textTransform: "none" }} />
            <Tab
              label="TEDAVİ PROGRAMI UYUM DURUMU"
              sx={{ textTransform: "none" }}
            />
            <Tab label="UYARILAR" sx={{ textTransform: "none" }} />
          </Tabs>
        </div>
      </div>
      <div className="archive-titles">
        <div className="archive-title">Hastalar</div>
        <div className="archive-title" style={{ margin: "0px 170px" }}>
          {selectedTab == 4 ? "Tedavi Uyumluluk Oranları" : "Sonuçlar"}
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
          {selectedTab === 4 && <PercentagePanel />}
          {selectedTab === 5 && <AlertPanel />}
        </div>
        <div className="filter">
          <ArchiveFilterPanel selectedTab={selectedTab} />
        </div>
      </div>
    </div>
  );
}

export default ArchivePanel;
