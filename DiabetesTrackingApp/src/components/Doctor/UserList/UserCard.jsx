import React from "react";
import { Button } from "@mui/material";
import { useDispatch } from "react-redux";
import { GetDailyStatus } from "../../../redux/slice/dailyStatusSlice";
import { GetBloodSugar } from "../../../redux/slice/bloodSugarSlice";
import { GetInsulin } from "../../../redux/slice/insulinSlice";
import { GetPrescription } from "../../../redux/slice/prescriptionSlice";

function UserCard({ user, activePatientId, setActivePatientId }) {
  const { firstName, lastName, id } = user;
  const dispatch = useDispatch();

  const GetDailyData = (patientId) => {
    dispatch(GetDailyStatus(patientId));
    dispatch(GetBloodSugar(patientId));
    dispatch(GetInsulin(patientId));
    dispatch(GetPrescription(patientId));
    setActivePatientId(id);
  };

  return (
    <div className="user-card-main">
      <div className="user-card-name">
        <Button
          variant={activePatientId === id ? "contained" : "outlined"}
          size="large"
          fullWidth
          color="success"
          onClick={() => GetDailyData(id)}
        >
          {firstName} {lastName}
        </Button>
      </div>
    </div>
  );
}

export default UserCard;
