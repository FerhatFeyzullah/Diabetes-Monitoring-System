import React, { useEffect, useState } from "react";
import "../../../css/Dashboards/P_Dashboard.css";
import { IconButton, TextField } from "@mui/material";
import { CiEdit } from "react-icons/ci";
import { IoCheckmark } from "react-icons/io5";
import { useSelector } from "react-redux";

function PrescriptionDashboard() {
  const { prescription } = useSelector((store) => store.prescription);
  const {
    prescriptionDate,
    diet = {},
    exercise = {},
    symptoms = [],
  } = prescription;

  const hasPrescription = Object.keys(prescription).length !== 0;

  const [isOnEditMode, setIsOnEditMode] = useState(false);
  const [newDiet, setNewDiet] = useState("");
  const [newExercise, setNewExercise] = useState("");

  const EditButton = () => {
    setNewDiet(diet.dietType);
    setNewExercise(exercise.exerciseType);
    setIsOnEditMode(true);
  };

  return (
    <div className="single-dashboard">
      <div className="p-title-header">
        <h3 className="p-title">Günlük Reçete</h3>
        {hasPrescription &&
          (!isOnEditMode ? (
            <IconButton className="p-edit-icon" onClick={EditButton}>
              <CiEdit style={{ fontSize: "30px" }} />
            </IconButton>
          ) : (
            <IconButton
              className="p-edit-icon"
              onClick={() => setIsOnEditMode(false)}
            >
              <IoCheckmark style={{ fontSize: "30px" }} />
            </IconButton>
          ))}
      </div>

      <div className="p-date">Tarih: {prescriptionDate}</div>
      {hasPrescription ? (
        <div className="p-status-main">
          <div>
            <div className="p-symptom-title">Belirtiler</div>
            <div className="p-symptom flex-column">
              {symptoms.map((symptom) => (
                <div>{symptom}</div>
              ))}
            </div>
          </div>

          <div>
            <div className="p-status-title">Diyet</div>
            {!isOnEditMode ? (
              <div className="p-status flex-row">{diet.dietType}</div>
            ) : (
              <div>
                <TextField
                  variant="outlined"
                  size="small"
                  value={newDiet}
                  onChange={(e) => setNewDiet(e.target.value)}
                  sx={{ width: "150px" }}
                />
              </div>
            )}
          </div>
          <div>
            <div className="p-status-title">Egzersiz</div>
            {!isOnEditMode ? (
              <div className="p-status flex-row">{exercise.exerciseType}</div>
            ) : (
              <div>
                <TextField
                  variant="outlined"
                  size="small"
                  value={newExercise}
                  onChange={(e) => setNewExercise(e.target.value)}
                  sx={{ width: "150px" }}
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
