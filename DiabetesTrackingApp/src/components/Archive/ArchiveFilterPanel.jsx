import React, { useState } from "react";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";
import { DemoContainer } from "@mui/x-date-pickers/internals/demo";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { Button } from "@mui/material";
import { useDispatch, useSelector } from "react-redux";
import {
  SetEndDate,
  SetFilterModFalse,
  SetFilterModTrue,
  SetStartDate,
} from "../../redux/slice/archiveSlice";
import dayjs from "dayjs";

function ArchiveFilterPanel() {
  const dispatch = useDispatch();
  const { filterMod } = useSelector((store) => store.archive);

  const [startDate, setStartDate] = useState(null);
  const [endDate, setEndDate] = useState(null);

  const SetDate = () => {
    if (!startDate || !endDate) return;
    const formattedStartDate = dayjs(startDate).format("YYYY-MM-DD");
    const formattedEndDate = dayjs(endDate).format("YYYY-MM-DD");
    dispatch(SetStartDate(formattedStartDate));
    dispatch(SetEndDate(formattedEndDate));
    dispatch(SetFilterModTrue());
  };
  const ClearDate = () => {
    setStartDate(null);
    setEndDate(null);
    dispatch(SetStartDate(null));
    dispatch(SetEndDate(null));
    dispatch(SetFilterModFalse());
  };

  return (
    <div style={{ marginTop: "30px" }}>
      <LocalizationProvider dateAdapter={AdapterDayjs}>
        <DemoContainer components={["DatePicker"]}>
          <div className="flex-column">
            <DatePicker
              label="Şu tarihten"
              sx={{
                width: "200px",
                marginBottom: "10px",
              }}
              value={startDate}
              onChange={(e) => setStartDate(e)}
            />
            <DatePicker
              label="Şu tarihe"
              sx={{ width: "200px" }}
              value={endDate}
              onChange={(e) => setEndDate(e)}
            />
          </div>
        </DemoContainer>
      </LocalizationProvider>

      <div className="flex-column">
        <div style={{ marginTop: "10px" }}>
          <Button
            variant={!filterMod ? "outlined" : "contained"}
            onClick={SetDate}
            sx={{ textTransform: "none", width: "150px" }}
          >
            Filtre Acik
          </Button>
        </div>
        <div style={{ marginTop: "10px" }}>
          <Button
            variant={filterMod ? "outlined" : "contained"}
            onClick={ClearDate}
            sx={{ textTransform: "none", width: "150px" }}
          >
            Filtre Kapali
          </Button>
        </div>
      </div>
    </div>
  );
}

export default ArchiveFilterPanel;
