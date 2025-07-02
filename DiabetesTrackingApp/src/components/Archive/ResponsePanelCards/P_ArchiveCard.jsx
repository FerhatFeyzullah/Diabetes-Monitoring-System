import React from "react";
import { useSelector } from "react-redux";
import "../../../css/Archive/ArchiveCards/P_ArchiveCard.css";

function P_ArchiveCard() {
  const { prescriptionArchive } = useSelector((store) => store.prescription);

  return (
    <>
      {prescriptionArchive &&
        prescriptionArchive.map((p) => (
          <div className="p-single-card p-main-card">
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
        ))}
    </>
  );
}

export default P_ArchiveCard;
