import React from "react";
import "../../../css/Patient/Patient.css";
import { useSelector } from "react-redux";

function DailyStatusDashboard() {
  const { dailyStatus } = useSelector((store) => store.dailyStatus);
  const { date, dietStatus, exerciseStatus } = dailyStatus;

  return (
    <div className="ds-single-dashboard">
      <div className="ds-title flex-column">
        <h3>Diyet Ve Spor Takibi</h3>
        <div>Tarih: {date}</div>
      </div>

      <div className="p-ds-status-main">
        <div>
          <div className="ds-status-title">Diyet</div>
          <div
            className="ds-status flex-row"
            style={{
              boxShadow: dietStatus
                ? "0 0 10px 5px rgb(90, 192, 80)"
                : "0 0 10px 5px rgb(182, 70, 70)",
            }}
          >
            {dietStatus ? "Yapıldı" : "Yapılmadı"}
          </div>
        </div>
        <div>
          <div className="ds-status-title">Egzersiz</div>
          <div
            className="ds-status flex-row"
            style={{
              boxShadow: exerciseStatus
                ? "0 0 10px 5px rgb(90, 192, 80)"
                : "0 0 10px 5px rgb(192, 80, 80)",
            }}
          >
            {exerciseStatus ? "Yapıldı" : "Yapılmadı"}
          </div>
        </div>
      </div>
    </div>
  );
}

export default DailyStatusDashboard;
