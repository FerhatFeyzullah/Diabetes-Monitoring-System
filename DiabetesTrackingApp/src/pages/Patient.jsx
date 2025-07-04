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

function Patient() {
  const { userId } = useParams();
  const { dailyStatus } = useSelector((store) => store.dailyStatus);
  const { dailyStatusId } = dailyStatus;

  const dispatch = useDispatch();

  const GetP_And_DS = (id) => {
    dispatch(GetPrescription(id));
    dispatch(GetDailyStatus(id));
  };

  useEffect(() => {
    GetP_And_DS(userId);
  }, []);
  return (
    <>
      <div>
        <PatientNavbar />
      </div>
      <div>
        <PatientDashboard />
      </div>
      {/* <div>
        <DietUpdateDialog dailyStatusId={dailyStatusId} />
      </div>
      <div>
        <ExerciseUpdateDialog dailyStatusId={dailyStatusId} />
      </div> */}
      <div>
        <BloodSugarDrawer />
      </div>
    </>
  );
}

export default Patient;
