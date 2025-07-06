import React from "react";
import { useSelector } from "react-redux";
import "../../../css/Patient/InsulinDailyDashboard.css";

function InsulinDailyDashboard() {
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
    <div className="patient-daily-insulin-dashboard">
      <div className="patient-daily-i-title flex-column">
        <div className="patient-daily-dashboard-title">İnsulin Değerleri</div>
        <div>Tarih: {date}</div>
      </div>

      <div className="patient-daily-i-periods-main">
        {Object.entries(timePeriods).map(([period, label]) => {
          const value = getDoseByPeriod(Number(period));
          const hasValue = typeof value === "number";

          return (
            <div key={period}>
              <div className="patient-daily-i-period-title">{label}</div>
              <div
                className="patient-daily-i-period flex-row"
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

export default InsulinDailyDashboard;
