import React, { useState } from "react";
import "../../css/Doctor.css";
import MailIcon from "@mui/icons-material/Mail";
import PersonIcon from "@mui/icons-material/Person";
import PersonAddAlt1Icon from "@mui/icons-material/PersonAddAlt1";
import { RiDashboardHorizontalFill } from "react-icons/ri";
import { RiArchive2Fill } from "react-icons/ri";
import Badge from "@mui/material/Badge";
import { IconButton } from "@mui/material";
import Tooltip from "@mui/material/Tooltip";
import { useLocation, useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { SetNewPatientDialogTrue } from "../../redux/slice/doctorSlice";

function DoctorNavbar() {
  const { doctorId } = useSelector((store) => store.doctor);
  const userId = doctorId;
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const location = useLocation();

  const isOnArchivePage = location.pathname.startsWith("/arsiv");

  return (
    <div className="doctor-navbar">
      <div className="flex-row">
        <div className="doctor-navbar-title">Diyabet Takip Sistemi</div>
      </div>
      <div className="flex-row">
        <div className="doctor-navbar-icons">
          <Tooltip title="Yeni Hasta Kaydı">
            <IconButton onClick={() => dispatch(SetNewPatientDialogTrue())}>
              <PersonAddAlt1Icon sx={{ fontSize: "35px" }} />
            </IconButton>
          </Tooltip>
        </div>
        {!isOnArchivePage ? (
          <div className="doctor-navbar-icons">
            <Tooltip title="Arşiv">
              <IconButton onClick={() => navigate("/arsiv/" + doctorId)}>
                <RiArchive2Fill style={{ fontSize: "30px" }} />
              </IconButton>
            </Tooltip>
          </div>
        ) : (
          <div className="doctor-navbar-icons">
            <Tooltip title="Günlük Takip Paneli">
              <IconButton onClick={() => navigate("/doktor/" + userId)}>
                <RiDashboardHorizontalFill style={{ fontSize: "30px" }} />
              </IconButton>
            </Tooltip>
          </div>
        )}
        <div className="doctor-navbar-icons">
          <Tooltip title="Mesajlar">
            <IconButton>
              <Badge badgeContent={5} color="warning">
                <MailIcon sx={{ fontSize: "30px" }} />
              </Badge>
            </IconButton>
          </Tooltip>
        </div>
        <div className="doctor-navbar-icons">
          <Tooltip title="Profil">
            <IconButton>
              <PersonIcon sx={{ fontSize: "35px" }} />
            </IconButton>
          </Tooltip>
        </div>
      </div>
    </div>
  );
}

export default DoctorNavbar;
