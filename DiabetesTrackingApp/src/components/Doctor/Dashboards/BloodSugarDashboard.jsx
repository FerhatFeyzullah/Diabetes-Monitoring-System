import React from "react";
import "../../../css//Dashboards/BS_Dashboard.css";

function BloodSugarDashboard() {
  return (
    <div className="single-dashboard">
      <div className="bs-title flex-column">
        <h3>Kan Şekeri Ölçümleri</h3>
        <div>Tarih: 2025.06.29</div>
      </div>

      <div className="bs-periods-main">
        <div>
          <div className="bs-period-title">Sabah</div>
          <div className="bs-period flex-row">90</div>
        </div>
        <div>
          <div className="bs-period-title">Öğle</div>
          <div className="bs-period flex-row">120</div>
        </div>
        <div>
          <div className="bs-period-title">İkindi</div>
          <div className="bs-period flex-row">150</div>
        </div>
        <div>
          <div className="bs-period-title">Akşam</div>
          <div className="bs-period flex-row">120</div>
        </div>
        <div>
          <div className="bs-period-title">Gece</div>
          <div className="bs-period flex-row">110</div>
        </div>
      </div>
    </div>
  );
}

export default BloodSugarDashboard;
