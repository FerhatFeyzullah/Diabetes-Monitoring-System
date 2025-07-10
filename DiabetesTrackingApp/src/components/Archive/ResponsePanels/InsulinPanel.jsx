import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  GetI_Filtered,
  GetI_UnFiltered,
} from "../../../redux/slice/insulinSlice";

import I_ArchiveCard from "../ResponsePanelCards/I_ArchiveCard";

function InsulinPanel() {
  const dispatch = useDispatch();

  const { filterMod, selectedEndDate, selectedStartDate, selectedPatientId } =
    useSelector((store) => store.archive);

  const GetFiltered = (patientId, startDate, endDate) => {
    const data = {
      patientId: patientId,
      startDate: startDate,
      endDate: endDate,
    };
    dispatch(GetI_Filtered(data));
  };
  const GetUnFiltered = (id) => {
    dispatch(GetI_UnFiltered(id));
  };

  useEffect(() => {
    if (filterMod) {
      GetFiltered(selectedPatientId, selectedStartDate, selectedEndDate);
    } else {
      GetUnFiltered(selectedPatientId);
    }
  }, [filterMod, selectedEndDate, selectedStartDate, selectedPatientId]);

  const { insulinArchive } = useSelector((store) => store.insulin);

  useEffect(() => {
    console.log(insulinArchive);
  }, [insulinArchive]);
  return (
    <div>
      <div>
        <I_ArchiveCard patId={selectedPatientId} />
      </div>
    </div>
  );
}

export default InsulinPanel;
