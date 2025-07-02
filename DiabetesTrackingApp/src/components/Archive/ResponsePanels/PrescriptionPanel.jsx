import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  GetP_Filtered,
  GetP_UnFiltered,
} from "../../../redux/slice/prescriptionSlice";

import I_ArchiveCard from "../ResponsePanelCards/P_ArchiveCard";

function PrescriptionPanel() {
  const dispatch = useDispatch();

  const { filterMod, selectedEndDate, selectedStartDate, selectedPatientId } =
    useSelector((store) => store.archive);

  const GetFiltered = (patientId, startDate, endDate) => {
    const data = {
      patientId: patientId,
      startDate: startDate,
      endDate: endDate,
    };
    dispatch(GetP_Filtered(data));
  };
  const GetUnFiltered = (id) => {
    dispatch(GetP_UnFiltered(id));
  };

  useEffect(() => {
    if (filterMod) {
      GetFiltered(selectedPatientId, selectedStartDate, selectedEndDate);
    } else {
      GetUnFiltered(selectedPatientId);
    }
  }, [filterMod, selectedEndDate, selectedStartDate, selectedPatientId]);

  const { prescriptionArchive } = useSelector((store) => store.prescription);

  useEffect(() => {
    console.log(prescriptionArchive);
  }, [prescriptionArchive]);

  return (
    <div>
      <div>
        <I_ArchiveCard />
      </div>
    </div>
  );
}

export default PrescriptionPanel;
