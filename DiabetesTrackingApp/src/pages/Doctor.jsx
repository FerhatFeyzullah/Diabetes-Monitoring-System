import React, { useEffect } from "react";
import { useParams } from "react-router-dom";
import "../css/Doctor.css";
import DoctorNavbar from "../components/Doctor/DoctorNavbar";
import DoctorDashboard from "../components/Doctor/DoctorDashboard";
import UserList from "../components/Doctor/UserList/UserList";
import { useDispatch, useSelector } from "react-redux";
import { GetPatientsForDoctor } from "../redux/slice/doctorSlice";
import NewPatientDialog from "../components/Doctor/NewPatientDialog";
import Loading from "../components/Loading";

function Doctor() {
  const { userId } = useParams();
  const dispatch = useDispatch();

  const GetPatient = async (userId) => {
    await dispatch(GetPatientsForDoctor(userId));
  };
  useEffect(() => {
    GetPatient(userId);
  }, []);

  const { loading } = useSelector((store) => store.doctor);
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
          <NewPatientDialog doctorId={userId} />
        </div>
        <Loading status={loading} />
      </div>
    </div>
  );
}

export default Doctor;
