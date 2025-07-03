import React from "react";
import Snackbar from "@mui/material/Snackbar";
import Alert from "@mui/material/Alert";
import { useDispatch } from "react-redux";

function SuccessAlert({ message, status, closer }) {
  return (
    <>
      <Snackbar open={status} autoHideDuration={6000} onClose={closer}>
        <Alert
          onClose={closer}
          severity="error"
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
