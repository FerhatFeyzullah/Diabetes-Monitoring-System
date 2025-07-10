import React from "react";
import { useSelector } from "react-redux";
import "../../../css/Archive/ArchiveCards/P_ArchiveCard.css";

function P_ArchiveCard({ patId }) {
  const { prescriptionArchive } = useSelector((store) => store.prescription);

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
      ) : prescriptionArchive.length === 0 ? (
        // Durum 2: Hasta var ama reçete verisi yok
        <div
          className="flex-column"
          style={{
            fontFamily: "sans-serif",
            fontSize: "17px",
            fontWeight: "bold",
            height: "450px",
          }}
        >
          <div>Seçilen hastaya ait reçete verisi bulunmamaktadır.</div>
        </div>
      ) : (
        // Durum 3: Veri varsa listele
        prescriptionArchive.map((p) => (
          <div className="p-single-card p-main-card" key={p.prescriptionId}>
            <div className="p-a-time-title">{p.prescriptionDate}</div>

            <div>
              <div className="p-a-info-title">Belirtiler</div>
              <div className="p-a-symptom">
                {p.symptoms.map((s) => (
                  <div key={s}>{s}</div>
                ))}
              </div>
            </div>

            <div>
              <div className="p-a-info-title">Diyet</div>
              <div className="p-a-info">{p.diet}</div>
            </div>

            <div>
              <div className="p-a-info-title">Egzersiz</div>
              <div className="p-a-info">{p.exercise}</div>
            </div>
          </div>
        ))
      )}
    </>
  );
}

export default P_ArchiveCard;
