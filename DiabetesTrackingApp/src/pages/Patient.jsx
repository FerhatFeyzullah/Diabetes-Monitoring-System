import React, { useEffect } from "react";
import PatientNavbar from "../components/Patient/PatientNavbar";
import PatientDashboard from "../components/Patient/PatientDashboard";
import { useParams } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { GetPrescription } from "../redux/slice/prescriptionSlice";
import { GetDailyStatus } from "../redux/slice/dailyStatusSlice";
import DietUpdateDialog from "../components/Patient/DietUpdateDialog";
import ExerciseUpdateDialog from "../components/Patient/ExerciseUpdateDialog";
import BloodSugarDrawer from "../components/Patient/BloodSugarDrawer";
import InsulinResultDialog from "../components/Patient/InsulinDoseCard";
import MistakeAlert from "../components/Alerts/MistakeAlert";
import { SetMistakeAlertFalse } from "../redux/slice/patientSlice";
import { GetInsulin } from "../redux/slice/insulinSlice";
import Loading from "../components/Loading";
import AccountSettingDrawer from "../components/AccountSettingDrawer";
import { GetAppUser } from "../redux/slice/accountSlice";

function Patient() {
  const { userId } = useParams();
  const dispatch = useDispatch();
  const { dailyStatus } = useSelector((store) => store.dailyStatus);
  const { dailyStatusId } = dailyStatus;

  const { errorMessage, mistakeAlert, loading } = useSelector(
    (store) => store.patient
  );
  const { logoutLoading } = useSelector((store) => store.auth);

  const CloserAlert = () => {
    dispatch(SetMistakeAlertFalse());
  };

  const GetP_And_DS_And_I = (id) => {
    dispatch(GetPrescription(id));
    dispatch(GetDailyStatus(id));
    dispatch(GetInsulin(id));
    dispatch(GetAppUser(id));
  };

  useEffect(() => {
    GetP_And_DS_And_I(userId);
  }, []);
  return (
    <>
      <div>
        <PatientNavbar />
      </div>
      <div>
        <PatientDashboard />
      </div>
      <div>
        <DietUpdateDialog dailyStatusId={dailyStatusId} />
      </div>
      <div>
        <ExerciseUpdateDialog dailyStatusId={dailyStatusId} />
      </div>
      <div>
        <BloodSugarDrawer patientId={userId} />
      </div>
      <div>
        <InsulinResultDialog />
      </div>
      <div>
        <MistakeAlert
          message={errorMessage}
          status={mistakeAlert}
          closer={CloserAlert}
        />
      </div>
      <div>
        <AccountSettingDrawer />
      </div>
      <Loading status={loading} />
    </>
  );
}

export default Patient;
