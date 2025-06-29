import React, { useState } from "react";
import "../../css/Doctor.css";
import MailIcon from "@mui/icons-material/Mail";
import PersonIcon from "@mui/icons-material/Person";
import { RiArchive2Fill } from "react-icons/ri";
import Badge from "@mui/material/Badge";
import { Button, IconButton } from "@mui/material";
import { useLocation, useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";

function DoctorNavbar() {
  const { doctorId } = useSelector((store) => store.doctor);
  const navigate = useNavigate();

  const location = useLocation();

  const isOnArchivePage = location.pathname.startsWith("/arsiv");

  return (
    <div className="doctor-navbar">
      <div className="flex-row">
        <div className="doctor-navbar-title">Diyabet Takip Sistemi</div>
      </div>
      <div className="flex-row">
        {!isOnArchivePage && (
          <div className="doctor-navbar-icons">
            <IconButton onClick={() => navigate("/arsiv/" + doctorId)}>
              <RiArchive2Fill style={{ fontSize: "30px" }} />
            </IconButton>
          </div>
        )}
        <div className="doctor-navbar-icons">
          <IconButton>
            <Badge badgeContent={5} color="warning">
              <MailIcon sx={{ fontSize: "30px" }} />
            </Badge>
          </IconButton>
        </div>
        <div className="doctor-navbar-icons">
          <IconButton>
            <PersonIcon sx={{ fontSize: "30px" }} />
          </IconButton>
        </div>
      </div>
    </div>
  );
}

export default DoctorNavbar;
