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
import AccountSettingDrawer from "../components/AccountSettingDrawer";
import {
  GetAppUser,
  SetAccountMistakeAlertFalse,
} from "../redux/slice/accountSlice";
import {
  GetA_Daily,
  IsAlertExist,
  SetAlertsErrorAlertFalse,
} from "../redux/slice/alertSlice";
import AlertsDrawer from "../components/Doctor/AlertsDrawer";
import ReviewPhotoDialog from "../components/ReviewPhotoDialog";

function Doctor() {
  const { userId } = useParams();
  const dispatch = useDispatch();

  const GetPatient = async (userId) => {
    await dispatch(GetPatientsForDoctor(userId));
    await dispatch(GetAppUser(userId));
    await dispatch(IsAlertExist(userId));
    const data = {};
    await dispatch(GetA_Daily(data));
  };
  useEffect(() => {
    GetPatient(userId);
  }, []);

  const { newPatientResponse, successAlert, mistakeAlert } = useSelector(
    (store) => store.doctor
  );
  const { responseMessage, a_mistakeAlert } = useSelector(
    (store) => store.account
  );
  const { alertsErrorMessage, alertsErrorAlert } = useSelector(
    (store) => store.alert
  );
  const handleDoctorMistakeClose = () => {
    dispatch(MistakeAlertChange());
  };
  const handleDoctorSuccessClose = () => {
    dispatch(SuccesAlertChange());
  };

  const handleAccountMistakeClose = () => {
    dispatch(SetAccountMistakeAlertFalse());
  };
  const handleAlertsMistakeClose = () => {
    dispatch(SetAlertsErrorAlertFalse());
  };

  return (
    <div className="doctor-dashboard-main-div">
      <DoctorNavbar />
      <div className="doctor-screen">
        <div>
          <UserList />
        </div>
        <div>
          <DoctorDashboard />
        </div>
      </div>
      <div>
        <NewPatientDialog />
      </div>
      <div>
        <SuccessAlert
          status={successAlert}
          message={newPatientResponse}
          closer={handleDoctorSuccessClose}
        />
        <MistakeAlert
          status={mistakeAlert}
          message={newPatientResponse}
          closer={handleDoctorMistakeClose}
        />
      </div>
      <div>
        <MistakeAlert
          status={a_mistakeAlert}
          message={responseMessage}
          closer={handleAccountMistakeClose}
        />
      </div>
      <div>
        <MistakeAlert
          status={alertsErrorAlert}
          message={alertsErrorMessage}
          closer={handleAlertsMistakeClose}
        />
      </div>

      <div>
        <AccountSettingDrawer />
      </div>
      <div>
        <AlertsDrawer />
      </div>
      <div>
        <ReviewPhotoDialog />
      </div>
    </div>
  );
}

export default Doctor;
