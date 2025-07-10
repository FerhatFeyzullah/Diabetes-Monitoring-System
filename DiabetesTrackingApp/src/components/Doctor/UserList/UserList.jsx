import React, { useState } from "react";
import "../../../css/DoctorUsersList.css";
import UserCard from "./UserCard";
import { useSelector } from "react-redux";

function UserList() {
  const { patients } = useSelector((store) => store.doctor);
  const [activePatientId, setActivePatientId] = useState(null);

  return (
    <div className="user-list-main">
      <div className="users-list">
        <div className="flex-column">
          {patients &&
            patients.map((patient) => (
              <UserCard
                key={patient.id}
                user={patient}
                activePatientId={activePatientId}
                setActivePatientId={setActivePatientId}
              />
            ))}
        </div>
      </div>
    </div>
  );
}
export default UserList;
