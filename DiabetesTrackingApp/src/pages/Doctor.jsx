import React, { useEffect } from "react";
import { useParams } from "react-router-dom";
import "../css/Doctor.css";
import DoctorNavbar from "../components/Doctor/DoctorNavbar";
import DoctorDashboard from "../components/Doctor/DoctorDashboard";
import UserList from "../components/Doctor/UserList/UserList";
import { useDispatch, useSelector } from "react-redux";
import {
  GetPatientsForDoctor,
  MistakeAlertChange,
  SuccesAlertChange,
} from "../redux/slice/doctorSlice";
import NewPatientDialog from "../components/Doctor/NewPatientDialog";
import SuccessAlert from "../components/Alerts/SuccessAlert";
import MistakeAlert from "../components/Alerts/MistakeAlert";

function Doctor() {
  const { userId } = useParams();
  const dispatch = useDispatch();

  const GetPatient = async (userId) => {
    await dispatch(GetPatientsForDoctor(userId));
  };
  useEffect(() => {
    GetPatient(userId);
  }, []);

  const { newPatientResponse, successAlert, mistakeAlert } = useSelector(
    (store) => store.doctor
  );
  const handleMistakeClose = () => {
    dispatch(MistakeAlertChange());
  };
  const handleSuccessClose = () => {
    dispatch(SuccesAlertChange());
  };

  return (
    <div>
      <DoctorNavbar />
      <div className="doctor-screen">
        <div>
          <UserList />
        </div>
        <div>
          <DoctorDashboard />
        </div>
        <div>
          <NewPatientDialog />
        </div>
        <SuccessAlert
          status={successAlert}
          message={newPatientResponse}
          closer={handleSuccessClose}
        />
        <MistakeAlert
          status={mistakeAlert}
          message={newPatientResponse}
          closer={handleMistakeClose}
        />
      </div>
    </div>
  );
}

export default Doctor;
