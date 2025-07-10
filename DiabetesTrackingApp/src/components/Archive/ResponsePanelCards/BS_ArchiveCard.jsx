import React from "react";
import { useSelector } from "react-redux";
import "../../../css/Archive/ArchiveCards/BS_ArchiveCard.css";

function BS_ArchiveCard({ patId }) {
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
      ) : bloodSugarArchive.length === 0 ? (
        // Durum 2: Hasta seçildi ama veri yok
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
            Seçilen hastaya ait kan şekeri ölçüm verisi bulunmamaktadır.
          </div>
        </div>
      ) : (
        // Durum 3: Hasta ve veri var
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
        ))
      )}
    </>
  );
}

export default BS_ArchiveCard;
