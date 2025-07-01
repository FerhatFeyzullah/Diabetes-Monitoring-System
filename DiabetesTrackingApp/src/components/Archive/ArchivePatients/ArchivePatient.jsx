import { Button } from "@mui/material";
import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { SetPatientId } from "../../../redux/slice/archiveSlice";

function ArchivePatient({ patient }) {
  const dispatch = useDispatch();
  const { firstName, lastName, id } = patient;

  const { selectedPatientId } = useSelector((store) => store.archive);

  return (
    <div style={{ marginTop: "10px" }}>
      <Button
        variant={selectedPatientId !== id ? "outlined" : "contained"}
        fullWidth
        sx={{ width: "170px" }}
        onClick={() => dispatch(SetPatientId(id))}
      >
        {firstName} {lastName}
      </Button>
    </div>
  );
}

export default ArchivePatient;
