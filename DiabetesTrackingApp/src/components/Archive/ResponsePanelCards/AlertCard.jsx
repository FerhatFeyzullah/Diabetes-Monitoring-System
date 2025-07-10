import React, { useEffect } from "react";
import { useSelector } from "react-redux";
import "../../../css/Archive/ArchiveCards/AlertCard.css";

function AlertCard({ patId }) {
  const { alertArchive } = useSelector((store) => store.alert);

  const timeLabels = {
    1: "Sabah",
    2: "Öğle",
    3: "İkindi",
    4: "Akşam",
    5: "Gece",
  };

  const alertColors = {
    1: "#d32f2f", // Acil
    2: "#fbc02d", // Takip Edilmeli
    3: "#ffa726", // İzlenmeli
    4: "#1976d2", // Eksik Ölçüm
    5: "#9c27b0", // Yetersiz Ölçüm
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
      ) : alertArchive.length === 0 ? (
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
          <div>Seçilen hastaya ait herhangi bir uyarı bulunmamaktadır.</div>
        </div>
      ) : (
        // Durum 3: Hasta var ve veri var
        alertArchive.map((a) => (
          <div
            key={a.alertId}
            className="a-single-card a-main-card"
            style={{
              border: `3px solid ${alertColors[a.alertType] || "#ccc"}`,
              borderRadius: "10px",
            }}
          >
            <div className="flex-column">
              <div className="alert-a-time-title">{a.alertDate}</div>
              <div className="alert-a-time-title">
                {timeLabels[a.timePeriod] || "Bilinmeyen"}
              </div>
            </div>

            <div>
              <div className="flex-column">
                <div className="a-a-message-title">Mesaj</div>
                <div className="a-a-message">{a.message}</div>
              </div>
            </div>
          </div>
        ))
      )}
    </>
  );
}

export default AlertCard;
