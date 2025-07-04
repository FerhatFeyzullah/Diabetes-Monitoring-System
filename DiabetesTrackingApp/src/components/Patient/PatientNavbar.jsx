import React, { useState } from "react";
import { useDispatch } from "react-redux";
import { useLocation, useNavigate } from "react-router-dom";
import { LogoutFromSystem } from "../../redux/slice/authSlice";
import "../../css/Patient/Patient.css";
import PersonIcon from "@mui/icons-material/Person";
import { IconButton } from "@mui/material";
import Tooltip from "@mui/material/Tooltip";
import Menu from "@mui/material/Menu";
import MenuItem from "@mui/material/MenuItem";
import blood from "../../assets/img/bloodSugar.png";
import diet from "../../assets/img/diet.png";
import exercise from "../../assets/img/exercise.png";
import {
  SetBsDrawerTrue,
  SetDietDialogTrue,
} from "../../redux/slice/patientSlice";
import BloodSugarDrawer from "./BloodSugarDrawer";

function PatientNavbar() {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const [anchorEl, setAnchorEl] = useState(null);
  const open = Boolean(anchorEl);

  const handleClick = (event) => {
    setAnchorEl(event.currentTarget);
  };
  const handleClose = () => {
    setAnchorEl(null);
  };

  const SignOut = async () => {
    const data = {};
    await dispatch(LogoutFromSystem(data));
    navigate("/girisyap");
  };
  return (
    <div className="patient-navbar">
      <div className="flex-row">
        <div className="patient-navbar-title">Diyabet Takip Sistemi</div>
      </div>
      <div className="flex-row">
        <div className="patient-navbar-icons">
          <Tooltip title="Egzersiz Durumu Güncelleme">
            <IconButton>
              <img src={exercise} className="p-navbar-png" />
            </IconButton>
          </Tooltip>
        </div>
        <div className="patient-navbar-icons">
          <Tooltip title="Diet Durumu Güncelleme">
            <IconButton onClick={() => dispatch(SetDietDialogTrue())}>
              <img src={diet} className="p-navbar-png" />
            </IconButton>
          </Tooltip>
        </div>
        <div className="patient-navbar-icons">
          <Tooltip title="Kan Şekeri Ölçümü">
            <IconButton onClick={() => dispatch(SetBsDrawerTrue())}>
              <img src={blood} className="p-navbar-png" />
            </IconButton>
          </Tooltip>
        </div>
        <div className="patient-navbar-icons">
          <Tooltip title="Profil">
            <IconButton onClick={handleClick}>
              <PersonIcon sx={{ fontSize: "35px" }} />
            </IconButton>
          </Tooltip>
          <div>
            <Menu
              anchorEl={anchorEl}
              open={open}
              onClose={handleClose}
              slotProps={{
                list: {
                  "aria-labelledby": "basic-button",
                },
              }}
            >
              <MenuItem onClick={handleClose}>Profilim</MenuItem>
              <MenuItem onClick={SignOut}>Çıkış Yap</MenuItem>
            </Menu>
          </div>
        </div>
      </div>
    </div>
  );
}

export default PatientNavbar;
