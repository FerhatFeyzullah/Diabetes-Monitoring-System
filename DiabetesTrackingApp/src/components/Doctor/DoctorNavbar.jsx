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

function DoctorNavbar() {
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const location = useLocation();

  const userId = localStorage.getItem("UserId");

  const { AppUser } = useSelector((store) => store.account);

  const AppUserId = localStorage.getItem("UserId");

  const { profilePhotoId } = AppUser;
  const letter = AppUser?.firstName?.[0]?.toUpperCase();

  useEffect(() => {
    dispatch(GetAppUser(AppUserId));
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

  return (
    <div className="doctor-navbar">
      <div className="flex-row">
        <div className="doctor-navbar-title">Diyabet Takip Sistemi</div>
      </div>
      <div className="flex-row">
        {isOnDoctorPage && (
          <div className="doctor-navbar-icons">
            <Tooltip title="Yeni Hasta Kaydı">
              <IconButton onClick={() => dispatch(SetNewPatientDialogTrue())}>
                <PersonAddAlt1Icon sx={{ fontSize: "35px" }} />
              </IconButton>
            </Tooltip>
          </div>
        )}

        {!isOnArchivePage ? (
          <div className="doctor-navbar-icons">
            <Tooltip title="Arşiv">
              <IconButton onClick={() => navigate("/arsiv/" + userId)}>
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
              <MenuItem onClick={AccountSetting}>Hesap Ayarları</MenuItem>
              <MenuItem onClick={SignOut}>Çıkış Yap</MenuItem>
            </Menu>
          </div>
        </div>
      </div>
    </div>
  );
}

export default DoctorNavbar;
