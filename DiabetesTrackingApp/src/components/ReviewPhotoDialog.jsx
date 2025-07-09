import { Dialog } from "@mui/material";
import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { SetReviewPhotoDialogFalse } from "../redux/slice/accountSlice";

function ReviewPhotoDialog() {
  const dispatch = useDispatch();
  const { reviewPhotoDialog } = useSelector((store) => store.account);

  if (!reviewPhotoDialog) return null;
  const AppUser = JSON.parse(localStorage.getItem("AppUser"));
  const { profilePhotoId } = AppUser;

  return (
    <>
      <Dialog
        open={reviewPhotoDialog}
        onClose={() => dispatch(SetReviewPhotoDialogFalse())}
      >
        <img
          src={`https://localhost:7014/api/Users/ProfileImage/${profilePhotoId}`}
          alt="Profile"
          style={{ width: "100%", height: "auto" }}
        />
      </Dialog>
    </>
  );
}

export default ReviewPhotoDialog;
