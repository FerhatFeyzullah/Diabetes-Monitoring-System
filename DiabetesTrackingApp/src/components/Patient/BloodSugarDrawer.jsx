import React, { useEffect, useMemo, useState } from "react";
import Drawer from "@mui/material/Drawer";
import { useDispatch, useSelector } from "react-redux";
import {
  CheckTimePeriod,
  CreateBloodSugar,
  SetBsDrawerFalse,
  SetCheckResultTrue,
} from "../../redux/slice/patientSlice";
import "../../css/Patient/BS_Drawer.css";
import TextField from "@mui/material/TextField";
import FormControl from "@mui/material/FormControl";
import InputLabel from "@mui/material/InputLabel";
import Select from "@mui/material/Select";
import MenuItem from "@mui/material/MenuItem";
import Button from "@mui/material/Button";
import InputAdornment from "@mui/material/InputAdornment";
import useTimeRange from "../../hooks/useTimeRange";
import { schema } from "../../schemas/CreateBloodSugarSchema";
import { GetInsulin } from "../../redux/slice/insulinSlice";

function BloodSugarDrawer({ patientId }) {
  const dispatch = useDispatch();
  const { bsDrawerStatus } = useSelector((store) => store.patient);
  const { prescription } = useSelector((store) => store.prescription);

  const hasPrescription = Boolean(prescription);

  const [bsValue, setBsValue] = useState(0);
  const [symptoms, setSymptoms] = useState([]);
  const [period, setPeriod] = useState(null);
  const [errors, setErrors] = useState({});

  const Morning = useTimeRange(7, 8);
  const Midday = useTimeRange(12, 13);
  const Afternoon = useTimeRange(15, 16);
  const Evening = useTimeRange(18, 19);
  const Night = useTimeRange(22, 23);

  useEffect(() => {
    if (Morning) setPeriod(1);
    else if (Midday) setPeriod(2);
    else if (Afternoon) setPeriod(3);
    else if (Evening) setPeriod(4);
    else if (Night) setPeriod(5);
    else setPeriod(null); // hiçbirine girmediyse
  }, [Morning, Midday, Afternoon, Evening, Night]);

  const allSymptoms = [
    {
      label: "Nöropati",
      value: "Nöropati",
      ranges: [
        [0, 70],
        [110, 180],
      ],
    },
    {
      label: "Polifaji",
      value: "Polifaji",
      ranges: [
        [0, 110],
        [180, 1000],
      ],
    },
    { label: "Polidipsi", value: "Polidipsi", ranges: [[70, 1000]] },
    { label: "Poliüri", value: "Poliüri", ranges: [[110, 180]] },
    { label: "Yorgunluk", value: "Yorgunluk", ranges: [[0, 180]] },
    {
      label: "Kilo Kaybı",
      value: "Kilo_Kaybı",
      ranges: [
        [70, 110],
        [180, 1000],
      ],
    },
    { label: "Bulanık Görme", value: "Bulanık_Görme", ranges: [[110, 180]] },
    {
      label: "Yaraların Yavaş İyileşmesi",
      value: "Yaraların_Yavaş_İyileşmesi",
      ranges: [[180, 1000]],
    },
  ];

  const filteredSymptoms = useMemo(() => {
    if (!bsValue) return [];
    const numericValue = parseFloat(bsValue);
    return allSymptoms.filter((s) =>
      s.ranges.some(([min, max]) => numericValue >= min && numericValue <= max)
    );
  }, [bsValue]);

  const conflictMap = {
    Polifaji: ["Yorgunluk", "Kilo_Kaybı"],
    Polidipsi: ["Yorgunluk", "Kilo_Kaybı", "Bulanık_Görme", "Nöropati"],
    Yorgunluk: ["Polifaji", "Polidipsi", "Poliüri"],
    Kilo_Kaybı: ["Polifaji", "Polidipsi"],
    Poliüri: ["Yorgunluk", "Kilo_Kaybı", "Bulanık_Görme", "Nöropati"],
    Bulanık_Görme: ["Polidipsi", "Poliüri"],
    Nöropati: ["Polidipsi", "Poliüri"],
  };

  const CreateBS = async (data, id) => {
    await dispatch(CreateBloodSugar(data));
    await dispatch(GetInsulin(id));
    dispatch(SetCheckResultTrue());
    setSymptoms([]);
    setBsValue("");
  };

  const submit = async () => {
    try {
      await schema.validate({ bsValue }, { abortEarly: false });

      if (!hasPrescription && (Morning || Midday) && symptoms.length === 0) {
        setErrors({ symptoms: "En az bir semptom seçilmelidir" });
        return;
      }

      const data = {
        Value: bsValue,
        TimePeriod: period,
        Symptoms: symptoms,
        PatientId: patientId,
      };
      CreateBS(data, patientId);

      setErrors({});
    } catch (error) {
      const errObj = {};
      error.inner.forEach((e) => {
        errObj[e.path] = e.message;
      });
      setErrors(errObj);
    }
  };

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
          <div className="bs-title">
            {period === 1
              ? "Sabah Ölçümü"
              : period === 2
              ? "Öğle Ölçümü"
              : period === 3
              ? "İkindi Ölçümü"
              : period === 4
              ? "Akşam Ölçümü"
              : period === 5
              ? "Gece Ölçümü"
              : "Zaman Belirsiz"}
          </div>

          <div className="bs-input">
            <TextField
              error={Boolean(errors.bsValue)}
              helperText={errors.bsValue}
              size="small"
              sx={{ width: "150px" }}
              label="Ölçüm Değeri"
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
          {!hasPrescription && (Morning || Midday) && (
            <div className="bs-input">
              <FormControl
                sx={{ width: "250px" }}
                size="small"
                error={Boolean(errors.symptoms)}
              >
                <InputLabel>Belirtiler</InputLabel>
                <Select
                  value={symptoms}
                  onChange={(e) => setSymptoms(e.target.value)}
                  multiple
                  label="Belirtiler"
                >
                  {filteredSymptoms.map((s) => {
                    const isDisabled = conflictMap[s.value]?.some((c) =>
                      symptoms.includes(c)
                    );

                    return (
                      <MenuItem
                        key={s.value}
                        value={s.value}
                        disabled={isDisabled}
                      >
                        {s.label}
                      </MenuItem>
                    );
                  })}
                </Select>

                {errors.symptoms && (
                  <FormHelperText>{errors.symptoms}</FormHelperText>
                )}
              </FormControl>
            </div>
          )}

          <div className="bs-input">
            <Button variant="contained" onClick={submit}>
              Gönder
            </Button>
          </div>
        </div>
      </Drawer>
    </>
  );
}

export default BloodSugarDrawer;
