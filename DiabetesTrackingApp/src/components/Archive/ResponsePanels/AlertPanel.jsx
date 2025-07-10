import React, { useEffect } from "react";
import AlertCard from "../ResponsePanelCards/AlertCard";
import { useDispatch, useSelector } from "react-redux";
import {
  GetA_FilteredDate,
  GetA_FilteredDateAndType,
  GetA_FilteredType,
  GetA_UnFiltered,
} from "../../../redux/slice/alertSlice";

function AlertPanel() {
  const dispatch = useDispatch();

  const {
    filterMod,
    selectedEndDate,
    selectedStartDate,
    selectedPatientId,
    selectedAlertType,
  } = useSelector((store) => store.archive);

  const GetUnFiltered = (patientId) => {
    dispatch(GetA_UnFiltered(patientId));
  };
  const GetFilteredDate = (patientId, startDate, endDate) => {
    const data = {
      id: patientId,
      start: startDate,
      end: endDate,
    };
    dispatch(GetA_FilteredDate(data));
  };
  const GetFilteredType = (patientId, alertType) => {
    const data = {
      id: patientId,
      type: alertType,
    };
    dispatch(GetA_FilteredType(data));
  };
  const GetFilteredDateAndType = (patientId, startDate, endDate, alertType) => {
    const data = {
      id: patientId,
      start: startDate,
      end: endDate,
      type: alertType,
    };
    dispatch(GetA_FilteredDateAndType(data));
  };

  useEffect(() => {
    //if (!selectedPatientId) return;
    if (filterMod && selectedAlertType != 0) {
      GetFilteredDateAndType(
        selectedPatientId,
        selectedStartDate,
        selectedEndDate,
        selectedAlertType
      );
    } else if (filterMod) {
      GetFilteredDate(selectedPatientId, selectedStartDate, selectedEndDate);
    } else if (selectedAlertType != 0) {
      GetFilteredType(selectedPatientId, selectedAlertType);
    } else {
      GetUnFiltered(selectedPatientId);
    }
  }, [
    filterMod,
    selectedEndDate,
    selectedStartDate,
    selectedPatientId,
    selectedAlertType,
  ]);
  return (
    <div>
      <div>
        <AlertCard patId={selectedPatientId} />
      </div>
    </div>
  );
}

export default AlertPanel;
