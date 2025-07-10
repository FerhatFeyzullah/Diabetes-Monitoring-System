import React from "react";
import { useSelector } from "react-redux";
import "../../../css/Archive/ArchiveCards/DS_ArchiveCard.css";

function DS_ArchiveCard({ patId }) {
  const { dailyStatusArchive } = useSelector((store) => store.dailyStatus);

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
      ) : dailyStatusArchive.length === 0 ? (
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
          <div>Seçilen hastaya ait günlük durum verisi bulunmamaktadır.</div>
        </div>
      ) : (
        // Durum 3: Veri var
        dailyStatusArchive.map((ds) => (
          <div className="single-card ds-main-card" key={ds.dailyStatusId}>
            <div className="ds-a-time-title">{ds.date}</div>

            <div>
              <div className="ds-a-status-title">Diyet</div>
              <div
                className="ds-a-status"
                style={{
                  boxShadow: ds.dietStatus
                    ? "0 0 10px 2px rgb(90, 192, 80)"
                    : "0 0 10px 2px rgb(192, 80, 80)",
                }}
              >
                {ds.dietStatus ? "Yapıldı" : "Yapılmadı"}
              </div>
            </div>

            <div>
              <div className="ds-a-status-title">Egzersiz</div>
              <div
                className="ds-a-status"
                style={{
                  boxShadow: ds.exerciseStatus
                    ? "0 0 10px 2px rgb(90, 192, 80)"
                    : "0 0 10px 2px rgb(192, 80, 80)",
                }}
              >
                {ds.exerciseStatus ? "Yapıldı" : "Yapılmadı"}
              </div>
            </div>
          </div>
        ))
      )}
    </>
  );
}

export default DS_ArchiveCard;
