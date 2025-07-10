import React, { useState } from "react";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";
import { DemoContainer } from "@mui/x-date-pickers/internals/demo";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { Button } from "@mui/material";
import { useDispatch, useSelector } from "react-redux";
import {
  SetAlertType,
  SetEndDate,
  SetFilterModFalse,
  SetFilterModTrue,
  SetStartDate,
} from "../../redux/slice/archiveSlice";
import dayjs from "dayjs";
import "../../css/Archive/ArchiveFilterPanel.css";
import { Divider } from "@mui/material";

function ArchiveFilterPanel({ selectedTab }) {
  const dispatch = useDispatch();
  const { filterMod, selectedAlertType } = useSelector(
    (store) => store.archive
  );

  const [startDate, setStartDate] = useState(null);
  const [endDate, setEndDate] = useState(null);
  const [alertType, setAlertType] = useState(0);

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

  const SetType = (typeId) => {
    dispatch(SetAlertType(typeId));
  };

  const ClearType = () => {
    setAlertType(0);
    dispatch(SetAlertType(0));
  };

  const alertTypes = {
    1: "Acil",
    2: "Takip",
    3: "İzleme",
    4: "Eksik Ölçüm",
    5: "Yetersiz Ölçüm",
  };

  return (
    <div style={{ marginTop: "10px" }}>
      {selectedTab == 5 ? (
        <>
          <hr />
          <div className="middle-filter-title">Tarih Filtrelemesi</div>
          <hr />
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
                  disabled={selectedTab == 4}
                />
                <DatePicker
                  label="Şu tarihe"
                  sx={{ width: "200px" }}
                  value={endDate}
                  onChange={(e) => setEndDate(e)}
                  disabled={selectedTab == 4}
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
                disabled={selectedTab == 4}
              >
                Filtre Açık
              </Button>
            </div>
            <div style={{ margin: "10px" }}>
              <Button
                variant={filterMod ? "outlined" : "contained"}
                onClick={ClearDate}
                sx={{ textTransform: "none", width: "150px" }}
                disabled={selectedTab == 4}
              >
                Filtre Kapalı
              </Button>
            </div>
          </div>
          <hr />
          <div className="middle-filter-title">Durum Filtrelemesi</div>
          <hr />

          <div className="flex-column">
            {Object.entries(alertTypes).map(([type, label]) => (
              <div style={{ marginTop: "10px" }}>
                <Button
                  key={type}
                  variant={
                    selectedAlertType != Number(type) ? "outlined" : "contained"
                  }
                  color="success"
                  sx={{
                    textTransform: "none",
                    width: "140px",
                  }}
                  onClick={() => SetType(type)}
                >
                  {label}
                </Button>
              </div>
            ))}
            <div style={{ margin: "30px" }}>
              <Button
                variant={selectedAlertType != 0 ? "outlined" : "contained"}
                onClick={ClearType}
                sx={{ textTransform: "none", width: "150px" }}
              >
                Filtre Kapalı
              </Button>
            </div>
          </div>
        </>
      ) : (
        <>
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
                  disabled={selectedTab == 4}
                />
                <DatePicker
                  label="Şu tarihe"
                  sx={{ width: "200px" }}
                  value={endDate}
                  onChange={(e) => setEndDate(e)}
                  disabled={selectedTab == 4}
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
                disabled={selectedTab == 4}
              >
                Filtre Açık
              </Button>
            </div>
            <div style={{ marginTop: "10px" }}>
              <Button
                variant={filterMod ? "outlined" : "contained"}
                onClick={ClearDate}
                sx={{ textTransform: "none", width: "150px" }}
                disabled={selectedTab == 4}
              >
                Filtre Kapalı
              </Button>
            </div>
          </div>
        </>
      )}
    </div>
  );
}

export default ArchiveFilterPanel;
