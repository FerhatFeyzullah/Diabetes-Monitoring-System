import React from "react";
import Snackbar from "@mui/material/Snackbar";
import Alert from "@mui/material/Alert";
import { useDispatch, useSelector } from "react-redux";
import { SuccesAlertChange } from "../../redux/slice/doctorSlice";

function SuccessAlert({ message, status, closer }) {
  return (
    <>
      <Snackbar open={status} autoHideDuration={6000} onClose={closer}>
        <Alert
          onClose={closer}
          severity="success"
          variant="filled"
          sx={{ width: "100%" }}
        >
          {message}
        </Alert>
      </Snackbar>
    </>
  );
}

export default SuccessAlert;
