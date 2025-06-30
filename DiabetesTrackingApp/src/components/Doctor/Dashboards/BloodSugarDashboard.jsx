import React, { useEffect } from "react";
import { useSelector } from "react-redux";
import "../../../css/Dashboards/BS_Dashboard.css";

function BloodSugarDashboard() {
  const { bloodSugar } = useSelector((store) => store.bloodSugar);
  const { measurementTime, measurements = [] } = bloodSugar || {};

  // TimePeriod değerleri: 1-Sabah, 2-Öğle, 3-İkindi, 4-Akşam, 5-Gece
  const timePeriods = {
    1: "Sabah",
    2: "Öğle",
    3: "İkindi",
    4: "Akşam",
    5: "Gece",
  };

  const getValueByPeriod = (period) => {
    const bsValue = measurements.find((m) => m.timePeriod === period);
    return bsValue ? bsValue.value : "-";
  };

  return (
    <div className="single-dashboard">
      <div className="bs-title flex-column">
        <h3>Kan Şekeri Ölçümleri</h3>
        <div>Tarih: {measurementTime || "-"}</div>
      </div>

      <div className="bs-periods-main">
        {Object.entries(timePeriods).map(([period, label]) => {
          const value = getValueByPeriod(Number(period));
          const hasValue = value !== "-";

          return (
            <div key={period}>
              <div className="bs-period-title">{label}</div>
              <div
                className="bs-period flex-row"
                style={{
                  boxShadow: hasValue
                    ? "0 0 10px 5px rgb(90, 192, 80)" // yeşil
                    : "0 0 10px 5px rgb(151, 45, 45)", // kırmızı
                }}
              >
                {value}
              </div>
            </div>
          );
        })}
      </div>
    </div>
  );
}

export default BloodSugarDashboard;
