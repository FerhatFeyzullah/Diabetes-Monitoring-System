import React from "react";
import { useSelector } from "react-redux";
import "../../../css/Archive/ArchiveCards/DS_ArchiveCard.css";

function DS_ArchiveCard() {
  const { dailyStatusArchive } = useSelector((store) => store.dailyStatus);

  return (
    <>
      {dailyStatusArchive &&
        dailyStatusArchive.map((ds) => (
          <div className="single-card ds-main-card">
            <div className="ds-a-time-title">{ds.date}</div>
            <div>
              <div className="ds-a-status-title">Diyet</div>
              {ds.dietStatus ? (
                <div
                  className="ds-a-status"
                  style={{ boxShadow: "0 0 10px 2px rgb(90, 192, 80)" }}
                >
                  Yapıldı
                </div>
              ) : (
                <div
                  className="ds-a-status"
                  style={{ boxShadow: "0 0 10px 2px rgb(192, 80, 80)" }}
                >
                  Yapılmadı
                </div>
              )}
            </div>
            <div>
              <div className="ds-a-status-title">Egzersiz</div>
              {ds.exerciseStatus ? (
                <div
                  className="ds-a-status"
                  style={{ boxShadow: "0 0 10px 2px rgb(90, 192, 80)" }}
                >
                  Yapıldı
                </div>
              ) : (
                <div
                  className="ds-a-status"
                  style={{ boxShadow: "0 0 10px 2px rgb(192, 80, 80)" }}
                >
                  Yapılmadı
                </div>
              )}
            </div>
          </div>
        ))}
    </>
  );
}

export default DS_ArchiveCard;
