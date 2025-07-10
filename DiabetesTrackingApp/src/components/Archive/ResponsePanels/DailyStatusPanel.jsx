import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  GetDS_Filtered,
  GetDS_UnFiltered,
} from "../../../redux/slice/dailyStatusSlice";

import DS_ArchiveCard from "../ResponsePanelCards/DS_ArchiveCard";

function DailyStatusPanel() {
  const dispatch = useDispatch();

  const { filterMod, selectedEndDate, selectedStartDate, selectedPatientId } =
    useSelector((store) => store.archive);

  const GetFiltered = (patientId, startDate, endDate) => {
    const data = {
      patientId: patientId,
      startDate: startDate,
      endDate: endDate,
    };
    dispatch(GetDS_Filtered(data));
  };
  const GetUnFiltered = (id) => {
    dispatch(GetDS_UnFiltered(id));
  };

  useEffect(() => {
    if (filterMod) {
      GetFiltered(selectedPatientId, selectedStartDate, selectedEndDate);
    } else {
      GetUnFiltered(selectedPatientId);
    }
  }, [filterMod, selectedEndDate, selectedStartDate, selectedPatientId]);

  const { dailyStatusArchive } = useSelector((store) => store.dailyStatus);

  useEffect(() => {
    console.log(dailyStatusArchive);
  }, [dailyStatusArchive]);

  return (
    <div>
      <div>
        <DS_ArchiveCard patId={selectedPatientId} />
      </div>
    </div>
  );
}

export default DailyStatusPanel;
