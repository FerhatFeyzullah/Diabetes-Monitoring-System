import React, { useEffect, useState } from "react";
import "../../../css/Dashboards/P_Dashboard.css";
import { IconButton, TextField } from "@mui/material";
import { CiEdit } from "react-icons/ci";
import { IoCheckmark } from "react-icons/io5";
import { useDispatch, useSelector } from "react-redux";
import { UpdatePrescription } from "../../../redux/slice/prescriptionSlice";
import useTimeRange from "../../../hooks/useTimeRange";

function PrescriptionDashboard() {
  const dispatch = useDispatch();
  const isActive = useTimeRange(7, 13);

  const { prescription } = useSelector((store) => store.prescription);
  const {
    prescriptionId,
    patientId,
    prescriptionDate,
    diet = "",
    exercise = "",
    symptoms = [],
  } = prescription;

  const hasPrescription = !!prescriptionDate;

  const [newDiet, setNewDiet] = useState("");
  const [newExercise, setNewExercise] = useState("");
  const [isOnEditMode, setIsOnEditMode] = useState(false);

  const EditButton = () => {
    setNewDiet(diet);
    setNewExercise(exercise);
    setIsOnEditMode(true);
  };

  const Update = () => {
    const data = {
      prescriptionId: prescriptionId,
      diet: newDiet,
      exercise: newExercise,
      symptoms: symptoms,
      patientId: patientId,
    };

    dispatch(UpdatePrescription(data));
    setIsOnEditMode(false);
  };

  return (
    <div className="single-dashboard">
      <div className="p-title-header">
        <h3
          className="p-title"
          style={{ marginRight: !hasPrescription ? "40px" : "0px" }}
        >
          Günlük Reçete
        </h3>
        {hasPrescription &&
          (!isOnEditMode ? (
            <IconButton
              className="p-edit-icon"
              onClick={EditButton}
              disabled={!isActive}
            >
              <CiEdit style={{ fontSize: "30px" }} />
            </IconButton>
          ) : (
            <IconButton className="p-edit-icon" onClick={Update}>
              <IoCheckmark style={{ fontSize: "30px" }} />
            </IconButton>
          ))}
      </div>

      <div className="p-date">Tarih: {prescriptionDate}</div>
      {hasPrescription ? (
        <div className="p-status-main">
          <div>
            <div className="p-symptom-title">Belirtiler</div>
            <div className="p-symptom flex-column" style={{ width: "200px" }}>
              {symptoms.map((symptom) => (
                <div>{symptom}</div>
              ))}
            </div>
          </div>

          <div>
            <div className="p-status-title">Diyet</div>
            {!isOnEditMode ? (
              <div className="p-status flex-row">{diet}</div>
            ) : (
              <div>
                <TextField
                  variant="outlined"
                  size="small"
                  value={newDiet}
                  onChange={(e) => setNewDiet(e.target.value)}
                  sx={{ width: "160px" }}
                />
              </div>
            )}
          </div>
          <div>
            <div className="p-status-title">Egzersiz</div>
            {!isOnEditMode ? (
              <div className="p-status flex-row">{exercise}</div>
            ) : (
              <div>
                <TextField
                  variant="outlined"
                  size="small"
                  value={newExercise}
                  onChange={(e) => setNewExercise(e.target.value)}
                  sx={{ width: "160px" }}
                />
              </div>
            )}
          </div>
        </div>
      ) : (
        <div className="p-empty-prescription flex-row">
          Hastanın Bugüne Ait Reçetesi Bulunmamaktadır.
        </div>
      )}
    </div>
  );
}

export default PrescriptionDashboard;
