import React from "react";
import "../../../css/Dashboards/I_Dashboard.css";

function InsulinDashboard() {
  return (
    <div className="single-dashboard">
      <div className="i-title flex-column">
        <h3>İnsulin Değerleri</h3>
        <div>Tarih: 2025.06.29</div>
      </div>

      <div className="i-periods-main">
        <div>
          <div className="i-period-title">Sabah</div>
          <div className="i-period flex-row">0 mg</div>
        </div>
        <div>
          <div className="i-period-title">Öğle</div>
          <div className="i-period flex-row">1 mg</div>
        </div>
        <div>
          <div className="i-period-title">İkindi</div>
          <div className="i-period flex-row">0 mg</div>
        </div>
        <div>
          <div className="i-period-title">Akşam</div>
          <div className="i-period flex-row">2 mg</div>
        </div>
        <div>
          <div className="i-period-title">Gece</div>
          <div className="i-period flex-row">0 mg</div>
        </div>
      </div>
    </div>
  );
}

export default InsulinDashboard;
