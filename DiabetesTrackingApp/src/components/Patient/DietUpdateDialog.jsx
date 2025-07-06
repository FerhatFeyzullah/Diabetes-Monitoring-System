import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogTitle from "@mui/material/DialogTitle";
import React from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  SetDietDialogFalse,
  UpdateDietNotOK,
  UpdateDietOK,
} from "../../redux/slice/patientSlice";
import "../../css/Patient/PatientDialogs.css";
import { Button, Slide } from "@mui/material";
import { GetDailyStatus } from "../../redux/slice/dailyStatusSlice";

const Transition = React.forwardRef(function Transition(props, ref) {
  return <Slide direction="down" ref={ref} {...props} />;
});

function DietUpdateDialog({ dailyStatusId }) {
  const dispatch = useDispatch();
  const { dietDialog } = useSelector((store) => store.patient);
  const patId = localStorage.getItem("UserId");

  const CloseDialog = () => {
    dispatch(SetDietDialogFalse());
  };
  const Yes = async (ds_id, userId) => {
    const data = {
      DailyStatusId: ds_id,
    };
    await dispatch(UpdateDietOK(data));
    await dispatch(GetDailyStatus(userId));
    dispatch(SetDietDialogFalse());
  };
  const No = async (ds_id, userId) => {
    const data = {
      DailyStatusId: ds_id,
    };
    await dispatch(UpdateDietNotOK(data));
    await dispatch(GetDailyStatus(userId));
    dispatch(SetDietDialogFalse());
  };
  return (
    <div>
      <Dialog
        open={dietDialog}
        slots={{
          transition: Transition,
        }}
        keepMounted
        onClose={CloseDialog}
      >
        <DialogTitle sx={{ textAlign: "center" }}>
          Günlük Diyet Durumu Güncelleme <hr />
        </DialogTitle>

        <DialogContent sx={{ height: "100px" }}>
          <div className="flex-row main-div">
            <div className="diet-text ">Bugün Diyetinizi Yaptınız Mı ?</div>
          </div>
        </DialogContent>
        <DialogActions sx={{ justifyContent: "center", boxShadow: 3 }}>
          <Button
            variant="contained"
            color="success"
            size="medium"
            onClick={() => Yes(dailyStatusId, patId)}
            sx={{ width: "100px" }}
          >
            Evet
          </Button>
          <Button
            variant="contained"
            color="error"
            size="medium"
            onClick={() => No(dailyStatusId, patId)}
            sx={{ width: "100px" }}
          >
            Hayır
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
}

export default DietUpdateDialog;
