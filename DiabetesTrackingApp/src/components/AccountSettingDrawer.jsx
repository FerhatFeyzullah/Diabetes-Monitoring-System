import { Avatar, Button, Drawer, IconButton, TextField } from "@mui/material";
import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  ChangePassword,
  GetAppUser,
  RemovePP,
  SetAccountDrawerFalse,
  SetAccountMistakeAlertFalse,
  SetReviewPhotoDialogTrue,
  SetSuccessAlertFalse,
  UploadPP,
} from "../redux/slice/accountSlice";
import "../css/AccountDrawer.css";
import { schema } from "../schemas/ChangePasswordSchema";
import EditIcon from "@mui/icons-material/Edit";
import Loading from "../components/Loading";
import SuccessAlert from "./Alerts/SuccessAlert";
import MistakeAlert from "./Alerts/MistakeAlert";

function AccountSettingDrawer() {
  const {
    accountDrawer,
    AppUser,
    a_mistakeAlert,
    a_successAlert,
    responseMessage,
    loading,
  } = useSelector((store) => store.account);

  const AppUserId = localStorage.getItem("UserId");

  const { profilePhotoId } = AppUser;
  const letter = AppUser?.firstName?.[0]?.toUpperCase();

  useEffect(() => {
    dispatch(GetAppUser(AppUserId));
  }, [profilePhotoId]);

  const [imgError, setImgError] = useState(false);

  const [oldPassword, setOldPassword] = useState("");
  const [newPassword, setNewPassword] = useState("");
  const [confirmPass, setConfirmPass] = useState("");
  const [errors, setErrors] = useState({});
  const dispatch = useDispatch();

  const handleFileChange = async (e) => {
    const selectedFile = e.target.files[0];

    if (selectedFile) {
      const allowedTypes = ["image/png", "image/jpeg", "image/jpg"];
      if (!allowedTypes.includes(selectedFile.type)) {
        alert("Sadece PNG veya JPG formatında bir fotoğraf yükleyebilirsin.");
        return;
      }

      const formData = new FormData();
      formData.append("Image", selectedFile);
      formData.append("AppUserId", AppUserId);

      await dispatch(UploadPP(formData));
      await dispatch(GetAppUser(AppUserId));
    }
  };

  const RemovePhoto = async (id) => {
    await dispatch(RemovePP(id));
    await dispatch(GetAppUser(id));
  };

  const handleSuccessClose = () => {
    dispatch(SetSuccessAlertFalse());
  };
  const handleMistakeClose = () => {
    dispatch(SetAccountMistakeAlertFalse());
  };
  const FormClear = () => {
    setOldPassword("");
    setNewPassword("");
    setConfirmPass("");
  };

  const submit = async () => {
    try {
      await schema.validate(
        { oldPassword, newPassword, confirmPass },
        { abortEarly: false }
      );
      setErrors({});

      const data = {
        AppUserId: AppUserId,
        OldPassword: oldPassword,
        NewPassword: newPassword,
        ConfirmNewPassword: confirmPass,
      };

      dispatch(ChangePassword(data));
      FormClear();
    } catch (error) {
      const errObj = {};
      error.inner.forEach((e) => {
        errObj[e.path] = e.message;
      });
      setErrors(errObj);
    }
  };

  const SetReviewPhotoDialog = () => {
    if (profilePhotoId && !imgError) {
      dispatch(SetReviewPhotoDialogTrue());
    }
  };

  return (
    <>
      <Drawer
        open={accountDrawer}
        onClose={() => dispatch(SetAccountDrawerFalse())}
        anchor="right"
        PaperProps={{
          sx: {
            position: "absolute", // ✅ artık fixed değil
            top: "80px", // ✅ istediğin kadar aşağı al
            height: "650px", // ✅ yükseklik belirle
            borderRadius: "10px",
            marginRight: "10px",
            width: "350px",
            backgroundColor: "whitesmoke",
          },
        }}
      >
        <div className="drawer-container" style={{ height: "100%" }}>
          <div className="account-titles">
            Profil Resmi
            <hr />
            <div style={{ position: "relative", display: "inline-block" }}>
              <Avatar
                sx={{
                  width: 120,
                  height: 120,
                  marginTop: "15px",
                  cursor: "pointer",
                }}
                src={
                  !imgError && profilePhotoId
                    ? `https://localhost:7014/api/Users/ProfileImage/${profilePhotoId}`
                    : undefined
                }
                onClick={SetReviewPhotoDialog}
                onError={() => setImgError(true)}
              >
                {(!profilePhotoId || imgError) && letter}
              </Avatar>

              <div
                style={{ position: "absolute", bottom: "5px", right: "5px" }}
              >
                <input
                  type="file"
                  accept="image/png, image/jpeg"
                  style={{ display: "none" }}
                  id="upload-photo"
                  onChange={handleFileChange}
                />
                <label htmlFor="upload-photo">
                  <IconButton
                    size="small"
                    component="span"
                    style={{
                      backgroundColor: "rgba(219, 218, 218, 0.62)",
                    }}
                  >
                    <EditIcon fontSize="small" />
                  </IconButton>
                </label>
              </div>
            </div>
            <div>
              <Button
                variant="outlined"
                size="small"
                sx={{ marginTop: "10px", textTransform: "none" }}
                disabled={!profilePhotoId || imgError}
                onClick={() => RemovePhoto(AppUserId)}
              >
                RESMİ KALDIR
              </Button>
            </div>
          </div>
          <div className="account-titles">
            Şifre Değişikliği
            <hr />
            <div className="account-input">
              <TextField
                error={Boolean(errors.oldPassword)}
                helperText={errors.oldPassword}
                label="Eski Şifre"
                value={oldPassword}
                onChange={(e) => setOldPassword(e.target.value)}
              />
            </div>
            <div className="account-input">
              <TextField
                error={Boolean(errors.newPassword)}
                helperText={errors.newPassword}
                label="Yeni Şifre"
                value={newPassword}
                onChange={(e) => setNewPassword(e.target.value)}
              />
            </div>
            <div className="account-input">
              <TextField
                error={Boolean(errors.confirmPass)}
                helperText={errors.confirmPass}
                label="Yeni Şifre Tekrarı"
                value={confirmPass}
                onChange={(e) => setConfirmPass(e.target.value)}
              />
            </div>
            <div className="account-input">
              <Button variant="contained" color="success" onClick={submit}>
                Kaydet
              </Button>
            </div>
          </div>
        </div>
      </Drawer>
      <div>
        <SuccessAlert
          status={a_successAlert}
          message={responseMessage}
          closer={handleSuccessClose}
        />
        <MistakeAlert
          status={a_mistakeAlert}
          message={responseMessage}
          closer={handleMistakeClose}
        />
        <Loading status={loading} />
      </div>
    </>
  );
}

export default AccountSettingDrawer;
