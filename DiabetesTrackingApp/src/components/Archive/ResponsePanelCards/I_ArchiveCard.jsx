import React from "react";
import "../../../css/Archive/ArchiveCards/I_ArchiveCard.css";
import { useSelector } from "react-redux";

function I_ArchiveCard() {
  const { insulinArchive } = useSelector((store) => store.insulin);

  const timePeriods = {
    1: "Sabah",
    2: "Öğle",
    3: "İkindi",
    4: "Akşam",
    5: "Gece",
  };

  const getValueByPeriod = (doses, period) => {
    const dose = doses.find((x) => x.timePeriod === period);
    return dose ? dose.dose : "-";
  };
  return (
    <>
      {insulinArchive &&
        insulinArchive.map((i) => (
          <div key={i.date} className="single-card i-main-card">
            <div className="i-a-time-title">{i.date}</div>
            {Object.entries(timePeriods).map(([period, label]) => {
              const value = getValueByPeriod(i.doses, Number(period));
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

export default I_ArchiveCard;
