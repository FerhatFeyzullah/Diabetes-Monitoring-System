import Dialog from "@mui/material/Dialog";
import DialogTitle from "@mui/material/DialogTitle";
import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { SetInsulinDialogFalse } from "../../redux/slice/patientSlice";
import Slide from "@mui/material/Slide";
import DialogContent from "@mui/material/DialogContent";
import "../../css/Patient/PatientDialogs.css";
import DialogActions from "@mui/material/DialogActions";
import Button from "@mui/material/Button";

const Transition = React.forwardRef(function Transition(props, ref) {
  return <Slide direction="right" ref={ref} {...props} />;
});

function InsulinResultDialog() {
  const dispatch = useDispatch();
  const { insulinDialog, insulinDose } = useSelector((store) => store.patient);

  const CloseDialog = () => {
    dispatch(SetInsulinDialogFalse());
  };
  return (
    <div>
      <Dialog
        open={insulinDialog}
        slots={{
          transition: Transition,
        }}
        keepMounted
        onClose={CloseDialog}
      >
        <DialogTitle>
          Ölçüm Sonucu Hesaplanan İnsulin Miktarı <hr />
        </DialogTitle>

        <DialogContent sx={{ height: "150px" }}>
          <div className="flex-row main-div">
            <div className="dose-text ">{insulinDose} ml</div>
          </div>
        </DialogContent>
        <DialogActions sx={{ justifyContent: "center", boxShadow: 3 }}>
          <Button
            variant="contained"
            color="success"
            size="medium"
            onClick={CloseDialog}
            sx={{ width: "100px" }}
          >
            Kapat
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
}

export default InsulinResultDialog;
