import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  GetBS_Filtered,
  GetBS_UnFiltered,
} from "../../../redux/slice/bloodSugarSlice";

function BloodSugarPanel() {
  const dispatch = useDispatch();

  const { filterMod, selectedEndDate, selectedStartDate, selectedPatientId } =
    useSelector((store) => store.archive);

  const GetFiltered = (patientId, startDate, endDate) => {
    const data = {
      patientId: patientId,
      startDate: startDate,
      endDate: endDate,
    };
    dispatch(GetBS_Filtered(data));
  };
  const GetUnFiltered = (id) => {
    dispatch(GetBS_UnFiltered(id));
  };

  useEffect(() => {
    if (filterMod) {
      GetFiltered(selectedPatientId, selectedStartDate, selectedEndDate);
    } else {
      GetUnFiltered(selectedPatientId);
    }
  }, [filterMod, selectedEndDate, selectedStartDate, selectedPatientId]);

  const { bloodSugarArchive } = useSelector((store) => store.bloodSugar);

  useEffect(() => {
    console.log(bloodSugarArchive);
  }, [bloodSugarArchive]);

  return <div>BloodSugarPanel</div>;
}

export default BloodSugarPanel;
