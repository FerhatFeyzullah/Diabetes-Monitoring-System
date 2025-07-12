import { Button, Drawer } from "@mui/material";
import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  GetA_Daily,
  IsAlertExist,
  ReadAlert,
  SetAlertDrawerFalse,
} from "../../redux/slice/alertSlice";
import "../../css/AlertsDrawer.css";
import Accordion from "@mui/material/Accordion";
import AccordionActions from "@mui/material/AccordionActions";
import AccordionSummary from "@mui/material/AccordionSummary";
import AccordionDetails from "@mui/material/AccordionDetails";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";

function AlertsDrawer() {
  const dispatch = useDispatch();
  const { alertDrawer, alerts } = useSelector((store) => store.alert);

  const AppUserId = localStorage.getItem("UserId");

  const timeLabels = {
    1: "Sabah",
    2: "Öğle",
    3: "İkindi",
    4: "Akşam",
    5: "Gece",
  };
  const alertTypes = {
    1: "Acil",
    2: "Takip",
    3: "İzleme",
    4: "Eksik Ölçüm",
    5: "Yetersiz Ölçüm",
  };

  const Read = async (alertId, docId, isRead) => {
    if (isRead) return;
    const data = {
      AlertId: alertId,
      DoctorId: Number(docId),
    };
    await dispatch(ReadAlert(data));
    await dispatch(IsAlertExist(AppUserId));
    await dispatch(GetA_Daily(AppUserId));
  };

  return (
    <>
      <Drawer
        open={alertDrawer}
        onClose={() => dispatch(SetAlertDrawerFalse())}
        anchor="right"
        PaperProps={{
          sx: {
            position: "absolute",
            top: "80px",
            height: "810px",
            borderRadius: "10px",
            marginRight: "10px",
            width: "350px",
            backgroundColor: "whitesmoke",
            display: "flex",
            flexDirection: "column",
          },
        }}
      >
        {/* Sabit başlık */}
        <div
          style={{
            padding: "10px",
            fontWeight: "bold",
            fontSize: "18px",
            borderBottom: "1px solid #ccc",
            position: "sticky",
            top: 0,
            backgroundColor: "whitesmoke",
            zIndex: 2,
            fontFamily: "sans-serif",
            textAlign: "center",
          }}
        >
          Günlük Bildirimler
        </div>

        {/* Scroll yapılabilir içerik */}
        <div
          className="alert-drawer-main"
          style={{
            overflowY: "auto",
            flex: 1,
            padding: "10px",
          }}
        >
          {alerts && alerts.length > 0 ? (
            alerts.map((a) => (
              <div
                className="alert-drawer-card"
                key={a.alertId}
                style={{
                  boxShadow: a.isRead ? "none" : "0 0 10px red",
                  marginBottom: "10px",
                }}
              >
                <Accordion
                  onChange={() => Read(a.alertId, AppUserId, a.isRead)}
                >
                  <AccordionSummary
                    expandIcon={<ExpandMoreIcon />}
                    aria-controls="panel1-content"
                  >
                    <div className="alert-drawer-title">
                      {a.patient.firstName + " " + a.patient.lastName}
                    </div>
                  </AccordionSummary>
                  <AccordionDetails>
                    <div className="alert-drawer-text">
                      {timeLabels[a.timePeriod] + " ölçümü | "}
                      {"Durum: " + alertTypes[a.alertType]}
                    </div>
                    <br />
                    <div className="alert-drawer-text">{a.message}</div>
                  </AccordionDetails>
                </Accordion>
              </div>
            ))
          ) : (
            <div className="alert-drawer-info">
              Bugüne Dair Bir Uyarı Bulunmamaktadır
            </div>
          )}
        </div>
      </Drawer>
    </>
  );
}

export default AlertsDrawer;
