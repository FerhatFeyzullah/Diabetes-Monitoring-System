import React, { useEffect, useState } from "react";
import "../../../css/Dashboards/P_Dashboard.css";
import {
  FormControl,
  IconButton,
  InputLabel,
  MenuItem,
  Select,
  TextField,
} from "@mui/material";
import { CiEdit } from "react-icons/ci";
import { IoCheckmark } from "react-icons/io5";
import { useDispatch, useSelector } from "react-redux";
import { UpdatePrescription } from "../../../redux/slice/prescriptionSlice";
import useTimeRange from "../../../hooks/useTimeRange";

function PrescriptionDashboard() {
  const dispatch = useDispatch();
  const isActive = useTimeRange(7, 15);

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
              {symptoms.map((s) => (
                <div key={s}>{s}</div>
              ))}
            </div>
          </div>

          <div>
            <div className="p-status-title">Diyet</div>
            {!isOnEditMode ? (
              <div className="p-status flex-row">{diet}</div>
            ) : (
              <div style={{ marginBottom: "40px" }}>
                <FormControl sx={{ width: "150px" }} size="small">
                  <Select
                    value={newDiet}
                    onChange={(e) => setNewDiet(e.target.value)}
                  >
                    <MenuItem value="Az Şekerli Diyet">
                      Az Şekerli Diyet
                    </MenuItem>
                    <MenuItem value="Şekersiz Diyet">Şekersiz Diyet</MenuItem>
                    <MenuItem value="Dengeli Beslenme">
                      Dengeli Beslenme
                    </MenuItem>
                  </Select>
                </FormControl>
              </div>
            )}
          </div>
          <div>
            <div className="p-status-title">Egzersiz</div>
            {!isOnEditMode ? (
              <div className="p-status flex-row">{exercise}</div>
            ) : (
              <div style={{ marginBottom: "40px" }}>
                <FormControl sx={{ width: "150px" }} size="small">
                  <Select
                    value={newExercise}
                    onChange={(e) => setNewExercise(e.target.value)}
                  >
                    <MenuItem value="Yürüyüş">Yürüyüş</MenuItem>
                    <MenuItem value="Bisiklet">Bisiklet</MenuItem>
                    <MenuItem value="Klinik Egzersiz">Klinik Egzersiz</MenuItem>
                  </Select>
                </FormControl>
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
