import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
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
import useTimeRange from "../../hooks/useTimeRange";
import Avatar from "@mui/material/Avatar";

function PatientNavbar() {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const { currentPeriod } = useSelector((store) => store.patient);
  const IsAlreadyDone = useSelector((store) =>
    store.patient.donePeriods.includes(currentPeriod)
  );
  const Morning = useTimeRange(7, 8);
  const Midday = useTimeRange(12, 13);
  const Afternoon = useTimeRange(15, 16);
  const Evening = useTimeRange(18, 19);
  const Night = useTimeRange(22, 23);

  const IsTime = Morning || Midday || Afternoon || Evening || Night;

  const { donePeriods } = useSelector((store) => store.patient);

  const IsButtonActive = IsTime && !IsAlreadyDone;

  useEffect(() => {
    console.log(IsButtonActive);
    console.log(IsAlreadyDone);
    console.log(donePeriods);
    console.log(currentPeriod);
  }, [IsButtonActive, donePeriods]);

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
            <span>
              <IconButton
                disabled={!Night}
                style={{
                  boxShadow: IsButtonActive
                    ? "0 0 10px 3px green"
                    : "0 0 10px 3px red",
                }}
              >
                <img src={exercise} className="p-navbar-png" />
              </IconButton>
            </span>
          </Tooltip>
        </div>

        <div className="patient-navbar-icons">
          <Tooltip title="Diet Durumu Güncelleme">
            <span>
              <IconButton
                onClick={() => dispatch(SetDietDialogTrue())}
                disabled={!Night}
                style={{
                  boxShadow: IsButtonActive
                    ? "0 0 10px 3px green"
                    : "0 0 10px 3px red",
                }}
              >
                <img src={diet} className="p-navbar-png" />
              </IconButton>
            </span>
          </Tooltip>
        </div>
        <div className="patient-navbar-icons">
          <Tooltip title="Kan Şekeri Ölçümü">
            <span>
              <IconButton
                onClick={() => dispatch(SetBsDrawerTrue())}
                disabled={!IsButtonActive}
                style={{
                  boxShadow: IsButtonActive
                    ? "0 0 10px 3px green"
                    : "0 0 10px 3px red",
                }}
              >
                <img src={blood} className="p-navbar-png" />
              </IconButton>
            </span>
          </Tooltip>
        </div>
        <div className="patient-navbar-icons">
          <Tooltip title="Profil">
            <IconButton onClick={handleClick}>
              {/* <PersonIcon sx={{ fontSize: "35px" }} /> */}
              <Avatar>H</Avatar>
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
