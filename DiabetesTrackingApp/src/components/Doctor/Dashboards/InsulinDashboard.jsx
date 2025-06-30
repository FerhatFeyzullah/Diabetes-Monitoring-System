import React, { useEffect } from "react";
import "../../../css/Dashboards/I_Dashboard.css";
import { useSelector } from "react-redux";

function InsulinDashboard() {
  const { insulin } = useSelector((store) => store.insulin);
  const { date, doses = [] } = insulin || {};

  const timePeriods = {
    1: "Sabah",
    2: "Öğle",
    3: "İkindi",
    4: "Akşam",
    5: "Gece",
  };

  const getDoseByPeriod = (period) => {
    const dose = doses.find((d) => d.timePeriod === period);
    return dose ? dose.dose : "-";
  };

  return (
    <div className="single-dashboard">
      <div className="i-title flex-column">
        <h3>İnsulin Değerleri</h3>
        <div>Tarih: {date}</div>
      </div>

      <div className="i-periods-main">
        {Object.entries(timePeriods).map(([period, label]) => {
          const value = getDoseByPeriod(Number(period));
          const hasValue = typeof value === "number";

          return (
            <div key={period}>
              <div className="i-period-title">{label}</div>
              <div
                className="i-period flex-row"
                style={{
                  boxShadow: hasValue
                    ? "0 0 10px 5px rgb(90, 192, 80)" // yeşil
                    : "0 0 10px 5px rgb(151, 45, 45)", // kırmızı
                }}
              >
                {hasValue ? `${value} mg` : "-"}
              </div>
            </div>
          );
        })}
      </div>
    </div>
  );
}

export default InsulinDashboard;
