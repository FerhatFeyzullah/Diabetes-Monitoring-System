import React, { useMemo, useState } from "react";
import Drawer from "@mui/material/Drawer";
import { useDispatch, useSelector } from "react-redux";
import { SetBsDrawerFalse } from "../../redux/slice/patientSlice";
import "../../css/Patient/BS_Drawer.css";
import TextField from "@mui/material/TextField";
import FormControl from "@mui/material/FormControl";
import InputLabel from "@mui/material/InputLabel";
import Select from "@mui/material/Select";
import MenuItem from "@mui/material/MenuItem";
import Button from "@mui/material/Button";
import InputAdornment from "@mui/material/InputAdornment";
import useTimeRange from "../../hooks/useTimeRange";

function BloodSugarDrawer() {
  const dispatch = useDispatch();
  const { bsDrawerStatus } = useSelector((store) => store.patient);

  const Morning = useTimeRange(7, 8);
  const Midday = useTimeRange(12, 13);
  const Afternoon = useTimeRange(15, 16);
  const Evening = useTimeRange(18, 19);
  const Night = useTimeRange(22, 23);

  const Period = useMemo(() => {
    if (Morning) return 1;
    if (Midday) return 2;
    if (Afternoon) return 3;
    if (Evening) return 4;
    if (Night) return 5;
    return null;
  }, [Morning, Midday, Afternoon, Evening, Night]);

  const [bsValue, setBsValue] = useState(0);
  const [symptoms, setSymptoms] = useState([]);

  return (
    <>
      <Drawer
        open={bsDrawerStatus}
        onClose={() => dispatch(SetBsDrawerFalse())}
        anchor="right"
        PaperProps={{
          sx: {
            position: "absolute", // ✅ artık fixed değil
            top: "150px", // ✅ istediğin kadar aşağı al
            height: "300px", // ✅ yükseklik belirle
            borderRadius: "10px",
            marginRight: "30px",
          },
        }}
      >
        <div className="bs-container">
          <div className="bs-title">Sabah Ölçümü</div>
          <div className="bs-input">
            <TextField
              size="small"
              sx={{ width: "150px" }}
              label="Öçüm Değeri"
              InputProps={{
                endAdornment: (
                  <InputAdornment position="end">mg/dl</InputAdornment>
                ),
              }}
              type="number"
              value={bsValue}
              onChange={(e) => setBsValue(e.target.value)}
            />
          </div>
          <div className="bs-input">
            <FormControl sx={{ width: "250px" }} size="small">
              <InputLabel>Belirtiler</InputLabel>
              <Select
                value={symptoms}
                onChange={(e) => setSymptoms(e.target.value)}
                multiple
              >
                <MenuItem value="Yorgunluk">Yorgunluk</MenuItem>
                <MenuItem value="Polifaji">Polifaji</MenuItem>
                <MenuItem value="Polidipsi">Polidipsi</MenuItem>
              </Select>
            </FormControl>
          </div>
          <div className="bs-input">
            <Button variant="contained">Gönder</Button>
          </div>
        </div>
      </Drawer>
    </>
  );
}

export default BloodSugarDrawer;
