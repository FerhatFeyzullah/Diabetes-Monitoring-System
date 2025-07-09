import React, { useEffect, useState } from "react";
import "../../css/Doctor.css";
import MailIcon from "@mui/icons-material/Mail";
import PersonIcon from "@mui/icons-material/Person";
import PersonAddAlt1Icon from "@mui/icons-material/PersonAddAlt1";
import { RiDashboardHorizontalFill } from "react-icons/ri";
import { RiArchive2Fill } from "react-icons/ri";
import Badge from "@mui/material/Badge";
import { Avatar, IconButton } from "@mui/material";
import Tooltip from "@mui/material/Tooltip";
import { useLocation, useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { SetNewPatientDialogTrue } from "../../redux/slice/doctorSlice";
import Menu from "@mui/material/Menu";
import MenuItem from "@mui/material/MenuItem";
import { LogoutFromSystem } from "../../redux/slice/authSlice";
import {
  GetAppUser,
  SetAccountDrawerTrue,
} from "../../redux/slice/accountSlice";
import archive_logo from "../../assets/img/archive.png";
import app_patient_logo from "../../assets/img/add-person.png";
import dashboard_logo from "../../assets/img/dashboard.png";
import bell from "../../assets/animation/bell.json";
import Lottie from "lottie-react";
import { SetAlertDrawerTrue } from "../../redux/slice/alertSlice";

function DoctorNavbar() {
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const location = useLocation();

  const { isAlert } = useSelector((store) => store.alert);

  const userId = localStorage.getItem("UserId");
  const { AppUser } = useSelector((store) => store.account);
  const { profilePhotoId } = AppUser;
  const letter = AppUser?.firstName?.[0]?.toUpperCase();

  useEffect(() => {
    dispatch(GetAppUser(userId));
  }, [profilePhotoId]);
  const [imgError, setImgError] = useState(false);

  const [anchorEl, setAnchorEl] = useState(null);
  const open = Boolean(anchorEl);

  const isOnArchivePage = location.pathname.startsWith("/arsiv");
  const isOnDoctorPage = location.pathname.startsWith("/doktor");

  const handleClick = (event) => {
    setAnchorEl(event.currentTarget);
  };
  const handleClose = () => {
    setAnchorEl(null);
  };

  const AccountSetting = () => {
    dispatch(SetAccountDrawerTrue());
    setAnchorEl(null);
  };

  const SignOut = async () => {
    const data = {};
    await dispatch(LogoutFromSystem(data));
    localStorage.clear();
    dispatch({ type: "auth/logout" });
    navigate("/girisyap");
  };

  const animation = () => {
    dispatch(SetAlertDrawerTrue());
  };

  return (
    <div className="doctor-navbar">
      <div className="flex-row">
        <div className="doctor-navbar-title">
          {isOnDoctorPage
            ? "Diyabet Takip Sistemi"
            : "Diyabet Takip Sistemi Arşiv Sayfası"}
        </div>
      </div>
      <div className="flex-row">
        {isOnDoctorPage && (
          <div className="doctor-navbar-icons">
            <Tooltip title="Yeni Hasta Kaydı">
              <IconButton onClick={() => dispatch(SetNewPatientDialogTrue())}>
                <img src={app_patient_logo} className="d-navbar-png" />
              </IconButton>
            </Tooltip>
          </div>
        )}

        {!isOnArchivePage ? (
          <div style={{ marginRight: 10 }}>
            <Tooltip title="Arşiv">
              <IconButton onClick={() => navigate("/arsiv/" + userId)}>
                <img src={archive_logo} className="d-navbar-png" />
              </IconButton>
            </Tooltip>
          </div>
        ) : (
          <div style={{ marginRight: 20 }}>
            <Tooltip title="Günlük Takip Paneli">
              <IconButton onClick={() => navigate("/doktor/" + userId)}>
                <img src={dashboard_logo} className="d-navbar-png" />
              </IconButton>
            </Tooltip>
          </div>
        )}
        {isOnDoctorPage && (
          <div style={{ marginRight: 10 }}>
            <Tooltip title="Gelen Hasta Bildirimleri">
              <IconButton onClick={animation}>
                <Lottie
                  animationData={bell}
                  loop={isAlert > 0}
                  style={{ width: 60, height: 60 }}
                />
              </IconButton>
            </Tooltip>
          </div>
        )}

        <div className="patient-navbar-icons">
          <IconButton onClick={handleClick}>
            <Avatar
              sx={{ width: 60, height: 60 }}
              src={
                !imgError && profilePhotoId
                  ? `https://localhost:7014/api/Users/ProfileImage/${profilePhotoId}`
                  : undefined
              }
              onError={() => setImgError(true)}
            >
              {(!profilePhotoId || imgError) && letter}
            </Avatar>
          </IconButton>
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
              <Tooltip
                title="Hesap Ayarlarını Görüntüleyebilmek İçin Günlük Takip Paneline Geçiniz."
                placement="left"
              >
                <span>
                  <MenuItem onClick={AccountSetting} disabled={isOnArchivePage}>
                    Hesap Ayarları
                  </MenuItem>
                </span>
              </Tooltip>

              <MenuItem onClick={SignOut}>Çıkış Yap</MenuItem>
            </Menu>
          </div>
        </div>
      </div>
    </div>
  );
}

export default DoctorNavbar;
