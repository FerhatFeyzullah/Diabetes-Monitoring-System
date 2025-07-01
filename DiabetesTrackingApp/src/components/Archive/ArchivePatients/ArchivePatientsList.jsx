import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { GetPatientsForDoctor } from "../../../redux/slice/doctorSlice";
import ArchivePatient from "./ArchivePatient";
import { Button } from "@mui/material";

function ArchivePatientsList({ doctorId }) {
  const dispatch = useDispatch();

  const GetPatientsForArchive = (id) => {
    dispatch(GetPatientsForDoctor(id));
  };

  useEffect(() => {
    GetPatientsForArchive(doctorId);
  }, [doctorId]);

  const { patients } = useSelector((store) => store.doctor);

  return (
    <div>
      {patients &&
        patients.map((patient) => (
          <div key={patient.id}>
            <ArchivePatient patient={patient} />
          </div>
        ))}
    </div>
  );
}

export default ArchivePatientsList;
