import React, { useEffect } from "react";
import "../../../css/Patient/Patient.css";
import "../../../css/Dashboards/P_Dashboard.css";
import { useDispatch, useSelector } from "react-redux";

function PrescriptionDashboard() {
  const dispatch = useDispatch();
  const { prescription } = useSelector((store) => store.prescription);
  const { prescriptionDate, diet = "", exercise = "" } = prescription;

  const hasPrescription = !!prescriptionDate;

  return (
    <div className="single-dashboard">
      <div className="p-pd-title-header">
        <h3 className="p-pd-title">Günlük Reçete</h3>
      </div>

      <div className="p-date">Tarih: {prescriptionDate}</div>
      {hasPrescription ? (
        <div className="p-status-main">
          <div>
            <div className="p-status-title">Diyet</div>
            <div className="p-status flex-row">{diet}</div>
          </div>
          <div>
            <div className="p-status-title">Egzersiz</div>
            <div className="p-status flex-row">{exercise}</div>
          </div>
        </div>
      ) : (
        <div className="p-empty-prescription flex-row">
          Bugüne Ait Reçeteniz Bulunmamaktadır.
        </div>
      )}
    </div>
  );
}

export default PrescriptionDashboard;
