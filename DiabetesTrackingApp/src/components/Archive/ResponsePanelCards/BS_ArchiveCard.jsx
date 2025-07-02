import React from "react";
import { useSelector } from "react-redux";
import "../../../css/Archive/ArchiveCards/BS_ArchiveCard.css";

function BS_ArchiveCard() {
  const { bloodSugarArchive } = useSelector((store) => store.bloodSugar);

  const timePeriods = {
    1: "Sabah",
    2: "Öğle",
    3: "İkindi",
    4: "Akşam",
    5: "Gece",
  };

  const getValueByPeriod = (measurements, period) => {
    const bsValue = measurements.find((x) => x.timePeriod === period);
    return bsValue ? bsValue.value : "-";
  };

  return (
    <>
      {bloodSugarArchive &&
        bloodSugarArchive.map((m) => (
          <div key={m.measurementTime} className="single-card bs-main-card">
            <div className="bs-a-time-title">{m.measurementTime}</div>
            {Object.entries(timePeriods).map(([period, label]) => {
              const value = getValueByPeriod(m.measurements, Number(period));
              const hasValue = value !== "-";

              return (
                <div key={period}>
                  <div className="bs-a-period-title">
                    {label}
                    <div
                      className="bs-a-period flex-row"
                      style={{
                        boxShadow: hasValue
                          ? "0 0 10px 3px rgb(90, 192, 80)"
                          : "0 0 10px 3px rgb(151, 45, 45)",
                      }}
                    >
                      {value}
                    </div>
                  </div>
                </div>
              );
            })}
          </div>
        ))}
    </>
  );
}

export default BS_ArchiveCard;
