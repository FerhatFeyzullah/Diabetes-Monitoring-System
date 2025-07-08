import React, { useEffect } from "react";
import PercentageChart from "../ResponsePanelCards/PercentagePieChart";
import { useDispatch, useSelector } from "react-redux";
import { GetPercentage } from "../../../redux/slice/dailyStatusSlice";

function PercentagePanel() {
  const dispatch = useDispatch();

  const { selectedPatientId } = useSelector((store) => store.archive);

  const GetPercent = (patientId) => {
    dispatch(GetPercentage(patientId));
  };

  useEffect(() => {
    GetPercent(selectedPatientId);
  }, [selectedPatientId]);
  return (
    <>
      <div className="flex-column">
        <div>
          <PercentageChart patId={selectedPatientId} />
        </div>
      </div>
    </>
  );
}

export default PercentagePanel;
