import React from "react";
import "../../../css/Archive/ArchiveCards/I_ArchiveCard.css";
import { useSelector } from "react-redux";

function I_ArchiveCard({ patId }) {
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
      {patId == null ? (
        // Durum 1: Hasta seçilmemiş
        <div
          className="flex-column"
          style={{
            fontFamily: "sans-serif",
            fontSize: "17px",
            fontWeight: "bold",
            height: "450px",
          }}
        >
          <div>
            Veri görüntüleme işlemi için lütfen önce bir hasta seçimi yapınız.
          </div>
        </div>
      ) : insulinArchive.length === 0 ? (
        // Durum 2: Hasta var ama veri yok
        <div
          className="flex-column"
          style={{
            fontFamily: "sans-serif",
            fontSize: "17px",
            fontWeight: "bold",
            height: "450px",
          }}
        >
          <div>Seçilen hastaya ait insülin verisi bulunmamaktadır.</div>
        </div>
      ) : (
        // Durum 3: Hasta ve veri var
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
        ))
      )}
    </>
  );
}

export default I_ArchiveCard;
